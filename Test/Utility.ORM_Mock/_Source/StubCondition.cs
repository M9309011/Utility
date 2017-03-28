using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM_Mock
{

    /// <summary>
    /// 提供條件操作物件功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class StubCondition : TOHU.Toolbox.Utility.ORM.IConditionOperator
    {
        #region -- 變數宣告 ( Declarations ) --   

        private string l_sConditionString = string.Empty;
      
        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_sConditionString">條件字串。</param>   
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
        public StubCondition(string pi_sConditionString)
        {
            this.l_sConditionString = pi_sConditionString;            
        }

        #endregion
        
        #region -- 介面實做 ( Implements ) - [IConditionOperator] --
        
        public Dictionary<string, object> GetConditionParameter(object pi_objSource)
        {
            return null;
        }

        public string GetConditionString()
        {
            return this.l_sConditionString;
        }

        #endregion
    }
}
