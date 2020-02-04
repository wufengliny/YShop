using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class PhoneMsg
    {
        public readonly static PhoneMsg Instance = new PhoneMsg();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.PhoneMsg model)
        {
            return SQLServerDAL.DataProvider.Instance.PhoneMsgAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.PhoneMsg model)
        {
            return SQLServerDAL.DataProvider.Instance.PhoneMsgUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("PhoneMsg", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.PhoneMsg GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByPhoneMsg(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.PhoneMsg> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListPhoneMsg(top, fldName, strWhere, fldSort);
        }
        public List<Model.PhoneMsg> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.PhoneMsg> list = new List<Model.PhoneMsg>();
            list = SQLServerDAL.DataProvider.Instance.GetPagePhoneMsg(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
