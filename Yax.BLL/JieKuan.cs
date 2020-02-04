using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class JieKuan
    {
        public readonly static JieKuan Instance = new JieKuan();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.JieKuan model)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.JieKuan model)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanUpdate(model);
        }
        public int Update_money(Model.JieKuan model)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanUpdate_Money(model);
        }
        public int UpdateEnable(int enable,int id)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanUpdate_enable(enable, id);
        }
        public int Update_state(int state,int id,string memo)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanUpdate_state(state,id, memo);
        }
        public int Update_state_pwd_memo(int state, int id, string memo,string pwd)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanUpdate_state_pwd_memo(state, id, memo,pwd);
        }
        public int Update_pwd(string TiKuanPWD, int id)
        {
            return SQLServerDAL.DataProvider.Instance.JieKuanUpdate_pwd(TiKuanPWD, id);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("JieKuan", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.JieKuan GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByJieKuan(ID);
        }

        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.JieKuan> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListJieKuan(top, fldName, strWhere, fldSort);
        }
        public List<Model.JieKuan> GetList_shenHeing(int uid)
        {
            string strWhere = " UserID=" + uid + " and State not in(1,3,11)  and Enable=1";
            return SQLServerDAL.DataProvider.Instance.GetListJieKuan(1, "*", strWhere, "ID desc");
        }
        public List<Model.JieKuan> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.JieKuan> list = new List<Model.JieKuan>();
            list = SQLServerDAL.DataProvider.Instance.GetPageJieKuan(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
