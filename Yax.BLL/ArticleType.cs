using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class ArticleType
    {
        public readonly static ArticleType Instance = new ArticleType();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.ArticleType model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleTypeAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.ArticleType model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleTypeUpdate(model);
        }
        public int Update_enable(Model.ArticleType model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleTypeUpdateEnable(model);
        }
        public int UpdateName(Model.ArticleType model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleTypeUpdateName(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("ArticleType", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.ArticleType GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByArticleType(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ArticleType> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListArticleType(top, fldName, strWhere, fldSort);
        }
        public List<Model.ArticleType> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.ArticleType> list = new List<Model.ArticleType>();
            list = SQLServerDAL.DataProvider.Instance.GetPageArticleType(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
