using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{

    /// <summary>
    /// <para>提供指定欄位名稱。</para>
    /// <para>當資料物件與資料表名稱相異時，可透過此標注該屬性對應的資料表欄位。</para>
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MappingFieldAttribute : Attribute
    {

        /// <summary>
        /// 取得或設定對應的欄位名稱。
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
        public string FieldName { get; set; }

    }
}
