using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data;
namespace YShop.Areas.Admin.Controllers
{

     [YUAction]
    public class AdminController : Controller
    {


        //
        // GET: /Admin/
        
        [PowerFiler("adminlist9")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and effect=1";
            Yax.BLL.Admin bll = new Yax.BLL.Admin();
            DataTable dt = bll.GetPage_view(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(dt);
        }

        [PowerFiler("adminlist9")]
        public ActionResult AddAdmin()
        {
            string ggroup= initsGroup();
            ViewBag.txtGroup = ggroup;
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            if (id > 0)
            {
                Yax.Model.Admin model = new Yax.BLL.Admin().GetModel(id);
                ViewBag.Name = model.Name;
                ViewBag.realName = model.RealName;
                ViewBag.KGroup = model.KGroup;
                ViewBag.phone = model.Phone;
                ViewBag.memo = model.Memo;
            }
            return View();
        }

        [PowerFiler("adminlist9")]
        public ActionResult AddAdminPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id",0);
            string name = Request.Form["txtname"];
            string pwd = Request.Form["pwd"];
            if (!string.IsNullOrEmpty(pwd))
            {
                pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            }
            string realName = Request.Form["realName"];
            int groupa = Yax.Common.Utils.GetFormInt("groupa",0);
            if(groupa<1)
            {
                return Content("请选择权限组");
            }
            string phone = Request.Form["phone"];
            string memo = Request.Form["memo"];
            Yax.Model.Admin model = new Yax.Model.Admin();
            model.Name = name;
            model.Pwd = pwd;
            model.RealName = realName;
            model.KGroup = groupa;
            model.Phone = phone;
            model.Memo = memo;
           
            model.UpdateTime = DateTime.Now;
            if (id > 0)
            {
                model.ID = id;
                if (string.IsNullOrEmpty(model.Pwd))
                {
                    Yax.Model.Admin model_get = new Yax.BLL.Admin().GetModel(id);
                    if (model_get != null)
                    {
                        model.Pwd = model_get.Pwd;
                    }
                }
          
                try
                {
                    int resu = new Yax.BLL.Admin().Update_info(model);
                    if (resu > 0)
                    {
                        new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改管理员(" + name + ")成功");
                        return Content("修改成功");
                    }
                    else
                    {
                        return Content("修改失败");
                    }
                }
                catch (Exception ex)
                {
                    new Yax.BLL.ZY_Log().AddLog(2, "修改管理员失败：" + ex.Message + ex.StackTrace);
                    return Content("修改异常");
                }
                //mod
            }
            else
            {
                //查询账号不能存在一样的
                Yax.Model.Admin model_yiyang = new Yax.BLL.Admin().GetModelByName(name);
                if (model != null&&model.ID>0)
                {
                    return Content("用户名已存在");
                }
                model.SecondPwd = pwd;
                model.AddTime = DateTime.Now;
                model.Effect = 1;
                model.ErrorCount = 0;
                model.LastErrTime = DateTime.Now.AddYears(-10);
                model.LastLoginIP = "";
                model.LastLoginTime = DateTime.Now.AddYears(-10);
                model.LoginCount = 0;
                model.RegIP = Yax.Common.Utils.GetClientIP();
                try
                {
                    int resa = new Yax.BLL.Admin().Add(model);
                    if (resa > 0)
                    {
                        new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加管理员(" + name + ")成功");
                        return Content("添加成功");
                    }
                    else
                    {
                        return Content("添加失败");
                    }
                }
                catch(Exception ex)
                {
                    new Yax.BLL.ZY_Log().AddLog(2,"添加管理员失败："+ex.Message+ex.StackTrace);
                    return Content("添加异常");
                }
            }
            return View();
        }
        [PowerFiler("adminlist9")]
        public ActionResult deladmin()
        {
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            //string name = Request.QueryString["name"];
            int res = new Yax.BLL.Admin().UpdateEnable(id, 0);
            try
            {
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除管理员ID(" + id + ")成功");
                    return Content("删除成功");
                }
                else
                {
                    return Content("删除失败");
                }
            }
            catch
            {
                return Content("操作异常");
            }
        }




        [PowerFiler("power8")]
        public ActionResult AdminGroup()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1";

