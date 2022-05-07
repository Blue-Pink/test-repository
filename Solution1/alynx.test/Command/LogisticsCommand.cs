using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using RekTec.Crm.HiddenApi;
using RekTec.Crm.Plugin.Helper;
using RekTec.OneSdk.Logistics.Common;
using RekTec.Service1.Logistics.Model;
using RekTec.XStudio.FileStorage.Model;
using RekTec.XStudio.FileStorage.Service;
using RekTec.XStudio.WebApi.Core;
using System;
using System.Collections.Generic;

namespace RekTec.Service1.Logistics.Command
{
    public class LogisticsCommand : HiddenCommand
    {

        /// <summary>
        /// 物流运单拦截 v4.12只支持退回
        /// </summary>
        /// <param name="logisticsNumber">运单号</param>
        /// <returns></returns>
        public LogisticsResponse InterceptOrder(string logisticsNumber)
        {
            var service = this.GetService<ILogisticsService>();
            return service.InterceptOrder(logisticsNumber);
        }

        /// <summary>
        /// 物流订单取消
        /// </summary>
        /// <param name="logisticsNumber">运单号</param>
        /// <returns></returns>
        public LogisticsResponse CancelOrder(string logisticsNumber)
        {
            var service = this.GetService<ILogisticsService>();
            return service.CancelOrder(logisticsNumber);
        }
    }
}
