using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class M_RegUserCode
    {
        public readonly static M_RegUserCode Instance = new M_RegUserCode();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.M_RegUserCode model)
        {
            return SQLServerDAL.DataProvider.Instance.M_RegUserCodeAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.M_RegUserCode model)
        {
            return SQLServerDAL.DataProvider.Instance.M_RegUserCodeUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("M_RegUserCode", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.M_RegUserCode GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByM_RegUserCode(ID);
        }
        public Model.M_RegUserCode GetModelBy_code(string code)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByM_RegUserCodeBYCode(code);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_RegUserCode> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListM_RegUserCode(top, fldName, strWhere, fldSort);
        }
        public List<Model.M_RegUserCode> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.M_RegUserCode> list = new List<Model.M_RegUserCode>();
            list = SQLServerDAL.DataProvider.Instance.GetPageM_RegUserCode(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
