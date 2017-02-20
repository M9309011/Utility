using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{

    /// <summary>
    /// 提供 RelationObjectCenter 必要資訊。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    public class RelationObjectParameters
    {

        #region -- 變數宣告 ( Declarations ) --   

        private string l_sTableName = string.Empty;
        private RelationObjectParameters l_objParent = null;
        private RelationObjectParameters l_objNextParameter = null;

        private IConditionOperator l_objCondition = null;
        private UpdateInfo l_objUpdate = null;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --    

        /// <summary>
        /// 
        /// </summary>
        public RelationObjectParameters(string pi_sTableName) { this.l_sTableName = pi_sTableName; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <param name="pi_objParent"></param>
        private RelationObjectParameters(IConditionOperator pi_objCondition, RelationObjectParameters pi_objParent)
        {
            this.l_objParent = pi_objParent;
            this.l_objCondition = pi_objCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objUpdate"></param>
        /// <param name="pi_objParent"></param>
        private RelationObjectParameters(UpdateInfo pi_objUpdate, RelationObjectParameters pi_objParent)
        {
            this.l_objParent = pi_objParent;
            this.l_objUpdate = pi_objUpdate;
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objCondition"></param>
        /// <returns></returns>
        public RelationObjectParameters SetCondition(IConditionOperator pi_objCondition)
        {
            RelationObjectParameters objReturn = new RelationObjectParameters(pi_objCondition, this);
            this.l_objNextParameter = objReturn;

            return this.l_objNextParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi_objUpdateInfo"></param>
        /// <returns></returns>
        public RelationObjectParameters SetUpdateInfo(UpdateInfo pi_objUpdateInfo)
        {
            RelationObjectParameters objReturn = new RelationObjectParameters(pi_objUpdateInfo, this);
            this.l_objNextParameter = objReturn;

            return objReturn;
        }

        internal IConditionOperator FindConditionFromParent()
        {
            IConditionOperator objReturn = null;

            if (this.l_objCondition != null)
            {
                objReturn = this.l_objCondition;
            }
            else if (this.l_objParent != null)
            {
                objReturn = this.l_objParent.FindConditionFromParent();
            }

            return objReturn;
        }

        internal UpdateInfo FindUpdateInfoFromParent()
        {
            UpdateInfo objReturn = null;

            if (this.l_objUpdate != null)
            {
                objReturn = this.l_objUpdate;
            }
            else if (this.l_objParent != null)
            {
                objReturn = this.l_objParent.FindUpdateInfoFromParent();
            }

            return objReturn;
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        /// <summary>
        /// 
        /// </summary>
        public string TableName
        {
            get
            {
                string sReturn = this.l_sTableName;

                if (this.l_objParent != null)
                {
                    sReturn = this.l_objParent.TableName;
                }
               
                return sReturn;
            }
        }

        /// <summary>
        /// 取得條件資訊。
        /// </summary>
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
        public IConditionOperator Condition
        {
            get
            {
                IConditionOperator objReturn = null;

                if (this.l_objNextParameter != null)
                {
                    objReturn = this.l_objNextParameter.Condition;
                }
                else
                {
                    objReturn = this.FindConditionFromParent();
                }

                return objReturn;
            }
        }

        /// <summary>
        /// 取得更新資訊。
        /// </summary>
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
        public UpdateInfo UpdateInfo
        {
            get
            {
                UpdateInfo objReturn = null;

                if (this.l_objNextParameter != null)
                {
                    objReturn = this.l_objNextParameter.UpdateInfo;
                }
                else
                {
                    objReturn = this.FindUpdateInfoFromParent();
                }
                return objReturn;
            }
        }

        #endregion

    }
}
