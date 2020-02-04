using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Config
    {
        public readonly static Config Instance = new Config();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Config model)
        {
            return SQLServerDAL.DataProvider.Instance.ConfigAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Config model)
        {
            return SQLServerDAL.DataProvider.Instance.ConfigUpdate(model);
        }
        public int UpdateInfo(Model.Config model)
        {
            return SQLServerDAL.DataProvider.Instance.ConfigUpdateInfo(model);
        }
        public int UpdateValue(Model.Config model)
        {
            return SQLServerDAL.DataProvider.Instance.ConfigUpdateValue(model);
        }
        public int UpdateEnable(Model.Config model)
        {
            return SQLServerDAL.DataProvider.Instance.ConfigUpdate_enable(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Config", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Config GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByConfig(ID);
        }
        /// <summary>
        /// 缓存中获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Model.Config GetModelBy_key(string key)
        {
            return SQLServerDAL.DataProvider.Instance.GetListConfig_cache_bykey(key);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Config> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListConfig(top, fldName, strWhere, fldSort);
        }
        public List<Model.Config> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Config> list = new List<Model.Config>();
            list = SQLServerDAL.DataProvider.Instance.GetPageConfig(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
