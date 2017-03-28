using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.ORM_UT.TestStep
{

    [Scope(Feature = "UpdateBuilding")]
    [Binding]
    public sealed class UpdateBuilding
    {
        private TOHU.Toolbox.Utility.ORM.UpdateInfo l_objUpdateInfo = null;

        [Given(@"更新欄位 (.*) 值為 (.*) 的設定")]
        public void Given更新欄位X值為Y的設定(string pi_sFieldName, string pi_sFieldValue)
        {
            this.l_objUpdateInfo = new TOHU.Toolbox.Utility.ORM.UpdateInfo(pi_sFieldName, pi_sFieldValue);
        }

        [When(@"要求取得更新字串及參數")]
        public void When要求取得更新字串及參數()
        {
            ScenarioContext.Current.Add("ConditionString", this.l_objUpdateInfo.GetString());
            ScenarioContext.Current.Add("ConditionParameters", this.l_objUpdateInfo.GetParameter(null));
        }


        [Then(@"得到更新語法 (.*)")]
        public void Then得到更新語法(string pi_sExpect)
        {
            string sConditionString = ScenarioContext.Current["ConditionString"] as string;

            Assert.AreEqual(pi_sExpect, sConditionString);
        }

        [Then(@"得到更新參數集合")]
        public void Then得到更新參數集合(Table table)
        {
            Dictionary<string, object> objExpect = this.ParameterTableConverter(table);
            Dictionary<string, object> objActual = ScenarioContext.Current["ConditionParameters"] as Dictionary<string, object>;
            Boolean bIsFind = true;

            foreach (KeyValuePair<string, object> objEachExpected in objExpect)
            {
                IEnumerable<KeyValuePair<string, object>> objQuery =
                    from KeyValuePair<string, object> objEachActual in objActual
                    where objEachActual.Key == objEachExpected.Key
                        && objEachActual.Value.Equals(objEachExpected.Value)
                    select objEachActual;

                bIsFind = objQuery.Any() ? bIsFind : false;
            }
            Assert.IsTrue(bIsFind);
        }

        private Dictionary<string, object> ParameterTableConverter(Table table)
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();

            foreach (TableRow objRow in table.Rows)
            {
                objReturn.Add(objRow["Key"], objRow["Value"]);
            }

            return objReturn;
        }


    }
}
