using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class QiYe_ProductType
    {
        public readonly static QiYe_ProductType Instance = new QiYe_ProductType();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.QiYe_ProductType model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_ProductTypeAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.QiYe_ProductType model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_ProductTypeUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("QiYe_ProductType", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.QiYe_ProductType GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByQiYe_ProductType(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.QiYe_ProductType> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListQiYe_ProductType(top, fldName, strWhere, fldSort);
        }
        public List<Model.QiYe_ProductType> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.QiYe_ProductType> list = new List<Model.QiYe_ProductType>();
            list = SQLServerDAL.DataProvider.Instance.GetPageQiYe_ProductType(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
