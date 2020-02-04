using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class M_Chapter
    {
        public readonly static M_Chapter Instance = new M_Chapter();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.M_Chapter model)
        {
            return SQLServerDAL.DataProvider.Instance.M_ChapterAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.M_Chapter model)
        {
            return SQLServerDAL.DataProvider.Instance.M_ChapterUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("M_Chapter", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.M_Chapter GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByM_Chapter(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_Chapter> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListM_Chapter(top, fldName, strWhere, fldSort);
        }
        public List<Model.M_Chapter> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.M_Chapter> list = new List<Model.M_Chapter>();
            list = SQLServerDAL.DataProvider.Instance.GetPageM_Chapter(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
