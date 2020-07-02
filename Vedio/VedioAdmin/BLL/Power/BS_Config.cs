using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;


namespace BLL
{
    public class BS_Config
    {
        DS_Config dal = new DS_Config();
       
  
        /// <summary>
        /// 更新系统配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateByKey(string key, string Val)
        {
            return dal.UpdateByKey(key,Val);
        }
        public int UpdateByID(int id,string val,string memo)
        {
            return dal.UpdateByID(id, val,memo);
        }




        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MS_Config GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }
        public MS_Config GetModelByIDFromCache(int id)
        {
            var list = GetALLFromCahce();
            return list.FirstOrDefault(p => p.ID == id);
        }
        /// <summary>
        /// kay
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public IList<MS_Config> GetListByGroup(string group)
        {
            return dal.GetListByGroup(group);
        }
        /// <summary>
        /// kay
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public IEnumerable<MS_Config> GetListByGroupFromCache(string group)
        {
            var list=  GetALLFromCahce();
            return list.Where(x => x.Group == group);
        }
        /// <summary>
        /// kay
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigByKeyFromCache(string key)
        {
            var list = GetALLFromCahce();
            return list.FirstOrDefault(p => p.key == key).Value;
        }
        /// <summary>
        /// kay
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public MS_Config GetModelByKeyFromCache(string key)
        {
            var list = GetALLFromCahce();
            return list.FirstOrDefault(p => p.key == key);
        }
        /// <summary>
        /// kay
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public MS_Config GetModelByKey(string key)
        {
            return dal.GetModelByKey(key);
        }
        /// <summary>
        /// kay
        /// </summary>
        /// <returns></returns>
        public IList<MS_Config> GetALLFromCahce()
        {
            IList<MS_Config> list = null;
            object obj = UCommon.UDataCache.GetCache(UCommon.ComNames.CacheNames.ConfigCacheName); 
            if (obj == null)
            {
                list = dal.GetALL();
                UCommon.UDataCache.SetCache(UCommon.ComNames.CacheNames.ConfigCacheName, list);
            }
            else
            {
                list = (IList<MS_Config>)obj;
            }
            return list;
        }


        /// <summary>
        /// 获取网站的名称，url
        /// 0.名称 1.url 2.网站描述 3.url1
        /// </summary>
        /// <returns></returns>
        public string[] SiteTitleUrl()
        {
            string[] tu = new string[5];
            object title = UCommon.UDataCache.GetCache("SiteTitleUrl");
            if (title == null)
            {
                MS_Config model = GetModelByIDFromCache(39);
                tu[0] = model.Value;
                tu[1] = GetModelByIDFromCache(40).Value;
                tu[2] = model.Memo;
                tu[3] = GetModelByKeyFromCache("SiteConfigUrl1").Value;
                tu[4] = GetModelByKeyFromCache("SiteConfigPhoneVersion").Value;
                UCommon.UDataCache.SetCache("SiteTitleUrl", tu);
            }
            else
            {
                tu = (string[])title;
            }
            return tu;
        }

        

  
    }
}
