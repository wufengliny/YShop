using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class MemberController : Controller
    {
        //
        // GET: /Member/

   


        #region 默认会员体系
        [PowerFiler("Memberlist11")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string phone = Yax.Common.Utils.GetSafeQueryString("phone");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and effect>0 ";
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and  phone like '%" + phone + "%'";
            }
            Yax.BLL.Y_User bll = new Yax.BLL.Y_User();
            List<Yax.Model.Y_User> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("Memberlist11")]
        public ActionResult AddMember()
        {
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            if (id > 0)
            {
                Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
                ViewBag.Account = model.Account;
                ViewBag.memo = model.Memo;
                ViewBag.UserType = model.UserType;
            }
            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult AddMemberPost()
        {
            // Account添加后 不可以修改 
            int id = Yax.Common.Utils.GetFormInt("id", 0);
            string Account = Yax.Common.Utils.GetSafeFormString("txtAccount");
            string pwd = Yax.Common.Utils.GetFormString("pwd");
            string memo = Yax.Common.Utils.GetSafeFormString("memo");
            string UserType = Yax.Common.Utils.GetSafeFormString("UserType");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModelAccount(Account);
            string strSQl = "";
            if (id > 0)
            {
                //mod
                if (string.IsNullOrEmpty(pwd))
                {
                    pwd = model.Pwd;
                }
                else
                {
                    pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                }
                strSQl = " update Y_User set  pwd='" + pwd + "',UserType='" + UserType + "',Memo='" + memo + "' where id=" + model.ID;
                new Yax.BLL.BCommon().ExecuteScalar(strSQl);
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改会员(" + model.Account + ")ID:" + id + "成功");
                return Content("修改成功");
            }
            else
            {
                pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                //查询账号是否已存在
                if (model != null)
                {
                    return Content("该账号已存在");
                }
                strSQl = " INSERT INTO [dbo].[Y_User] ([Account],[Pwd] ,[Memo],[UserType],[Effect],[AddTime])VALUES ";
                strSQl += "('" + Account + "','" + pwd + "','" + memo + "','" + UserType + "',1 ,getdate())";
                new Yax.BLL.BCommon().ExecuteScalar(strSQl);
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加会员(" + Account + ")成功");
                return Content("添加成功");
            }
        }
        /// <summary>
        /// 根据手机号修改密码
        /// </summary>
        /// <returns></returns>
        [PowerFiler("Memberlist11")]
        public ActionResult ModPwd()
        {
            return View();
        }
    
        [PowerFiler("Memberlist11")]
        public ActionResult ModPwdPost(string phone, string pwd)
        {
            try
            {
                Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModelPhone(phone);
                if (model != null && model.ID > 0)
                {
                    model.Pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                    int res = new Yax.BLL.Y_User().Update_pwd(model);
                    if (res > 0)
                    {
                        new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改会员(" + phone + ")ID:" + model.ID + " 密码成功");
                        return Content("修改账户：" + phone + "密码成功");
                    }
                    else
                    {
                        return Content("修改账户：" + phone + "密码失败");
                    }
                }
                else
                {
                    return Content("账户不存在！");
                }
            }
            catch
            {
                return Content("网络异常！");
            }

            return View();
        }


        [PowerFiler("Memberlist11")]
        public ActionResult ChongZhi(int id)
        {
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            if (model != null)
            {
                ViewBag.Phone = model.Phone;
                ViewBag.RealName = model.RealName;
                string msg = new Yax.BLL.Config().GetModelBy_key("huiyuanhoutaichongzhi").Value;
                msg = msg.Replace("{name}", model.RealName);
                msg = msg.Replace("{phone}", model.Phone);
                ViewBag.msg = msg;
            }
            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult ChongZhiPost()
        {
            int uid = Yax.Common.Utils.GetFormInt("id");
            decimal money = 0;
            decimal.TryParse(Request.Form["money"], out money);
            Yax.Model.MoneyDetail model = new Yax.Model.MoneyDetail();
            model.AddTime = DateTime.Now;
            model.AdminID = new Yax.BLL.CurrentUser().Id;
            model.CZtype = 1;
            model.Enable = 1;
            model.Memo = "";
            model.OrderNO = "UM" + Yax.Common.Utils.RandomDateCard("yyyyMMddHHmmss") + Yax.Common.Utils.RandStr(5);
            model.UserID = uid;
            Yax.Model.Y_User m_user = new Yax.BLL.Y_User().GetModel(uid);
            if (m_user != null)
            {
                model.Phone = m_user.Phone;
                model.RealName = m_user.RealName;
                model.PreMoney = m_user.Money;
                model.Money = money;
                model.AfterMoney = model.PreMoney + money;
                string msg = "";
                if (money > 0)   //充值
                {
                    msg = Request.Form["msg"].Replace("{money}", money.ToString());
                    model.msgRecord = msg;
                    model.MoneyType = "in";

                    new Yax.BLL.Y_User().UpdateMoney(model.AfterMoney, m_user.ID);
                    int res = new Yax.BLL.MoneyDetail().Add(model);
                    if (res > 0)
                    {
                        string res_msg = new Yax.BLL.MsgConfig().SendCheckCode(model.Phone, msg);
                        if (res_msg == "ok")
                        {
                            return Content("充值成功,短信发送成功");
                        }
                        else
                        {
                            return Content("充值成功,短信发送失败");
                        }

                    }
                    else
                    {
                        return Content("充值失败");
                    }
                }
                else    //扣款
                {
                    model.MoneyType = "out";
                    model.msgRecord = "";
                    if (model.AfterMoney < 0)
                    {
                        return Content("扣款失败，会员余额小于扣款金额");
                    }
                    else
                    {
                        new Yax.BLL.Y_User().UpdateMoney(model.AfterMoney, m_user.ID);
                        int res = new Yax.BLL.MoneyDetail().Add(model);
                        if (res > 0)
                        {
                            return Content("扣款成功");
                        }
                        else
                        {
                            return Content("扣款失败");
                        }
                    }
                }
                return Content("");
            }
            else
            {
                return Content("会员不存在");
            }


        }



        [PowerFiler("Memberlist11")]
        public ActionResult ModInfo(int id)
        {
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            if (model != null && model.Effect >= 1)
            {
                ViewBag.Phone = model.Phone;
                ViewBag.RealName = model.RealName;
                ViewBag.IDCard = model.IDCard;
                ViewBag.IDCardImgZheng = model.IDCardImgZheng;
                ViewBag.IDCardImgBei = model.IDCardImgBei;
                ViewBag.IDCardImgShouChi = model.IDCardImgShouChi;
                ViewBag.IDCardSelf = model.IDCardSelf;
                ViewBag.LivePlace = model.LivePlace;
                ViewBag.JobCompanyName = model.JobCompanyName;
                ViewBag.WorkPlace = model.WorkPlace;
                ViewBag.JobName = model.JobName;
                ViewBag.JobAge = model.JobAge;
                ViewBag.JobCompanyPhone = model.JobCompanyPhone;
                ViewBag.ContactMan = model.ContactMan;
                ViewBag.ContactMan2 = model.ContactMan2;
                ViewBag.BankName = model.BankName;
                ViewBag.BankCardNO = model.BankCardNO;
                ViewBag.JobMoney = model.JobMoney;
            }
            else
            {
                return Content("账户不存在");
            }
            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult ModInfoPost(Yax.Model.Y_User m)
        {
            try
            {
                Yax.Model.Y_User model;
                if (m.ID > 0)
                {
                    model = new Yax.BLL.Y_User().GetModel(m.ID);
                    if (model != null && model.Effect > 0)
                    {
                        model.RealName = m.RealName;
                        model.IDCard = m.IDCard;
                        model.BankName = m.BankName;
                        model.BankCardNO = m.BankCardNO;
                        if (model.LastErrTime < DateTime.Now.AddYears(-10))
                        {
                            model.LastErrTime = DateTime.Now.AddYears(-5);
                        }
                        int res = new Yax.BLL.Y_User().Update(model);
                        if (res > 0)
                        {
                            new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改会员(" + m.Phone + ")ID:" + model.ID + "信息成功");
                            return Content("修改成功！");
                        }
                        else
                        {
                            return Content("修改失败！");
                        }

                    }
                    else
                    {
                        return Content("账号不存在！");
                    }
                }
            }
            catch (Exception e)
            {
                return Content("网络异常！");
            }

            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult ShenHe(int id)
        {
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            if (model.Effect != 0)
            {
                ViewBag.Phone = model.Phone;
                ViewBag.RealName = model.RealName;
                ViewBag.RZState = model.RZState;
            }
            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult ShenHePost(int RZState, int id)
        {
            Yax.Model.Y_User model = new Yax.Model.Y_User();
            model.RZState = RZState;
            model.ID = id;
            int res = new Yax.BLL.Y_User().UpdateEnable_RZstate(model);
            if (res > 0)
            {
                //new Yax.BLL.MsgConfig().SendCheckCode(phone, msg);
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "审核会员ID(" + model.ID + ")状态为:" + RZState + "成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            return Content("");
        }

        [PowerFiler("Memberlist11")]
        public ActionResult delmember(int id, int effect)
        {
            Yax.Model.Y_User y = new Yax.Model.Y_User();
            y.Effect = effect;
            y.ID = id;
            string doactName = "";
            if (effect == 0)
            {
                doactName = "删除";
            }
            else if (effect == 1)
            {
                doactName = "恢复账户";
            }
            else if (effect == 2)
            {
                doactName = "禁止账户";
            }
            int res = new Yax.BLL.Y_User().UpdateEnable(y);
            try
            {
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + doactName + "会员ID(" + id + ")成功");
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
            catch
            {
                return Content("操作异常");
            }
        }


        [PowerFiler("zijin14")]
        public ActionResult MoneyDetail()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string phone = Yax.Common.Utils.GetSafeQueryString("phone");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and enable=1 ";
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and  phone like '%" + phone + "%'";
            }
            Yax.BLL.MoneyDetail bll = new Yax.BLL.MoneyDetail();
            List<Yax.Model.MoneyDetail> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        #endregion


        #region 漫画会员体系
        [PowerFiler("Memberlist11")]
        public ActionResult IndexMV()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string phone = Yax.Common.Utils.GetSafeQueryString("phone");
            string UserType = Yax.Common.Utils.GetSafeQueryString("UserType");
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int AgentID = Yax.Common.Utils.GetFormInt("AgentID");
            if (string.IsNullOrEmpty(UserType))
            {
                UserType = "会员";
            }
            ViewBag.UserType = UserType;
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and effect>0 ";
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and  phone like '%" + phone + "%'";
            }
            if (!string.IsNullOrEmpty(UserType))
            {
                strWhere += " and  UserType='" + UserType + "'";
            }
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account like '%" + Account + "%'";
            }
            if (AgentID > 0)
            {
                strWhere += " and  AgentID=" + AgentID;
            }
            Yax.BLL.Y_User bll = new Yax.BLL.Y_User();
            List<Yax.Model.Y_User> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("Memberlist11")]
        public ActionResult upToAgent()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            if (model.UserType == "代理")
            {
                return Content("已经是代理了");
            }
            else
            {
                List<string> listSQL = new List<string>();
                int AgentID = model.AgentID;
                Yax.Model.Y_User mAgent = new Yax.BLL.Y_User().GetModel(AgentID);
                if (AgentID > 0)
                {
                    listSQL.Add(" update Y_User set JIFen=" + (mAgent.JIFen + 1000) + " where id=" + AgentID);
                    string strSQL_JIfen = "INSERT INTO [dbo].[JiFenDetail]([PreJiFen],[Jifen],[AfterJIfen],[Memo],[AddTime],[UID],[Account])";
                    strSQL_JIfen += " VALUES(" + mAgent.JIFen + ",1000," + (mAgent.JIFen + 1000) + ",'您的会员：" + model.Account + "升级为代理',getdate()," + AgentID + ",'" + mAgent.Account + "')";
                    listSQL.Add(strSQL_JIfen);
                }
                listSQL.Add(" update Y_User set UserType='代理' where id=" + model.ID);
                listSQL.Add(" update Y_User set DianQuan=" + (model.DianQuan + 5000) + " where id=" + model.ID);
                string strSQL_dianquan = " INSERT INTO [dbo].[DianQuanDetail]([PreJiFen] ,[Jifen] ,[Memo] ,[AddTime],[UID] ,[AfterJIfen],[Account])";
                strSQL_dianquan += " VALUES(" + model.DianQuan + ",5000,'升级代理赠送',getdate()," + model.ID + "," + (model.DianQuan + 5000) + ",'" + model.Account + "')";
                listSQL.Add(strSQL_dianquan);
                new Yax.BLL.BCommon().ExecuteSqlTran(listSQL);
                return Content("升级成功");
            }
            return Content("");
        }


        [PowerFiler("Memberlist11")]
        public ActionResult JiFenChongZhi()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            ViewBag.Account = model.Account;
            ViewBag.Phone = model.Phone;
            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult JiFenChongZhiPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            int jifenType = Yax.Common.Utils.GetFormInt("jifenType");
            int Jifen = Yax.Common.Utils.GetFormInt("Jifen");
            string Memo = Yax.Common.Utils.GetSafeFormString("memo");
            List<string> liststr = new List<string>();
            string str = " update Y_User set JIFen=JIFen+" + Jifen + " where id=" + id;
            if (jifenType == 2)
            {
                str = " update Y_User set DianQuan=DianQuan+" + Jifen + " where id=" + id;
            }
            liststr.Add(str);
            string strDetail = " INSERT INTO [dbo].[JiFenDetail]([PreJiFen],[Jifen] ,[AfterJIfen],[Memo],[AddTime] ,[UID],[Account])";
            strDetail += "     VALUES(" + model.JIFen + "," + Jifen + "," + (model.JIFen + Jifen) + ",'" + Memo + "',getdate()," + id + " ,'" + model.Account + "')";
            if (jifenType == 2)
            {
                strDetail = " INSERT INTO [dbo].[DianQuanDetail]([PreJiFen],[Jifen] ,[AfterJIfen],[Memo],[AddTime] ,[UID],[Account])";
                strDetail += "     VALUES(" + model.DianQuan + "," + Jifen + "," + (model.DianQuan + Jifen) + ",'" + Memo + "',getdate()," + id + ",'" + model.Account + "' )";
            }
            liststr.Add(strDetail);
            int res = new Yax.BLL.BCommon().ExecuteSqlTran(liststr);
            return Content("充值成功");
        }



        [PowerFiler("JifenDetail11")]
        public ActionResult JifenDetail()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 ";
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account = '" + Account + "'";
            }
            Yax.BLL.JiFenDetail bll = new Yax.BLL.JiFenDetail();
            List<Yax.Model.JiFenDetail> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("DianQuanDetail11")]
        public ActionResult DianQuanDetail()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 ";
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account = '" + Account + "'";
            }
            Yax.BLL.DianQuanDetail bll = new Yax.BLL.DianQuanDetail();
            List<Yax.Model.DianQuanDetail> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        #endregion



        #region 游艇预定会员体系
        /// <summary>
        /// 游艇预定会员列表
        /// </summary>
        /// <returns></returns> 
        [PowerFiler("Memberlist11")]
        public ActionResult IndexYT()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string UserType = Yax.Common.Utils.GetSafeQueryString("UserType");
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            if (string.IsNullOrEmpty(UserType))
            {
                UserType = "普通";
            }
            ViewBag.UserType = UserType;
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and effect>0 ";
            if (!string.IsNullOrEmpty(UserType))
            {
                strWhere += " and  UserType='" + UserType + "'";
            }
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account like '%" + Account + "%'";
            }
            Yax.BLL.Y_User bll = new Yax.BLL.Y_User();
            List<Yax.Model.Y_User> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("Memberlist11")]
        public ActionResult YTMod()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            ViewBag.Account = model.Account;
            ViewBag.UserType = model.UserType;
            ViewBag.Memo = model.Memo;
            return View();
        }
        [PowerFiler("Memberlist11")]
        public ActionResult YTModPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            string pwd = Yax.Common.Utils.GetFormString("pwd");
            string UserType = Yax.Common.Utils.GetSafeFormString("UserType");
            string Memo = Yax.Common.Utils.GetSafeFormString("Memo");
            Yax.Model.Y_User model_get = new Yax.BLL.Y_User().GetModel(id);
            if(string.IsNullOrEmpty(pwd))
            {
                pwd = model_get.Pwd;
            }
            else
            {
                pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            }
            string str = " update Y_User set pwd='"+pwd+ "',UserType='"+ UserType + "',Memo='"+Memo+"' where id="+ id;
            new Yax.BLL.BCommon().ExecuteScalar(str);
            return Content("操作成功");
        }
        #endregion



        #region 视频会员体系
        [PowerFiler("MemberlistAMH11")]
        public ActionResult MemberAMH()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int VIP = Yax.Common.Utils.GetQueryInt("VIP",-1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and effect>0 ";
            if (VIP>=0)
            {
                if(VIP==0)
                {
                    strWhere += " and (VIP=0 or (vip=1 and VIPEndTime<getdate()))";
                }
                else
                {
                    strWhere += " and VIP=1 and VIPEndTime>getdate()";
                }
              
            }
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account like '%" + Account + "%'";
            }
      
            Yax.BLL.Y_User bll = new Yax.BLL.Y_User();
            List<Yax.Model.Y_User> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        public ActionResult ChongZhiVIP()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(id);
            ViewBag.Account = model.Account;
            if(model.VIP!=1)
            {
                ViewBag.vipstate = "暂未开通VIP";
            }
            else
            {
                if(model.VIPEndTime<DateTime.Now)
                {
                    ViewBag.vipstate = "VIP已过期";
                }
                else
                {
                    string VIPEndTime = model.VIPEndTime.ToString("yyyy-MM-dd");
                    if(model.VIPEndTime.Year>2200)
                    {
                        VIPEndTime = "永久";
                    }
                    ViewBag.vipstate = "已开通，到期："+ VIPEndTime;
                }
            }
            
            return View();
        }


        public ActionResult ChongZhiVIPPost()
        {
            int uid = Yax.Common.Utils.GetFormInt("id");
            int VIPTime = Yax.Common.Utils.GetFormInt("VIPTime");
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            if(model!=null)
            {
                DateTime BGTime = DateTime.Now;
                DateTime EndTime = DateTime.Now;
                if(model.VIP==1)
                {
                    if(model.VIPEndTime>DateTime.Now)
                    {
                        BGTime = model.VIPEndTime;
                    }
                }
                if(VIPTime==1)
                {
                    EndTime = BGTime.AddMonths(1);
                }
                else if(VIPTime==2)
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
                string str = " update Y_User set VIP=1,VIPEndTime='"+ EndTime + "' where ID="+uid;
                new Yax.BLL.BCommon().ExecuteScalar(str);
                new Yax.BLL.ZY_Log().AddLog(1,"为会员"+model.Account+"充值VIP");
            }
            return Content("充值VIP成功");
        }
        #endregion



        #region 暂未归类

        [PowerFiler("Memberlist11")]
        public ActionResult ShoujianAddress()
        {
            int uid = Yax.Common.Utils.GetQueryInt("id");
            List<Yax.Model.Address> listaddress = new Yax.BLL.Address().GetList_view(5, "*", " Enable=1 and userid=" + uid, "ID desc");
            ViewBag.listaddress = listaddress;
            return View();
        }


        #endregion




















    }
}
