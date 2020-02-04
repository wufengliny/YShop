using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class QiYe_Product
    {
        public readonly static QiYe_Product Instance = new QiYe_Product();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.QiYe_Product model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_ProductAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.QiYe_Product model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_ProductUpdate(model);
        }
        public int Update_hits(Model.QiYe_Product model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_ProductUpdate_hits(model);
        }
        public int Update_info(Model.QiYe_Product model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_ProductUpdate_info(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("QiYe_Product", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.QiYe_Product GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByQiYe_Product(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.QiYe_Product> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListQiYe_Product(top, fldName, strWhere, fldSort);
        }
        public List<Model.QiYe_Product> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.QiYe_Product> list = new List<Model.QiYe_Product>();
            list = SQLServerDAL.DataProvider.Instance.GetPageQiYe_Product(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
