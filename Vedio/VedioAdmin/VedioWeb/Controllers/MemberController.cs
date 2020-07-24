using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VedioWeb.Filters;
using UCommon;
namespace VedioWeb.Controllers
{
    [MemAction]
    public class MemberController : Controller
    {
        // GET: Member

        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int uid = new CurrentUser().ID;
            MS_User model = new BS_User().GetModelByID(uid);
            string vipInfo = "";
            if (model.VIP)
            {
                if (model.VIPEndTime.Year > 2200)
                {
                    vipInfo = "永久VIP";
                }
                else if (model.VIPEndTime > DateTime.Now)
                {
                    vipInfo = "已开通：到期时间：" + model.VIPEndTime;
                }
                else
                {
                    vipInfo = "VIP已到期";
                }
            }
            else
            {
                vipInfo = "未激活";
            }
            ViewBag.vipInfo = vipInfo;
            return View(model);
        }

        /// <summary>
        /// 修改头像
        /// </summary>
        /// <returns></returns>
        public ActionResult ModHeadPic()
        {
            return View();
        }
        /// <summary>
        /// 绑定邮箱
        /// </summary>
        /// <returns></returns>
        public ActionResult BindEmail()
        {
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ModPwd(string passwordold,string password)
        {
            int uid = new CurrentUser().ID;
            MS_User model = new BS_User().GetModelByID(uid);
            if(model.Pwd==SecurityHelper.DifferentMD5(passwordold))
            {
                model.Pwd = SecurityHelper.DifferentMD5(password);
                new BS_User().EditPwd(model);
                return Content("操作成功");
            }
            else
            {
                return Content("输入原密码错误");
            }
            return Content("");
        }
        /// <summary>
        /// 修改封面
        /// </summary>
        /// <returns></returns>
        public ActionResult ModBanner()
        {
            return View();
        }

        /// <summary>
        /// VIP会员
        /// </summary>
        /// <returns></returns>
        public ActionResult OpneVIP()
        {
            return View();
        }
        /// <summary>
        /// 打赏设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Reward()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <returns></returns>
        public ActionResult Like(int pi = 1)
        {
            int uid = new CurrentUser().ID;
            var list = new BC_UserLikes().PagerLikes(pi, 20, uid);
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            return View(list);
        }
        public ActionResult Goods(int pi = 1)
        {
            int uid = new CurrentUser().ID;
            var list = new BC_UserGoods().PagerGoods(pi, 20, uid);
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            return View(list);
        }

        /// <summary>
        /// 关注
        /// </summary>
        /// <returns></returns>
        public ActionResult Focus()
        {
            return View();
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        public ActionResult Comment()
        {
            return View();
        }

    }
}