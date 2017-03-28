using System.Collections.Generic;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 定義條件運算元操作功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public interface IConditionOperator
    {

        /// <summary>
        /// 取回條件字串。
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
        string GetConditionString();

        /// <summary>
        /// 取得參數值集合。
        /// </summary>
        /// <param name="pi_objSource">屬性型態參數的預設資料來源物件。</param>
        /// <returns>條件語法包含的參數。</returns>
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
        Dictionary<string, object> GetConditionParameter(object pi_objSource);
     
    }
}
