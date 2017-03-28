using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 來源資料存取代理。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class AccessAgent : ISourceAgent
    {
        #region -- 變數宣告 ( Declarations ) --   

        private System.Data.OleDb.OleDbConnection l_objConnection = null;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_sAccessFullPath">Access 檔案完整路徑。</param>
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
        public AccessAgent(string pi_sAccessFullPath)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            string sConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=True", pi_sAccessFullPath);

            this.l_objConnection = new System.Data.OleDb.OleDbConnection();
            this.l_objConnection.ConnectionString = sConnectionString;
        }

        #endregion
    
        #region -- 介面實做 ( Implements ) - [ISourceAgent] --

        /// <summary>
        /// 執行維護語法。
        /// </summary>
        /// <param name="pi_sSQL">維護語法。</param>
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
        public void Execute(string pi_sSQL)
        {
            this.Execute(pi_sSQL, null);
        }

        /// <summary>
        /// 執行維護語法。
        /// </summary>
        /// <param name="pi_sSQL">維護語法。</param>
        /// <param name="pi_objParameters">語法參數集合。(開放多組參數，套用相同維護語法)</param>
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
        public void Execute(string pi_sSQL, List<Dictionary<string, object>> pi_objParameters)
        {
            this.l_objConnection.Open();
            OleDbTransaction objTrans = this.l_objConnection.BeginTransaction();
            OleDbCommand cmd = this.l_objConnection.CreateCommand();

            cmd.Transaction = objTrans;

            if (pi_objParameters == null)
            {
                cmd.CommandText = pi_sSQL;
                cmd.ExecuteNonQuery();
            }
            else
            {
                foreach (Dictionary<string, object> objParameters in pi_objParameters)
                {
                    cmd.CommandText = pi_sSQL;
                    foreach (KeyValuePair<string, object> objParameter in objParameters)
                    {
                        cmd.Parameters.Add(new OleDbParameter(objParameter.Key, objParameter.Value));
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            objTrans.Commit();
            this.l_objConnection.Close();
        }

        /// <summary>
        /// 查詢資料記錄。
        /// </summary>
        /// <param name="pi_sSQL">查詢語法。</param>
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
        public DataTable Query(string pi_sSQL)
        {
            return this.Query(pi_sSQL, null);
        }

        /// <summary>
        /// 查詢資料記錄。
        /// </summary>
        /// <param name="pi_sSQL">查詢語法。</param>
        /// <param name="pi_objParameters">查詢參數。(僅包含一組)</param>
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
        public DataTable Query(string pi_sSQL, Dictionary<string, object> pi_objParameters)
        {
            DataTable objReturn = null;

            if (pi_objParameters == null)
            {
                IDbDataAdapter dbAdapter = new OleDbDataAdapter(pi_sSQL, this.l_objConnection);
                DataSet dbSet = new DataSet();

                dbAdapter.Fill(dbSet);
                objReturn = dbSet.Tables[0];
            }
            else
            {
                IDbDataAdapter dbAdapter = new OleDbDataAdapter();
                DataSet dbSet = new DataSet();
                OleDbCommand cmd = this.l_objConnection.CreateCommand();

                cmd.CommandText = pi_sSQL;
                foreach (KeyValuePair<string, object> objParameter in pi_objParameters)
                {
                    cmd.Parameters.Add(new OleDbParameter(objParameter.Key, objParameter.Value));
                }
                dbAdapter.SelectCommand = cmd;
                dbAdapter.Fill(dbSet);
                objReturn = dbSet.Tables[0];
            }
            return objReturn;
        }

        #endregion

    }
}
