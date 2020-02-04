using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MVWeb.Filters;

namespace MVWeb.Controllers
{
    [MemAction]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int TotalRecord = 0;
            int TotalPage = 0;
            List<Yax.Model.M_ManHua> list = new Yax.BLL.M_ManHua().GetPage(1,12, " Enable=1","Sort desc","*",out TotalRecord,out TotalPage);
            ViewBag.list = list;
            ViewBag.filePath = new Yax.BLL.Config().GetModelBy_key("manhuapicpath").Value;
            return View();
        }
        public ActionResult IndexMHAjax()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string filePath = new Yax.BLL.Config().GetModelBy_key("manhuapicpath").Value;
            string strWhere = " Enable=1";
            int PIndex = Yax.Common.Utils.GetFormInt("PIndex");
            int TotalRecord = 0;
            int TotalPage = 0;
            List<Yax.Model.M_ManHua> list = new Yax.BLL.M_ManHua().GetPage(PIndex, 12, strWhere, "Sort desc", "*", out TotalRecord, out TotalPage);
            if (list != null && list.Count > 0)
            {
                StringBuilder sb = new StringBuilder(2000);
                for (int i = 0; i < list.Count; i++)
                {
                    int XUHao = (PIndex - 1) * 10 + i + 1;
                    sb.Append("<div class=\"span3 col-sm-6\">");
                    sb.Append(" <a href=\"/home/MHView?id="+list[i].ID+"\" class=\"kzlistLi\">");
                    sb.Append("<div class=\"kzimage\">");
                    sb.Append("<img src=\""+ filePath+ list[i].Cover + "\" />");
                    sb.Append("</div>");
                    sb.Append(" <p class=\"kzbrief\">");
                    sb.Append(list[i].Name);
                    sb.Append(" </p></a>  </div>");
                }
                return Content(sb.ToString());
            }
            else
            {
                return Content("no");
            }
            return Content("");
        }
        public ActionResult MHView()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string filePath = new Yax.BLL.Config().GetModelBy_key("manhuapicpath").Value;
            ViewBag.filePath = filePath;
            Yax.Model.M_ManHua model = new Yax.BLL.M_ManHua().GetModel(id);
            if(model!=null)
            {
                string str = "select id from UserLike where uid="+ uid+ " and GID="+id;
                DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(str);
                if(dt.Rows.Count>0)
                {
                    ViewBag.likestr = "已收藏";
                }
                else
                {
                    ViewBag.likestr = "加入收藏";
                }
                ViewBag.Name = model.Name;
                ViewBag.Introduce = model.Introduce;
                ViewBag.Cover = filePath+ model.Cover;
                List<Yax.Model.M_Chapter> list = new Yax.BLL.M_Chapter().GetList(-1,"*", " Enable=1 and ManHuaID="+ id, " Sort desc");
                ViewBag.list = list;
            }
            return View();
        }

        public ActionResult MHDoLikePost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
           
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            if (uid <= 0)
            {
                return Content("请先登录");
            }
            string str = "select id from UserLike where uid=" + uid + " and GID=" + id;
            DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(str);
            if (dt.Rows.Count > 0)
            {
                return Content("f");
            }
            else
            {
                Yax.Model.M_ManHua model = new Yax.BLL.M_ManHua().GetModel(id);
                string stradd = " INSERT INTO [dbo].[UserLike]([UID] ,[GID],[AddTime] ,[Enable],[Name])";
                stradd += " VALUES(" + uid + "," + id + ",getdate(),1,'"+model.Name+"')";
                new Yax.BLL.BCommon().ExecuteScalar(stradd);
            }
            return Content("ok");
        }


        public ActionResult MHPic()
        {
            int cid = Yax.Common.Utils.GetQueryInt("cid");
            int mid = 0;
            string name = "";
            string cname ="";
            int csort = 0;
            int TotalRecord = 0;
            int TotalPage = 0;
            string strWhere = "  cid="+cid ;
            DataTable dt= new Yax.BLL.BCommon().GetPagerViewData(1,1,strWhere ,"sort asc", "View_Manhua_MHPic", out TotalRecord,out TotalPage);
            ViewBag.TotalRecord = TotalRecord;
            if(dt != null&& dt.Rows.Count>0)
            {
                ViewBag.pic = dt.Rows[0]["ImgUrl"];
                ViewBag.mid=mid =int.Parse(dt.Rows[0]["mid"].ToString());
                ViewBag.name= name= dt.Rows[0]["Name"].ToString();
                ViewBag.cname = cname = dt.Rows[0]["cname"].ToString();
                csort = int.Parse(dt.Rows[0]["csort"].ToString());
            }
            //下一章 4 5 6  7
            string str = " select top 1 m.id mid,m.Name,c.Name cname,c.id cid, p.ID,p.ImgUrl from M_Pic p left join M_Chapter c on p.ChapterID=c.ID left join M_ManHua m on c.ManHuaID=m.ID ";
            str += " where c.ManHuaID = " + mid + " and c.Enable = 1 and c.sort>" + csort + " order by c.sort asc";
            DataTable dtnext = new Yax.BLL.BCommon().GetDataBySQL(str);
            if(dtnext != null&& dtnext.Rows.Count>0)
            {
                ViewBag.nextName = dtnext.Rows[0]["cname"];
                ViewBag.nextUrl = "/home/MHPic?cid="+ dtnext.Rows[0]["cid"] ;
            }
            str = " select top 1 m.Name,c.Name cname,c.id cid, p.ID,p.ImgUrl from M_Pic p left join M_Chapter c on p.ChapterID=c.ID left join M_ManHua m on c.ManHuaID=m.ID ";
            str += " where c.ManHuaID = " + mid + " and c.Enable = 1 and c.sort<" + csort + " order by c.sort desc";
            DataTable dtPre = new Yax.BLL.BCommon().GetDataBySQL(str);
            if (dtPre != null && dtPre.Rows.Count > 0)
            {
                ViewBag.preName = dtPre.Rows[0]["cname"];
                ViewBag.preUrl = "/home/MHPic?cid=" + dtPre.Rows[0]["cid"];
            }
            return View();
        }
        public ActionResult MHPicAjax()
        {
            int cid = Yax.Common.Utils.GetFormInt("cid");
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 1;
            int TotalCount;
            int TotalPage;
            string strWhere = "ChapterID=" + cid + " and Enable=1";
            Yax.BLL.M_Pic bll = new Yax.BLL.M_Pic();
            List<Yax.Model.M_Pic> list = bll.GetPage(pageIndex, pageSize, strWhere, "Sort asc", "*", out TotalCount, out TotalPage);
            StringBuilder sb = new StringBuilder(2000);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sb.AppendLine("<img src=\""+list[i].ImgUrl+"\" style=\"width: 100 %;\" />");
                }
                return Content(sb.ToString());
            }
            else
            {
                return Content("no");
            }
        }




        public ActionResult test()
        {
            return View();
        }
    }
}