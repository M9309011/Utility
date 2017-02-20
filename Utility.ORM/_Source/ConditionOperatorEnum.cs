using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{

    /// <summary>
    /// 定義條件運算子種類。
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
    internal enum ConditionOperatorEnum
    {
        @Idle,
        @AND,
        @OR
    }
}
