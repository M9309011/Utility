using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供條件式中的邏輯判斷。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class LogicOperator : IConditionOperator
    {
        #region -- 變數宣告 ( Declarations ) --   

        private int l_nBracketsID = 0;
        private int m_nID = 0;
        private string m_sCondition = string.Empty;
        private System.Reflection.PropertyInfo m_objCondition = null;
        private object l_objValue = null;

        private LogicOperator l_objParent = default(LogicOperator);
        private LogicOperator l_objNextCondition = default(LogicOperator);
        private ConditionOperatorEnum l_objConditionOperator = ConditionOperatorEnum.Idle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --        

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_sCondition">條件欄位。</param>
        /// <param name="pi_objValue">條件值。</param>
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
        public LogicOperator(string pi_sCondition, object pi_objValue) : this(0, pi_sCondition, pi_objValue, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>       
        /// <param name="pi_objCondition">條件屬性。</param>  
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
        public LogicOperator(System.Reflection.PropertyInfo pi_objCondition) : this(0, pi_objCondition, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>       
        /// <param name="pi_objCondition">條件屬性。</param>
        /// <param name="pi_objSource">條件屬性值來源物件。</param>
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
        public LogicOperator(System.Reflection.PropertyInfo pi_objCondition, object pi_objSource) : this(0, pi_objCondition.Name, pi_objCondition.GetValue(pi_objSource), null) { }

        /// <summary>
        /// 建構元。( 提供內部 And/Or 函式及其他建構元呼叫 )
        /// </summary>
        /// <param name="pi_nId">條件序號。</param>
        /// <param name="pi_sCondition">條件欄位。</param>
        /// <param name="pi_objValue">條件值。</param>
        /// <param name="pi_objParent">母項。</param>
        private LogicOperator(int pi_nId, string pi_sCondition, object pi_objValue, LogicOperator pi_objParent)
        {
            this.m_nID = pi_nId + 1;
            this.l_objParent = pi_objParent;
            this.m_sCondition = pi_sCondition;
            this.l_objValue = pi_objValue;
        }

        /// <summary>
        /// 建構元。( 提供內部 And/Or 函式及其他建構元呼叫 )
        /// </summary>
        /// <param name="pi_nId">條件序號。</param>
        /// <param name="pi_objCondition">條件屬性。</param>
        /// <param name="pi_objParent">母項。</param>
        private LogicOperator(int pi_nId, System.Reflection.PropertyInfo pi_objCondition, LogicOperator pi_objParent)
        {
            this.m_nID = pi_nId + 1;
            this.l_objParent = pi_objParent;
            this.m_sCondition = pi_objCondition.Name;
            this.m_objCondition = pi_objCondition;
        }

        #endregion

        #region -- 方法 ( Public Method ) --   

        /// <summary>
        /// 提供以 And 串聯條件。
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <returns>次個條件。</returns>
        public LogicOperator And(PropertyInfo pi_objCondition)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.AND;
            this.l_objNextCondition = new LogicOperator(this.m_nID, pi_objCondition, this);
            return this.l_objNextCondition;
        }

        /// <summary>
        /// 提供以 And 串聯條件。
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <param name="pi_objSource"></param>
        /// <returns>次個條件。</returns>
        public LogicOperator And(PropertyInfo pi_objCondition, object pi_objSource)
        {
            return this.And(pi_objCondition.Name, pi_objCondition.GetValue(pi_objSource));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_sCondition"></param>
        /// <param name="pi_objValue"></param>
        /// <returns></returns>
        public LogicOperator And(string pi_sCondition, object pi_objValue)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.AND;
            this.l_objNextCondition = new LogicOperator(this.m_nID, pi_sCondition, pi_objValue, this);
            return this.l_objNextCondition;
        }

        /// <summary>
        /// 提供以 Or 串聯條件。
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <returns>次個條件。</returns>
        public LogicOperator Or(PropertyInfo pi_objCondition)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.OR;
            this.l_objNextCondition = new LogicOperator(this.m_nID, pi_objCondition, this);
            return this.l_objNextCondition;
        }

        /// <summary>
        /// 提供以 Or 串聯條件。
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <param name="pi_objSource"></param>
        /// <returns>次個條件。</returns>
        public LogicOperator Or(PropertyInfo pi_objCondition, object pi_objSource)
        {
            return this.Or(pi_objCondition.Name, pi_objCondition.GetValue(pi_objSource));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_sCondition"></param>
        /// <param name="pi_objValue"></param>
        /// <returns></returns>
        public LogicOperator Or(string pi_sCondition, object pi_objValue)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.OR;
            this.l_objNextCondition = new LogicOperator(this.m_nID, pi_sCondition, pi_objValue, this);
            return this.l_objNextCondition;
        }
        #endregion

        #region -- 屬性 ( Properties ) --

        /// <summary>
        /// 
        /// </summary>
        internal int BracketsID
        {
            get { return this.l_nBracketsID; }
            set
            {
                this.l_nBracketsID = value;

                if (this.l_objNextCondition != null)
                {
                    this.l_objNextCondition.SetChildBracketsID(this.l_nBracketsID);
                }

                if (this.l_objParent != null)
                {
                    this.l_objParent.SetParentBracketsID(this.l_nBracketsID);
                }
            }
        }

        #endregion            

        #region -- 介面實做 ( Implements ) - [IConditionOperator] --

        /// <summary>
        /// 取回條件字串。
        /// </summary>
        /// <returns>執行的語法字串。</returns>
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
        public string GetConditionString()
        {
            string sReturn = string.Empty;

            if (this.l_objParent == null)
            {
                string sPattern = this.BracketsID > 0 ? "[{0}] = @{0}_{1}_{2}" : "[{0}] = @{0}_{1}";

                sReturn = string.Format(sPattern, this.m_sCondition, this.m_nID, this.BracketsID);

                if (this.l_objNextCondition != null)
                {
                    sReturn = string.Format("{0} {1} {2}",
                        sReturn,
                        this.l_objConditionOperator.ToString(),
                        this.l_objNextCondition.GetConditionFromChild());
                }
            }
            else
            {
                sReturn = this.l_objParent.GetConditionString();
            }

            return sReturn;
        }

        /// <summary>
        /// 取得參數值集合。
        /// </summary>
        /// <param name="pi_objSource">
        /// <para>條件屬性來源物件。</para>
        /// <para>做為屬性條件的預設資料來源，若是個別的屬性條件未指定其資料來源時，會套用此資料來源。</para>        
        /// </param>
        /// <returns>執行語法所需的參數集合。</returns>
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
        public Dictionary<string, object> GetConditionParameter(object pi_objSource)
        {
            Dictionary<string, object> objReturn = null;

            if (this.l_objParent == null)
            {
                string sPattern = this.BracketsID > 0 ? "@{0}_{1}_{2}" : "@{0}_{1}";

                //取得後繼條件的參數集合。
                if (this.l_objNextCondition != null)
                {
                    objReturn = this.l_objNextCondition.GetConditionParameterFromChild(pi_objSource);
                }
                else
                {
                    objReturn = new Dictionary<string, object>();
                }

                //加上當前條件的參數集合。
                if (this.m_objCondition != null && pi_objSource != null)
                {
                    objReturn.Add(string.Format(sPattern, this.m_sCondition, this.m_nID, this.BracketsID), this.m_objCondition.GetValue(pi_objSource));
                }
                else
                {
                    objReturn.Add(string.Format(sPattern, this.m_sCondition, this.m_nID, this.BracketsID), this.l_objValue);
                }
            }
            else
            {
                objReturn = this.l_objParent.GetConditionParameter(pi_objSource);
            }

            return objReturn;
        }

        #endregion

        #region -- 區域函式 ( Internal Method ) --   

        internal string GetConditionFromChild()
        {
            string sReturn = string.Empty;
            string sPattern = this.BracketsID > 0 ? "[{0}] = @{0}_{1}_{2}" : "[{0}] = @{0}_{1}";

            sReturn = string.Format(sPattern, this.m_sCondition, this.m_nID, this.BracketsID);

            if (this.l_objNextCondition != null)
            {
                sReturn = string.Format("{0} {1} {2}",
                    sReturn,
                    this.l_objConditionOperator.ToString(),
                    this.l_objNextCondition.GetConditionFromChild());
            }

            return sReturn;
        }

        internal Dictionary<string, object> GetConditionParameterFromChild(object pi_objSource)
        {
            Dictionary<string, object> objReturn = null;
            string sPattern = this.BracketsID > 0 ? "@{0}_{1}_{2}" : "@{0}_{1}";

            //取得後繼條件的參數集合。
            if (this.l_objNextCondition != null)
            {
                objReturn = this.l_objNextCondition.GetConditionParameterFromChild(pi_objSource);
            }
            else
            {
                objReturn = new Dictionary<string, object>();
            }

            //加上當前條件的參數集合。
            if (this.m_objCondition != null && pi_objSource != null)
            {
                objReturn.Add(string.Format(sPattern, this.m_sCondition, this.m_nID, this.BracketsID), this.m_objCondition.GetValue(pi_objSource));
            }
            else
            {
                objReturn.Add(string.Format(sPattern, this.m_sCondition, this.m_nID, this.BracketsID), this.l_objValue);
            }

            return objReturn;
        }

        internal void SetParentBracketsID(int pi_nBracketsID)
        {
            this.l_nBracketsID = pi_nBracketsID;
            if (this.l_objParent != null) { this.l_objParent.SetParentBracketsID(pi_nBracketsID); }
        }

        internal void SetChildBracketsID(int pi_nBracketsID)
        {
            this.l_nBracketsID = pi_nBracketsID;
            if (this.l_objNextCondition != null) { this.l_objNextCondition.SetParentBracketsID(pi_nBracketsID); }
        }

        #endregion

    }
}
