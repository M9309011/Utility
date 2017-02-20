using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 定義資料來源應提供的功能操作。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public interface ISourceAgent
    {

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
        DataTable Query(string pi_sSQL);

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
        DataTable Query(string pi_sSQL, Dictionary<string, object> pi_objParameters);

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
        void Execute(string pi_sSQL);

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
        void Execute(string pi_sSQL, List<Dictionary<string, object>> pi_objParameters);

    }
}
