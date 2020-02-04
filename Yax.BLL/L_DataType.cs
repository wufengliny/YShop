using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class L_DataType
    {
        public readonly static L_DataType Instance = new L_DataType();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.L_DataType model)
        {
            return SQLServerDAL.DataProvider.Instance.L_DataTypeAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.L_DataType model)
        {
            return SQLServerDAL.DataProvider.Instance.L_DataTypeUpdate(model);
        }
        public int UpdateName(Model.L_DataType model)
        {
            return SQLServerDAL.DataProvider.Instance.L_DataTypeUpdateName(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("L_DataType", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.L_DataType GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByL_DataType(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.L_DataType> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListL_DataType(top, fldName, strWhere, fldSort);
        }
        public List<Model.L_DataType> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.L_DataType> list = new List<Model.L_DataType>();
            list = SQLServerDAL.DataProvider.Instance.GetPageL_DataType(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
