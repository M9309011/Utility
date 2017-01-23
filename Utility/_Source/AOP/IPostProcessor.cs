using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.AOP
{
    /// <summary>
    /// 定義執行呼叫後執行器操作功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public interface IPostProcessor
    {

        /// <summary>
        /// 進行處理程序。
        /// </summary>
        /// <param name="pi_objCallMsg">待執行的呼叫。</param>
        /// <param name="pi_objReturnMsg">回傳的呼叫。</param>
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
        void Process(IMethodCallMessage pi_objCallMsg, ref IMethodReturnMessage pi_objReturnMsg);

    }
}
