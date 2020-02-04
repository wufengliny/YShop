using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Yax.BLL
{
    public partial class Admin
    {
        public readonly static Admin Instance = new Admin();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Admin model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Admin model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminUpdate(model);
        }
        public int Update_Pwd(Model.Admin model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminUpdatePWD(model);
        }
        public int Update_SecondPwd(Model.Admin model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminUpdateSecondPWD(model);
        }
        public int Update_info(Model.Admin model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminUpdate_info(model);
        }
        public int UpdateErr(Model.Admin model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminUpdateErr(model);
        }
        public int UpdateEnable(int id,int effect)
        {
            return SQLServerDAL.DataProvider.Instance.AdminUpdateEnable(id, effect);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Admin", strWhere);
        }
  

        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Admin GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByAdmin(ID);
        }
        public Model.Admin GetModelByName(string name)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByAdminName(name);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Admin> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListAdmin(top, fldName, strWhere, fldSort);
        }
       
        public List<Model.Admin> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Admin> list = new List<Model.Admin>();
            list = SQLServerDAL.DataProvider.Instance.GetPageAdmin(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }

        public DataTable GetPage_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            DataTable dt;
            dt = SQLServerDAL.DataProvider.Instance.GetPageAdmin_view(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return dt;
        }
       
    }
}
