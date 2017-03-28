using System.Collections.Generic;
using System.Reflection;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供更新參數建立功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
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
        public UpdateInfo(string pi_sFieldName, object pi_objValue) : this(0, pi_sFieldName, pi_objValue, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objField">更新屬性。</param>
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
        public UpdateInfo(PropertyInfo pi_objField) : this(0, pi_objField, null) { }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_objField">更新欄位。</param>
        /// <param name="pi_objSource">更新內容。</param>
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
        public UpdateInfo(PropertyInfo pi_objField, object pi_objSource)
        {
            string sCondition = pi_objField.Name;
            string sMappingField = new MapperFieldFinder().Find(pi_objField);

            if (sMappingField != string.Empty)
            {
                sCondition = sMappingField;
            }

            this.Initial(0, sCondition, pi_objField.GetValue(pi_objSource), null);
        }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_nID">序號。</param>
        /// <param name="pi_sFieldName">更新欄位。</param>
        /// <param name="pi_objValue">更新值。</param>
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
        internal UpdateInfo(int pi_nID, string pi_sFieldName, object pi_objValue, UpdateInfo pi_objParent)
        {          
            this.Initial(pi_nID, pi_sFieldName, pi_objValue, pi_objParent);
        }

        /// <summary>
        /// 建構元。
        /// </summary>
        /// <param name="pi_nID">序號。</param>
        /// <param name="pi_objField">更新欄位屬性物件。</param>
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
        internal UpdateInfo(int pi_nID, PropertyInfo pi_objField, UpdateInfo pi_objParent)
        {
            string sFieldName = pi_objField.Name;
            string sMappingField = new MapperFieldFinder().Find(pi_objField);

            if (sMappingField != string.Empty)
            {
                sFieldName = sMappingField;
            }

            this.l_nID = pi_nID + 1;
            this.l_sFieldName = sFieldName;
            this.l_objField = pi_objField;
            this.l_objParent = pi_objParent;
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 增加更新欄位。
        /// </summary>
        /// <param name="pi_objInfo">待更新欄位屬性物件。</param>
        /// <returns>次個更新資訊物件。</returns>
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
        public UpdateInfo Add(System.Reflection.PropertyInfo pi_objInfo)
        {
            this.l_objNextInfo = new UpdateInfo(this.l_nID, pi_objInfo, this);
            return this.l_objNextInfo;
        }

        /// <summary>
        /// 取得更新字串。
        /// </summary>
        /// <returns>更新字串。</returns>
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
        /// 取得更新參數集合。
        /// </summary>
        /// <param name="pi_objSource">提供屬性物件的預設資料來源物件。</param>
        /// <returns>更新參數集合。</returns>
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

        #region -- 私有函式 ( Private Method) --

        /// <summary>
        /// 初始資料。(提供建構元呼叫)
        /// </summary>
        /// <param name="pi_nID">序號。</param>
        /// <param name="pi_sFieldName">更新欄位。</param>
        /// <param name="pi_objValue">更新值。</param>
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
        internal void Initial(int pi_nID, string pi_sFieldName, object pi_objValue, UpdateInfo pi_objParent)
        {
            this.l_nID = pi_nID + 1;
            this.l_sFieldName = pi_sFieldName;
            this.l_objValue = pi_objValue;
            this.l_objParent = pi_objParent;
        }

        /// <summary>
        /// 從子項取得更新字串。
        /// </summary>
        /// <returns>更新字串。</returns>
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
        internal string GetFieldInfoFromChild()
        {
            string sReturn =
                string.Format("[{0}] = @{0}_U{1}", this.l_sFieldName, this.l_nID);

            if (this.l_objNextInfo != null)
            {
                sReturn = string.Format("{0} , {1}", sReturn, this.l_objNextInfo.GetFieldInfoFromChild());
            }

            return sReturn;
        }

        /// <summary>
        /// 從子項取更新參數集合。
        /// </summary>
        /// <param name="pi_objSource">提供屬性物件的預設資料來源物件。</param>
        /// <returns>更新參數集合。</returns>
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
        internal Dictionary<string, object> GetParameterFromChild(object pi_objSource)
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();

            if (this.l_objNextInfo != null)
            {
                objReturn = this.l_objNextInfo.GetParameterFromChild(pi_objSource);
            }

            if (this.l_objField != null && pi_objSource != null)
            {
                objReturn.Add(string.Format("@{0}_U{1}", this.l_sFieldName, this.l_nID), this.l_objField.GetValue(pi_objSource));
            }
            else
            {
                objReturn.Add(string.Format("@{0}_U{1}", this.l_sFieldName, this.l_nID), this.l_objValue);
            }
            return objReturn;
        }

        #endregion        
    }
}
