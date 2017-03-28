using TOHU.Toolbox.Utility.ORM;
using TOHU.Toolbox.Utility.ORM_Mock;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Utility_UT.Utility.ORM
{
    [Scope(Feature = "關連物件的查詢、新增、刪除及更新功能")]
    [Scope(Feature = "條件式查詢取得資料物件")]
    [Binding]
    public sealed class 關連物件的查詢_新增_刪除及更新功能
    {

        #region -- 變數宣告 ( Declarations ) --   

        private string l_sSGID = string.Empty;

        #endregion

        #region -- 方法 ( Public Method ) --

        [AfterScenario]
        public void AfterScenario()
        {
            new DatabaseHelper().RemoveDatabase(this.l_sSGID);
        }

        [Given(@"具備 (.*) 資料表內容的資料庫")]
        public void Given具備X資料表內容的資料庫(string pi_sTableName, Table pi_objSource)
        {
            DataSet objTarget = new DataSet();
            this.l_sSGID = System.Guid.NewGuid().ToString();

            objTarget.Tables.Add(this.ParseTable(pi_sTableName, pi_objSource));
            string sDatabasePath = new DatabaseHelper().InitialDatabase(this.l_sSGID, objTarget);
            ScenarioContext.Current.Set<string>(sDatabasePath, "DatabasePath");
        }

        [When(@"要求取得 CustomObject 關連資料物件清單時")]
        public void When要求取得CustomObject關連資料物件清單時()
        {
            string sDatabasePath = ScenarioContext.Current.Get<string>("DatabasePath");
            AccessAgent objAgent = new AccessAgent(sDatabasePath);
            List<CustomObject> objActual = new ObjectFactory<CustomObject>().Query(objAgent);
            
            ScenarioContext.Current.Set<List<CustomObject>>(objActual, "Actual");
        }

        [When(@"要求新增 CustomObject 關連資料物件")]
        public void When要求新增CustomObject關連資料物件(Table pi_objRequest)
        {
            string sDatabasePath = ScenarioContext.Current.Get<string>("DatabasePath");
            AccessAgent objAgent = new AccessAgent(sDatabasePath);
            new ObjectFactory<CustomObject>().Create(objAgent, this.ParseCustom(pi_objRequest));
        }

        [When(@"要求刪除關連資料物件")]
        public void When要求刪除關連資料物件(Table pi_objRequest)
        {
            string sDatabasePath = ScenarioContext.Current.Get<string>("DatabasePath");
            AccessAgent objAgent = new AccessAgent(sDatabasePath);
            new ObjectFactory<CustomObject>().Delete(objAgent, this.ParseCustom(pi_objRequest));
        }

        [When(@"要求更新關連資料物件")]
        public void When要求更新關連資料物件(Table pi_objRequest)
        {
            string sDatabasePath = ScenarioContext.Current.Get<string>("DatabasePath");
            AccessAgent objAgent = new AccessAgent(sDatabasePath);
            new ObjectFactory<CustomObject>().Update(objAgent, this.ParseCustom(pi_objRequest));
        }

        [Then(@"取得 CustomObject 資料物件")]
        public void Then取得CustomObject資料物件(Table pi_objExpected)
        {
            List<CustomObject> objActual = ScenarioContext.Current.Get<List<CustomObject>>("Actual");
            List<CustomObject> objExpecteds = this.ParseCustom(pi_objExpected);

            Assert.AreEqual(objExpecteds.Count, objActual.Count);

            foreach (CustomObject objCustom in objExpecteds)
            {
                IEnumerable<CustomObject> objQuery =
                     from CustomObject objEachCustom in objActual
                     where objEachCustom.Initial == objCustom.Initial
                         && objEachCustom.Name == objCustom.Name
                         && objEachCustom.EMail == objCustom.EMail
                     select objEachCustom;
                Assert.IsTrue(objQuery.Any());
                Assert.IsTrue(objQuery.Count() == 1);
            }

            foreach (CustomObject objCustom in objActual)
            {
                IEnumerable<CustomObject> objQuery =
                     from CustomObject objEachCustom in objExpecteds
                     where objEachCustom.Initial == objCustom.Initial
                         && objEachCustom.Name == objCustom.Name
                         && objEachCustom.EMail == objCustom.EMail
                     select objEachCustom;
                Assert.IsTrue(objQuery.Any());
                Assert.IsTrue(objQuery.Count() == 1);
            }
        }

        #endregion

        #region -- 私有函式 ( Private Method) --

        /// <summary>
        /// 解析傳入資料轉為資料表。
        /// </summary>
        /// <param name="pi_sTableName">資料表名稱。</param>
        /// <param name="pi_objSource">資料來源。</param>
        /// <returns>資料表。</returns>
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
        private DataTable ParseTable(string pi_sTableName, Table pi_objSource)
        {
            DataTable objReturn = new DataTable(pi_sTableName);

            foreach (string sField in pi_objSource.Header)
            {
                objReturn.Columns.Add(sField, typeof(string));
            }

            foreach (TableRow objRow in pi_objSource.Rows)
            {
                DataRow objNewRow = objReturn.NewRow();

                foreach (string sField in pi_objSource.Header)
                {
                    objNewRow[sField] = objRow[sField];
                }
                objReturn.Rows.Add(objNewRow);
            }
            return objReturn;
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

        #endregion

    }
}
