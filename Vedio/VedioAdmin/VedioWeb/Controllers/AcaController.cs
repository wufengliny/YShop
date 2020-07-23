using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace VedioWeb.Controllers
{
    public class AcaController : Controller
    {
        // GET: Aca
        public ActionResult Index(int pi = 1)
        {
            ViewBag.Title = "记录青年生活";
            string strWhere = " where cv.Enable=1  ";
            string SortStr = "[IsTop] Desc,[Sort] desc";
            string Category = UCommon.UUtils.GetSafeQueryString("Category");
            if (!string.IsNullOrEmpty(Category))
            {
                strWhere += " and cv.Category='"+ Category + "'";
            }
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            ViewBag.weburl = new BS_Config().GetModelByKeyFromCache("weburl").Value;
            var list = new BC_Vedios().Pager(pi, 20, strWhere, SortStr);
            return View(list);
        }


        public ActionResult Play(int ID)
        {
            int uid = new CurrentUser().ID;
            MC_Vedios model = new BC_Vedios().GetModelByID(ID);
            bool AllowPlay = false;
            string msg = "";
            string likeStr = "";
            string goodsStr = "";
            if(model!=null)
            {
                new BC_Vedios().UpdateHit(ID);
                if(uid>0)
                {
                    var likeModel = new BC_UserLikes().GetModel(ID, uid);
                    if (likeModel != null)
                    {
                        likeStr = "actived";
                    }
                    var goodsModel = new BC_UserGoods().GetModel(ID, uid);
                    if (goodsModel != null)
                    {
                        goodsStr = "actived";
                    }
                }
                if (model.Price == 0)
                {
                    AllowPlay = true;
                }
                else
                {
                    if(uid>0)
                    {
                        MS_User user = new BS_User().GetModelByID(uid);
                        if (user!=null&& user.Enable == 1)
                        {
                            if(user.VIP&&user.VIPEndTime>DateTime.Now)
                            {
                                AllowPlay = true;
                            }
                            else
                            {
                                //查询是否单独购买过此视频的付费信息
                                MC_Orders mo = new BC_Orders().GetModelByVedioID(ID,uid);
                                if(mo!=null)
                                {
                                    AllowPlay = true;
                                }
                                else
                                {
                                    msg = "此视频为付费视频";
                                }
                            }
                        }
                        else
                        {
                            msg = "账号异常，请重新登录";
                        }
                    }
                    else
                    {
                        AllowPlay = false;
                        msg = "此视频为付费视频";
                    }
                }
            }
            else
            {
                model = new MC_Vedios();
            }
           
            string cover = "";
            string url = "";
            if(!string.IsNullOrEmpty(model.Cover))
            {
                string picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
                cover = picurl + model.Cover;
            }
            ViewBag.cover = cover;
            if(AllowPlay)
            {
                if (model.Url.ToLower().StartsWith("http"))
                {
                    url = model.Url;
                }
                else
                {
                    string vediourl = new BS_Config().GetModelByKeyFromCache("vediourl").Value;
                    url = vediourl + model.Url;
                }
            }
            ViewBag.Url = url;
            ViewBag.AllowPlay = AllowPlay;
            ViewBag.likeStr = likeStr;
            ViewBag.goodsStr = goodsStr;
            return View(model);
        }

        /// <summary>
        /// 异步收藏
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLike(int ID,int addOrCancel)
        {
            int uid = new CurrentUser().ID;
            if(uid>0)
            {
                MC_Vedios model = new BC_Vedios().GetModelByID(ID);
                if(model!=null)
                {
                    new BC_Vedios().UpdateLike(ID, addOrCancel);
                    if(addOrCancel==1)
                    {
                        MC_UserLikes mlike = new MC_UserLikes();
                        mlike.AddTime = DateTime.Now;
                        mlike.UID = uid;
                        mlike.VedioID = ID;
                        mlike.VedioName = model.Name;
                        new BC_UserLikes().Add(mlike);
                    }
                    else
                    {
                        new BC_UserLikes().Delete(ID,uid);
                    }
                    return Content("操作成功");
                }
                else
                {
                    return Content("数据异常");
                }
            }
            else
            {
                return Content("请先登录");
            }
            return Content("");
        }
        /// <summary>
        /// 异步点赞
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoGoods(int ID, int addOrCancel)
        {
            int uid = new CurrentUser().ID;
            if (uid > 0)
            {
                MC_Vedios model = new BC_Vedios().GetModelByID(ID);
                if (model != null)
                {
                    new BC_Vedios().UpdateGoods(ID, addOrCancel);
                    if (addOrCancel == 1)
                    {
                        MC_UserGoods mgoods = new MC_UserGoods();
                        mgoods.AddTime = DateTime.Now;
                        mgoods.UID = uid;
                        mgoods.VedioID = ID;
                        mgoods.VedioName = model.Name;
                        new BC_UserGoods().Add(mgoods);
                    }
                    else
                    {
                        new BC_UserGoods().Delete(ID, uid);
                    }
                    return Content("操作成功");
                }
                else
                {
                    return Content("数据异常");
                }
            }
            else
            {
                return Content("请先登录");
            }
            return Content("");
        }

        public ActionResult Test()
        {
            return Content("");
        }
    }
}