using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Chw_Order
    {
        public readonly static Chw_Order Instance = new Chw_Order();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Chw_Order model)
        {
            return SQLServerDAL.DataProvider.Instance.Chw_OrderAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Chw_Order model)
        {
            return SQLServerDAL.DataProvider.Instance.Chw_OrderUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Chw_Order", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Chw_Order GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByChw_Order(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Chw_Order> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListChw_Order(top, fldName, strWhere, fldSort);
        }
        public List<Model.Chw_Order> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Chw_Order> list = new List<Model.Chw_Order>();
            list = SQLServerDAL.DataProvider.Instance.GetPageChw_Order(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
