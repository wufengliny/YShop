using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class ShopGood
    {
        public readonly static ShopGood Instance = new ShopGood();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.ShopGood model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopGoodAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.ShopGood model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopGoodUpdate(model);
        }
        public int UpdateHits(int id)
        {
            return SQLServerDAL.DataProvider.Instance.ShopGoodUpdateHits(id);
        }
        public int Update_enable(Model.ShopGood model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopGoodUpdateEnable(model);
        }
        public int UpdateInfo(Model.ShopGood model)
        {
            return SQLServerDAL.DataProvider.Instance.ShopGoodUpdateInfo(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("ShopGood", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.ShopGood GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByShopGood(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ShopGood> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListShopGood(top, fldName, strWhere, fldSort);
        }
        public List<Model.ShopGood> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.ShopGood> list = new List<Model.ShopGood>();
            list = SQLServerDAL.DataProvider.Instance.GetPageShopGood(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
        public List<Model.ShopGood> GetPage_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.ShopGood> list = new List<Model.ShopGood>();
            list = SQLServerDAL.DataProvider.Instance.GetPageShopGood_view(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }


    }
}
