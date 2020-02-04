using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class UserLoginIP
    {
        public readonly static UserLoginIP Instance = new UserLoginIP();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.UserLoginIP model)
        {
            return SQLServerDAL.DataProvider.Instance.UserLoginIPAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.UserLoginIP model)
        {
            return SQLServerDAL.DataProvider.Instance.UserLoginIPUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("UserLoginIP", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.UserLoginIP GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByUserLoginIP(ID);
        }
        public Model.UserLoginIP GetModelByIP(string IP,int uid)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByUserLoginIPBYIP(IP,uid);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.UserLoginIP> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListUserLoginIP(top, fldName, strWhere, fldSort);
        }
        public List<Model.UserLoginIP> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.UserLoginIP> list = new List<Model.UserLoginIP>();
            list = SQLServerDAL.DataProvider.Instance.GetPageUserLoginIP(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
