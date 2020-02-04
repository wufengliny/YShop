using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// MsgConfig
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表MsgConfig)
        /// </summary>
        public static Model.MsgConfig ConvertToMsgConfig(DataRow dr)
        {
            Model.MsgConfig model = new Model.MsgConfig();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.QIYeID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["QIYeID"]) ? string.Empty : dr["QIYeID"].ToString();
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();
            model.Pwd = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Pwd"]) ? string.Empty : dr["Pwd"].ToString();
            model.owner = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["owner"]) ? string.Empty : dr["owner"].ToString();
            model.Addtime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Addtime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["Addtime"].ToString());
            model.ContentPre = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ContentPre"]) ? string.Empty : dr["ContentPre"].ToString();
            model.URL = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["URL"]) ? string.Empty : dr["URL"].ToString();//短信接口网关地址
            model.DayMax = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DayMax"]) ? 0 : int.Parse(dr["DayMax"].ToString());//每日短信条数上线
            model.UserDayMax = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserDayMax"]) ? 0 : int.Parse(dr["UserDayMax"].ToString());//单个会员每日短信条数上限

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表MsgConfig)
        /// </summary>
        public static Model.MsgConfig ConvetToMsgConfig(SqlDataReader reader, string extParam)
        {
            Model.MsgConfig model = new Model.MsgConfig();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.QIYeID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Account = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Pwd = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.owner = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Addtime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.ContentPre = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.URL = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//短信接口网关地址
            model.DayMax = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);//每日短信条数上限
            model.UserDayMax = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);//单个会员每日短信条数上限

            return model;
        }
        /// <summary>
        /// 增加一条数据(表MsgConfig)
        /// </summary>
        public int MsgConfigAdd(Model.MsgConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO MsgConfig(");
            strSql.Append("QIYeID,Account,Pwd,owner,Addtime,ContentPre,URL,DayMax,UserDayMax)");
            strSql.Append(" VALUES (");
            strSql.Append("@QIYeID,@Account,@Pwd,@owner,@Addtime,@ContentPre,@URL,@DayMax,@UserDayMax)");
            SqlParameter[] parameters = {
		            new SqlParameter("@QIYeID", SqlDbType.NVarChar,100),
		            new SqlParameter("@Account", SqlDbType.NVarChar,100),
		            new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
		            new SqlParameter("@owner", SqlDbType.NChar,20),
		            new SqlParameter("@Addtime", SqlDbType.DateTime,8),
		            new SqlParameter("@ContentPre", SqlDbType.NVarChar,100),
		            new SqlParameter("@URL", SqlDbType.NVarChar,100),
		            new SqlParameter("@DayMax", SqlDbType.Int,4),
		            new SqlParameter("@UserDayMax", SqlDbType.Int,4)};
            parameters[0].Value = model.QIYeID;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.owner;
            parameters[4].Value = model.Addtime;
            parameters[5].Value = model.ContentPre;
            parameters[6].Value = model.URL;
            parameters[7].Value = model.DayMax;
            parameters[8].Value = model.UserDayMax;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表MsgConfig)
        /// </summary>
        public int MsgConfigUpdate(Model.MsgConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE MsgConfig SET ");
            strSql.Append("QIYeID=@QIYeID,");
            strSql.Append("Account=@Account,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("owner=@owner,");
            strSql.Append("Addtime=@Addtime,");
            strSql.Append("ContentPre=@ContentPre,");
            strSql.Append("URL=@URL,");
            strSql.Append("DayMax=@DayMax,");
            strSql.Append("UserDayMax=@UserDayMax");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@QIYeID", SqlDbType.NVarChar,100),
               new SqlParameter("@Account", SqlDbType.NVarChar,100),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
               new SqlParameter("@owner", SqlDbType.NChar,20),
               new SqlParameter("@Addtime", SqlDbType.DateTime,8),
               new SqlParameter("@ContentPre", SqlDbType.NVarChar,100),
               new SqlParameter("@URL", SqlDbType.NVarChar,100),
               new SqlParameter("@DayMax", SqlDbType.Int,4),
               new SqlParameter("@UserDayMax", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.QIYeID;
            parameters[2].Value = model.Account;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.owner;
            parameters[5].Value = model.Addtime;
            parameters[6].Value = model.ContentPre;
            parameters[7].Value = model.URL;
            parameters[8].Value = model.DayMax;
            parameters[9].Value = model.UserDayMax;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int MsgConfigUpdate_info(Model.MsgConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE MsgConfig SET ");
            strSql.Append("QIYeID=@QIYeID,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("ContentPre=@ContentPre,");
            strSql.Append("URL=@URL,");
            strSql.Append("DayMax=@DayMax,");
            strSql.Append("UserDayMax=@UserDayMax");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@QIYeID", SqlDbType.NVarChar,100),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
               new SqlParameter("@ContentPre", SqlDbType.NVarChar,100),
               new SqlParameter("@URL", SqlDbType.NVarChar,100),
               new SqlParameter("@DayMax", SqlDbType.Int,4),
               new SqlParameter("@UserDayMax", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.QIYeID;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.ContentPre;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.DayMax;
            parameters[6].Value = model.UserDayMax;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.MsgConfig GetModelByMsgConfig(int ID)
        {
            string sql = string.Format("SELECT * FROM MsgConfig WITH(NOLOCK) WHERE ID={0}", ID);
            Model.MsgConfig model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.MsgConfig();
                    }
                    model = ConvetToMsgConfig(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.MsgConfig> GetListMsgConfig(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.MsgConfig> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "MsgConfig", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.MsgConfig>();
                    }
                    list.Add(ConvetToMsgConfig(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.MsgConfig> GetPageMsgConfig(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.MsgConfig> list = new List<Yax.Model.MsgConfig>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "MsgConfig", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToMsgConfig(dt.Rows[i]));
                }
            }
            return list;
        }

        public string MsgConfigSendCheckCode(string phone, string msg,string Tid="")
        {
            Yax.Model.MsgConfig model=new Yax.Model.MsgConfig();

            object MsgconfigCache= Yax.Common.DataCache.GetCache("MsgconfigCache");
            if(MsgconfigCache!=null)
            {
                model=(Yax.Model.MsgConfig)MsgconfigCache;
            }
            else
            {
                model=GetModelByMsgConfig(1);
                Yax.Common.DataCache.SetCache("MsgconfigCache",model);
            }
            string res = "";
            if (string.IsNullOrEmpty(Tid))
            {
                res = Yax.Common.SendPhoneMsg.SendMsg_FG(model.QIYeID, model.Pwd, msg, phone, model.ContentPre, model.URL);
            }
            else
            {
                res = Yax.Common.SendPhoneMsg.SendMsg_FG_Template(model.QIYeID, model.Pwd, msg, phone, model.ContentPre, model.URL,Tid);
            }
            return res;
        }


    }
}
