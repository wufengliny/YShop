using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class QiYe_LiuYan
    {
        public readonly static QiYe_LiuYan Instance = new QiYe_LiuYan();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.QiYe_LiuYan model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_LiuYanAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.QiYe_LiuYan model)
        {
            return SQLServerDAL.DataProvider.Instance.QiYe_LiuYanUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("QiYe_LiuYan", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.QiYe_LiuYan GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByQiYe_LiuYan(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.QiYe_LiuYan> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListQiYe_LiuYan(top, fldName, strWhere, fldSort);
        }
        public List<Model.QiYe_LiuYan> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.QiYe_LiuYan> list = new List<Model.QiYe_LiuYan>();
            list = SQLServerDAL.DataProvider.Instance.GetPageQiYe_LiuYan(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
