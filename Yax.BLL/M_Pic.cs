using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class M_Pic
    {
        public readonly static M_Pic Instance = new M_Pic();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.M_Pic model)
        {
            return SQLServerDAL.DataProvider.Instance.M_PicAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.M_Pic model)
        {
            return SQLServerDAL.DataProvider.Instance.M_PicUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("M_Pic", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.M_Pic GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByM_Pic(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_Pic> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListM_Pic(top, fldName, strWhere, fldSort);
        }
        public List<Model.M_Pic> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.M_Pic> list = new List<Model.M_Pic>();
            list = SQLServerDAL.DataProvider.Instance.GetPageM_Pic(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
