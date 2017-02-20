using System.Collections.Generic;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 定義條件運算元操作功能。
    /// </summary>
    public interface IConditionOperator
    {
        /// <summary>
        /// 取回條件字串。
        /// </summary>        
        string GetConditionString();

        /// <summary>
        /// 取得參數值集合。
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
        Dictionary<string, object> GetConditionParameter(object pi_objSource);
     
    }
}
