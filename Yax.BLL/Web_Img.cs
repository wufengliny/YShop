using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Web_Img
    {
        public readonly static Web_Img Instance = new Web_Img();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Web_Img model)
        {
            return SQLServerDAL.DataProvider.Instance.Web_ImgAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Web_Img model)
        {
            return SQLServerDAL.DataProvider.Instance.Web_ImgUpdate(model);
        }
        public int Update_sortimg(Model.Web_Img model)
        {
            return SQLServerDAL.DataProvider.Instance.Web_ImgUpdate_sortImg(model);
        }
        public int Update_enable(Model.Web_Img model)
        {
            return SQLServerDAL.DataProvider.Instance.Web_ImgUpdate_Enable(model);
        }
        public int Update_info(Model.Web_Img model)
        {
            return SQLServerDAL.DataProvider.Instance.Web_ImgUpdate_info(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Web_Img", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Web_Img GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByWeb_Img(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Web_Img> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListWeb_Img(top, fldName, strWhere, fldSort);
        }
        public List<Model.Web_Img> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Web_Img> list = new List<Model.Web_Img>();
            list = SQLServerDAL.DataProvider.Instance.GetPageWeb_Img(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
