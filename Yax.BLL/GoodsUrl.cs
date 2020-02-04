using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class GoodsUrl
    {
        public readonly static GoodsUrl Instance = new GoodsUrl();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.GoodsUrl model)
        {
            return SQLServerDAL.DataProvider.Instance.GoodsUrlAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.GoodsUrl model)
        {
            return SQLServerDAL.DataProvider.Instance.GoodsUrlUpdate(model);
        }
        public int Update_enable(Model.GoodsUrl model)
        {
            return SQLServerDAL.DataProvider.Instance.GoodsUrlUpdate_enable(model);
        }
        public int UpdateInfo(Model.GoodsUrl model)
        {
            return SQLServerDAL.DataProvider.Instance.GoodsUrlUpdateInfo(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("GoodsUrl", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.GoodsUrl GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByGoodsUrl(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.GoodsUrl> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListGoodsUrl(top, fldName, strWhere, fldSort);
        }
        public List<Model.GoodsUrl> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.GoodsUrl> list = new List<Model.GoodsUrl>();
            list = SQLServerDAL.DataProvider.Instance.GetPageGoodsUrl(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
