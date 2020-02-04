using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class CompanyBankCard
    {
        public readonly static CompanyBankCard Instance = new CompanyBankCard();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.CompanyBankCard model)
        {
            return SQLServerDAL.DataProvider.Instance.CompanyBankCardAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.CompanyBankCard model)
        {
            return SQLServerDAL.DataProvider.Instance.CompanyBankCardUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("CompanyBankCard", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.CompanyBankCard GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByCompanyBankCard(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.CompanyBankCard> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListCompanyBankCard(top, fldName, strWhere, fldSort);
        }
        public List<Model.CompanyBankCard> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.CompanyBankCard> list = new List<Model.CompanyBankCard>();
            list = SQLServerDAL.DataProvider.Instance.GetPageCompanyBankCard(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
