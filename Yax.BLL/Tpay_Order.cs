using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Tpay_Order
    {
        public readonly static Tpay_Order Instance = new Tpay_Order();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Tpay_Order model)
        {
            return SQLServerDAL.DataProvider.Instance.Tpay_OrderAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Tpay_Order model)
        {
            return SQLServerDAL.DataProvider.Instance.Tpay_OrderUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Tpay_Order", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Tpay_Order GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTpay_Order(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Tpay_Order> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTpay_Order(top, fldName, strWhere, fldSort);
        }
        public List<Model.Tpay_Order> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Tpay_Order> list = new List<Model.Tpay_Order>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTpay_Order(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
