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
    public class BC_UserGoods
    {
        DC_UserGoods dal = new DC_UserGoods();

        public List<MC_UserGoods> PagerGoods(int pageIndex, int pageSize, int UID)
        {
            List<object> list = dal.PagerGoods(pageIndex, pageSize, UID);
            PagedList<MC_UserGoods> pl = new PagedList<MC_UserGoods>((List<MC_UserGoods>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public int Add(MC_UserGoods model)
        {
            return dal.Add(model);
        }
        public int Delete(int VedioID, int UID)
        {
            return dal.Delete(VedioID,UID);
        }
        public MC_UserGoods GetModel(int VedioID, int UID)
        {
            return dal.GetModel(VedioID,UID);
        }
    }
}
