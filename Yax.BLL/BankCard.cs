using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class BankCard
    {
        public readonly static BankCard Instance = new BankCard();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.BankCard model)
        {
            return SQLServerDAL.DataProvider.Instance.BankCardAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.BankCard model)
        {
            return SQLServerDAL.DataProvider.Instance.BankCardUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("BankCard", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.BankCard GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByBankCard(ID);
        }
        public Model.BankCard GetModelBy_BankNO(string BankNo)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByBankCardBy_BankNo(BankNo);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.BankCard> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListBankCard(top, fldName, strWhere, fldSort);
        }
        public List<Model.BankCard> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.BankCard> list = new List<Model.BankCard>();
            list = SQLServerDAL.DataProvider.Instance.GetPageBankCard(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
