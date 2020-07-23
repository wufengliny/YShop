using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Webdiyer.WebControls.Mvc;

namespace BLL
{
    public class BC_UserLikes
    {
        DC_UserLikes dal = new DC_UserLikes();
        public List<MC_UserLikes> PagerLikes(int pageIndex, int pageSize, int UID)
        {
            List<object> list = dal.PagerLikes(pageIndex, pageSize, UID);
            PagedList<MC_UserLikes> pl = new PagedList<MC_UserLikes>((List<MC_UserLikes>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public int Add(MC_UserLikes model)
        {
            return dal.Add(model);
        }
        public int Delete(int VedioID, int UID)
        {
            return dal.Delete(VedioID,UID);
        }
        public MC_UserLikes GetModel(int VedioID, int UID)
        {
            return dal.GetModel(VedioID,UID);
        }
    }
}
