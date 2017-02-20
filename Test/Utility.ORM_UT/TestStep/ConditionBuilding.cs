using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.ORM_UT.TestStep
{
    [Scope(Feature = "ConditionBuilding")]
    [Binding]
    public sealed class ConditionBuilding
    {

        private Dictionary<int, CustomObject> l_objConditionSources = new Dictionary<int, CustomObject>();
        private TOHU.Toolbox.Utility.ORM.IConditionOperator l_objConditionOperator = null;

        [Given(@"條件來源物件")]
        public void Given條件來源物件(Table table)
        {
            CustomObject objCustom = new CustomObject();

            objCustom.ID = table.Rows[0]["ID"];
            objCustom.Name = table.Rows[0]["Name"];
            this.l_objConditionSources.Add(this.l_objConditionSources.Count + 1, objCustom);
        }

        [Given(@"欄位 (.*) 等於 (.*)")]
        public void Given欄位X等於Y(string pi_sCondition, string pi_sValue)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sCondition, pi_sValue);
        }

        [Given(@"欄位 (.*) 等於空值")]
        public void Given欄位X等於空值(string pi_sCondition)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sCondition, null);
        }

        [Given(@"以及欄位 (.*) 等於 (.*)")]
        public void Given以及欄位X等於Y(string pi_sCondition, string pi_sValue)
        {
            TOHU.Toolbox.Utility.ORM.LogicOperator objOperator = (TOHU.Toolbox.Utility.ORM.LogicOperator)this.l_objConditionOperator;

            objOperator.And(pi_sCondition, pi_sValue);
        }

        [Given(@"同時將欄位 (.*) 等於 (.*) 以及欄位 (.*) 等於 (.*)")]
        public void Given同時將欄位X等於X1以及欄位Y等於Y1(string pi_sCondition1, string pi_sValue1, string pi_sCondition2, string pi_sValue2)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sCondition1, pi_sValue1)
                .And(pi_sCondition2, pi_sValue2);
        }

        [Given(@"類別 CustomObject 屬性 (.*) 設定為條件")]
        public void Given屬性X設定為條件(string pi_sProperty)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(typeof(CustomObject).GetProperty(pi_sProperty));
        }

        [Given(@"以及類別 CustomObject 屬性 (.*) 設定為條件")]
        public void Given以及類別CustomObject屬性X設定為條件(string pi_sProperty)
        {
            TOHU.Toolbox.Utility.ORM.LogicOperator objOperator = (TOHU.Toolbox.Utility.ORM.LogicOperator)this.l_objConditionOperator;

            objOperator.And(typeof(CustomObject).GetProperty(pi_sProperty));
        }

        [Given(@"同時將類別 CustomObject 屬性 (.*) 以及屬性 (.*) 設定為條件")]
        public void Given同時將類別CustomObject屬性X以及屬性Y設定為條件(string pi_sProperty1, string pi_sProperty2)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(typeof(CustomObject).GetProperty(pi_sProperty1))
                .And(typeof(CustomObject).GetProperty(pi_sProperty2));
        }

        [Given(@"類別 CustomObject 屬性 (.*) 設定為條件，採用第 (.*) 個資料來源")]
        public void Given類別CustomObject屬性X設定為條件採用第n個資料來源(string pi_sProperty, int pi_nSourceIndex)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(
                    typeof(CustomObject).GetProperty(pi_sProperty),
                    this.l_objConditionSources[pi_nSourceIndex]);
        }

        [Given(@"以及類別 CustomObject 屬性 (.*) 設定為條件，採用第 (.*) 個資料來源")]
        public void Given以及類別CustomObject屬性X設定為條件採用第n個資料來源(string pi_sProperty, int pi_nSourceIndex)
        {
            TOHU.Toolbox.Utility.ORM.LogicOperator objOperator = (TOHU.Toolbox.Utility.ORM.LogicOperator)this.l_objConditionOperator;

            this.l_objConditionOperator =
                objOperator.And(
                    typeof(CustomObject).GetProperty(pi_sProperty),
                    this.l_objConditionSources[pi_nSourceIndex]);
        }

        [Given(@"括號框住欄位 (.*) 等於 (.*)")]
        public void Given括號框住欄位ID等於V(string pi_sCondition, string pi_sValue)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.BracketsOperator(
                    new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sCondition, pi_sValue));
        }

        [Given(@"括號分別框住第一組條件欄位 (.*) 等於 (.*) 以及第二組欄位 (.*) 等於 (.*)")]
        public void Given括號框住第一個欄位ID等於以及第二個欄位Name等於TOHU(string pi_sCondition1, string pi_sValue1, string pi_sCondition2, string pi_sValue2)
        {
            this.l_objConditionOperator =
                new TOHU.Toolbox.Utility.ORM.BracketsOperator(
                    new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sCondition1, pi_sValue1))
                    .And(new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sCondition2, pi_sValue2));
        }

        [Given(@"括號分別框住第一組條件欄位 (.*) 等於 (.*) 及 (.*) 欄位等於 (.*) 與第二組條件欄位 (.*) 等於 (.*) 及 (.*) 欄位等於 (.*) 且以 OR 邏輯運算元串接括號")]
        public void Given括號分別框住第一組條件欄位ID等於及Name欄位等於TOHU與第二組條件欄位ID等於及Name欄位等於ALL且以OR邏輯運算元串接括號(string pi_sConditionA1, string pi_sValueA1, string pi_sConditionA2, string pi_sValueA2, string pi_sConditionB1, string pi_sValueB1, string pi_sConditionB2, string pi_sValueB2)
        {
            TOHU.Toolbox.Utility.ORM.LogicOperator objCondition1 =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sConditionA1, pi_sValueA1);

            objCondition1.And(pi_sConditionA2, pi_sValueA2);

            TOHU.Toolbox.Utility.ORM.LogicOperator objCondition2 =
                new TOHU.Toolbox.Utility.ORM.LogicOperator(pi_sConditionB1, pi_sValueB1)
                .And(pi_sConditionB2, pi_sValueB2);

            this.l_objConditionOperator =
               new TOHU.Toolbox.Utility.ORM.BracketsOperator(objCondition1).Or(objCondition2);
        }

        [When(@"要求取得字串及參數")]
        public void When要求取得字串及參數()
        {
            ScenarioContext.Current.Add("ConditionString", this.l_objConditionOperator.GetConditionString());
            ScenarioContext.Current.Add("ConditionParameters", this.l_objConditionOperator.GetConditionParameter(null));
        }

        [When(@"要求來源物件 (.*) 取得字串及參數")]
        public void When要求來源物件N取得字串及參數(int pi_nSourceIndex)
        {
            ScenarioContext.Current.Add("ConditionString", this.l_objConditionOperator.GetConditionString());
            ScenarioContext.Current.Add("ConditionParameters", this.l_objConditionOperator.GetConditionParameter(this.l_objConditionSources[pi_nSourceIndex]));
        }           
        

        [Then(@"得到語法 (.*)")]
        public void Then得到語法(string pi_sExpect)
        {
            string sConditionString = ScenarioContext.Current["ConditionString"] as string;

            Assert.AreEqual(pi_sExpect, sConditionString);
        }

        [Then(@"得到參數集合")]
        public void Then得到參數集合(Table table)
        {
            Dictionary<string, object> objExpect = this.ParameterTableConverter(table);
            Dictionary<string, object> objActual = ScenarioContext.Current["ConditionParameters"] as Dictionary<string, object>;

            foreach (KeyValuePair<string, Object> objEach in objExpect)
            {
                Assert.IsTrue(objActual.ContainsKey(objEach.Key));
                Assert.AreEqual(objEach.Value, objActual[objEach.Key]);
            }
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
