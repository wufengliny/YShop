using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Chat_msg
    {
        public readonly static Chat_msg Instance = new Chat_msg();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Chat_msg model)
        {
            return SQLServerDAL.DataProvider.Instance.Chat_msgAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Chat_msg model)
        {
            return SQLServerDAL.DataProvider.Instance.Chat_msgUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Chat_msg", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Chat_msg GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByChat_msg(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Chat_msg> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListChat_msg(top, fldName, strWhere, fldSort);
        }
        public List<Model.Chat_msg> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Chat_msg> list = new List<Model.Chat_msg>();
            list = SQLServerDAL.DataProvider.Instance.GetPageChat_msg(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
