using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class ShopOrder
    {
        public readonly static ShopOrder Instance = new ShopOrder();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.ShopOrder model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopOrderAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.ShopOrder model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopOrderUpdate(model);
        }
        public int Update_enable(Model.ShopOrder model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopOrderUpdate_enable(model);
        }
        public int Update_wuliu(Model.ShopOrder model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopOrderUpdate_wuliu(model);
        }
        public int Update_statu(Model.ShopOrder model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopOrderUpdate_statu(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("ShopOrder", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.ShopOrder GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByShopOrder(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ShopOrder> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListShopOrder(top, fldName, strWhere, fldSort);
        }
        public List<Model.ShopOrder> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.ShopOrder> list = new List<Model.ShopOrder>();
            list = SQLServerDAL.DataProvider.Instance.GetPageShopOrder(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
        public List<Model.ShopOrder> GetPage_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.ShopOrder> list = new List<Model.ShopOrder>();
            list = SQLServerDAL.DataProvider.Instance.GetPageOrder_view(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }





    }
}
