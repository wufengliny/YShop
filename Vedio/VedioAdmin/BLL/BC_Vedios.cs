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
        public int Add(MC_Vedios model)
        {
            return dal.Add(model);
        }
        public MC_Vedios GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }
        public int GetMaxSort()
        {
            MC_Vedios model = dal.GetMaxSort();
            if(model==null)
            {
                return 100000;
            }
            else
            {
                return model.Sort;
            }
        }

    }
}
