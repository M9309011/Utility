using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供關連資料物件的查詢、新增、刪除及更新操作。
    /// </summary>
    /// <typeparam name="TRelationObject">資料物件型別。</typeparam>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class ObjectFactory<TRelationObject> where TRelationObject : new()
    {

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 查詢指定的關連資料物件。
        /// </summary>
        /// <returns>查詢結果清單。</returns>
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
        public List<TRelationObject> Query(ISourceAgent pi_objSource)
        {
            List<TRelationObject> objReturn = new List<TRelationObject>();
            DataTable objTable = null;
            string sTableName = this.FindTableName();

            if (string.IsNullOrEmpty(sTableName) == false)
            {
                string sSQL = string.Format("SELECT * FROM {0}", sTableName);

                objTable = pi_objSource.Query(sSQL);
                objReturn = new TableMapper().Loading<TRelationObject>(objTable);
            }
            return objReturn;
        }

        public List<TRelationObject> Query(ISourceAgent pi_objSource, IConditionOperator pi_objCondition)
        {
            List<TRelationObject> objReturn = new List<TRelationObject>();

            if (pi_objCondition == null)
            {
                objReturn = this.Query(pi_objSource);
            }
            else
            {
                DataTable objTable = null;
                string sTableName = this.FindTableName();

                if (string.IsNullOrEmpty(sTableName) == false)
                {
                    string sSQL = string.Format("SELECT * FROM {0} WHERE {1}", sTableName, pi_objCondition.GetConditionString());
                    Dictionary<string, object> objConditionParameter = pi_objCondition.GetConditionParameter(null);
                    objTable = pi_objSource.Query(sSQL, objConditionParameter);
                    objReturn = new TableMapper().Loading<TRelationObject>(objTable);
                }
            }
            return objReturn;
        }


        public List<TRelationObject> Query(ISourceAgent pi_objSource, IConditionOperator pi_objCondition, TRelationObject pi_objSourceObject)
        {
            List<TRelationObject> objReturn = new List<TRelationObject>();

            if (pi_objSourceObject == null)
            {
                objReturn = this.Query(pi_objSource, pi_objCondition);
            }
            else
            {
                DataTable objTable = null;
                string sTableName = this.FindTableName();

                if (string.IsNullOrEmpty(sTableName) == false)
                {
                    string sSQL = string.Format("SELECT * FROM {0} WHERE {1}", sTableName, pi_objCondition.GetConditionString());
                    Dictionary<string, object> objConditionParameter = pi_objCondition.GetConditionParameter(pi_objSourceObject);
                    objTable = pi_objSource.Query(sSQL, objConditionParameter);
                    objReturn = new TableMapper().Loading<TRelationObject>(objTable);
                }
            }
            return objReturn;
        }

        /// <summary>
        /// 新增指定項目。
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <param name="pi_objRelationObjects"></param>
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
        public void Create(AccessAgent pi_objSource, List<TRelationObject> pi_objRelationObjects)
        {
            string sTableName = this.FindTableName();

            if (string.IsNullOrEmpty(sTableName) == false)
            {
                string sSQL = string.Empty;
                List<string> objColumns = new List<string>();
                MapperFieldFinder objFinder = new MapperFieldFinder();

                foreach (PropertyInfo objProperty in typeof(TRelationObject).GetProperties())
                {
                    if (objProperty.GetCustomAttribute<SkipInsertFieldAttribute>(true) == null)
                    {
                        string sFieldName = objFinder.Find(objProperty);

                        sFieldName = sFieldName == string.Empty ? objProperty.Name : sFieldName;
                        objColumns.Add(sFieldName);
                    }
                }

                objColumns.Sort();

                sSQL = string.Format("INSERT INTO [{2}] ( [{0}] ) VALUES ( @{1} )", string.Join("], [", objColumns), string.Join(", @", objColumns), sTableName);

                List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

                foreach (TRelationObject objRelationObject in pi_objRelationObjects)
                {
                    Dictionary<string, object> objParameter = new Dictionary<string, object>();
                    Dictionary<string, PropertyInfo> objFieldInfoCollection = new Dictionary<string, PropertyInfo>();

                    foreach (PropertyInfo objProperty in typeof(TRelationObject).GetProperties())
                    {
                        if (objProperty.GetCustomAttribute<SkipInsertFieldAttribute>(true) == null)
                        {
                            string sFieldName = objFinder.Find(objProperty);

                            sFieldName = sFieldName == string.Empty ? objProperty.Name : sFieldName;
                            objFieldInfoCollection.Add(sFieldName, objProperty);
                        }
                    }

                    foreach (string sColumn in objColumns)
                    {
                        if (objFieldInfoCollection.ContainsKey(sColumn))
                        {
                            objParameter.Add(string.Format("@{0}", sColumn), objFieldInfoCollection[sColumn].GetValue(objRelationObject));
                        }
                    }
                    objParameters.Add(objParameter);
                }
                pi_objSource.Execute(sSQL, objParameters);
            }
        }

        /// <summary>
        /// 刪除指定項目。
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <param name="pi_objRelationObjects"></param>
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
        public void Delete(AccessAgent pi_objSource, List<TRelationObject> pi_objRelationObjects)
        {
            string sTableName = this.FindTableName();
            Dictionary<string, PropertyInfo> objPrimaryIndexCollection = this.FindPrimaryIndex();

            if (string.IsNullOrEmpty(sTableName) == false && objPrimaryIndexCollection != null)
            {
                string sCondition = this.BuildCondition(objPrimaryIndexCollection.Keys.ToList<string>());
                string sSQL = string.Format("DELETE FROM [{0}] WHERE {1}", sTableName, sCondition);
                List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

                foreach (TRelationObject objRelationObject in pi_objRelationObjects)
                {
                    Dictionary<string, object> objParameter = new Dictionary<string, object>();

                    foreach (KeyValuePair<string, PropertyInfo> objPrimaryIndex in objPrimaryIndexCollection)
                    {

                        objParameter.Add(string.Format("@{0}", objPrimaryIndex.Key), objPrimaryIndex.Value.GetValue(objRelationObject));

                    }
                    objParameters.Add(objParameter);
                }
                pi_objSource.Execute(sSQL, objParameters);
            }
        }

        /// <summary>
        /// 更新指定項目。
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <param name="pi_objRelationObjects"></param>
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
        public void Update(AccessAgent pi_objSource, List<TRelationObject> pi_objRelationObjects)
        {
            string sTableName = this.FindTableName();
            Dictionary<string, PropertyInfo> objPrimaryIndexCollection = this.FindPrimaryIndex();
            Dictionary<string, PropertyInfo> objUpdateFieldCollection = this.FindUpdateField();

            if (string.IsNullOrEmpty(sTableName) == false && objPrimaryIndexCollection != null)
            {
                string sCondition = this.BuildCondition(objPrimaryIndexCollection.Keys.ToList<string>());
                string sUpdate = this.BuildUpdate(objUpdateFieldCollection.Keys.ToList<string>());
                string sSQL = string.Format("UPDATE [{0}]  SET {2} WHERE {1}", sTableName, sCondition, sUpdate);
                List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

                foreach (TRelationObject objRelationObject in pi_objRelationObjects)
                {
                    Dictionary<string, object> objParameter = new Dictionary<string, object>();

                    foreach (KeyValuePair<string, PropertyInfo> objPrimaryIndex in objUpdateFieldCollection)
                    {
                        objParameter.Add(string.Format("@{0}", objPrimaryIndex.Key), objPrimaryIndex.Value.GetValue(objRelationObject));
                    }

                    foreach (KeyValuePair<string, PropertyInfo> objPrimaryIndex in objPrimaryIndexCollection)
                    {
                        objParameter.Add(string.Format("@{0}", objPrimaryIndex.Key), objPrimaryIndex.Value.GetValue(objRelationObject));
                    }
                    objParameters.Add(objParameter);
                }
                pi_objSource.Execute(sSQL, objParameters);
            }
        }

        #endregion        

        #region -- 私有函式 ( Private Method) --

        /// <summary>
        /// 找尋資料表名稱。
        /// </summary>
        /// <returns>資料表名稱。</returns>
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
        private string FindTableName()
        {
            string sReturn = string.Empty;
            TableNameAttribute objTableName =
                typeof(TRelationObject).GetCustomAttributes(typeof(TableNameAttribute), false).FirstOrDefault() as TableNameAttribute;

            if (objTableName != null)
            {
                sReturn = objTableName.TableName;
            }
            return sReturn;
        }

        /// <summary>
        /// 找尋索引值集合。
        /// </summary>
        /// <returns>索引值集合。</returns>
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
        private Dictionary<string, PropertyInfo> FindPrimaryIndex()
        {
            Dictionary<string, PropertyInfo> objReturn = new Dictionary<string, PropertyInfo>();
            MapperFieldFinder objFinder = new MapperFieldFinder();

            foreach (PropertyInfo objProperty in typeof(TRelationObject).GetProperties())
            {
                if (objProperty.GetCustomAttribute(typeof(PrimaryIndexAttribute), false) != null)
                {
                    string sFieldName = objFinder.Find(objProperty);

                    sFieldName = sFieldName == string.Empty ? objProperty.Name : sFieldName;
                    objReturn.Add(sFieldName, objProperty);
                }
            }

            if (objReturn.Count <= 0) { objReturn = null; }

            return objReturn;
        }

        /// <summary>
        /// 找尋待更新欄集合。
        /// </summary>
        /// <returns>待更新欄集合。</returns>
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
        private Dictionary<string, PropertyInfo> FindUpdateField()
        {
            Dictionary<string, PropertyInfo> objReturn = new Dictionary<string, PropertyInfo>();
            MapperFieldFinder objFinder = new MapperFieldFinder();

            foreach (PropertyInfo objProperty in typeof(TRelationObject).GetProperties())
            {
                if (objProperty.GetCustomAttribute(typeof(PrimaryIndexAttribute), false) == null
                    && objProperty.GetCustomAttribute<SkipInsertFieldAttribute>(true) == null)
                {
                    string sFieldName = objFinder.Find(objProperty);

                    sFieldName = sFieldName == string.Empty ? objProperty.Name : sFieldName;
                    objReturn.Add(sFieldName, objProperty);
                }
            }

            if (objReturn.Count <= 0) { objReturn = null; }

            return objReturn;
        }

        /// <summary>
        /// 建立索引值條件字串。
        /// </summary>
        /// <param name="pi_sPrimaryIndexs"></param>
        /// <returns>索引值條件字串。</returns>
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
        private string BuildCondition(List<string> pi_sPrimaryIndexs)
        {
            string sReturn = string.Empty;
            List<string> objParts = new List<string>();

            foreach (string sPrimaryIndex in pi_sPrimaryIndexs)
            {
                objParts.Add(string.Format("{0}=@{0}", sPrimaryIndex));
            }
            sReturn = string.Join("And ", objParts);
            return sReturn;
        }

        /// <summary>
        /// 建立更新欄字串。
        /// </summary>
        /// <param name="pi_sPrimaryIndexs"></param>
        /// <returns>更新欄字串。</returns>
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
        private string BuildUpdate(List<string> pi_sPrimaryIndexs)
        {
            string sReturn = string.Empty;
            List<string> objParts = new List<string>();

            foreach (string sPrimaryIndex in pi_sPrimaryIndexs)
            {
                objParts.Add(string.Format("{0}=@{0}", sPrimaryIndex));
            }
            sReturn = string.Join(",  ", objParts);
            return sReturn;
        }

        #endregion
    }
}
