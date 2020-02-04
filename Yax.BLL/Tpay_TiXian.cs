using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Tpay_TiXian
    {
        public readonly static Tpay_TiXian Instance = new Tpay_TiXian();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Tpay_TiXian model)
        {
            return SQLServerDAL.DataProvider.Instance.Tpay_TiXianAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Tpay_TiXian model)
        {
            return SQLServerDAL.DataProvider.Instance.Tpay_TiXianUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Tpay_TiXian", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Tpay_TiXian GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTpay_TiXian(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Tpay_TiXian> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTpay_TiXian(top, fldName, strWhere, fldSort);
        }
        public List<Model.Tpay_TiXian> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Tpay_TiXian> list = new List<Model.Tpay_TiXian>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTpay_TiXian(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
