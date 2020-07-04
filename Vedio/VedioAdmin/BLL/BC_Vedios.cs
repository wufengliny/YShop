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
    public class BC_Vedios
    {
        DC_Vedios dal = new DC_Vedios();
        public PagedList<MC_Vedios> Pager(int pageIndex, int pageSize, string strWhere, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strWhere, strOrder);
            PagedList<MC_Vedios> pl = new PagedList<MC_Vedios>((List<MC_Vedios>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
    }
}
