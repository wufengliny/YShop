using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Yax.BLL
{
    public partial class L_Data
    {
        public readonly static L_Data Instance = new L_Data();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.L_Data model)
        {
            return SQLServerDAL.DataProvider.Instance.L_DataAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.L_Data model)
        {
            return SQLServerDAL.DataProvider.Instance.L_DataUpdate(model);
        }
        public int Update_info(Model.L_Data model)
        {
            return SQLServerDAL.DataProvider.Instance.L_DataUpdate_info(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("L_Data", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.L_Data GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByL_Data(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.L_Data> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListL_Data(top, fldName, strWhere, fldSort);
        }
        public List<Model.L_Data> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.L_Data> list = new List<Model.L_Data>();
            list = SQLServerDAL.DataProvider.Instance.GetPageL_Data(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
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
            dt = SQLServerDAL.DataProvider.Instance.GetPage_L_Data_view(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return dt;
        }
    }
}
