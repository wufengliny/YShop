using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Chw_Boat
    {
        public readonly static Chw_Boat Instance = new Chw_Boat();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Chw_Boat model)
        {
            return SQLServerDAL.DataProvider.Instance.Chw_BoatAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Chw_Boat model)
        {
            return SQLServerDAL.DataProvider.Instance.Chw_BoatUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Chw_Boat", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Chw_Boat GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByChw_Boat(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Chw_Boat> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListChw_Boat(top, fldName, strWhere, fldSort);
        }
        public List<Model.Chw_Boat> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Chw_Boat> list = new List<Model.Chw_Boat>();
            list = SQLServerDAL.DataProvider.Instance.GetPageChw_Boat(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
