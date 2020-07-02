using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using System.Data;
namespace BLL
{
    public class BS_AdminGroup
    {
        private DS_AdminGroup dal = new DS_AdminGroup();
        public PagedList<MS_AdminGroup> Pager(int pageIndex, int pageSize, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strOrder);
            PagedList<MS_AdminGroup> pl = new PagedList<MS_AdminGroup>((List<MS_AdminGroup>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
        public int Add(MS_AdminGroup model)
        {
            return dal.Add(model);
        }
        public MS_AdminGroup GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }
        public MS_AdminGroup GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
        public int Update(string Name,string Memo,int ID)
        {
            return dal.Update(Name,Memo,ID);
        }
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }
    }
}
