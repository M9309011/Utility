using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ORM_UT
{
    internal class StubCondition : TOHU.Toolbox.Utility.ORM.IConditionOperator
    {
        private string l_sConditionString = string.Empty;
        private Dictionary<string, object> l_objParameters = null;

        public StubCondition(string pi_sConditionString, Dictionary<string, object> pi_objParameters)
        {
            this.l_sConditionString = pi_sConditionString;
            this.l_objParameters = pi_objParameters;
        }

        public Dictionary<string, object> GetConditionParameter(object pi_objSource)
        {
            return this.l_objParameters;
        }

        public string GetConditionString()
        {
            return this.l_sConditionString;
        }
    }
}
