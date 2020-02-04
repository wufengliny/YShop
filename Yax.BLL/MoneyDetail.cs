using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class MoneyDetail
    {
        public readonly static MoneyDetail Instance = new MoneyDetail();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.MoneyDetail model)
        {
            return SQLServerDAL.DataProvider.Instance.MoneyDetailAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.MoneyDetail model)
        {
            return SQLServerDAL.DataProvider.Instance.MoneyDetailUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("MoneyDetail", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.MoneyDetail GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByMoneyDetail(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.MoneyDetail> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListMoneyDetail(top, fldName, strWhere, fldSort);
        }
        public List<Model.MoneyDetail> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.MoneyDetail> list = new List<Model.MoneyDetail>();
            list = SQLServerDAL.DataProvider.Instance.GetPageMoneyDetail(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
