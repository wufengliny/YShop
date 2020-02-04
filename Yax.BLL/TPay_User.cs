using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class TPay_User
    {
        public readonly static TPay_User Instance = new TPay_User();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.TPay_User model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_UserAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.TPay_User model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_UserUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("TPay_User", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.TPay_User GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTPay_User(ID);
        }
        public Model.TPay_User GetModel_ByAccount(string Account)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTPay_User_Account(Account);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_User> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTPay_User(top, fldName, strWhere, fldSort);
        }
        public List<Model.TPay_User> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.TPay_User> list = new List<Model.TPay_User>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTPay_User(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
