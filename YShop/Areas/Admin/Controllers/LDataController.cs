using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class LDataController : Controller
    {
        //
        // GET: /Admin/LData/

        [PowerFiler("LData19")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "Enable=1";
            string GroupName = Yax.Common.Utils.GetSafeQueryString("Name"); 
            if (!string.IsNullOrEmpty(GroupName))
            {
                strWhere += "  and  keyName like '%" + GroupName + "%'";
            }
           
            DataTable dt=new Yax.BLL.L_Data().GetPage_view(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);

            string keypwd = new Yax.BLL.Config().GetModelBy_key("jiajiemipwd").Value;
            ViewBag.keypwd = keypwd;
            return View(dt);
        }
        [PowerFiler("LData19")]
        public ActionResult LDataAdd()
        {
            int t1;
            int t2;
            List<Yax.Model.L_DataType> listType = new Yax.BLL.L_DataType().GetPage(1, 100, " Enable=1 ", "ID desc", "*", out t1, out t2);
            ViewBag.listType = listType;

            int id = Yax.Common.Utils.GetQueryInt("id");
            if(id>0)
            {
                string keypwd = new Yax.BLL.Config().GetModelBy_key("jiajiemipwd").Value;
                Yax.Model.L_Data model = new Yax.BLL.L_Data().GetModel(id);
                ViewBag.KeyName = model.KeyName;
                ViewBag.DataTypeID = model.DataTypeID;
                ViewBag.Data = Yax.Common.SecurityHelper.Decrypt_jie(model.Data,keypwd);
            }
            else
            {
                if(listType!=null&&listType.Count>0)
                {
                    ViewBag.DataTypeID = listType[0].ID;
                }
            }
           
            return View();
        }
        [PowerFiler("LData19")]
        public ActionResult LDataAddPost(Yax.Model.L_Data model)
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            int res;
            string keypwd = new Yax.BLL.Config().GetModelBy_key("jiajiemipwd").Value;
            if(string.IsNullOrEmpty(model.Data))
            {
                model.Data = "";
            }
            model.Data = Yax.Common.SecurityHelper.Encrypt_jia(model.Data, keypwd);
            if(id>0)
            {
                model.ID = id;
                res= new Yax.BLL.L_Data().Update_info(model);
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                model.SearchWord = "";
                res= new Yax.BLL.L_Data().Add(model);
            }
            if(res>0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            return View();
        }

        [PowerFiler("Ldatatype18")]
        public ActionResult LDataType()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "Enable=1";
            string GroupName = Yax.Common.Utils.GetSafeQueryString("GroupName"); 
            if (!string.IsNullOrEmpty(GroupName))
            {
                strWhere += "  and  Name like '%" + GroupName + "%'";
            }
            Yax.BLL.L_DataType bll = new Yax.BLL.L_DataType();
            List<Yax.Model.L_DataType> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("Ldatatype18")]
        public ActionResult LDataTypeAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if(id>0)
            {
                Yax.Model.L_DataType model = new Yax.BLL.L_DataType().GetModel(id);
                if(model!=null)
                {
                    ViewBag.Name = model.Name;
                }
            }
            return View();
        }
        [PowerFiler("Ldatatype18")]
        public ActionResult LDataTypeAddPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            Yax.Model.L_DataType model = new Yax.Model.L_DataType();
            model.Name = Request.Form["Name"].Trim();
            int res = 0;
            if(id>0)
            {
                model.ID = id;
                res= new Yax.BLL.L_DataType().UpdateName(model);
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                res= new Yax.BLL.L_DataType().Add(model);
            }
            if(res>0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            return View();
        }



    }
}
