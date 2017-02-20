using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{

    /// <summary>
    /// <para>提供標記新增記錄時忽略欄位。</para>
    /// <para>當資料表欄位為自動編號欄位，查詢時需要取回但在新增記錄時無需給值的欄位，可透過此標注該屬性於新增時忽略。</para>
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SkipInsertFieldAttribute : Attribute { }

}