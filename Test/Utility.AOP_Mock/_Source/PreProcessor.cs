using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.AOP_Mock
{
    /// <summary>
    /// 示範剖面導向設計進行呼叫前處理器。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class PreProcessor : TOHU.Toolbox.Utility.AOP.IPreProcessor
    {

        #region -- 介面實做 ( Implements ) - [IPostProcessor] --

        /// <summary>
        /// 進行程序處理。
        /// </summary>
        /// <param name="pi_objCallMessage">呼叫物件。</param>
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
        public void Process(ref IMethodCallMessage pi_objCallMessage)
        {
            CallStacks.Call("PreProcess");
        }

        #endregion
    }
}
