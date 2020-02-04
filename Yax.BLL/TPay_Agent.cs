using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class TPay_Agent
    {
        public readonly static TPay_Agent Instance = new TPay_Agent();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.TPay_Agent model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_AgentAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.TPay_Agent model)
        {
            return SQLServerDAL.DataProvider.Instance.TPay_AgentUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("TPay_Agent", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.TPay_Agent GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTPay_Agent(ID);
        }
       
        public Model.TPay_Agent GetModelByAccount(string Account)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTPay_Agent_Account(Account);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_Agent> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTPay_Agent(top, fldName, strWhere, fldSort);
        }
        public List<Model.TPay_Agent> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.TPay_Agent> list = new List<Model.TPay_Agent>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTPay_Agent(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
