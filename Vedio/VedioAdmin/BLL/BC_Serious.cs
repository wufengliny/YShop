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
    public  class BC_Serious
    {
        private DC_Serious dal = new DC_Serious();

        public PagedList<MC_Serious> Pager(int pageIndex, int pageSize, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strOrder);
            PagedList<MC_Serious> pl = new PagedList<MC_Serious>((List<MC_Serious>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public IList<MC_Serious> List()
        {
            return dal.List();
        }
        public MC_Serious GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }
        public MC_Serious GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
        public int Add(MC_Serious model)
        {
            return dal.Add(model);
        }
        public int Edit(MC_Serious model)
        {
            return dal.Edit(model);
        }
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
