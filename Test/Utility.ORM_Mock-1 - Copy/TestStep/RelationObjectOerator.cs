using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TOHU.Toolbox.Utility.ORM;
using System.IO;

namespace Utility.ORM_UT.TestStep
{    
    [Binding]
    public sealed class RelationObjectOerator
    {
        private string l_sSGID = string.Empty;
        private ISourceAgent l_objSourceAgent = null;
        private IConditionOperator l_objCondition = null;
        private UpdateInfo l_objUpdateInfo = null;
        private List<CustomObject> l_objCustoms = null;

        [BeforeScenario]
        public void BeforScenario()
        {
            this.l_sSGID = Guid.NewGuid().ToString();
            string sSource = string.Format("{0}\\_Resource\\EastSun.accdb", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Locati‌​on));
            string sTarget = string.Format("{0}\\_Resource\\{1}\\EastSun.accdb", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Locati‌​on), this.l_sSGID);
            Directory.CreateDirectory(Path.GetDirectoryName(sTarget));
            File.Copy(sSource, sTarget);
            this.l_objSourceAgent = new MockSourceAgent(sTarget);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            string sTarget = string.Format("{0}\\_Resource\\{1}\\", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Locati‌​on), this.l_sSGID);
            Directory.Delete(Path.GetDirectoryName(sTarget), true);
        }   

        [Given(@"關連資料物件集合")]
        public void Given關連資料物件集合(Table table)
        {
            this.l_objCustoms = this.ParseCustom(table);
        }

        [Given(@"建立關連資料物件集合項目")]
        public void Given建立關連資料物件集合項目(Table table)
        {
            if (this.l_objCustoms == null)
            {
                this.l_objCustoms = new List<CustomObject>();
            }
            this.l_objCustoms.Add(table.CreateInstance<CustomObject>());
        }


        [Given(@"條件為欄位 (.*)")]
        public void Given條件為欄位X(string pi_sPropertyName)
        {
            this.l_objCondition = new LogicOperator(typeof(CustomObject).GetProperty(pi_sPropertyName));
        }

        [Given(@"更新欄位 (.*)")]
        public void Given更新欄位X(string pi_sPropertyName)
        {
            this.l_objUpdateInfo = new UpdateInfo(typeof(CustomObject).GetProperty(pi_sPropertyName));
        }

        [Given(@"更新 (.*) 欄位為 (.*)")]
        public void Given更新X欄位為Y(string pi_sFieldName, string pi_sValue)
        {
            this.l_objUpdateInfo = new UpdateInfo(pi_sFieldName, pi_sValue);
        }

        [When(@"要求取得欄位 (.*) 為 (.*) 的 CustomObject 關連資料物件")]
        public void When要求取得欄位X為Y的CustomObject關連資料物件(string pi_sFieldName, string pi_sFieldValue)
        {
            RelationObjectCenter objCenter = new RelationObjectCenter();
            RelationObjectParameters objParameter =
                new RelationObjectParameters("Custom")
                .SetCondition(new LogicOperator(pi_sFieldName, pi_sFieldValue))
                .SetUpdateInfo(this.l_objUpdateInfo);

            ScenarioContext.Current.Add("Actual", objCenter.Query<CustomObject>(objParameter, this.l_objSourceAgent));
        }

        [When(@"要求取得 Custom 關連資料物件")]
        public void When要求取得Custom關連資料物件()
        {
            RelationObjectCenter objCenter = new RelationObjectCenter();
            RelationObjectParameters objParameter = new RelationObjectParameters("Custom");

            ScenarioContext.Current.Add("Actual", objCenter.Query<CustomObject>(objParameter, this.l_objSourceAgent));
        }

        [When(@"要求新增關連資料物件")]
        public void When要求新增關連資料物件()
        {
            RelationObjectCenter objCenter = new RelationObjectCenter();
            RelationObjectParameters objParameter =
                new RelationObjectParameters("Custom")
                    .SetCondition(this.l_objCondition)
                    .SetUpdateInfo(this.l_objUpdateInfo);

            objCenter.Create(this.l_objCustoms, objParameter, this.l_objSourceAgent);
        }

        [When(@"要求刪除關連資料物件")]
        public void When要求刪除關連資料物件()
        {
            RelationObjectCenter objCenter = new TOHU.Toolbox.Utility.ORM.RelationObjectCenter();
            RelationObjectParameters objParameter =
               new RelationObjectParameters("Custom")
                .SetCondition(this.l_objCondition)
                .SetUpdateInfo(this.l_objUpdateInfo);

            objCenter.Delete(this.l_objCustoms, objParameter, this.l_objSourceAgent);
        }

        [When(@"要求更新關連資料物件")]
        public void When要求更新關連資料物件()
        {
            RelationObjectCenter objCenter = new TOHU.Toolbox.Utility.ORM.RelationObjectCenter();
            RelationObjectParameters objParameter =
               new RelationObjectParameters("Custom")
                .SetCondition(this.l_objCondition)
                .SetUpdateInfo(this.l_objUpdateInfo);

            objCenter.Update(this.l_objCustoms, objParameter, this.l_objSourceAgent);
        }

        [Then(@"取得 CustomObject 資料物件")]
        public void Then取得CustomObject資料物件(Table table)
        {
            List<CustomObject> objActual = ScenarioContext.Current["Actual"] as List<CustomObject>;
            List<CustomObject> objExpecteds = this.ParseCustom(table);

            Assert.AreEqual(objExpecteds.Count, objActual.Count);
        }

        [Then(@"得到執行語法 (.*)")]
        public void Then得到執行語法X(string pi_sExpected)
        {
            MockSourceAgent objAgent = this.l_objSourceAgent as MockSourceAgent;

            Assert.AreEqual(pi_sExpected, objAgent.SQL);
        }

        [Then(@"得到查詢參數集合包含")]
        public void Then得到查詢參數集合包含(Table table)
        {
            Boolean bIsFind = false;
            MockSourceAgent objAgent = this.l_objSourceAgent as MockSourceAgent;
            Dictionary<string, object> objQueryParameters = objAgent.QueryParameters;
            List<Dictionary<string, object>> objActual = new List<Dictionary<string, object>>();
            Dictionary<string, object> objExpecteds = this.ParseParameters(table);

            objActual.Add(objQueryParameters);

            foreach (Dictionary<string, object> objParameters in objActual)
            {
                if (objParameters.Count == objExpecteds.Count)//數量一致。
                {
                    bIsFind = false;
                    foreach (KeyValuePair<string, object> objExpected in objExpecteds)
                    {
                        //每個預期的參數項都有對應的項目。
                        IEnumerable<KeyValuePair<string, object>> objQuery =
                            from KeyValuePair<string, object> objEachParameter in objParameters
                            where objEachParameter.Key == objExpected.Key
                                && objEachParameter.Value.Equals(objExpected.Value)
                            select objEachParameter;

                        //保留是否有對應的項目。
                        bIsFind = objQuery.Any();
                        //若有預期參數不在此集合就跳出，繼續次個參數集合。
                        if (bIsFind == false) { break; }
                    }
                    //如果所有預期項目都有對應就不用再繼續不同的參數集合。
                    if (bIsFind) { break; }
                }
            }
            Assert.IsTrue(bIsFind);
        }


        [Then(@"得到參數集合包含")]
        public void Then得到參數集合包含(Table table)
        {
            Boolean bIsFind = false;
            MockSourceAgent objAgent = this.l_objSourceAgent as MockSourceAgent;
            List<Dictionary<string, object>> objActual = objAgent.MaintailParameters;
            Dictionary<string, object> objExpecteds = this.ParseParameters(table);

            foreach (Dictionary<string, object> objParameters in objActual)
            {
                if (objParameters.Count == objExpecteds.Count)//數量一致。
                {
                    bIsFind = false;
                    foreach (KeyValuePair<string, object> objExpected in objExpecteds)
                    {
                        //每個預期的參數項都有對應的項目。
                        IEnumerable<KeyValuePair<string, object>> objQuery =
                            from KeyValuePair<string, object> objEachParameter in objParameters
                            where objEachParameter.Key == objExpected.Key
                                && objEachParameter.Value.Equals(objExpected.Value)
                            select objEachParameter;

                        //保留是否有對應的項目。
                        bIsFind = objQuery.Any();
                        //若有預期參數不在此集合就跳出，繼續次個參數集合。
                        if (bIsFind == false) { break; }
                    }
                    //如果所有預期項目都有對應就不用再繼續不同的參數集合。
                    if (bIsFind) { break; }
                }
            }
            Assert.IsTrue(bIsFind);
        }

        private System.Data.DataTable ConverTable(Table table)
        {
            System.Data.DataTable objReturn = new System.Data.DataTable();

            foreach (string sRowName in table.Rows[0].Keys)
            {
                objReturn.Columns.Add(sRowName, typeof(string));
            }

            foreach (TableRow objRow in table.Rows)
            {
                System.Data.DataRow objNewRow = objReturn.NewRow();

                foreach (string sRowName in table.Rows[0].Keys)
                {
                    objNewRow[sRowName] = objRow[sRowName];
                }
                objReturn.Rows.Add(objNewRow);
            }
            return objReturn;
        }

        private Dictionary<string, object> ParseParameters(Table table)
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();

            foreach (TableRow objRow in table.Rows)
            {
                objReturn.Add(objRow["Key"], objRow["Value"]);
            }
            return objReturn;
        }

        private List<CustomObject> ParseCustom(Table table)
        {
            List<CustomObject> objReturn = new List<CustomObject>();
            foreach (TableRow objRow in table.Rows)
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
