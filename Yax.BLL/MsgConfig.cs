using System;
using System.Collections.Generic;
using System.Text;
using Yax.Common.DataModelHelper;

namespace Yax.BLL
{
    public partial class MsgConfig
    {
        public readonly static MsgConfig Instance = new MsgConfig();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.MsgConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.MsgConfigAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.MsgConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.MsgConfigUpdate(model);
        }
        public int Update_info(Model.MsgConfig model)
        {
            return SQLServerDAL.DataProvider.Instance.MsgConfigUpdate_info(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("MsgConfig", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.MsgConfig GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByMsgConfig(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.MsgConfig> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListMsgConfig(top, fldName, strWhere, fldSort);
        }
        public List<Model.MsgConfig> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.MsgConfig> list = new List<Model.MsgConfig>();
            list = SQLServerDAL.DataProvider.Instance.GetPageMsgConfig(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
        public string SendCheckCode(string phone,string msg,string TID="")
        {
            try
            {
                string res = "";
                res = SQLServerDAL.DataProvider.Instance.MsgConfigSendCheckCode(phone, msg, TID);
                try
                {
                    PhoneMsgRes_FG m_res = Newtonsoft.Json.JsonConvert.DeserializeObject<PhoneMsgRes_FG>(res);
                    if (m_res.Message.ToLower() == "ok")
                    {
                        Yax.Model.PhoneMsg mpMsg = new Yax.Model.PhoneMsg();
                        mpMsg.AddTime = DateTime.Now;
                        mpMsg.Memo = "域名：" + System.Web.HttpContext.Current.Request.Url.Host;
                        mpMsg.Msg = msg;
                        mpMsg.Phone = phone;
                        mpMsg.IP = Yax.Common.Utils.GetClientIP();
                        mpMsg.Size = 0;//int.Parse(res);
                        int res2 = new PhoneMsg().Add(mpMsg);
                        return "ok";
                    }
                    else
                    {
                        return "false";
                    }
                }
                catch
                {
                    new Yax.BLL.ZY_Log().AddLog(2,"短信发送失败："+res);
                    return "false";
                }
                
            }
            catch
            {
                return "false";
            }
            
        }
    }
}
