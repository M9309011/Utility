using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.AOP_Mock
{
    /// <summary>
    /// 示範剖面導向設計進行呼叫後處理器。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class PostProcessor : TOHU.Toolbox.Utility.AOP.IPostProcessor
    {

        #region -- 介面實做 ( Implements ) - [IPostProcessor] --

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
        public void Process(IMethodCallMessage pi_objCallMsg, ref IMethodReturnMessage pi_objReturnMsg)
        {
            CallStacks.Call("PostProcess");
            List<string> objReturnValue = pi_objReturnMsg.ReturnValue as List<string>;
            objReturnValue.Add("PostProcess");
        }

        #endregion  
    }
}
