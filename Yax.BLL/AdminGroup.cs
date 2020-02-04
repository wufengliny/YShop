using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class AdminGroup
    {
        public readonly static AdminGroup Instance = new AdminGroup();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.AdminGroup model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminGroupAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.AdminGroup model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminGroupUpdate(model);
        }
        public int Update_name(Model.AdminGroup model)
        {
            return SQLServerDAL.DataProvider.Instance.AdminGroupUpdate_Name(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("AdminGroup", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.AdminGroup GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByAdminGroup(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.AdminGroup> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListAdminGroup(top, fldName, strWhere, fldSort);
        }
        public List<Model.AdminGroup> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.AdminGroup> list = new List<Model.AdminGroup>();
            list = SQLServerDAL.DataProvider.Instance.GetPageAdminGroup(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
