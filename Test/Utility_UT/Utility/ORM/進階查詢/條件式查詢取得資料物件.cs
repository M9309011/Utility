using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOHU.Toolbox.Utility.ORM;
using TechTalk.SpecFlow;
using TOHU.Toolbox.Utility.ORM_Mock;

namespace TOHU.Toolbox.Utility_UT.Utility.ORM.進階查詢
{
    [Scope(Feature = "條件式查詢取得資料物件")]
    [Binding]
    public sealed class 條件式查詢取得資料物件
    {
        [Given(@"查詢條件為 (.*) 欄位的值為 (.*) 時")]
        public void Given查詢條件為X欄位的值為N時(string pi_sField, string pi_sValue)
        {
            ScenarioContext.Current.Set<IConditionOperator>(new LogicOperator(pi_sField, pi_sValue), "Condition");
        }

        [Given(@"條件資料物件")]
        public void Given條件資料物件(Table pi_objSource)
        {
            ScenarioContext.Current.Set<CustomObject>(this.ParseCustom(pi_objSource)[0], "ConditionSourceObject");
        }


        [Given(@"查詢屬性為 (.*) 時")]
        public void Given查詢屬性為X時(string pi_sPropertyName)
        {
            ScenarioContext.Current.Set<IConditionOperator>(new LogicOperator(typeof(CustomObject).GetProperty(pi_sPropertyName)), "Condition");
        }

        [When(@"要求取得符合查詢條件的 CustomObject 關連資料物件清單時")]
        public void When要求取得符合查詢條件的CustomObject關連資料物件清單時()
        {
            string sDatabasePath = ScenarioContext.Current.Get<string>("DatabasePath");
            AccessAgent objAgent = new AccessAgent(sDatabasePath);
            IConditionOperator objCondition = ScenarioContext.Current.Get<IConditionOperator>("Condition");          
            List<CustomObject> objActual = new ObjectFactory<CustomObject>().Query(objAgent, objCondition);

            ScenarioContext.Current.Set<List<CustomObject>>(objActual, "Actual");
        }

        [When(@"要求取得符合屬性查詢條件的 CustomObject 關連資料物件清單時")]
        public void When要求取得符合屬性查詢條件的CustomObject關連資料物件清單時()
        {
            string sDatabasePath = ScenarioContext.Current.Get<string>("DatabasePath");
            AccessAgent objAgent = new AccessAgent(sDatabasePath);
            IConditionOperator objCondition = ScenarioContext.Current.Get<IConditionOperator>("Condition");
            CustomObject objSourceObject = ScenarioContext.Current.Get<CustomObject>("ConditionSourceObject");
            List<CustomObject> objActual = new ObjectFactory<CustomObject>().Query(objAgent, objCondition, objSourceObject);

            ScenarioContext.Current.Set<List<CustomObject>>(objActual, "Actual");
        }


        /// <summary>
        /// 解析來源資料為資料物件集合。
        /// </summary>
        /// <param name="pi_objSource">來源資料。</param>
        /// <returns>資料物件集合。</returns>
        /// <remarks>
        /// <list type="bullet">
        /// <item><term>Author:</term><description>黃竣祥</description></item>
        /// <item><term>Time:</term><description>[Time]</description></item>
        /// <item><term>History</term><description>
        /// <list type="number">
        /// <item><term>[Time]</term><description>建立方法。</description></item>
        /// </list>
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        private List<CustomObject> ParseCustom(Table pi_objSource)
        {
            List<CustomObject> objReturn = new List<CustomObject>();
            foreach (TableRow objRow in pi_objSource.Rows)
            {
                CustomObject objCustom = new CustomObject();

                foreach (System.Reflection.PropertyInfo objProperty in objCustom.GetType().GetProperties())
                {
                    if (objRow.ContainsKey(objProperty.Name))
                    {
                        objProperty.SetValue(objCustom, objRow[objProperty.Name]);
                    }
                }
                objReturn.Add(objCustom);
            }
            return objReturn;
        }


    }
}
