using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.AOP
{

    /// <summary>
    /// 提供標注函式於呼叫前要執行的處理器的標籤。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class PreProcessAttribute : Attribute
    {

        #region -- 變數宣告 ( Declarations ) --   

        private IPreProcessor m_objProcessor;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_tPreProcessorType">處理器型別。</param>
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
        public PreProcessAttribute(Type pi_tPreProcessorType)
        {
            this.m_objProcessor = Activator.CreateInstance(pi_tPreProcessorType) as IPreProcessor;
            if (this.m_objProcessor == null)
            {
                throw new ArgumentException(
                    String.Format("The type '{0}' does not implement interface IPreProcessor", pi_tPreProcessorType.Name));
            }
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        /// <summary>
        /// 取得處理器。
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
        public IPreProcessor Processor
        {
            get { return m_objProcessor; }
        }

        #endregion

    }
}
