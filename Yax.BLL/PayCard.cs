using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class PayCard
    {
        public readonly static PayCard Instance = new PayCard();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.PayCard model)
        {
            return SQLServerDAL.DataProvider.Instance.PayCardAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.PayCard model)
        {
            return SQLServerDAL.DataProvider.Instance.PayCardUpdate(model);
        }
        public int UpdateEnable(Model.PayCard model)
        {
            return SQLServerDAL.DataProvider.Instance.PayCardUpdateenable(model);
        }
        public int UpdateInfo(Model.PayCard model)
        {
            return SQLServerDAL.DataProvider.Instance.PayCardUpdateInfo(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("PayCard", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.PayCard GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByPayCard(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.PayCard> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListPayCard(top, fldName, strWhere, fldSort);
        }
        public List<Model.PayCard> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.PayCard> list = new List<Model.PayCard>();
            list = SQLServerDAL.DataProvider.Instance.GetPagePayCard(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
