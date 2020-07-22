using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VedioAdmin.Filters;
using BLL;
using Entity;
namespace VedioAdmin.Controllers
{
    /// <summary>
    /// 删除会员会导致 数据关联错误 统计等相关  所以还是不提供会员删除的相关 功能，仅提供禁用
    /// </summary>
    [IsAuditorFilter]
    public class UserController : BaseController
    {
        // GET: User
        [Power("User", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Index(int pi=1,string Account="",int Enable=-1,int VIP=-1, string fromTime="",string endTime="")
        {
            string strWhere = " 1=1";
            if(!string.IsNullOrEmpty(Account))
            {
                strWhere += " and Account='"+Account+"'";
            }
            if (!string.IsNullOrEmpty(fromTime))
            {
                strWhere += " and AddTime>'" + fromTime + "'";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += " and AddTime<'" + endTime + "'";
            }
            if(Enable!=-1)
            {
                strWhere += " and Enable="+Enable;
            }
            if (VIP != -1)
            {
                if(VIP==1)
                {
                    strWhere += " and VIP=1" ;
                }
                else
                {
                    strWhere += " and VIP=0";
                }
            }
            string SortStr = "ID Desc";
            var list = new BS_User().Pager(pi, 20, strWhere, SortStr);
            return View(list);
        }
        [HttpGet]
        [Power("UserAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Power("UserAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Add(string txtAccount,string pwd,string memo="")
        {
            MS_User model = new BS_User().GetModelByAccount(txtAccount);
            if(model!=null)
            {
                return Content("账号已存在");
            }
            else
            {
                model = new MS_User();
            }
            model.Account = txtAccount;
            model.Pwd = UCommon.SecurityHelper.DifferentMD5(pwd);
            model.Memo = memo;
            //
            model.GUID = Guid.NewGuid().ToString("N");
            model.LoginCount = 0;
            model.RegIP = UCommon.UUtils.GetClientIP();
            model.RegURL = Request.Url.Host;
            model.AddTime = DateTime.Now;
            model.RegType = 3;
            model.Enable = 1;
            model.Memo = memo;
            model.ErrorCount = 0;
            model.UserType = "会员";
            model.VIP = false;
            int res = new BS_User().Add(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [HttpGet]
        [Power("UserEdit", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult Edit(int ID)
        {
            MS_User model = new BS_User().GetModelByID(ID);
            return View(model);
        }
        [HttpPost]
        [Power("UserEdit", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult Edit(int ID, string pwd="", string memo = "")
        {
            MS_User model_old = new BS_User().GetModelByID(ID);
            MS_User model = new MS_User();
            model.ID = ID;
            model.Memo = memo;
            if(string.IsNullOrEmpty(model.Pwd))
            {
                model.Pwd = model_old.Pwd;
            }
            else
            {
                model.Pwd = UCommon.SecurityHelper.DifferentMD5(pwd);
            }
            int res = new BS_User().EditByAdmin(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [Power("UserLockUnLock", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult LockUnLock(int ID,int Enable)
        {
            if(Enable!=0)
            {
                Enable = 1;
            }
            int res = new BS_User().UpdateEnable(ID,Enable);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        /// <summary>
        /// VIP 手动充值
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Power("UserVIPLoad", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult VIPLoad(int ID)
        {
            MS_User model = new BS_User().GetModelByID(ID);
            ViewBag.Account = model.Account;
            if (model.VIP==false)
            {
                ViewBag.vipstate = "暂未开通VIP";
            }
            else
            {
                if (model.VIPEndTime < DateTime.Now)
                {
                    ViewBag.vipstate = "VIP已过期";
                }
                else
                {
                    string VIPEndTime = model.VIPEndTime.ToString("yyyy-MM-dd");
                    if (model.VIPEndTime.Year > 2200)
                    {
                        VIPEndTime = "永久";
                    }
                    ViewBag.vipstate = "已开通，到期：" + VIPEndTime;
                }
            }
            return View();
        }

        [HttpPost]
        [Power("UserVIPLoad", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult VIPLoad(int ID,int loadtype,int VIPTime=1,string endTime2="")
        {
            MS_User model = new BS_User().GetModelByID(ID);
            if (model != null)
            {
                DateTime BGTime = DateTime.Now;
                DateTime EndTime = DateTime.Now;
                if(loadtype==1)
                {
                    if (model.VIP)
                    {
                        if (model.VIPEndTime > DateTime.Now)
                        {
                            BGTime = model.VIPEndTime;
                        }
                    }
                    if (VIPTime == 1)
                    {
                        EndTime = BGTime.AddMonths(1);
                    }
                    else if (VIPTime == 2)
                    {
                        EndTime = BGTime.AddMonths(6);
                    }
                    else if (VIPTime == 3)
                    {
                        EndTime = BGTime.AddMonths(12);
                    }
                    else if (VIPTime == 4)
                    {
                        EndTime = BGTime.AddYears(200);
                    }
                }
                else
                {
                    EndTime = DateTime.Parse(endTime2);
                }
                new BS_User().VIPLoad(ID, EndTime);
                OperateLogAdd( "为会员" + model.Account + "充值VIP",true);
            }
            else
            {
                return Content("会员不存在");
            }
            return Content("操作成功");
        }

    }
}