using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TOHU.Toolbox.Utility.ORM
{
    /// <summary>
    /// 提供資料表對應關連物件功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>Author:</term><description>黃竣祥</description></item>
    /// <item><term>Version:</term><description>[version]</description></item>
    /// </list>
    /// </remarks>
    internal class TableMapper : IObjectMapper<System.Data.DataTable>
    {
        #region -- 介面實做 ( Implements ) - [IObjectMapper] --

        /// <summary>
        /// 載入資料表記錄後輸出資料物件清單。
        /// </summary>
        /// <typeparam name="TDataInfo">關連資料物件型別。</typeparam>
        /// <param name="pi_objSource">資料來源。</param>
        /// <returns>載入資料後的關連資料物件清單。</returns>
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
        public List<TDataInfo> Loading<TDataInfo>(DataTable pi_objSource) where TDataInfo : new()
        {
            List<TDataInfo> objReturn = new List<TDataInfo>();
            MapperFieldFinder objFinder = new MapperFieldFinder();

            foreach (DataRow objRow in pi_objSource.Rows)
            {
                TDataInfo objDataInfo = new TDataInfo();

                foreach (PropertyInfo objProperty in typeof(TDataInfo).GetProperties())
                {
                    if (objProperty.CanWrite)
                    {
                        string sFieldName = objProperty.Name;

                        if (pi_objSource.Columns[sFieldName] == null)
                        {
                            //以屬性名稱在來源資料表找不到對應的欄位。
                            sFieldName = objFinder.Find(objProperty);
                            if (string.IsNullOrEmpty(sFieldName) || pi_objSource.Columns[sFieldName] == null)
                            {
                                //未取得欄位名稱或欄位名稱不在來源資料表，即跳出此項屬性值設定，繼續次個屬性值設定。
                                continue;
                            }
                        }
                        //欄位內容不是 DBNull 且與屬性型態相同時才設定。
                        if (objRow[sFieldName] != System.DBNull.Value && pi_objSource.Columns[sFieldName].DataType == objProperty.PropertyType)
                        {
                            objProperty.SetValue(objDataInfo, objRow[sFieldName]);
                        }
                    }
                }
                objReturn.Add(objDataInfo);
            }
            return objReturn;
        }

        #endregion       
    }
}
