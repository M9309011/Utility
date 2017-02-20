using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供更新參數建立功能。
    /// </summary>
    public class UpdateInfo
    {
        #region -- 變數宣告 ( Declarations ) --   

        private int l_nID = 0;
        private UpdateInfo l_objParent = null;
        private UpdateInfo l_objNextInfo = null;
        private System.Reflection.PropertyInfo l_objField = null;
        private string l_sFieldName = string.Empty;
        private object l_objValue = null;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_sFieldName"></param>
        /// <param name="pi_objValue"></param>
        public UpdateInfo(string pi_sFieldName, object pi_objValue) : this(0, pi_sFieldName, pi_objValue, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objField">更新屬性。</param>
        public UpdateInfo(System.Reflection.PropertyInfo pi_objField) : this(0, pi_objField, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objField"></param>
        /// <param name="pi_objSource"></param>
        public UpdateInfo(System.Reflection.PropertyInfo pi_objField, object pi_objSource) : this(0, pi_objField.Name, pi_objField.GetValue(pi_objSource), null) { }
        
        internal UpdateInfo(int pi_nID, string pi_sFieldName, object pi_objValue, UpdateInfo pi_objParent)
        {
            this.l_nID = pi_nID + 1;
            this.l_sFieldName = pi_sFieldName;
            this.l_objValue = pi_objValue;
            this.l_objParent = pi_objParent;
        }

        internal UpdateInfo(int pi_nID, System.Reflection.PropertyInfo pi_objField, UpdateInfo pi_objParent)
        {
            this.l_nID = pi_nID + 1;
            this.l_sFieldName = pi_objField.Name;
            this.l_objField = pi_objField;
            this.l_objParent = pi_objParent;
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objInfo"></param>
        /// <returns></returns>
        public UpdateInfo Add(System.Reflection.PropertyInfo pi_objInfo)
        {
            this.l_objNextInfo = new UpdateInfo(this.l_nID, pi_objInfo, this);
            return this.l_objNextInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string GetFieldInfoFromChild()
        {
            string sReturn = string.Empty;

            sReturn = string.Format("[{0}] = @{0}_{1}", this.l_sFieldName, this.l_nID);

            if (this.l_objNextInfo != null)
            {
                sReturn = string.Format("{0} , {1}",
                    sReturn,
                    this.l_objNextInfo.GetFieldInfoFromChild());
            }

            return sReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
        internal Dictionary<string, object> GetParameterFromChild(object pi_objSource)
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();

            if (this.l_objNextInfo != null)
            {
                objReturn = this.l_objNextInfo.GetParameterFromChild(pi_objSource);
            }

            if (this.l_objField != null && pi_objSource != null)
            {
                objReturn.Add(string.Format("@{0}_{1}", this.l_sFieldName, this.l_nID), this.l_objField.GetValue(pi_objSource));
            }
            else
            {
                objReturn.Add(string.Format("@{0}_{1}", this.l_sFieldName, this.l_nID), this.l_objValue);
            }
            return objReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetString()
        {
            string sReturn = string.Empty;

            if (this.l_objParent != null)
            {
                sReturn = this.l_objParent.GetString();
            }
            else
            {
                sReturn = this.GetFieldInfoFromChild();
            }

            return sReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objSource"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetParameter(object pi_objSource)
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();

            if (this.l_objParent != null)
            {
                objReturn = this.l_objParent.GetParameter(pi_objSource);
            }
            else
            {
                objReturn = this.GetParameterFromChild(pi_objSource);
            }
            return objReturn;
        }

        #endregion

    }
}
