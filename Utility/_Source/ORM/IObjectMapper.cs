using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{

    /// <summary>
    /// 定義關連資料物件與資料來源對應的操作。
    /// </summary>
    /// <typeparam name="TSource">來源資料型別。</typeparam>
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
    public interface IObjectMapper<TSource>
    {

        /// <summary>
        /// 載入資料後輸出資料物件清單。
        /// </summary>
        /// <typeparam name="TDataInfo">關連資料物件型別。</typeparam>
        /// <param name="pi_objSource">資料來源。</param>
        /// <returns>載入資料後的關連資料物件清單。</returns>
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
        List<TDataInfo> Loading<TDataInfo>(TSource pi_objSource) where TDataInfo : new();

    }
}
