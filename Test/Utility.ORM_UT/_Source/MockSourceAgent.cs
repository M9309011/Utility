using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOHU.Toolbox.Utility.ORM;

namespace Utility.ORM_UT
{
    /// <summary>
    /// 
    /// </summary>
    internal class MockSourceAgent : TOHU.Toolbox.Utility.ORM.ISourceAgent
    {

        #region -- 變數宣告 ( Declarations ) --   

        private DataTable l_objTable = null;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public MockSourceAgent(DataTable pi_objTable)
        {
            this.l_objTable = pi_objTable;
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        internal string SQL { get; set; }

        internal List<Dictionary<string, object>> MaintailParameters { get; set; }

        internal Dictionary<string, object> QueryParameters { get; set; }
        #endregion

        #region -- 介面實做 ( Implements ) - [ISourceAgent] --

        public void Execute(string pi_sSQL)
        {
            this.SQL = pi_sSQL;
        }

        public void Execute(string pi_sSQL, List<Dictionary<string, object>> pi_objParameters)
        {
            this.SQL = pi_sSQL;
            this.MaintailParameters = pi_objParameters;
        }

        public DataTable Query(string pi_sSQL)
        {
            return this.Query(pi_sSQL, null);
        }

        public DataTable Query(string pi_sSQL, Dictionary<string, object> pi_objParameters)
        {
            this.SQL = pi_sSQL;
            this.QueryParameters = pi_objParameters;
            return this.l_objTable;
        }

        #endregion

    }
}
