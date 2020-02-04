using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Address
    {
        public readonly static Address Instance = new Address();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Address model)
        {
            return SQLServerDAL.DataProvider.Instance.AddressAdd(model);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Address model)
        {
            return SQLServerDAL.DataProvider.Instance.AddressUpdate(model);
        }
        public int UpdateEnable(Model.Address model)
        {
            return SQLServerDAL.DataProvider.Instance.AddressUpdateEnable(model);
        }
        public int Update_info(Model.Address model)
        {
            return SQLServerDAL.DataProvider.Instance.AddressUpdate_info(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Address", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Address GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByAddress(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Address> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListAddress(top, fldName, strWhere, fldSort);
        }
        public List<Model.Address> GetList_view(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListAddress_view(top, fldName, strWhere, fldSort);
        }
        public List<Model.Address> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Address> list = new List<Model.Address>();
            list = SQLServerDAL.DataProvider.Instance.GetPageAddress(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
