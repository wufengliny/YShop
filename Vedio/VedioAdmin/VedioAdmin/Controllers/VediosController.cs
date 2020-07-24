using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VedioAdmin.Filters;
using BLL;
using Entity;
using Webdiyer.WebControls.Mvc;
using System.CodeDom;

namespace VedioAdmin.Controllers
{
    [IsAuditorFilter]
    public class VediosController : BaseController
    {
        // GET: Vedios
        #region 视频
        [Power("Vedios", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Index(string Name = "", string Category = "", string Tag = "", int SeriousID = 0, string fromTime = "", string endTime = "",int Pricetype=0,int SortType=0, int pi = 1)
        {
            string strWhere = " where  cv.Enable=1 ";
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += " and cv.Name like'%" + Name + "%'";
            }
            if (!string.IsNullOrEmpty(Category))
            {
                strWhere += " and cv.Category='" + Category + "'";
            }
            if (!string.IsNullOrEmpty(Tag))
            {
                strWhere += " and cv.Tag like'%" + Tag + "%'";
            }
            if (SeriousID > 0)
            {
                strWhere += " and cv.SeriousID=" + SeriousID;
            }
            if (!string.IsNullOrEmpty(fromTime))
            {
                strWhere += " and cv.AddTime>'" + fromTime + "'";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += " and cv.AddTime<'" + endTime + "'";
            }
            if (Pricetype > 0)
            {
                if(Pricetype==1)
                {
                    strWhere += " and cv.Price=0";
                }
                else
                {
                    strWhere += " and cv.Price>0";
                }
            }
            string SortStr = string.Empty;
            switch(SortType)
            {
                case 0:
                    SortStr = " [IsTop] Desc,[Sort] desc";
                    break;
                case 1:
                    SortStr = " AddTime desc";
                    break;
                case 2:
                    SortStr = " AddTime asc";
                    break;
                case 3:
                    SortStr = " Price Desc";
                    break;
                case 4:
                    SortStr = " Price asc";
                    break;
                case 5:
                    SortStr = " Hits Desc";
                    break;
                case 6:
                    SortStr = " Hits asc";
                    break;
                case 7:
                    SortStr = " Likes desc";
                    break;
                case 8:
                    SortStr = " Likes asc";
                    break;
            }
            var list = new BC_Vedios().Pager(pi, 20, strWhere, SortStr);
            ViewBag.tags = new BC_Tags().List();
            ViewBag.serious = new BC_Serious().List();
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            return View(list);
        }





        [HttpGet]
        [Power("VediosAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult Add(int ID = 0)
        {

            ViewBag.tags = new BC_Tags().List();
            ViewBag.serious = new BC_Serious().List();
            MC_Vedios model = new MC_Vedios();
            if (ID > 0)
            {
                model = new BC_Vedios().GetModelByID(ID);
                ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            }
            else
            {
                model.Category = "国产";
                model.Price = 0;
                model.Tag = "";
            }
            return View(model);
        }
        [HttpPost]
        [Power("VediosAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Add(string txtName, string CategoryA, string Url, string VedioLong = "", decimal Price = 0, string Cover = "", string tags = "", string Seriousname = "")
        {

            MC_Vedios model = new MC_Vedios();
            model.Name = txtName;
            model.Tag = tags;
            model.VedioLong = VedioLong;
            model.Category = CategoryA;
            model.PreUrl = new BS_Config().GetModelByKey("vediourl").Value;//
            model.Url = Url;
            model.Cover = Cover;
            model.Sort = new BC_Vedios().GetMaxSort(); //
            if (Price < 0)
            {
                Price = 0;
            }
            model.Price = Price;
            if (string.IsNullOrEmpty(Seriousname))
            {
                model.SeriousID = 0;
            }
            else
            {
                var seriousModel = new BC_Serious().GetModelByName(Seriousname);
                if (seriousModel != null)
                {
                    model.SeriousID = seriousModel.ID;
                }
                else
                {
                    model.SeriousID = 0;
                }
            }
            //
            model.Actor = "";
            model.AddTime = DateTime.Now;
            model.Enable = 1;
            model.FreeDownNum = 0;
            model.FreePartUrl = "";
            model.FromCoverUrl = "";
            model.FromPageUrl = "";
            model.FromSite = "sys";
            model.FromVedioUrl = "";
            model.Goods = 0;
            model.Hits = 0;
            model.Introduce = "";
            model.Likes = 0;
            model.Memo = "";
            model.SinglePayDownLoadNum = 0;
            model.VIPDownNum = 0;
            model.IsTop=0;
            int res = new BC_Vedios().Add(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }



        [HttpPost]
        [Power("VediosEdit", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Edit(string txtName, int ID, string CategoryA, decimal Price = 0, string Cover = "", string tags = "", string Seriousname = "",string Url="",string VedioLong="")
        {
            MC_Vedios model = new MC_Vedios();
            model.Name = txtName;
            model.Category = CategoryA;
            model.Cover = Cover;
            model.Tag = tags;
            model.Url = Url;
            model.VedioLong = VedioLong;
            if (Price < 0)
            {
                Price = 0;
            }
            model.Price = Price;
            if (string.IsNullOrEmpty(Seriousname))
            {
                model.SeriousID = 0;
            }
            else
            {
                var seriousModel = new BC_Serious().GetModelByName(Seriousname);
                if (seriousModel != null)
                {
                    model.SeriousID = seriousModel.ID;
                }
                else
                {
                    model.SeriousID = 0;
                }
            }
            model.ID = ID;
            int res = new BC_Vedios().Update(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [Power("VediosDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Delete(int ID)
        {
            int res = new BC_Vedios().UpdateEnable(ID, 0);
            if (res > 0)
            {
                OperateLogAdd("删除视频ID:" + ID, false);
                return Content("操作成功");
            }
            else
            {
                return Content("删除失败");
            }
        }

        /// <summary>
        /// 回收站
        /// </summary>
        /// <returns></returns>
        [Power("VediosRecycle", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult VedioRecycle(int pi = 1)
        {
            string strWhere = " where  cv.Enable=0";
            var list = new BC_Vedios().Pager(pi, 20, strWhere, " [Sort] asc,AddTime desc ");
            return View(list);
        }
        [Power("VediosRecycleBack", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult RecycleBack(int ID)
        {
            int res = new BC_Vedios().UpdateEnable(ID, 1);
            if (res > 0)
            {
                OperateLogAdd("还原视频ID:" + ID, false);
                return Content("操作成功");
            }
            else
            {
                return Content("还原失败");
            }
        }
        [Power("VediosRecycleDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult RecycleDelete(int ID)
        {
            int res = new BC_Vedios().DeleteHard(ID);
            //后期优化》 删除视频文件  封面图片  
            if (res > 0)
            {
                OperateLogAdd("回收站删除视频ID:" + ID, false);
                return Content("操作成功");
            }
            else
            {
                return Content("回收站删除视频失败");
            }
        }


        /// <summary>
        /// 视频播放
        /// </summary>
        /// <returns></returns>
        [Power("VediosPlay", ComEnum.OpenTypeEnum.Page)]
        public ActionResult Play(int ID)
        {
            MC_Vedios model = new BC_Vedios().GetModelByID(ID);
            return View(model);
        }
        /// <summary>
        /// 设置价格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Power("VediosPriceSet", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult PriceSet(int ID)
        {
            MC_Vedios model = new BC_Vedios().GetModelByID(ID);
            return View(model);
        }
        [HttpPost]
        [Power("VediosPriceSet", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult PriceSet(int ID,Decimal txtPrice=0)
        {
            if(txtPrice<0)
            {
                txtPrice = 0;
            }
            int res= new BC_Vedios().UpdatePrice(ID,txtPrice);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        [Power("VediosSetTop", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SetTop(int ID,int topval)
        {
            if(topval!=0)
            {
                topval = 1;
            }
            int res = new BC_Vedios().UpdateTop(ID, topval);
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
        /// 浏览量  收藏  点赞 -- 添加时间
        /// </summary>
        /// <returns></returns>
        [Power("VediosSetOther", ComEnum.OpenTypeEnum.Dialog)]
        [HttpGet]
        public ActionResult SetOther(int ID)
        {
            MC_Vedios model = new BC_Vedios().GetModelByID(ID);
            return View(model);
        }
        [HttpPost]
        [Power("VediosSetOther", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SetOther(int ID, int txtHits,int txtGoods,int txtLikes)
        {
            int res= new BC_Vedios().UpdateOther(ID,txtHits,txtGoods,txtLikes);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        #endregion


        #region 系列
        [Power("VedioSerious", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Serious(int pi=1)
        {
            PagedList<MC_Serious> list = new BC_Serious().Pager(pi, PageSize, "Sort asc");
            return View(list);
        }
        [HttpGet]
        [Power("VedioSeriousAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult SeriousAdd()
        {
            return View();
        }
        [HttpPost]
        [Power("VedioSeriousAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SeriousAdd(string name)
        {
            var model = new BC_Serious().GetModelByName(name);
            if (model != null)
            {
                return Content("系列已存在");
            }
            else
            {
                model = new MC_Serious();
                model.Name = name;
                model.Sort = 100000;
                int res = new BC_Serious().Add(model);
                if (res > 0)
                {
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
        }

        [HttpGet]
        [Power("VedioSeriousEdit", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult SeriousEdit(int ID)
        {
            var model = new BC_Serious().GetModelByID(ID);
            return View(model);
        }
        [HttpPost]
        [Power("VedioSeriousEdit", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SeriousEdit(int ID,string name)
        {
            MC_Serious model = new MC_Serious();
            model.ID = ID;
            model.Name = name;
            int res= new BC_Serious().Edit(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [Power("VedioSeriousDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SeriousDelete(int ID)
        {
            var model = new BC_Serious().GetModelByID(ID);
            int res = new BC_Serious().Delete(ID);
            if (res > 0)
            {
                OperateLogAdd("删除系列:" + model.Name, false);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        #endregion


        #region 标签

        [Power("VedioTags", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Tags(int pi = 1)
        {
            PagedList<MC_Tags> list = new BC_Tags().Pager(pi, PageSize, "Sort asc");
            return View(list);
        }

        [HttpGet]
        [Power("VedioTagsAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult TagsAdd()
        {
            return View();
        }
        [HttpPost]
        [Power("VedioTagsAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult TagsAdd(string name)
        {
            var model = new BC_Tags().GetModelByName(name);
            if (model != null)
            {
                return Content("标签已存在");
            }
            else
            {
                model = new MC_Tags();
                model.Name = name;
                model.Sort = 100000;
                int res = new BC_Tags().Add(model);
                if (res > 0)
                {
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }

        }


        [Power("VedioTagsDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult TagsDelete(int ID)
        {
            var model = new BC_Tags().GetModelByID(ID);
            int res = new BC_Tags().Delete(ID);
            if (res > 0)
            {
                OperateLogAdd("删除标签:" + model.Name, false);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        #endregion

        #region 数据配置
        /// <summary>
        /// 点赞 访问 收藏 价格 数量配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Power("VedioDataNumSet", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult DataNumSet()
        {
            return View();
        }
        [HttpPost]
        [Power("VedioDataNumSet", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult DataNumSet(string setType, int Hits = -1, int Goods = -1, int Likes = -1, decimal Price = -1)
        {
            int res = new BC_Vedios().DataNumSet(setType, Hits, Goods, Likes, Price);
            if (res > 0)
            {
                string sign = string.Empty;
                OperateLogAdd("点赞 访问 收藏 价格 全局配置setType:" + setType + "Hits:" + Hits + "Goods:" + Goods + "Likes:" + Likes + "Price:" + Price, false);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }

        }


        #endregion
    }


}