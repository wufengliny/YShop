using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.Security;
using VedioAdmin.Filters;
using ComEnum;

namespace VedioAdmin.Controllers
{
    /// <summary>
    /// 2019-12-21
    /// </summary>
    [IsAuditorFilter]
    public class AdminController : BaseController
    {
        BS_Admin bll = new BS_Admin();
        BS_AdminGroup bll_adminGroup = new BS_AdminGroup();
       
        // GET: Admin
        [Power("admin",OpenTypeEnum.Page)]
        public ActionResult Index(int p = 1)
        {
            return View(bll.Pager(p, PageSize, "", "ID desc"));
        }

        [Power("adminadd", OpenTypeEnum.Dialog)]
        public ActionResult AdminAdd()
        {
            ViewBag.admingroup = bll_adminGroup.GetAll();
            return View();
        }

        [Power("adminadd", OpenTypeEnum.Ajax)]
        public ActionResult AdminAddPost(string txtname,string pwd,string realName,int groupa,string phone,string memo)
        {
            if(groupa==0)
            {
                return Content("请选择权限组");
            }
            if(pwd.Length<6)
            {
                return Content("密码最少6个字符");
            }
            var groupModel= bll_adminGroup.GetModelByID(groupa);
            if(groupModel==null)
            {
                return Content("权限组不存在");
            }
            MS_Admin model = bll.GetModelByName(txtname);
            if(model!=null)
            {
                return Content("管理员已存在，添加失败");
            }
            model = new MS_Admin();
            model.AddTime = DateTime.Now;
            model.GUID = Guid.NewGuid().ToString("N");
            model.AdminGroupID = groupa;
            model.Enable = true;
            model.ErrorCount = 0;
            //model.LastErrTime = DateTime.Now;
            model.LastLoginIP = "";
            //model.LastLoginTime = "";
            model.LoginCount = 0;
            model.Memo = memo;
            model.Name = txtname;
            model.Phone = phone;
            model.Pwd = UCommon.SecurityHelper.DifferentMD5(pwd);
            model.RealName = realName;
            model.RegIP = UCommon.UUtils.GetClientIP();
            model.SecondPwd= UCommon.SecurityHelper.DifferentMD5(pwd);
            model.UpdateTime = DateTime.Now;
            int res= bll.Add(model);
            if(res>0)
            {
                OperateLogAdd("添加管理员："+model.Name,true);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            
        }

        [Power("adminedit", OpenTypeEnum.Dialog)]
        public ActionResult AdminEdit(int id)
        {
            MS_Admin model = bll.GetModelByID(id);
            if(model==null)
            {
                return Redirect("/error/Dialog?msg=管理员不存在");
            }
            else
            {
                ViewBag.admingroup = bll_adminGroup.GetAll();
                return View(model);
            }
           
        }

        [Power("adminedit", OpenTypeEnum.Ajax)]
        public ActionResult AdminEditPost(string txtname, string pwd, string realName, int groupa, string phone, string memo,int id)
        {
            MS_Admin model_old = bll.GetModelByID(id);
            if (model_old == null)
            {
                return Content("管理员不存在");
            }
            else
            {
                MS_Admin model = new MS_Admin();
                model.Name = txtname;
                if(model_old.Name!=model.Name)
                {
                    var chkEsist = bll.GetModelByName(model.Name);
                    if (chkEsist != null)
                    {
                        return Content("管理员名称已被占用");
                    }
                }
                if(string.IsNullOrEmpty(pwd))
                {
                    model.Pwd = model_old.Pwd;
                }
                else
                {
                    if(pwd.Length<6)
                    {
                        return Content("密码长度至少6个字符");
                    }
                    model.Pwd = UCommon.SecurityHelper.DifferentMD5(pwd);
                }
                model.RealName = realName;
                model.AdminGroupID = groupa;
                model.Phone = phone;
                model.Memo = memo;
                model.ID = id;
                int res= bll.Update(model);
                if(res>0)
                {
                    string domsg = string.Empty;
                    if(model_old.Name!=model.Name)
                    {
                        domsg += "名称："+model_old.Name+">"+model.Name+"。";
                    }
                    if(UCommon.SecurityHelper.DifferentMD5(pwd)!=model_old.Pwd)
                    {
                        domsg += "密码已修改。";
                    }
                    else
                    {
                        domsg += "密码未修改。";
                    }
                    if (model_old.RealName != model.RealName)
                    {
                        domsg += "姓名：" + model_old.RealName + ">" + model.RealName + "。";
                    }
                    if (model_old.AdminGroupID != model.AdminGroupID)
                    {
                        domsg += "权限组已变动 权限组ID：" + model_old.AdminGroupID + ">" + model.AdminGroupID + "。";
                    }
                    if (model_old.Phone != model.Phone)
                    {
                        domsg += "手机号：" + model_old.Phone + ">" + model.Phone + "。";
                    }
                    if (model_old.Memo != model.Memo)
                    {
                        domsg += "备注：" + model_old.Memo + ">" + model.Memo + "。";
                    }
                    if(!string.IsNullOrEmpty(domsg))
                    {
                        OperateLogAdd("修改管理账号：" + domsg, true);
                    }
                    return Content("操作成功");
                }
                return Content("操作失败");
            }

        }


        [Power("admindel", OpenTypeEnum.Ajax)]
        public ActionResult AdminDelte(int id)
        {
            if(id==1)
            {
                return Content("此管理员无法删除");
            }
            MS_Admin model = bll.GetModelByID(id);
            if(model==null)
            {
                return Content("数据不存在");
            }
            int res = bll.Delete(id);
            if(res>0)
            {
                OperateLogAdd("删除管理员账号ID："+model.ID+",账号："+model.Name,true);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [Power("AdminGroup", OpenTypeEnum.Page)]
        public ActionResult AdminGroup(int p = 1)
        {
            return View(bll_adminGroup.Pager(p, PageSize, "ID asc"));
        }

        [Power("admingroupadd", OpenTypeEnum.Dialog)]
        public ActionResult AdminGroupAdd()
        {
            return View();
        }
        /// <summary>
        /// 添加权限组
        /// </summary>
        /// <param name="name"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        [Power("admingroupadd", OpenTypeEnum.Ajax)]
        public ActionResult AdminGroupAddPost(string name,string memo)
        {
            if(string.IsNullOrEmpty(name))
            {
                return Content("权限组名称不能为空");
            }
            MS_AdminGroup model = bll_adminGroup.GetModelByName(name);
            if(model!=null)
            {
                return Content("权限组已存在");
            }
            else
            {
                model = new MS_AdminGroup();
                model.AddTime = DateTime.Now;
                model.Enable = true;
                model.Memo = memo;
                model.Name = name;
                int res= bll_adminGroup.Add(model);
                if(res>0)
                {
                    OperateLogAdd("添加权限组："+name,false);
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
                
            }
          
        }
       
        [Power("admingroupedit", OpenTypeEnum.Dialog)]
        public ActionResult AdminGroupEdit(int id)
        {
            MS_AdminGroup model = bll_adminGroup.GetModelByID(id);
            if(model==null)
            {
                return Content("数据不存在");
            }
            else
            {
                return View(model);
            }
        }
        /// <summary>
        /// 修改权限组
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Memo"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Power("admingroupedit", OpenTypeEnum.Ajax)]
        public ActionResult AdminGroupEditPost(string Name,string Memo,int ID)
        {
            MS_AdminGroup model_old = bll_adminGroup.GetModelByID(ID);
            if(model_old==null)
            {
                return Content("数据不存在");
            }
            if(model_old.Name!=Name)
            {
                var chkexist = bll_adminGroup.GetModelByName(Name);
                if (chkexist != null)
                {
                    return Content("管理员名称已存在");
                }
            }
            int res=  bll_adminGroup.Update(Name,Memo,ID);
            if(res>0)
            {
                string domsg = "";
                if(model_old.Name!=Name)
                {
                    domsg += "名称："+model_old.Name+">"+Name+"。";
                }
                if(model_old.Memo!=Memo)
                {
                    domsg += "备注：" + model_old.Memo + ">" + Memo;
                }
                if(!string.IsNullOrEmpty(domsg))
                {
                    OperateLogAdd("修改权限组:" + domsg, false);
                }
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        /// <summary>
        /// 删除权限组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Power("admingroupdel", OpenTypeEnum.Ajax)]
        public ActionResult AdminGroupDelPost(int id)
        {
            //查询权限组 下面是否有管理员  有则不能删除
            int adminNum = bll.GetAdminCountByGroup(id);
            if(adminNum>0)
            {
                OperateLogAdd("删除权限组失败，原因：权限组下面还有"+ adminNum + "个管理员" , false);
                return Content("删除失败，权限组下面还有管理员");
            }
            MS_AdminGroup model = bll_adminGroup.GetModelByID(id);
            if(model==null)
            {
                return Content("数据不存在");
            }
            int res= bll_adminGroup.Delete(id);
            if(res>0)
            {
                OperateLogAdd("删除权限组："+model.Name, false);
            }
            else
            {

            }
            return Content("操作成功");
        }





        #region 只需要登录权限
        [HttpGet]
        public ActionResult ModPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ModPwd(string oldpwd, string newpwd)
        {
            var model = bll.GetModelByGUID(CUser.GUID);
            if (model.Pwd != UCommon.SecurityHelper.DifferentMD5(oldpwd))
            {
                OperateLogAdd("修改登录密码失败，输入原密码错误", true);
                return Content("原密码输入错误");
            }
            if (newpwd.Length < 6)
            {
                return Content("新密码长度至少6个字符");
            }
            model.Pwd = UCommon.SecurityHelper.DifferentMD5(newpwd);
            int res = bll.UpdatePwd(model);
            if (res > 0)
            {
                OperateLogAdd("成功修改自己的密码", true);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }

        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            bll.LoginOut(CUser.ID);
            OperateLogAdd("手动注销退出后台", false);
            FormsAuthentication.SignOut();
            return Redirect("/Login/index");
        }
        
        #endregion

    }
}