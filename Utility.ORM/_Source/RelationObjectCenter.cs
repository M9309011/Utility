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
    /// 提供關連資料物件操作功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class RelationObjectCenter
    {

        /// <summary>
        /// 查詢關連資料物件。
        /// </summary>
        /// <typeparam name="TRelationObject">關連資料物件型別。</typeparam>
        /// <param name="pi_objConditionSource">條件式資料來源物件。</param>
        /// <param name="pi_objParameters">執行關連資料物件操作的參數。</param>      
        /// <param name="pi_objSource">資料庫代理物件。</param>
        /// <returns>關連資料物件清單。</returns>
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
        public List<TRelationObject> Query<TRelationObject>(object pi_objConditionSource, RelationObjectParameters pi_objParameters, ISourceAgent pi_objSource) where TRelationObject : new()
        {
            List<TRelationObject> objReturn = new List<TRelationObject>();
            DataTable objTable = null;
            string sSQL = string.Format("SELECT * FROM {0}", pi_objParameters.TableName);

            if (pi_objParameters.Condition != null)
            {
                string sCondition = pi_objParameters.Condition.GetConditionString();
                sSQL = string.Format("{0} WHERE {1}", sSQL, sCondition);

                objTable = pi_objSource.Query(sSQL, pi_objParameters.Condition.GetConditionParameter(pi_objConditionSource));
            }
            else
            {
                objTable = pi_objSource.Query(sSQL);
            }

            objReturn = new TableMapper().Loading<TRelationObject>(objTable);

            return objReturn;
        }

        /// <summary>
        /// 新增關連資料。
        /// </summary>
        /// <param name="pi_objRelationObjects">待新增的關連資料物件清單。</param>
        /// <param name="pi_objParameters">執行關連資料物件操作的參數。</param>
        /// <param name="pi_objSource">資料庫代理物件。</param>
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
        public void Create<TRelationObject>(List<TRelationObject> pi_objRelationObjects, RelationObjectParameters pi_objParameters, ISourceAgent pi_objSource)
        {
            string sSQL = string.Empty;
            List<string> objColumns = new List<string>();

            foreach (PropertyInfo objProperty in typeof(TRelationObject).GetProperties())
            {
                if (objProperty.GetCustomAttribute<SkipInsertFieldAttribute>(true) == null)
                {
                    objColumns.Add(objProperty.Name);
                }
            }

            sSQL = string.Format("INSERT INTO [{2}] ( [{0}] ) VALUES ( @{1} )", string.Join("], [", objColumns), string.Join(", @", objColumns), pi_objParameters.TableName);

            List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

            foreach (TRelationObject objRelationObject in pi_objRelationObjects)
            {
                Dictionary<string, object> objParameter = new Dictionary<string, object>();

                foreach (PropertyInfo objProperty in typeof(TRelationObject).GetProperties())
                {
                    if (objProperty.GetCustomAttribute<SkipInsertFieldAttribute>(true) == null)
                    {
                        objParameter.Add(string.Format("@{0}", objProperty.Name), objProperty.GetValue(objRelationObject));
                    }
                }
                objParameters.Add(objParameter);
            }
            pi_objSource.Execute(sSQL, objParameters);
        }

        /// <summary>
        /// 刪除關連資料。
        /// </summary>
        /// <param name="pi_objRelationObjects">待新增的關連資料物件清單。</param>
        /// <param name="pi_objParameters">執行關連資料物件操作的參數。</param>
        /// <param name="pi_objSource">資料庫代理物件。</param>
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
        public void Delete<TRelationObject>(List<TRelationObject> pi_objRelationObjects, RelationObjectParameters pi_objParameters, ISourceAgent pi_objSource)
        {
            string sSQL = string.Format("DELETE FROM [{0}]", pi_objParameters.TableName);

            if (pi_objParameters.Condition != null)
            {
                List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

                sSQL = string.Format("{0} WHERE {1}", sSQL, pi_objParameters.Condition.GetConditionString());
                foreach (TRelationObject objRelationObject in pi_objRelationObjects)
                {
                    Dictionary<string, object> objParameter = pi_objParameters.Condition.GetConditionParameter(objRelationObject);
                    objParameters.Add(objParameter);
                }
                pi_objSource.Execute(sSQL, objParameters);
            }
            else
            {
                pi_objSource.Execute(sSQL);
            }
        }

        /// <summary>
        /// 更新關連資料。
        /// </summary>
        /// <param name="pi_objRelationObjects">待新增的關連資料物件清單。</param>
        /// <param name="pi_objParameters">執行關連資料物件操作的參數。</param>
        /// <param name="pi_objSource">資料庫代理物件。</param>
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
        public void Update<TRelationObject>(List<TRelationObject> pi_objRelationObjects, RelationObjectParameters pi_objParameters, ISourceAgent pi_objSource)
        {
            string sSQL = string.Format("UPDATE [{0}] SET ( {1} )",
                pi_objParameters.TableName,
                pi_objParameters.UpdateInfo.GetString());

            if (pi_objParameters.Condition != null)
            {
                sSQL = string.Format("{0} WHERE {1}", sSQL, pi_objParameters.Condition.GetConditionString());
            }

            List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

            foreach (TRelationObject objRelationObject in pi_objRelationObjects)
            {
                Dictionary<string, object> objParameter = pi_objParameters.UpdateInfo.GetParameter(objRelationObject);

                if (pi_objParameters.Condition != null)
                {
                    foreach (KeyValuePair<string, object> objEachUpdateParameter in pi_objParameters.Condition.GetConditionParameter(objRelationObject))
                    {
                        objParameter.Add(objEachUpdateParameter.Key, objEachUpdateParameter.Value);
                    }
                }
                objParameters.Add(objParameter);
            }

            pi_objSource.Execute(sSQL, objParameters);
        }
    }
}
