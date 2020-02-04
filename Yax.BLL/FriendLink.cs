using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class FriendLink
    {
        public readonly static FriendLink Instance = new FriendLink();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.FriendLink model)
        {
            return SQLServerDAL.DataProvider.Instance.FriendLinkAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.FriendLink model)
        {
            return SQLServerDAL.DataProvider.Instance.FriendLinkUpdate(model);
        }
        public int UpdateEnable(int id, int enable)
        {
            return SQLServerDAL.DataProvider.Instance.FriendLinkUpdateEnable(id,enable);
        }
        public int UpdateInfo(Model.FriendLink model)
        {
            return SQLServerDAL.DataProvider.Instance.FriendLinkUpdateInfo(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("FriendLink", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.FriendLink GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByFriendLink(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.FriendLink> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListFriendLink(top, fldName, strWhere, fldSort);
        }
        public List<Model.FriendLink> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.FriendLink> list = new List<Model.FriendLink>();
            list = SQLServerDAL.DataProvider.Instance.GetPageFriendLink(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
