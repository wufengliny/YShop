using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Yax.BLL
{
    public partial class S_Menu
    {
        public readonly static S_Menu Instance = new S_Menu();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.S_Menu model)
        {
            return SQLServerDAL.DataProvider.Instance.S_MenuAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.S_Menu model)
        {
            return SQLServerDAL.DataProvider.Instance.S_MenuUpdate(model);
        }
        public int Update_ht(Model.S_Menu model)
        {
            return SQLServerDAL.DataProvider.Instance.S_MenuUpdate_ht(model);
        }
        public int Update_enable(Model.S_Menu model)
        {
            return SQLServerDAL.DataProvider.Instance.S_MenuUpdate_enable(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("S_Menu", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.S_Menu GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByS_Menu(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.S_Menu> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListS_Menu(top, fldName, strWhere, fldSort);
        }
        public List<Model.S_Menu> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.S_Menu> list = new List<Model.S_Menu>();
            list = SQLServerDAL.DataProvider.Instance.GetPageS_Menu(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
        public  DataTable GetPage_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            DataTable dt;
            dt = SQLServerDAL.DataProvider.Instance.GetPageS_Menu_view(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return dt;
        }


    }
}
