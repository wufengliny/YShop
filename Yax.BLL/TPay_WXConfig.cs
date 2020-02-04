using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class TPay_WXConfig
    {
        public readonly static TPay_WXConfig Instance = new TPay_WXConfig();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.TPay_WXConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_WXConfigAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.TPay_WXConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_WXConfigUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("TPay_WXConfig", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.TPay_WXConfig GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTPay_WXConfig(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_WXConfig> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTPay_WXConfig(top, fldName, strWhere, fldSort);
        }
        public List<Model.TPay_WXConfig> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.TPay_WXConfig> list = new List<Model.TPay_WXConfig>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTPay_WXConfig(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
