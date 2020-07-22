using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Webdiyer.WebControls.Mvc;
using DAL;
namespace BLL
{
    public class BS_User
    {
        DS_User dal = new DS_User();
        public PagedList<MS_User> Pager(int pageIndex, int pageSize, string strWhere, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strWhere, strOrder);
            PagedList<MS_User> pl = new PagedList<MS_User>((List<MS_User>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public int Add(MS_User model)
        {
            return dal.Add(model);
        }
        public int EditByAdmin(MS_User model)
        {
            return dal.EditByAdmin(model);
        }
        public int UpdateEnable(int ID, int Enable)
        {
            return dal.UpdateEnable(ID,Enable);
        }
        public int UpdateLoginErr(int ID)
        {
            return dal.UpdateLoginErr(ID);
        }
        public int UpdateLoginOK(string IP, DateTime dt, int ID)
        {
            return dal.UpdateLoginOK(IP,dt,ID);
        }
        public MS_User GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }
        public MS_User GetModelByAccount(string Account)
        {
            return dal.GetModelByAccount(Account);
        }
        public int VIPLoad(int ID, DateTime endtime)
        {
            return dal.VIPLoad(ID,endtime);
        }
    }
}
