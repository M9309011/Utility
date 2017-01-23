using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.AOP
{

    /// <summary>
    /// 提供訊息接收的操作功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class InterceptSink : IMessageSink
    {
        #region -- 變數宣告 ( Declarations ) --

        private IMessageSink m_objNextSink;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objNextSink">次個 MessageSink 實體。</param>
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
        public InterceptSink(IMessageSink pi_objNextSink)
        {
            this.m_objNextSink = pi_objNextSink;
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IMessageSink] --

        /// <summary>
        /// 取得接收鍵結中的下一個訊息接收。
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
        public IMessageSink NextSink
        {
            get { return this.m_objNextSink; }
        }

        /// <summary>
        /// 同步處理指定的訊息。
        /// </summary>
        /// <param name="msg">要處理的訊息。</param>
        /// <returns>要求回應回覆訊息。</returns>
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
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage mcm = (msg as IMethodCallMessage);
            this.PreProcess(ref mcm);
            IMessage rtnMsg = m_objNextSink.SyncProcessMessage(msg);
            IMethodReturnMessage mrm = (rtnMsg as IMethodReturnMessage);
            this.PostProcess(msg as IMethodCallMessage, ref mrm);
            return mrm;
        }

        /// <summary>
        /// 以非同步方式處理指定的訊息。
        /// </summary>
        /// <param name="msg">要處理的訊息。</param>
        /// <param name="replySink">回覆接收回覆訊息。</param>
        /// <returns>傳回 IMessageCtrl 介面會提供方法來控制非同步訊息分派他們之後。</returns>
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
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return this.m_objNextSink.AsyncProcessMessage(msg, replySink);
        }

        #endregion

        #region -- 私有函式 ( Private Method) --

        /// <summary>
        /// 處理函式呼叫前程序。
        /// </summary>
        /// <param name="pi_objMessage">待呼叫函式。</param>
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
        private void PreProcess(ref IMethodCallMessage pi_objMessage)
        {
            PreProcessAttribute[] attrs
                = (PreProcessAttribute[])pi_objMessage.MethodBase.GetCustomAttributes(typeof(PreProcessAttribute), true);
            for (int i = 0; i < attrs.Length; i++)
                attrs[i].Processor.Process(ref pi_objMessage);
        }

        /// <summary>
        /// 處理函式呼叫後程序。
        /// </summary>
        /// <param name="pi_objCallMsg">呼叫的函式。</param>
        /// <param name="pi_objReturnMsg">呼叫後的回覆。</param>
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
        private void PostProcess(IMethodCallMessage pi_objCallMsg, ref IMethodReturnMessage pi_objReturnMsg)
        {
            PostProcessAttribute[] attrs
                = (PostProcessAttribute[])pi_objCallMsg.MethodBase.GetCustomAttributes(typeof(PostProcessAttribute), true);
            for (int i = 0; i < attrs.Length; i++)
                attrs[i].Processor.Process(pi_objCallMsg, ref pi_objReturnMsg);
        }

        #endregion
    }

}
