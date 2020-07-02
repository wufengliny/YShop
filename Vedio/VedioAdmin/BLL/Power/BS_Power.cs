using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCommon.ComNames;

namespace BLL
{
    public class BS_Power
    {
        DS_Power dal = new DS_Power();
        public int PowerAdd(MS_Power model)
        {
            return dal.PowerAdd(model);
        }
        public int DeletePower(int admingroupID)
        {
            return dal.DeletePower(admingroupID);
        }
        public IList<MS_Power> List()
        {
            return dal.List();
        }
        public IList<MS_Power> GetPowersByAdmingroup(int AdminGroup)
        {
            return dal.GetPowersByAdmingroup(AdminGroup);
        }
        public IEnumerable<MS_Power> ListFromCache(int AdminGroup)
        {
            object obj = UCommon.UDataCache.GetCache(CacheNames.PowerCacheName); 
            IList<MS_Power> list = null;
            Dictionary<int, IEnumerable<MS_Power>> dir = null;
            if (obj == null)
            {
                list = dal.List();
                dir = new Dictionary<int, IEnumerable<MS_Power>>();
                var groups = list.GroupBy(x => x.AdminGroup);
                foreach(var group in groups)
                {
                    dir.Add(group.Key, group);
                }
                UCommon.UDataCache.SetCache(CacheNames.PowerCacheName, dir);
            }
            else
            {
                dir = (Dictionary<int, IEnumerable<MS_Power>>)obj;
            }
            return dir[AdminGroup];
        }
    }
}
