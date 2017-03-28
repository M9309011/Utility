using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.ORM_UT.TestStep
{

    [Scope(Feature = "ParameterCollection")]
    [Binding]
    public sealed class ParameterCollection
    {
        [Given(@"自訂篩選條件式 (.*)")]
        public void Given自訂篩選條件式(string pi_sCondition)
        {
            ScenarioContext.Current.Add("Condition", new StubCondition(pi_sCondition));
        }

        [Given(@"自訂二組篩選條件式 (.*) 以及 (.*)")]
        public void Given自訂篩選條件式A及B(string pi_sCondition1, string pi_sCondition2)
        {
            ScenarioContext.Current.Add("Condition1", new StubCondition(pi_sCondition1));
            ScenarioContext.Current.Add("Condition2", new StubCondition(pi_sCondition2));

        }

        [Given(@"自訂更新資訊 (.*)")]
        public void Given自訂更新資訊(string pi_sUpdateInfo)
        {
            ScenarioContext.Current.Add("UpdateInfo", new StubUpdateInfo(pi_sUpdateInfo));
        }

        [Given(@"自訂二組更新資訊 (.*) 以及 (.*)")]
        public void Given自訂二組更新資訊A以及B(string pi_sUpdateinfo1, string pi_sUpdateInfo2)
        {
            ScenarioContext.Current.Add("UpdateInfo1", new StubUpdateInfo(pi_sUpdateinfo1));
            ScenarioContext.Current.Add("UpdateInfo2", new StubUpdateInfo(pi_sUpdateInfo2));
        }
        
        [Given(@"將篩選條件式設定給參數集")]
        public void Given將篩選條件式設定給參數集()
        {
            TOHU.Toolbox.Utility.ORM.IConditionOperator objCondition =
                ScenarioContext.Current["Condition"] as TOHU.Toolbox.Utility.ORM.IConditionOperator;
            ScenarioContext.Current.Add("Parameters", new TOHU.Toolbox.Utility.ORM.RelationObjectParameters("Table").SetCondition(objCondition));
        }

        [Given(@"將二個篩選條件式一次設定給參數集")]
        public void Given將二個篩選條件式一次設定給參數集()
        {
            TOHU.Toolbox.Utility.ORM.IConditionOperator objCondition1 =
                ScenarioContext.Current["Condition1"] as TOHU.Toolbox.Utility.ORM.IConditionOperator;

            TOHU.Toolbox.Utility.ORM.IConditionOperator objCondition2 =
                ScenarioContext.Current["Condition2"] as TOHU.Toolbox.Utility.ORM.IConditionOperator;

            ScenarioContext.Current.Add("Parameters",
                new TOHU.Toolbox.Utility.ORM.RelationObjectParameters("table").
                SetCondition(objCondition1).
                SetCondition(objCondition2));
        }

        [Given(@"重覆設定參數集的條件式 (.*)")]
        public void Given重覆設定參數集的條件式(string pi_sCondition)
        {
            TOHU.Toolbox.Utility.ORM.RelationObjectParameters objParameters =
                ScenarioContext.Current["Parameters"] as TOHU.Toolbox.Utility.ORM.RelationObjectParameters;

            objParameters.SetCondition(new StubCondition(pi_sCondition));

            ScenarioContext.Current["Parameters"] = objParameters;
        }

        [Given(@"將更新資訊設定給參數集")]
        public void Given將更新資訊設定給參數集()
        {
            TOHU.Toolbox.Utility.ORM.UpdateInfo objUpdateInfo =
                ScenarioContext.Current["UpdateInfo"] as TOHU.Toolbox.Utility.ORM.UpdateInfo;
            ScenarioContext.Current.Add("Parameters",
                new TOHU.Toolbox.Utility.ORM.RelationObjectParameters("Table").SetUpdateInfo(objUpdateInfo));
        }

        [Given(@"重覆設定參數集的更新資訊 (.*)")]
        public void Given重覆設定參數集的更新資訊(string pi_sUpdateInfo)
        {
            TOHU.Toolbox.Utility.ORM.RelationObjectParameters objParameters =
                ScenarioContext.Current["Parameters"] as TOHU.Toolbox.Utility.ORM.RelationObjectParameters;

            objParameters.SetUpdateInfo(new StubUpdateInfo(pi_sUpdateInfo));

            ScenarioContext.Current["Parameters"] = objParameters;
        }


        [Given(@"將二個更新資訊一次設定給參數集")]
        public void Given將二個更新資訊一次設定給參數集()
        {
            TOHU.Toolbox.Utility.ORM.UpdateInfo objUpdateInfo1 =
                ScenarioContext.Current["UpdateInfo1"] as TOHU.Toolbox.Utility.ORM.UpdateInfo;

            TOHU.Toolbox.Utility.ORM.UpdateInfo objUpdateInfo2 =
                ScenarioContext.Current["UpdateInfo2"] as TOHU.Toolbox.Utility.ORM.UpdateInfo;

            ScenarioContext.Current.Add("Parameters",
                new TOHU.Toolbox.Utility.ORM.RelationObjectParameters("Table")
                .SetUpdateInfo(objUpdateInfo1).SetUpdateInfo(objUpdateInfo2));
        }


        [When(@"向參數集要條件式時")]
        public void When向參數集要條件式時()
        {
            TOHU.Toolbox.Utility.ORM.RelationObjectParameters objParameters =
                ScenarioContext.Current["Parameters"] as TOHU.Toolbox.Utility.ORM.RelationObjectParameters;
            TOHU.Toolbox.Utility.ORM.IConditionOperator objActual = objParameters.Condition;
            ScenarioContext.Current.Add("Actual", objActual);
        }

        [When(@"向參數集要更新資訊時")]
        public void When向參數集要更新資訊時()
        {
            TOHU.Toolbox.Utility.ORM.RelationObjectParameters objParameters =
                ScenarioContext.Current["Parameters"] as TOHU.Toolbox.Utility.ORM.RelationObjectParameters;
            TOHU.Toolbox.Utility.ORM.UpdateInfo objActual = objParameters.UpdateInfo;
            ScenarioContext.Current.Add("Actual", objActual);
        }


        [Then(@"取回原來的篩選條件式 (.*)")]
        public void Then取回原來的篩選條件式(string pi_sExpect)
        {
            TOHU.Toolbox.Utility.ORM.IConditionOperator objActual =
                 ScenarioContext.Current["Actual"] as TOHU.Toolbox.Utility.ORM.IConditionOperator;

            Assert.AreEqual(pi_sExpect, objActual.GetConditionString());
        }

        [Then(@"取回原來的更新資訊 (.*)")]
        public void Then取回原來的更新資訊(string pi_sExpect)
        {
            TOHU.Toolbox.Utility.ORM.UpdateInfo objActual =
                 ScenarioContext.Current["Actual"] as TOHU.Toolbox.Utility.ORM.UpdateInfo;

            Assert.AreEqual(pi_sExpect, objActual.GetString());
        }


    }
}
