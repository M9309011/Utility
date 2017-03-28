using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOHU.Toolbox.Utility.ORM;

namespace TOHU.Toolbox.Utility.ORM_Mock
{
    /// <summary>
    /// 提供 EastSun 資料庫的 Custom 資料表關連資料物件。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>  
    [TableName(TableName = "Custom")]
    public class CustomObject
    {

        #region -- 屬性 ( Properties ) --

        /// <summary>
        /// 設定或取得 ID 欄位資料。(屬性名稱與資料表欄位名稱不一致時)
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
        [PrimaryIndex]
        [TOHU.Toolbox.Utility.ORM.MappingField(FieldName = "ID")]
        public string Initial { get; set; }

        /// <summary>
        /// 設定或取得 Name 欄位資料。
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
        public string Name { get; set; }

        /// <summary>
        /// 設定或取得 Extenstion 欄位資料。
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
        public string Extenstion { get; set; }

        /// <summary>
        /// 設定或取得 EMail 欄位資料。(屬性不存在資料表欄位的範例)
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
        [TOHU.Toolbox.Utility.ORM.SkipInsertField]
        public string EMail { get; set; }

        #endregion

    }
}
