using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class M_ManHua
    {
        public readonly static M_ManHua Instance = new M_ManHua();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.M_ManHua model)
        {
            return SQLServerDAL.DataProvider.Instance.M_ManHuaAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.M_ManHua model)
        {
            return SQLServerDAL.DataProvider.Instance.M_ManHuaUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("M_ManHua", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.M_ManHua GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByM_ManHua(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_ManHua> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListM_ManHua(top, fldName, strWhere, fldSort);
        }
        public List<Model.M_ManHua> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.M_ManHua> list = new List<Model.M_ManHua>();
            list = SQLServerDAL.DataProvider.Instance.GetPageM_ManHua(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
