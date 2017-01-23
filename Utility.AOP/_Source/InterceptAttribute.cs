using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.AOP
{

    /// <summary>
    /// <para>定義可攔截類別的 Attrute 功能，測試ORM。</para>
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class InterceptAttribute : ContextAttribute, IContributeObjectSink
    {

        #region -- 變數宣告 ( Declarations ) --   

        private const string c_sPropertyName = "Intercept";

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// <para>建構元。</para>
        /// <para>繼承 <see cref="ContextAttribute"/> 必需呼叫基底的建構元，傳入名稱。</para>
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
        public InterceptAttribute() : base(c_sPropertyName) { }

        #endregion 

        #region -- 介面實做 ( Implements ) - [IContextProperty] --

        /// <summary>
        /// 提供自訂程序停擺時的處理。
        /// </summary>
        /// <param name="newContext">新的 Context 物件。</param>
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
        public override void Freeze(Context newContext) { }

        /// <summary>
        /// 提供自訂是否新建 Context 判斷邏輯。
        /// </summary>
        /// <param name="newCtx">新的 Context 物件。</param>
        /// <returns>是否新建 Context 物件。</returns>
        /// <remarks>
        /// <list type="bullet">
        /// <item><term>Author:</term><description>黃竣祥</description></item>
        /// <item><term>Time:</term><description>2017/01/09</description></item>
        /// <item><term>History</term><description>
        /// <list type="number">
        /// <item><term>2017/01/09</term><description>建立方法。</description></item>
        /// </list>
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        public override bool IsNewContextOK(Context newCtx)
        {
            return newCtx.GetProperty(c_sPropertyName) != null;
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IContextAttribute] --

        /// <summary>
        /// 取得新 Context 的額外屬性。
        /// </summary>
        /// <param name="ctorMsg">呼叫的 Message 物件。</param>
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
        public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
        {
            ctorMsg.ContextProperties.Add(this);
        }

        /// <summary>
        /// 提供自訂 Context 物件是否準備完畢判斷。
        /// </summary>
        /// <param name="newCtx">Context 物件。</param>
        /// <param name="ctorMsg">呼叫 Message 物件。</param>
        /// <returns> Context 物件是否準備完畢。</returns>
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
        public override bool IsContextOK(Context newCtx, IConstructionCallMessage ctorMsg)
        {
            return newCtx.GetProperty(c_sPropertyName) != null;
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IContributeObjectSink] --

        /// <summary>
        /// 將訊息接收的提供的伺服器物件，指定的接收鏈結的前面。
        /// </summary>
        /// <param name="obj">伺服器物件，其提供的訊息接收是鏈結前面指定的鏈結。</param>
        /// <param name="nextSink">目前為止所撰寫之接收鏈結。</param>
        /// <returns>複合接收鏈結。</returns>
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
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new InterceptSink(nextSink);
        }

        #endregion

    }
}
