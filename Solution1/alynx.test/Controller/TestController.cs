using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using alynx.test.Command;
using RekTec.Crm.Common;
using RekTec.Crm.HiddenApi;
using RekTec.CrmSdk.Scope;
using RekTec.OneSdk.Crm.Common;
using RekTec.OneSdk.Crm.Common.Helper;
using ServiceReference2;

namespace alynx.test.Controller
{
    [Scope(PredefinedScopes.user, PredefinedScopes.admin)]
    [AllowCustomerAccess]
    public class TestController:HiddenApiController
    {
        [RelativeEntity("new_alynx_test_entity")]
        [Description("alynx测试hiddenapi")]
        public async Task<string> Test()
        {
            try
            {
              
            }
            catch (Exception exception)
            {
                return $@"调用失败!
{exception}
";
            }
            WebService1SoapClient client = new WebService1SoapClient(WebService1SoapClient.EndpointConfiguration.WebService1Soap);
            var res = await client.HelloWorldAsync();
            var res2 = await client.APlusBAsync(3, 5);
            return Command<TestCommand>().Test();
        }

        [RelativeEntity("new_alynx_test_entity")]
        [Description("alynx测试hiddenapi2")]
        public async Task<string> Test2()
        {
            return Command<TestCommand>().Test();
        }
    }
}
