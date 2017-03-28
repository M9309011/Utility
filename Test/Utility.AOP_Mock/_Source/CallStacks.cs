using System.Collections.Generic;

namespace TOHU.Toolbox.Utility.AOP_Mock
{

    /// <summary>
    /// 記錄呼叫情形，提供測試確認。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public  class CallStacks
    {

        #region -- 變數宣告 ( Declarations ) --   

        static private Queue<string> m_objCalls;

        #endregion
        
        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 重設呼叫堆疊。
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
        public static void Reset()
        {
            if (m_objCalls == null)
            {
                m_objCalls = new Queue<string>();
            }
            else
            {
                m_objCalls.Clear();
            }
        }

        /// <summary>
        /// 呼叫記錄。
        /// </summary>
        /// <param name="pi_sCall">呼叫來源名稱。</param>
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
        public static void Call(string pi_sCall) { m_objCalls.Enqueue(pi_sCall); }

        /// <summary>
        /// 取得呼叫堆疊。
        /// </summary>
        /// <returns>呼叫堆疊</returns>
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
        public static Queue<string> GetCalls() { return m_objCalls; }
        
        #endregion        
     
    }
}
