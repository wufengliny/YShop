using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entity;
using System.Text;
using System.Data;
using ComEnum;
using VedioAdmin.Filters;

namespace VedioAdmin.Controllers
{
    
    public class BaseController : Controller
    {
        public static BS_Log bll_log = new BS_Log();
        public int PageSize = 20;

        #region 2019 kay
        /// <summary>
        /// 管理员操作日志
        /// </summary>
        /// <param name="msg">操作信息</param>
        /// <param name="IsSensitive">是否敏感信息操作</param>
        /// <returns></returns>
        public int OperateLogAdd(string msg,bool IsSensitive)
        {
           return bll_log.OperateLogAdd(msg,CUser.ID,CUser.Account,AccountEnum.Admin, IsSensitive);
        }


        #endregion


        /// <summary>
        /// 当前登录用户
        /// </summary>
        public CurrentAdmin CUser
        {
            get
            {
                CurrentAdmin cu = new CurrentAdmin();
                return cu;
            }
        }
 
       
      
       





        

        
       
   
      
      
       
      


 

       

    }
}