using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ORM_UT
{
    /// <summary>
    /// 
    /// </summary>
    internal class StubUpdateInfo : TOHU.Toolbox.Utility.ORM.UpdateInfo
    {

        private string l_sUpdateSetting = string.Empty;

        public StubUpdateInfo(string pi_sString) : base(null)
        {
            this.l_sUpdateSetting = pi_sString;
        }

        public StubUpdateInfo(PropertyInfo pi_objField) : base(pi_objField) { }

        public override string GetString()
        {
            return this.l_sUpdateSetting;
        }

    }
}
