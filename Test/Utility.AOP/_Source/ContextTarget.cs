using System;

namespace TOHU.Toolbox.Utility.AOP_UT
{
    /// <summary>
    /// <para>提供函式需要剖面導向處理的類別範例。</para>
    /// <list type="bullet">
    /// <item><term>繼承：</term><description>需要繼承 <see cref="System.ContextBoundObject"/> 類別。</description></item>
    /// <item><term>標注：</term><description>函式要標注 <see cref="TOHU.Toolbox.Utility.AOP.PreProcessAttribute"/> 或是 <see cref="TOHU.Toolbox.Utility.AOP.PostProcessAttribute"/>。</description></item>
    /// </list>
    /// </summary>
    [TOHU.Toolbox.Utility.AOP.Intercept]
    public  class ContextTarget : ContextBoundObject
    {
        /// <summary>
        /// 示範具備執行前剖面導向處理的函式。
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
        [TOHU.Toolbox.Utility.AOP.PreProcess(typeof(PreProcessor))]
        public void DoSomethingAndPreProcess()
        {
            CallStacks.Call("DoSomething");
        }

        /// <summary>
        /// 示範具備執行後剖面導向處理的函式。
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
        [TOHU.Toolbox.Utility.AOP.PostProcess(typeof(PostProcessor))]
        public void DoSomethingAndPostProcess()
        {
            CallStacks.Call("DoSomething");
        }

        /// <summary>
        /// 示範具備執行前剖面導向處理及執行後剖面導向處理的函式。
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
        [TOHU.Toolbox.Utility.AOP.PreProcess(typeof(PreProcessor))]
        [TOHU.Toolbox.Utility.AOP.PostProcess(typeof(PostProcessor))]
        public void DoSomethingAndPreProcessAndPostProcess()
        {
            CallStacks.Call("DoSomething");
        }
    }
}
