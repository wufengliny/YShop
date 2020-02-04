using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Yax.BLL
{
    public partial class Article
    {
        public readonly static Article Instance = new Article();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdate(model);
        }
        public int Update_enable(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdate_enable(model);
        }
        public int Update_Index(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdate_Index(model);
        }
        public int Update_hot(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdate_hot(model);
        }
        public int Update_Hits(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdate_Hits(model);
        }
        public int Update_Recommend(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdate_Recommend(model);
        }
        public int UpdateInfo(Model.Article model)
        {
            return SQLServerDAL.DataProvider.Instance.ArticleUpdateInfo(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Article", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Article GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByArticle(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Article> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListArticle(top, fldName, strWhere, fldSort);
        }
        public List<Model.Article> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Article> list = new List<Model.Article>();
            list = SQLServerDAL.DataProvider.Instance.GetPageArticle(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
        public DataTable GetPage_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            DataTable dt;
            dt = SQLServerDAL.DataProvider.Instance.GetPageArticle_view(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return dt;
        }


    }
}
