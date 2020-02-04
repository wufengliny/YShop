using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// FriendLink
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表FriendLink)
        /// </summary>
        public static Model.FriendLink ConvertToFriendLink(DataRow dr)
        {
            Model.FriendLink model = new Model.FriendLink();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.SiteName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SiteName"]) ? string.Empty : dr["SiteName"].ToString();
            model.Url = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Url"]) ? string.Empty : dr["Url"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.ImgUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ImgUrl"]) ? string.Empty : dr["ImgUrl"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表FriendLink)
        /// </summary>
        public static Model.FriendLink ConvetToFriendLink(SqlDataReader reader, string extParam)
        {
            Model.FriendLink model = new Model.FriendLink();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.SiteName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Url = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.AddTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);
            model.Sort = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.Memo = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.ImgUrl = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表FriendLink)
        /// </summary>
        public int FriendLinkAdd(Model.FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO FriendLink(");
            strSql.Append("SiteName,Url,Enable,AddTime,Sort,Memo,ImgUrl)");
            strSql.Append(" VALUES (");
            strSql.Append("@SiteName,@Url,@Enable,@AddTime,@Sort,@Memo,@ImgUrl)");
            SqlParameter[] parameters = {
                    new SqlParameter("@SiteName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Url", SqlDbType.NVarChar,500),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.SiteName;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.ImgUrl;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表FriendLink)
        /// </summary>
        public int FriendLinkUpdate(Model.FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE FriendLink SET ");
            strSql.Append("SiteName=@SiteName,");
            strSql.Append("Url=@Url,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@SiteName", SqlDbType.NVarChar,100),
               new SqlParameter("@Url", SqlDbType.NVarChar,500),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SiteName;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int FriendLinkUpdateInfo(Model.FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE FriendLink SET ");
            strSql.Append("SiteName=@SiteName,");
            strSql.Append("Url=@Url,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("ImgUrl=@ImgUrl");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@SiteName", SqlDbType.NVarChar,100),
               new SqlParameter("@Url", SqlDbType.NVarChar,500),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
             new SqlParameter("@ImgUrl", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SiteName;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.ImgUrl;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int FriendLinkUpdateEnable(int id,int enable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE FriendLink SET ");
            strSql.Append("Enable= "+enable);
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4)
              };
            parameters[0].Value = id;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.FriendLink GetModelByFriendLink(int ID)
        {
            string sql = string.Format("SELECT * FROM FriendLink WITH(NOLOCK) WHERE ID={0}", ID);
            Model.FriendLink model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.FriendLink();
                    }
                    model = ConvetToFriendLink(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.FriendLink> GetListFriendLink(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.FriendLink> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "FriendLink", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.FriendLink>();
                    }
                    list.Add(ConvetToFriendLink(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.FriendLink> GetPageFriendLink(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.FriendLink> list = new List<Yax.Model.FriendLink>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "FriendLink", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToFriendLink(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
