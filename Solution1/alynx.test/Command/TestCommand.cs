using System;
using System.Collections.Generic;
using System.Text;
using RekTec.Crm.HiddenApi;

namespace alynx.test.Command
{
    public class TestCommand:HiddenCommand
    {
        public string Test()
        {
            return "alynx-test";
        }
    }
}
