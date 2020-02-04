using ChwYuDing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace ChwYuDing.Controllers
{
    [MemAction]
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YuDIng()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            Yax.Model.Y_User muser = new Yax.BLL.Y_User().GetModel(uid);
            Yax.Model.Chw_Boat mBoat = new Yax.BLL.Chw_Boat().GetModel(id);
            ViewBag.RealName = muser.RealName;
            ViewBag.Phone = muser.Phone;
            ViewBag.Name = mBoat.Name;
            string istimeerrStr = "select * from Chw_Order where   BoatID=" + id + " and EndTime>getdate() and state in('待审核','已审核')";
            DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(istimeerrStr);
            ViewBag.dt = dt;
            return View();
        }
        public ActionResult YuDIngPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string usertype = new Yax.BLL.QuickData.CurrentUserMV().UserType;
            if(usertype!="超级")
            {
                return Content("您的会员权限不足，请联系客服");
            }
            int BoatID= Yax.Common.Utils.GetFormInt("id");
            Yax.Model.Chw_Boat mBoat = new Yax.BLL.Chw_Boat().GetModel(BoatID);
            int PeopleNum = Yax.Common.Utils.GetFormInt("PeopleNum");
            string RealName= Yax.Common.Utils.GetSafeFormString("RealName");
            string Phone = Yax.Common.Utils.GetSafeFormString("Phone");
            DateTime BeginTime = Yax.Common.Utils.GetFormDate("BeginTime");
            int zuHour = Yax.Common.Utils.GetFormInt("zuHour");
            DateTime EndTime = BeginTime.AddHours(zuHour);
            string Memo = Yax.Common.Utils.GetSafeFormString("Memo");
            if (!Yax.Common.ValidateHelper.IsPhone(Phone))
            {
                return Content("请输入正确的联系手机号");
            }
            if(PeopleNum==0)
            {
                return Content("请输入你们的人数（整数）");
            }
            if(PeopleNum>mBoat.MaxNum)
            {
                return Content("此艘游艇最多承载"+mBoat.MaxNum+"人");
            }
            if(zuHour==0)
            {
                return Content("请输入您要租多久");
            }
            string istimeerrStr = "select * from Chw_Order where (BeginTime>'"+BeginTime+"' and BeginTime<'"+EndTime+"' )or (BeginTime<'"+BeginTime+"' and EndTime>'"+BeginTime+"') and BoatID="+BoatID+ " and EndTime>getdate() and state in('待审核','已审核')";
            DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(istimeerrStr);
            if(dt.Rows.Count>0)
            {
                string chongTu = dt.Rows[0]["BeginTime"]+ "-"+ dt.Rows[0]["EndTime"]+"被预定，与您的预定时间存在冲突，请重新编辑提交您的预定时间";
                return Content(chongTu);
            }

            string str = " update Y_User set RealName='"+ RealName + "',Phone='"+Phone+"' where id="+uid;
            new Yax.BLL.BCommon().ExecuteScalar(str);
            Yax.Model.Chw_Order model = new Yax.Model.Chw_Order();
            model.AddTime = DateTime.Now;
            model.BeginTime = BeginTime;
            model.BoatID = BoatID;
            model.EndTime = EndTime;
            model.Memo = Memo;
            model.OrderNO = "NO" + Yax.Common.Utils.RandomDateCard() + Yax.Common.Utils.RandStr(2);
            model.PeopleNum = PeopleNum;
            model.Phone = Phone;
            model.State = "待审核";
            model.UID = uid;
            new Yax.BLL.Chw_Order().Add(model);

            return Content("ok");
        }
        public ActionResult MyYuDing()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 30;
            int TotalCount = 0;
            int TotalPage = 0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " UID=" + uid;

            DataTable dt = new Yax.BLL.BCommon().GetPagerViewData(pageIndex, pageSize, strWhere, "ID desc", "View_ChwBoatOrder", out TotalCount, out TotalPage);
            ViewBag.dt = dt;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            return View();
        }

        public ActionResult GetEndDate()
        {
            DateTime BeginTime = Yax.Common.Utils.GetFormDate("BeginTime",DateTime.Now.AddYears(-100));
            int zuHour = Yax.Common.Utils.GetFormInt("zuHour");
            if(BeginTime>DateTime.Now.AddYears(-50))
            {
                if(zuHour>=1)
                {
                    return Content(BeginTime.AddHours(zuHour).ToString("yyyy年MM月dd日 HH时mm分"));
                }
            }
            return Content("");
        }


    }
}