using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Catagory
    {
        public readonly static Catagory Instance = new Catagory();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Catagory model)
        {
            return SQLServerDAL.DataProvider.Instance.CatagoryAdd(model);
        }
        /// <summary>
        /// 修改数据  
        /// </summary>
        public int Update(Model.Catagory model)
        {
            return SQLServerDAL.DataProvider.Instance.CatagoryUpdate(model);
        }
        public int Update_enable(Model.Catagory model)
        {
            return SQLServerDAL.DataProvider.Instance.CatagoryUpdate_enable(model);
        }
        public int UpdateName(Model.Catagory model)
        {
            return SQLServerDAL.DataProvider.Instance.CatagoryUpdateName(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Catagory", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Catagory GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByCatagory(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Catagory> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListCatagory(top, fldName, strWhere, fldSort);
        }
        //
        public List<Model.Catagory> GetListAllFromChche()
        {
            object obj = Yax.Common.DataCache.GetCache("GoodCatagory");
            List<Model.Catagory> listc = null;
            if (obj == null)
            {
                listc = SQLServerDAL.DataProvider.Instance.GetListCatagory(9999, "*", " Enable=1 ", "ID  desc");
                Yax.Common.DataCache.SetCache("GoodCatagory", listc);
            }
            else
            {
                listc = (List<Model.Catagory>)obj;
            }
            return listc;
        }


        public List<Model.Catagory> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Catagory> list = new List<Model.Catagory>();
            list = SQLServerDAL.DataProvider.Instance.GetPageCatagory(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
