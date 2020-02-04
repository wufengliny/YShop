using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class JiFenDetail
    {
        public readonly static JiFenDetail Instance = new JiFenDetail();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.JiFenDetail model)
        {
            return SQLServerDAL.DataProvider.Instance.JiFenDetailAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.JiFenDetail model)
        {
            return SQLServerDAL.DataProvider.Instance.JiFenDetailUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("JiFenDetail", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.JiFenDetail GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByJiFenDetail(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.JiFenDetail> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListJiFenDetail(top, fldName, strWhere, fldSort);
        }
        public List<Model.JiFenDetail> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.JiFenDetail> list = new List<Model.JiFenDetail>();
            list = SQLServerDAL.DataProvider.Instance.GetPageJiFenDetail(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