            Yax.BLL.AdminGroup bll = new Yax.BLL.AdminGroup();
            List<Yax.Model.AdminGroup> list = bll.GetPage(pageIndex, pageSize, strWhere, "id asc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("power8")]
        public ActionResult AddGroup()
        {
            string txtGroup=  initsGroup();
            ViewBag.txtGroup = txtGroup;
            int id = Yax.Common.Utils.GetQueryInt("id",0);
            if (id > 0)
            {
                Yax.Model.AdminGroup model = new Yax.BLL.AdminGroup().GetModel(id);
                if (model != null)
                {
                    ViewBag.name = model.Name;
                    ViewBag.memo = model.Memo;
                }
            }
            return View();
        }

        private string initsGroup()
        {
            List<Yax.Model.AdminGroup> list = new Yax.BLL.AdminGroup().GetList(100, "*", "Enable=1","ID  desc");
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sb.AppendLine(" <option value=\""+list[i].ID+"\">"+list[i].Name+"</option>");
                }
            }
            return sb.ToString();
        }

        [PowerFiler("power8")]
        public ActionResult AddGroupPOst()
        {
            string name = Request.Form["txtname"];
            string memo=Request.Form["memo"];
            int id = Yax.Common.Utils.GetFormInt("id",0);
            Yax.Model.AdminGroup model = new Yax.Model.AdminGroup();
            model.Name = name;
            model.Memo = memo;
            if (id > 0)
            {
                if(id==1)
                {
                    return Content("不允许修改超级管理员");
                }
                try
                {
                    model.ID = id;
                    int resu = new Yax.BLL.AdminGroup().Update_name(model);
                    if (resu > 0)
                    {
                        new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改管理员组(" + name + ")成功");
                        return Content("修改成功");
                    }
                    else
                    {
                        return Content("修改失败");
                    }
                }
                catch
                {
                    return Content("操作异常");
                }
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                try
                {
                    int res = new Yax.BLL.AdminGroup().Add(model);
                    if (res > 0)
                    {
                        new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加管理员组(" + name + ")成功");
                        return Content("添加成功");
                    }
                    else
                    {
                        return Content("添加失败");
                    }
                }
                catch
                {
                    return Content("操作异常");
                }
            }
        }

        [PowerFiler("power8")]
        public ActionResult delgroup()
        {
            int id = Yax.Common.Utils.GetQueryInt("id",0);
            if(id==1)
            {
                return Content("不允许删除超级管理员");
            }
            string name=Request.QueryString["name"];
            int res=  new Yax.BLL.AdminGroup().Delete(id);
            try
            {
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除管理员组(" + name + ")成功");
                    return Content("删除成功");
                }
                else
                {
                    return Content("删除失败");
                }
            }
            catch
            {
                return Content("操作异常");
            }
        }

        // 还有一个权限分配在Menu 控制器
        //

     

        //
        [PowerFiler("secondpwd10")]
        public ActionResult SecondPwd()
        {
            return View();
        }
        [PowerFiler("secondpwd10")]
        public ActionResult SecondPwdPost()
        {
            string oldpwd = Yax.Common.Utils.GetSafeFormString("oldsecpwd").Trim();
            string secpwd= Yax.Common.Utils.GetSafeFormString("secpwd").Trim();
            Yax.Model.Admin model = new Yax.BLL.Admin().GetModel(new Yax.BLL.CurrentUser().Id);
            if(model!=null)
            {
                if(model.SecondPwd==Yax.Common.SecurityHelper.DifferentMD5(oldpwd))
                {
                    model.SecondPwd = Yax.Common.SecurityHelper.DifferentMD5(secpwd);
                    int res= new Yax.BLL.Admin().Update_SecondPwd(model);
                    if(res>0)
                    {
                        new Yax.BLL.ZY_Log().AddLog(1,"成功修改二级密码");
                        return Content("修改成功");
                    }
                    else
                    {
                        return Content("修改失败");
                    }
                }
                else
                {
                    return Content("原二级密码错误");
                }
            }
            else
            {
                return Content("");
            }
           
        }
        //


        public ActionResult ModPwd()
        {
            return View();
        }
        public ActionResult ModPwdPost()
        {
            int id = new Yax.BLL.CurrentUser().Id;
            Yax.Model.Admin modele = new Yax.Model.Admin();
            string pwdold = Request.Form["txtname"];
            string pwd = Request.Form["pwd"];
            if (id > 0)
            {
                modele = new Yax.BLL.Admin().GetModel(id);
                if (modele != null)
                {
                    if (modele.Pwd == Yax.Common.SecurityHelper.DifferentMD5(pwdold))
                    {
                        modele.Pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                        int res = new Yax.BLL.Admin().Update_Pwd(modele);
                        if (res > 0)
                        {
                            return Content("修改成功");
                        }
                        else
                        {
                            return Content("修改失败");
                        }
                    }
                    else
                    {
                        return Content("原密码输入错误");
                    }

                }
            }
            else
            {
                return Content("修改失败");
            }
            return Content("修改失败");
        }


    }
}
