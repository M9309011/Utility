using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供括號功能。
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
        /// <param name="pi_objOperator"></param>
        public BracketsOperator(LogicOperator pi_objOperator) : this(0, pi_objOperator, null, null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objOperator"></param>
        /// <param name="pi_objSource"></param>
        public BracketsOperator(LogicOperator pi_objOperator, object pi_objSource) : this(0, pi_objOperator, pi_objSource, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_nID"></param>
        /// <param name="pi_objOperator"></param>
        /// <param name="pi_objSource"></param>
        /// <param name="pi_objParent"></param>
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
        /// 
        /// </summary>       
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <returns></returns>
        public BracketsOperator And(LogicOperator pi_objCondition)
        {
            return this.And(pi_objCondition, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
        public BracketsOperator And(LogicOperator pi_objCondition, object pi_objSource)
        {
            this.l_objConditionOperator = ConditionOperatorEnum.AND;
            this.l_objNextBrackets = new BracketsOperator(this.m_nID, pi_objCondition, pi_objSource, this);
            return this.l_objNextBrackets;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <returns></returns>
        public BracketsOperator Or(LogicOperator pi_objCondition) { return this.Or(pi_objCondition, null); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
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

            if(this.l_objParent == null)
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

    }
}
