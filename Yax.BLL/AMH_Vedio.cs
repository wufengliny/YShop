using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class AMH_Vedio
    {
        public readonly static AMH_Vedio Instance = new AMH_Vedio();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.AMH_Vedio model)
        {
            return SQLServerDAL.DataProvider.Instance.AMH_VedioAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.AMH_Vedio model)
        {
            return SQLServerDAL.DataProvider.Instance.AMH_VedioUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("AMH_Vedio", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.AMH_Vedio GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByAMH_Vedio(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.AMH_Vedio> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListAMH_Vedio(top, fldName, strWhere, fldSort);
        }
        public List<Model.AMH_Vedio> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.AMH_Vedio> list = new List<Model.AMH_Vedio>();
            list = SQLServerDAL.DataProvider.Instance.GetPageAMH_Vedio(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
