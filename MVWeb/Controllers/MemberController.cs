using MVWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVWeb.Controllers
{
    [MemAction]
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            string strSort = " select top 1 ID from Article where ArticleTypeID=2 order by SOrt desc ";
            object obj = new Yax.BLL.BCommon().ExecuteScalar(strSort);
            ViewBag.Latestid = obj.ToString();
            return View();
        }
        public ActionResult MyJifen()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 10;
            int TotalCount=0;
            int TotalPage=0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            ViewBag.JIFen = model.JIFen;
            ViewBag.DianQuan = model.DianQuan;
            string strWhere = "";
            string tp = Yax.Common.Utils.GetSafeQueryString("tp");
            if(string.IsNullOrEmpty(tp))
            {
                strWhere = " UID="+uid;
                List<Yax.Model.JiFenDetail> list =new Yax.BLL.JiFenDetail().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
                ViewBag.list = list;
            }
            else if (tp== "dq")
            {
                strWhere = " UID=" + uid;
                List<Yax.Model.DianQuanDetail> list = new Yax.BLL.DianQuanDetail().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
                ViewBag.list = list;
            }
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View();
        }


        public ActionResult Mylike()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 10;
            int TotalCount = 0;
            int TotalPage = 0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " UID=" + uid;
            List<Yax.Model.UserLike> list = new Yax.BLL.UserLike().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.list = list;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            return View();
        }

        public ActionResult MyLikeAjax()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " UId=" + uid;
            int PIndex = Yax.Common.Utils.GetFormInt("PIndex");
            int TotalRecord = 0;
            int TotalPage = 0;
            List<Yax.Model.UserLike> list = new Yax.BLL.UserLike().GetPage(PIndex, 10, strWhere, "ID desc", "*", out TotalRecord, out TotalPage);
            if (list != null && list.Count > 0)
            {
                StringBuilder sb = new StringBuilder(2000);
                for (int i = 0; i < list.Count; i++)
                {
                    int XUHao = (PIndex - 1) * 10 + i + 1;
                    sb.Append("<tr>");
                    sb.Append("<td >" + XUHao + "</td>");
                    sb.Append("  <td><a href=\"/home/MHView?id="+list[i].GID+ "\">"+list[i].Name+"</a></td>");
                    sb.Append(" </tr>");
                }
                return Content(sb.ToString());
            }
            else
            {
                return Content("no");
            }
            return Content("");
        }
        public ActionResult MyJifenAjax()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " uid="+uid;
            int PIndex = Yax.Common.Utils.GetFormInt("PIndex");
            int TotalRecord = 0;
            int TotalPage = 0;
            string tp = Yax.Common.Utils.GetSafeFormString("tp");
            if (string.IsNullOrEmpty(tp))
            {
                List<Yax.Model.JiFenDetail> list = new Yax.BLL.JiFenDetail().GetPage(PIndex, 10, strWhere, "ID desc", "*", out TotalRecord, out TotalPage);
                if (list != null && list.Count > 0)
                {
                    StringBuilder sb = new StringBuilder(2000);
                    for (int i = 0; i < list.Count; i++)
                    {
                        int XUHao = (PIndex - 1) * 10 + i + 1;
                        string spanJiaJian = "+";
                        if(list[i].PreJiFen>list[i].AfterJIfen)
                        {
                            spanJiaJian = "-";
                        }
                        sb.Append("<tr>");
                        sb.Append("<td >" + XUHao + "</td>");
                        sb.Append(" <td >"+ spanJiaJian + list[i].Jifen + "</td>");
                        sb.Append(" <td >" + list[i].Memo + "</td>");
                        sb.Append(" <td >" + list[i].AddTime.ToString("yyyy-MM-dd") + "</td>");
                        sb.Append(" </tr>");
                    }
                    return Content(sb.ToString());
                }
                else
                {
                    return Content("no");
                }
            }
            else if (tp == "dq")
            {
                strWhere = " UID=" + uid;
                List<Yax.Model.DianQuanDetail> list = new Yax.BLL.DianQuanDetail().GetPage(PIndex, 10, strWhere, "ID desc", "*", out TotalRecord, out TotalPage);
                if (list != null && list.Count > 0)
                {
                    StringBuilder sb = new StringBuilder(2000);
                    for (int i = 0; i < list.Count; i++)
                    {
                        int XUHao = (PIndex - 1) * 10 + i + 1;
                        string spanJiaJian = "+";
                        if (list[i].PreJiFen > list[i].AfterJIfen)
                        {
                            spanJiaJian = "-";
                        }
                        sb.Append("<tr>");
                        sb.Append("<td >" + XUHao + "</td>");
                        sb.Append(" <td >"+ spanJiaJian + list[i].Jifen + "</td>");
                        sb.Append(" <td >" + list[i].Memo + "</td>");
                        sb.Append(" <td >" + list[i].AddTime.ToString("yyyy-MM-dd") + "</td>");
                        sb.Append(" </tr>");
                    }
                    return Content(sb.ToString());
                }
                else
                {
                    return Content("no");
                }
            }
            else
            {
                return Content("no");
            }
            return Content("");
        }

        /// <summary>
        /// 添加会员码
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserCode()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            string RegPreUrl = new Yax.BLL.Config().GetModelBy_key("mvWebUrl").Value+"/login/RegC?rcode=";//mvWebUrl
            ViewBag.JIFen = model.JIFen;
            ViewBag.DianQuan = model.DianQuan;
            ViewBag.RegPreUrl = RegPreUrl;
            Yax.Model.Config mc = new Yax.BLL.Config().GetModelBy_key("MVMakeregcodejifen");
            ViewBag.jfval = mc.Value;
            string strWhere = "AgentID="+uid+ " and UseTime=0";
            List<Yax.Model.M_RegUserCode> list = new Yax.BLL.M_RegUserCode().GetList(20,"*",strWhere,"ID desc");
            ViewBag.list = list;
            return View();
        }
        public ActionResult MakeRegUserCodestr()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User muser = new Yax.BLL.Y_User().GetModel(uid);
            if(muser.UserType == "代理")
            {
                string RegUserCode ="R"+Yax.Common.Utils.RandStr(12);
                Yax.Model.M_RegUserCode mcode = new Yax.BLL.M_RegUserCode().GetModelBy_code(RegUserCode);
                if(mcode!=null)
                {
                    return Content("生成失败,请重新生成");
                }
                else
                {
                    List<string> listSQL = new List<string>();
                  
                    string temp = new Yax.BLL.Config().GetModelBy_key("MVMakeregcodejifen").Value;
                    int subJiFen = int.Parse(temp.ToString());  //需要扣除的点数
                    int DianQUanPay = 0;
                    int JiFenPay = 0;
                    if((muser.DianQuan+muser.JIFen)<subJiFen)
                    {
                        return Content("点券积分不足");
                    }
                    if(muser.DianQuan>= subJiFen)
                    {
                        DianQUanPay = subJiFen;
                        JiFenPay = 0;
                    }
                    else
                    {
                        if(muser.DianQuan>0)
                        {
                            DianQUanPay = muser.DianQuan;
                            JiFenPay = subJiFen - DianQUanPay;
                        }
                        else
                        {
                            DianQUanPay = 0;
                            JiFenPay = subJiFen;
                        }
                    }
                    //点券支付
                    if(DianQUanPay>0)
                    {
                        listSQL.Add(" update Y_User set DianQuan=" + (muser.DianQuan - DianQUanPay) + " where id=" + uid);
                        string strSQL_dianquan = " INSERT INTO [dbo].[DianQuanDetail]([PreJiFen] ,[Jifen] ,[Memo] ,[AddTime],[UID] ,[AfterJIfen],[Account])";
                        strSQL_dianquan += " VALUES(" + muser.DianQuan + "," + DianQUanPay + ",'生成注册码',getdate()," + uid + "," + (muser.DianQuan - DianQUanPay) + ",'" + muser.Account + "')";
                        listSQL.Add(strSQL_dianquan);
                    }
                    if(JiFenPay>0)
                    {
                        listSQL.Add(" update Y_User set JIFen=" + (muser.JIFen - JiFenPay) + " where id=" + uid);
                        string strSQL_JIfen = "INSERT INTO [dbo].[JiFenDetail]([PreJiFen],[Jifen],[AfterJIfen],[Memo],[AddTime],[UID],[Account])";
                        strSQL_JIfen += " VALUES("+muser.JIFen+","+JiFenPay+","+(muser.JIFen-JiFenPay)+ ",'生成注册码',getdate(),"+uid+",'"+muser.Account+"')";
                        listSQL.Add(strSQL_JIfen);
                    }
                    //生成注册码
                    string strSQL = "INSERT INTO [dbo].[M_RegUserCode]([AgentID],[RegCode],[AgentAccount],[UseTime],[AddTime] ,[RType],[Memo])";
                    strSQL += "VALUES(" + uid + ",'" + RegUserCode + "','" + muser.Account + "',0,getdate(),1,'')";
                    listSQL.Add(strSQL);
                    int res= new Yax.BLL.BCommon().ExecuteSqlTran(listSQL);
                    if(res>0)
                    {
                        return Content("生成成功");
                    }
                    else
                    {
                        return Content("系统繁忙");
                    }
                }
            }
            else
            {
                return Content("权限不足");
            }
            return Content("");
        }


        public ActionResult MyUser()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 10;
            int TotalCount = 0;
            int TotalPage = 0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " AgentID=" + uid;
            List<Yax.Model.Y_User> list = new Yax.BLL.Y_User().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.list = list;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            return View();
        }
        public ActionResult MyUserAjax()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " AgentID=" + uid;
            int PIndex = Yax.Common.Utils.GetFormInt("PIndex");
            int TotalRecord = 0;
            int TotalPage = 0;
            List<Yax.Model.Y_User> list = new Yax.BLL.Y_User().GetPage(PIndex, 10, strWhere, "ID desc", "*", out TotalRecord, out TotalPage);
            if (list != null && list.Count > 0)
            {
                StringBuilder sb = new StringBuilder(2000);
                for (int i = 0; i < list.Count; i++)
                {
                    int XUHao = (PIndex - 1) * 10 + i + 1;
                    sb.Append("<tr>");
                    sb.Append("<td >" + XUHao + "</td>");
                    sb.Append("<td>" + list[i].Account + "</td>");
                    sb.Append(" <td >" + list[i].UserType + "</td>");
                    sb.Append(" <td >" + list[i].AddTime.ToString("yyyy-MM-dd") + "</td>");
                    sb.Append(" </tr>");
                }
                return Content(sb.ToString());
            }
            else
            {
                return Content("no");
            }
            return Content("");
        }


        public ActionResult BindTiXianBank()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            ViewBag.ContactMan = model.ContactMan;
            return View();
        }
        public ActionResult BindTiXianBankPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            string ContactMan = Yax.Common.Utils.GetSafeFormString("wxbank");
            if (!string.IsNullOrEmpty(model.ContactMan))
            {
                return Content("您已绑定微信号，无法修改");
            }
            else
            {
                new Yax.BLL.BCommon().UpdateOneField("Y_User", "ContactMan", ContactMan,"id="+uid,null);
                return Content("绑定成功");
            }
        }
        public ActionResult TiXian()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            ViewBag.JIFen = model.JIFen;
            ViewBag.ContactMan = model.ContactMan;

            int TotalCount = 0;
            int TotalPage = 0;
            string strWhere = " UserID=" + uid;
            List<Yax.Model.TiXian> list = new Yax.BLL.TiXian().GetPage(1, 20, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.list = list;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            return View();
        }
        public ActionResult TiXianPost()
        {
            decimal money = Yax.Common.Utils.GetFormDecimal("money");
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            if(money<10)
            {
                return Content("最低提现金额10元");
            }
            if(model.JIFen>=(money*10))
            {
                if(!string.IsNullOrEmpty(model.ContactMan))
                {
                    List<string> listSQL = new List<string>();
                    listSQL.Add(" update Y_User set JIFen=" + (model.JIFen - (money * 10)) + " where id=" + uid);
                    string strSQL_JIfen = "INSERT INTO [dbo].[JiFenDetail]([PreJiFen],[Jifen],[AfterJIfen],[Memo],[AddTime],[UID],[Account])";
                    strSQL_JIfen += " VALUES(" + model.JIFen + "," + (money * 10) + "," + (model.JIFen - (money * 10)) + ",'积分提现',getdate()," + uid + ",'" + model.Account + "')";
                    listSQL.Add(strSQL_JIfen);
                    string strTemp = " INSERT INTO [dbo].[TiXian]([RealName],[BankNO] ,[Money],[AddTime],[PreMoney],[AfterMoney],[UserID],[Enable] ,[State],[Memo])";
                    strTemp += " VALUES ('"+model.Account+"','"+ model.ContactMan + "',"+money+",getdate(),"+model.JIFen+","+(model.JIFen- money*10) +","+uid+",1,1,'')";
                    listSQL.Add(strTemp);
                    int res= new Yax.BLL.BCommon().ExecuteSqlTran(listSQL);
                    if(res>0)
                    {
                        return Content("提现成功");
                    }
                    else
                    {
                        return Content("系统繁忙");
                    }
                }
                else
                {
                    return Content("您还未绑定您的微信提现账户");
                }
            }
            else
            {
                return Content("您当前账户积分"+model.JIFen+",最多可提现"+(model.JIFen/10)+"元");
            }
            return Content("");
        }

        
        public ActionResult ModPwd()
        {
            return View();
        }
        public ActionResult ModPwdPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
            string opwd = Yax.Common.Utils.GetFormString("opwd").Trim();
            string pwd = Yax.Common.Utils.GetFormString("pwd").Trim();
            if(string.IsNullOrEmpty(pwd))
            {
                return Content("新密码不能为空");
            }
            if(Yax.Common.SecurityHelper.DifferentMD5(opwd)==model.Pwd)
            {
                string str = " update Y_User set pwd='"+Yax.Common.SecurityHelper.DifferentMD5(pwd)+"' where id="+uid;
                new Yax.BLL.BCommon().ExecuteScalar(str);
                return Content("修改成功");
            }
            else
            {
                return Content("密码输入错误");
            }
            return Content("");
        }

        public ActionResult NewsView()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Article model = new Yax.BLL.Article().GetModel(id);
            new Yax.BLL.BCommon().UpdateOneFieldAdd("Article", "Hits", "1", "id=" + id);
            ViewBag.Name = model.Name;
            ViewBag.Detail = model.Detail;
            ViewBag.Hits = model.Hits+1;
            return View();
        }


        public ActionResult LoginIP()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 30;
            int TotalCount = 0;
            int TotalPage = 0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " UID=" + uid;
            List<Yax.Model.UserLoginIP> list = new Yax.BLL.UserLoginIP().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.list = list;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            return View();
        }



        public ActionResult DailyList()
        {
            int utype = Yax.Common.Utils.GetQueryInt("utype",2);
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 31;
            int TotalCount = 0;
            int TotalPage = 0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " ArticleTypeID=" + utype;
            List<Yax.Model.Article> list = new Yax.BLL.Article().GetPage(pageIndex, pageSize, strWhere, "Sort desc", "*", out TotalCount, out TotalPage);
            ViewBag.list = list;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            return View();
        }

    }
}