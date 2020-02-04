using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class UserLike
    {
        public readonly static UserLike Instance = new UserLike();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.UserLike model)
        {
            return SQLServerDAL.DataProvider.Instance.UserLikeAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.UserLike model)
        {
            return SQLServerDAL.DataProvider.Instance.UserLikeUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("UserLike", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.UserLike GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByUserLike(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.UserLike> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListUserLike(top, fldName, strWhere, fldSort);
        }
        public List<Model.UserLike> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.UserLike> list = new List<Model.UserLike>();
            list = SQLServerDAL.DataProvider.Instance.GetPageUserLike(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
