using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using TOHU.Toolbox.Utility.ORM;

namespace TOHU.Toolbox.Utility.ORM_Mock
{
    /// <summary>
    /// 提供資料庫操作功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class DatabaseHelper
    {

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 準備資料庫。
        /// </summary>
        /// <param name="pi_sVersion">版本。</param>
        /// <param name="pi_objDatabase">資料庫資料來源。</param>
        /// <returns>資料庫路徑。</returns>
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
        public string InitialDatabase(string pi_sVersion, DataSet pi_objDatabase)
        {
            string sReturn = string.Empty;
            string sSource = string.Format("{0}\\_Resource\\EastSun.accdb", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Locati‌​on));
            AccessAgent objDatabaseAgent = null;

            sReturn = string.Format("{0}\\_Resource\\{1}\\EastSun.accdb", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Locati‌​on), pi_sVersion);
            Directory.CreateDirectory(Path.GetDirectoryName(sReturn));
            File.Copy(sSource, sReturn);
            objDatabaseAgent = new AccessAgent(sReturn);

            if (pi_objDatabase != null)
            {
                foreach (DataTable objTable in pi_objDatabase.Tables)
                {
                    this.InsertIntoDatabase(objDatabaseAgent, objTable);
                }
            }
            return sReturn;
        }

        /// <summary>
        /// 移除資料庫。
        /// </summary>
        /// <param name="pi_sVersion">版本。</param>
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
        public void RemoveDatabase(string pi_sVersion)
        {
            string sTarget = string.Format("{0}\\_Resource\\{1}\\", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Locati‌​on), pi_sVersion);
            Directory.Delete(Path.GetDirectoryName(sTarget), true);
        }

        #endregion   

        #region -- 私有函式 ( Private Method) --

        /// <summary>
        /// 新增資料庫內容。
        /// </summary>
        /// <param name="pi_objDatabaseAgent">資料庫代理物件。</param>
        /// <param name="pi_objTable">資料來源資料表。</param>
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
        private void InsertIntoDatabase(AccessAgent pi_objDatabaseAgent, DataTable pi_objTable)
        {
            IEnumerable<string> objColumns =
                (from DataColumn objColumn in pi_objTable.Columns
                 select objColumn.ColumnName);

            string sSQL = string.Format("INSERT INTO [{2}] ( [{0}] ) VALUES ( @{1} )", string.Join("], [", objColumns), string.Join(", @", objColumns), pi_objTable.TableName);
            List<Dictionary<string, object>> objParameters = new List<Dictionary<string, object>>();

            foreach (DataRow objRow in pi_objTable.Rows)
            {
                Dictionary<string, object> objParameter = new Dictionary<string, object>();

                foreach (DataColumn objColumn in pi_objTable.Columns)
                {
                    objParameter.Add(objColumn.ColumnName, objRow[objColumn.ColumnName]);
                }
                objParameters.Add(objParameter);
            }
            pi_objDatabaseAgent.Execute(sSQL, objParameters);
        }

        #endregion
        
    }
}
