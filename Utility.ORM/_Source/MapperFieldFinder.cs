using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供從 <see cref="System.Reflection.PropertyInfo"/> 取得 <see cref="MappingFieldAttribute"/> 的設定值。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    internal class MapperFieldFinder
    {

        /// <summary>
        /// <para>尋找傳入 <see cref="System.Reflection.PropertyInfo"/> 標注的 <see cref="MappingFieldAttribute"/> 的設定值。</para>
        /// <para>沒有標注時則回傳 <see cref="System.String.Empty"/> 。</para>
        /// </summary>
        /// <param name="pi_objSource">尋找的來源 <see cref="System.Reflection.PropertyInfo"/> 。</param>
        /// <returns>
        /// <para>傳入 <see cref="System.Reflection.PropertyInfo"/> 標注的 <see cref="MappingFieldAttribute"/> 的設定值。</para>
        /// <para>沒有標注時則回傳 <see cref="System.String.Empty"/> 。</para>
        /// </returns>
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
        public string Find(PropertyInfo pi_objSource)
        {
            string sReturn = string.Empty;

            MappingFieldAttribute objAttribute = pi_objSource.GetCustomAttribute<MappingFieldAttribute>(true);

            if (objAttribute != null) { sReturn = objAttribute.FieldName; }

            return sReturn;
        }
    }
}
