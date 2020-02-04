using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Img_Type
    {
        public readonly static Img_Type Instance = new Img_Type();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Img_Type model)
        {
            return SQLServerDAL.DataProvider.Instance.Img_TypeAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Img_Type model)
        {
            return SQLServerDAL.DataProvider.Instance.Img_TypeUpdate(model);
        }

        public int Update_Name(Model.Img_Type model)
        {
            return SQLServerDAL.DataProvider.Instance.Img_TypeUpdate_Name(model);
        }
        public int Update_Enable(Model.Img_Type model)
        {
            return SQLServerDAL.DataProvider.Instance.Img_TypeUpdate_Enable(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Img_Type", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Img_Type GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByImg_Type(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Img_Type> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListImg_Type(top, fldName, strWhere, fldSort);
        }
        public List<Model.Img_Type> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Img_Type> list = new List<Model.Img_Type>();
            list = SQLServerDAL.DataProvider.Instance.GetPageImg_Type(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
