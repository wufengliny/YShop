using DAL;
using Entity;
using Entity.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace BLL
{
    public class BS_Admin
    {
        private DS_Admin dal = new DS_Admin();
        public PagedList<S_AdminViewModel> Pager(int pageIndex, int pageSize,string strWhere, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strWhere, strOrder);
            PagedList<S_AdminViewModel> pl = new PagedList<S_AdminViewModel>((List<S_AdminViewModel>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public MS_Admin GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }
        public MS_Admin GetModelByGUID(string guid)
        {
            return dal.GetModelByGUID(guid);
        }
        public MS_Admin GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
        public int Add(MS_Admin model)
        {
            return dal.Add(model);
        }
        public int Update(MS_Admin model)
        {
            return dal.Update(model);
        }
        public int UpdatePwd(MS_Admin model)
        {
            return dal.UpdatePwd(model);
        }
        public int UpdateLogin(MS_Admin model)
        {
            return dal.UpdateLogin(model);
        }
        public int UpdateLoginError(MS_Admin model)
        {
            return dal.UpdateLoginError(model);
        }
        public int LoginOut(int AdminId)
        {
            return dal.LoginOut(AdminId);
        }


        public int Delete(int id)
        {
            return dal.Delete(id);
        }
        public int DisOrEnable(int id, bool enable)
        {
            return dal.DisOrEnable(id,enable);
        }
        public int GetAdminCountByGroup(int adminGroupID)
        {
            return dal.GetAdminCountByGroup(adminGroupID);
        }
    }
}
