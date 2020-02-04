using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class TPay_ZFBConfig
    {
        public readonly static TPay_ZFBConfig Instance = new TPay_ZFBConfig();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.TPay_ZFBConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_ZFBConfigAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.TPay_ZFBConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_ZFBConfigUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("TPay_ZFBConfig", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.TPay_ZFBConfig GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTPay_ZFBConfig(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_ZFBConfig> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTPay_ZFBConfig(top, fldName, strWhere, fldSort);
        }
        public List<Model.TPay_ZFBConfig> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.TPay_ZFBConfig> list = new List<Model.TPay_ZFBConfig>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTPay_ZFBConfig(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
