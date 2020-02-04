using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class DianQuanDetail
    {
        public readonly static DianQuanDetail Instance = new DianQuanDetail();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.DianQuanDetail model)
        {
            return SQLServerDAL.DataProvider.Instance.DianQuanDetailAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.DianQuanDetail model)
        {
            return SQLServerDAL.DataProvider.Instance.DianQuanDetailUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("DianQuanDetail", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.DianQuanDetail GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByDianQuanDetail(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.DianQuanDetail> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListDianQuanDetail(top, fldName, strWhere, fldSort);
        }
        public List<Model.DianQuanDetail> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.DianQuanDetail> list = new List<Model.DianQuanDetail>();
            list = SQLServerDAL.DataProvider.Instance.GetPageDianQuanDetail(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
