using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供條件式的括號功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class BracketsOperator : IConditionOperator
    {

        #region -- 變數宣告 ( Declarations ) -- 

        private int m_nID = 0;
        private LogicOperator l_objCondition = null;
        private object l_objSource = null;
        private BracketsOperator l_objParent = default(BracketsOperator);
        private BracketsOperator l_objNextBrackets = default(BracketsOperator);
        private ConditionOperatorEnum l_objConditionOperator = ConditionOperatorEnum.Idle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --             

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objOperator">邏輯操作物件。</param>
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
        public BracketsOperator(LogicOperator pi_objOperator) : this(0, pi_objOperator, null, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objOperator">邏輯操作物件。</param>
        /// <param name="pi_objSource">邏輯操作物件建立條件的預設資料物件。</param>
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
        public BracketsOperator(LogicOperator pi_objOperator, object pi_objSource) : this(0, pi_objOperator, pi_objSource, null) { }

        /// <summary>
        /// 建構元。(提供內部及其他建構元呼叫，所以設定為 internal )
        /// </summary>
        /// <param name="pi_nID">序號。</param>
        /// <param name="pi_objOperator">邏輯操作物件。</param>
        /// <param name="pi_objSource">邏輯操作物件建立條件的預設資料物件。</param>
        /// <param name="pi_objParent">母項。</param>
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
        internal BracketsOperator(int pi_nID, LogicOperator pi_objOperator, object pi_objSource, BracketsOperator pi_objParent)
        {
            this.m_nID = pi_nID + 1;
            pi_objOperator.BracketsID = this.m_nID;
            this.l_objCondition = pi_objOperator;
            this.l_objSource = pi_objSource;
            this.l_objParent = pi_objParent;
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 透過 And 串接次個括號。
        /// </summary>
        /// <param name="pi_objCondition">次個括號所包含的邏輯操作。</param>
        /// <returns>次個括號物件。</returns>
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
        public BracketsOperator And(LogicOperator pi_objCondition)
        {
            return this.And(pi_objCondition, null);
        }

        /// <summary>
        /// 透過 And 串接次個括號。
        /// </summary>
        /// <param name="pi_objCondition">次個括號所包含的邏輯操作。</param>
        /// <param name="pi_objSource">次個括號所包含的邏輯操作所需的預設資料來源物件。</param>
        /// <returns>次個括號物件。</returns>
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
        public BracketsOperator And(LogicOperator pi_objCondition, object pi_objSource)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.AND;
            this.l_objNextBrackets = new BracketsOperator(this.m_nID, pi_objCondition, pi_objSource, this);
            return this.l_objNextBrackets;
        }

        /// <summary>
        /// 透過 Or 串接次個括號。
        /// </summary>
        /// <param name="pi_objCondition">次個括號所包含的邏輯操作。</param>
        /// <returns>次個括號物件。</returns>
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
        public BracketsOperator Or(LogicOperator pi_objCondition) { return this.Or(pi_objCondition, null); }

        /// <summary>
        /// 透過 Or 串接次個括號。
        /// </summary>
        /// <param name="pi_objCondition">次個括號所包含的邏輯操作。</param>
        /// <param name="pi_objSource">次個括號所包含的邏輯操作所需的預設資料來源物件。</param>
        /// <returns>次個括號物件。</returns>
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
        public BracketsOperator Or(LogicOperator pi_objCondition, object pi_objSource)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.OR;
            this.l_objNextBrackets = new BracketsOperator(this.m_nID, pi_objCondition, pi_objSource, this);
            return this.l_objNextBrackets;
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IConditionOperator] --

        /// <summary>
        /// 
        /// </summary>     
        /// <returns></returns>
        public string GetConditionString()
        {
            string sReturn = string.Empty;

            if (this.l_objParent == null)
            {
                sReturn = string.Format("( {0} )", this.l_objCondition.GetConditionString());
                if (this.l_objNextBrackets != null)
                {
                    sReturn = string.Format("{0} {1} {2}",
                        sReturn,
                        this.l_objConditionOperator.ToString(),
                        this.l_objNextBrackets.GetConditionStringFromChild());
                }
            }
            else
            {
                sReturn = this.l_objParent.GetConditionString();
            }

            return sReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetConditionParameter(object pi_objSource)
        {
            Dictionary<string, object> objReturn = null;

            if (this.l_objParent == null)
            {
                object objSource = this.l_objSource == null ? pi_objSource : this.l_objSource;

                objReturn = this.l_objCondition.GetConditionParameter(objSource);
                if (this.l_objNextBrackets != null)
                {
                    foreach (KeyValuePair<string, object> objParameter in this.l_objNextBrackets.GetConditionParameterFromChild(pi_objSource))
                    {
                        objReturn.Add(objParameter.Key, objParameter.Value);
                    }
                }
            }
            else
            {
                objReturn = this.l_objParent.GetConditionParameter(pi_objSource);
            }

            return objReturn;
        }

        #endregion

        #region -- 私有函式 ( Private Method) --
        
        /// <summary>
        /// 從子項取得條件字串。
        /// </summary>       
        /// <returns>條件字串。</returns>
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
        internal string GetConditionStringFromChild()
        {
            string sReturn = string.Empty;

            sReturn = string.Format("( {0} )", this.l_objCondition.GetConditionString());
            if (this.l_objNextBrackets != null)
            {
                sReturn = string.Format("{0} {1} {2}",
                    sReturn,
                    this.l_objConditionOperator.ToString(),
                    this.l_objNextBrackets.GetConditionStringFromChild());
            }
            return sReturn;
        }

        /// <summary>
        /// 從子項取得條件參數集合。
        /// </summary>
        /// <param name="pi_objSource">預設來源資料物件。</param>
        /// <returns>條件參數集合。</returns>
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
        internal Dictionary<string, object> GetConditionParameterFromChild(object pi_objSource)
        {
            Dictionary<string, object> objReturn = null;
            object objSource = this.l_objSource == null ? pi_objSource : this.l_objSource;

            objReturn = this.l_objCondition.GetConditionParameter(objSource);
            if (this.l_objNextBrackets != null)
            {
                foreach (KeyValuePair<string, object> objParameter in this.l_objNextBrackets.GetConditionParameterFromChild(pi_objSource))
                {
                    objReturn.Add(objParameter.Key, objParameter.Value);
                }
            }
            return objReturn;
        }

        #endregion
    }
}
