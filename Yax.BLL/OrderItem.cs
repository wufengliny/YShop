using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Yax.BLL
{
    public partial class OrderItem
    {
        public readonly static OrderItem Instance = new OrderItem();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.OrderItem model)
        {
            return SQLServerDAL.DataProvider.Instance.OrderItemAdd(model);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.OrderItem model)
        {
            return SQLServerDAL.DataProvider.Instance.OrderItemUpdate(model);
        }
        public int UpdateIsComment(int id)
        {
            return SQLServerDAL.DataProvider.Instance.OrderItemUpdate_IsComment(id);
        }
        public int Update_num(Model.OrderItem model)
        {
            return SQLServerDAL.DataProvider.Instance.OrderItemUpdate_Num(model);
        }
        public int Update_orderno(int uid,string orderno)
        {
            return SQLServerDAL.DataProvider.Instance.OrderItemUpdate_orderno(uid,orderno);
        }

        public int Update_enableMember(Model.OrderItem model)
        {
            return SQLServerDAL.DataProvider.Instance.OrderItemUpdate_enableMember(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("OrderItem", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.OrderItem GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByOrderItem(ID);
        }
      
        /// <summary>
        /// 读取数据,多条件
        /// </summary>

        public List<Model.OrderItem> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.OrderItem> list = new List<Model.OrderItem>();
            list = SQLServerDAL.DataProvider.Instance.GetPageOrderItem(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
