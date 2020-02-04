using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Comment
    {
        public readonly static Comment Instance = new Comment();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Comment model)
        {
            return SQLServerDAL.DataProvider.Instance.CommentAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Comment model)
        {
            return SQLServerDAL.DataProvider.Instance.CommentUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Comment", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Comment GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByComment(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Comment> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListComment(top, fldName, strWhere, fldSort);
        }
        public List<Model.Comment> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Comment> list = new List<Model.Comment>();
            list = SQLServerDAL.DataProvider.Instance.GetPageComment(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }


        public List<Model.Comment> GetPageView(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Comment> list = new List<Model.Comment>();
            list = SQLServerDAL.DataProvider.Instance.GetPageCommentView(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
