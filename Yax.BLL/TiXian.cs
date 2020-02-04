using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class TiXian
    {
        public readonly static TiXian Instance = new TiXian();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.TiXian model)
        {
            return SQLServerDAL.DataProvider.Instance.TiXianAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.TiXian model)
        {
            return SQLServerDAL.DataProvider.Instance.TiXianUpdate(model);
        }
        public int UpdateEnable(Model.TiXian model)
        {
            return SQLServerDAL.DataProvider.Instance.TiXianUpdate_Enable(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("TiXian", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.TiXian GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByTiXian(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TiXian> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListTiXian(top, fldName, strWhere, fldSort);
        }
        public List<Model.TiXian> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.TiXian> list = new List<Model.TiXian>();
            list = SQLServerDAL.DataProvider.Instance.GetPageTiXian(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
