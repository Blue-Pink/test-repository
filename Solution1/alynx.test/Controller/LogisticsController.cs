using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using RekTec.Crm.Common;
using RekTec.Crm.HiddenApi;
using RekTec.CrmSdk.Scope;
using RekTec.OneSdk.Crm.Common;
using RekTec.OneSdk.Crm.Common.Helper;
using RekTec.OneSdk.Logistics.Common;
using RekTec.Service1.Logistics.Command;
using RekTec.Service1.Logistics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace RekTec.Service1.Logistics
{
    [Scope(PredefinedScopes.user, PredefinedScopes.admin)]
    [AllowCustomerAccess]
    //轨迹查询 100,物流下单 200,面单打印 300,订单取消 400,运单拦截 500
    public class LogisticsController : HiddenApiController
    {
        /// <summary>
        /// 获取订单路由
        /// </summary>
        /// <param name="logisticscorpId">物流公司id</param>
        /// <param name="logisticsNumber">订单号</param>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        [RelativeEntity("new_srv_logisticscorp")]
        [Description("快递物流轨迹查询统一接口")]
        public List<LogisticsTrackItem> GetOrderRouters(Guid logisticscorpId, string logisticsNumber, string mobile)
        {
            var cmd = this.GetService<ILogisticsService>();
            Dictionary<string, object> valuePairs = new Dictionary<string, object>
            {
                { "logisticscorpId", logisticscorpId },
                { "logisticsNumber", logisticsNumber },
                { "mobile", mobile }
            };
            var resp = (LogisticsTrackResponseModel)cmd.CallLogisticsHiddenApi(logisticscorpId, 100, valuePairs);

            if(resp == null ) return null;

            return resp?.routes;
           
        }


        /// <summary>
        /// 获取电子面单
        /// </summary>
        /// <param name="logisticsNumber">运单号</param>
        /// <returns></returns>
        [RelativeEntity("new_srv_logisticscorp")]
        [Description("物流获取电子面单统一接口")]
        public LogisticsResponse GetEOrder(string logisticsNumber)
        {
            LogisticsResponse result = new LogisticsResponse { success = true };
            try
            {
                var cmd = this.GetService<ILogisticsService>();
                int command = 300;

                var data = cmd.GetLogisticsOrderData(logisticsNumber);

                if (!data.IsPrint)
                {
                    LogisticsEOrderResponseModel eorderResult = new LogisticsEOrderResponseModel();
                    try
                    {
                        LogisticsEOrderRequestModel eorder = new LogisticsEOrderRequestModel(null);
                        eorder.LogisticsCorpId = data.LogisticsCorp.Id;
                        eorder.TrackNum = logisticsNumber;
                        eorder.LogisticsOrderId = data.LogisticsOrderCode;
                        eorderResult = (LogisticsEOrderResponseModel)cmd.CallLogisticsHiddenApi(data.LogisticsCorp.Id, command, new Dictionary<string, object> { { "eorderModel", eorder } });
                    }
                    catch (Exception ex)
                    {
                        eorderResult = new LogisticsEOrderResponseModel { success = false,msg = ex.Message };
                    }
                    result = cmd.BuildResult(eorderResult, command, data);
                   
                }

                if (result.success)
                {
                    QueryExpression query = new QueryExpression("annotation");
                    query.Criteria.AddCondition("objectid", ConditionOperator.Equal, data.Id.ToString());
                    query.ColumnSet.AddColumn("mimetype");
                    var attachment = this.OrganizationService.RetrieveMultipleBase(query);
                    //目前一个运单应该就一个电子面单数据
                    if (attachment != null && attachment.Entities != null && attachment.Entities.Count == 1)
                    {
                        //此时确定有数据了对打印次数累加
                        Entity entity = new Entity(data.LogicalName, data.Id);
                        entity["new_isprint"] = true;
                        entity["new_printtimes"] = data.PrintTimes + 1;
                        this.OrganizationService.Update(entity);
                        string mimetype = attachment.Entities[0].GetStringAttributeValue("mimetype");
                        result.msg = HttpUtility.UrlEncode($"/api/attachment/download/{data.LogicalName}/{attachment.Entities[0].Id}@{mimetype}");
                    }
                    else
                    {
                        result.msg = LangHelper.Get(LangId,"logistics.waiteorder","面单文件未到达,请稍后..");
                    }
                }
                
            }
            catch (Exception ex)
            {
                result.success=false;
                result.msg = ex.Message;
            }
            return result;
        }

        //[RelativeEntity("new_logisticsapilog")]
        //[Description("测试回调的异常")]
        //public LogisticsResponse TestCallBack(Entity entity)
        //{

        //    //Entity entity1 = new Entity("new_testentity1");
        //    //OrganizationService.Create(entity1);
        //    var linkOrder = entity.GetAttributeValue<EntityReference>("new_linkorder_id");
        //    var rma = new Entity("new_srv_rma", linkOrder.Id);
        //    rma["new_returnedon"] = OneSdk.CoreShared.CrmDateTime.Now;
        //    //rma["new_logisticscorp_id"] = new EntityReference("new_srv_logisticscorp", logisticScorpId);
        //    rma["new_returnlogisticsnumber"] = entity.GetStringAttributeValue("name");
        //    OrganizationService.Update(rma);

        //    throw new Exception("测试回调的异常");


        //    return new LogisticsResponse() { success = true };
        //}
    }
}
