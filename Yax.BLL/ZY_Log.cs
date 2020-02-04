using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Yax.BLL
{
    public partial class ZY_Log
    {
        public readonly static ZY_Log Instance = new ZY_Log();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.ZY_Log model)
        {
            return SQLServerDAL.DataProvider.Instance.ZY_LogAdd(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0 :登录日志1：操作日志2：系统日志</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int AddLog(int type,string message)
        {
            Yax.Model.ZY_Log model = new Model.ZY_Log();
            model.Addtime = DateTime.Now;
            model.Browser =HttpContext.Current.Request.Browser.Type;
            model.IP = Yax.Common.Utils.GetClientIP();
            model.Message = message;
            model.Type = type;
            model.Url = HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.Url.AbsolutePath;
            model.UserID =new Yax.BLL.CurrentUser().Id;
            model.UserName = new Yax.BLL.CurrentUser().Name;
            return  Add(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0 :登录日志1：操作日志2：系统日志</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int AddLog_JustMessage(int type, string message)
        {
            Yax.Model.ZY_Log model = new Model.ZY_Log();
            model.Addtime = DateTime.Now;
            model.Browser = "";
            model.IP = Yax.Common.Utils.GetIP();
            model.Message = message;
            model.Url = "";
            model.UserID = 0;
            model.Type = type;
            model.UserName = "";
            return Add(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.ZY_Log model)
        {
            return SQLServerDAL.DataProvider.Instance.ZY_LogUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("ZY_Log", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.ZY_Log GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByZY_Log(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ZY_Log> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListZY_Log(top, fldName, strWhere, fldSort);
        }
  
        public List<Model.ZY_Log> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.ZY_Log> list = new List<Model.ZY_Log>();
            list = SQLServerDAL.DataProvider.Instance.GetPageZY_Log(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }



     
    }
}
