using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ORM_UT
{
    /// <summary>
    /// 提供更新資訊功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    internal class StubUpdateInfo : TOHU.Toolbox.Utility.ORM.UpdateInfo
    {

        #region -- 變數宣告 ( Declarations ) --  

        private string l_sUpdateSetting = string.Empty;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_sString">預設回傳字串。</param>
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
        public StubUpdateInfo(string pi_sString) : base(pi_sString, string.Empty)
        {
            this.l_sUpdateSetting = pi_sString;
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 覆寫取得更新字串函式。
        /// </summary>
        /// <returns>更新字串。</returns>
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
        public override string GetString()
        {
            return this.l_sUpdateSetting;
        }

        #endregion
    }
}
