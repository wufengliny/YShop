using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Webdiyer.WebControls.Mvc;

namespace BLL
{
    public class BC_Tags
    {
        private DC_Tags dal = new DC_Tags();
        public PagedList<MC_Tags> Pager(int pageIndex, int pageSize, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strOrder);
            PagedList<MC_Tags> pl = new PagedList<MC_Tags>((List<MC_Tags>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public IList<MC_Tags> List()
        {
            return dal.List();
        }
        public MC_Tags GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }
        public MC_Tags GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
        public int Add(MC_Tags model)
        {
            return dal.Add(model);
        }
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
