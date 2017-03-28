using System.Collections.Generic;
using System.Data;

namespace Utility.ORM_UT
{

    /// <summary>
    /// 提供資料來源代理物件。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class MockSourceAgent : TOHU.Toolbox.Utility.ORM.ISourceAgent
    {

        #region -- 變數宣告 ( Declarations ) --   

        private TOHU.Toolbox.Utility.ORM.AccessAgent l_objAgent = null;       

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_sFilePath">資料庫路徑。</param>
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
        public MockSourceAgent(string pi_sFilePath)
        {
            this.l_objAgent = new TOHU.Toolbox.Utility.ORM.AccessAgent(pi_sFilePath);
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        /// <summary>
        /// 取得或設定語法字串。(供測試案例驗證)
        /// </summary>
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
        public string SQL { get; set; }

        /// <summary>
        /// 取得或設定維護(新增／刪除／更新)的參數。(供測試案例驗證)
        /// </summary>
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
        public List<Dictionary<string, object>> MaintailParameters { get; set; }

        /// <summary>
        /// 取得或設定查詢的參數。(供測試案例驗證)
        /// </summary>
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
        public Dictionary<string, object> QueryParameters { get; set; }

        #endregion

        #region -- 介面實做 ( Implements ) - [ISourceAgent] --

        /// <summary>
        /// 提供資料維護操作。
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
        /// 提供資料維護操作。
        /// </summary>
        /// <param name="pi_sSQL">維護語法。</param>
        /// <param name="pi_objParameters">維護語法參數。</param>
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
            this.SQL = pi_sSQL;
            this.MaintailParameters = pi_objParameters;

            this.l_objAgent.Execute(pi_sSQL, pi_objParameters);
        }

        /// <summary>
        /// 提供資料表查詢。
        /// </summary>
        /// <param name="pi_sSQL">查詢語法</param>
        /// <returns>查詢結果。</returns>
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
        /// 提供資料表查詢。
        /// </summary>
        /// <param name="pi_sSQL">查詢語法。</param>
        /// <param name="pi_objParameters">查詢語法參數。</param>
        /// <returns>查詢結果。</returns>
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
            this.SQL = pi_sSQL;
            this.QueryParameters = pi_objParameters;

            return this.l_objAgent.Query(pi_sSQL, pi_objParameters);
        }

        #endregion

    }
}
