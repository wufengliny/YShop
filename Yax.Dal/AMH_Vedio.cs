using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// AMH_Vedio
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表AMH_Vedio)
        /// </summary>
        public static Model.AMH_Vedio ConvertToAMH_Vedio(DataRow dr)
        {
            Model.AMH_Vedio model = new Model.AMH_Vedio();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Cover = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cover"]) ? string.Empty : dr["Cover"].ToString();
            model.Tag = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Tag"]) ? string.Empty : dr["Tag"].ToString();
            model.Category = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Category"]) ? string.Empty : dr["Category"].ToString();
            model.IsFree = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsFree"]) ? 0 : int.Parse(dr["IsFree"].ToString());//1:免费 2不免费
            model.Url = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Url"]) ? string.Empty : dr["Url"].ToString();
            model.VedioLong = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["VedioLong"]) ? string.Empty : dr["VedioLong"].ToString();//分钟
            model.Hits = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Hits"]) ? 0 : int.Parse(dr["Hits"].ToString());
            model.Likes = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Likes"]) ? 0 : int.Parse(dr["Likes"].ToString());//收藏
            model.Area = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Area"]) ? string.Empty : dr["Area"].ToString();
            model.Introduce = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Introduce"]) ? string.Empty : dr["Introduce"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Actor = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Actor"]) ? string.Empty : dr["Actor"].ToString();//主演
            model.AddUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddUser"]) ? 0 : int.Parse(dr["AddUser"].ToString());
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.FromVedioUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromVedioUrl"]) ? string.Empty : dr["FromVedioUrl"].ToString();
            model.FromPageUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromPageUrl"]) ? string.Empty : dr["FromPageUrl"].ToString();
            model.FromSite = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromSite"]) ? string.Empty : dr["FromSite"].ToString();
            model.FromVedioM3u8 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromVedioM3u8"]) ? string.Empty : dr["FromVedioM3u8"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表AMH_Vedio)
        /// </summary>
        public static Model.AMH_Vedio ConvetToAMH_Vedio(SqlDataReader reader, string extParam)
        {
            Model.AMH_Vedio model = new Model.AMH_Vedio();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Cover = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Tag = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Category = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.IsFree = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);//1:免费 2不免费
            model.Url = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.VedioLong = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//分钟
            model.Hits = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            model.Likes = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);//收藏
            model.Area = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.Introduce = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.AddTime = reader.IsDBNull(12) ? System.DateTime.MinValue : reader.GetDateTime(12);
            model.Enable = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
            model.Actor = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);//主演
            model.AddUser = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
            model.Sort = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
            model.FromVedioUrl = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
            model.FromPageUrl = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
            model.FromSite = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
            model.FromVedioM3u8 = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表AMH_Vedio)
        /// </summary>
        public int AMH_VedioAdd(Model.AMH_Vedio model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO AMH_Vedio(");
            strSql.Append("Name,Cover,Tag,Category,IsFree,Url,VedioLong,Hits,Likes,Area,Introduce,AddTime,Enable,Actor,AddUser,Sort,FromVedioUrl,FromPageUrl,FromSite,FromVedioM3u8)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Cover,@Tag,@Category,@IsFree,@Url,@VedioLong,@Hits,@Likes,@Area,@Introduce,@AddTime,@Enable,@Actor,@AddUser,@Sort,@FromVedioUrl,@FromPageUrl,@FromSite,@FromVedioM3u8)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,500),
                    new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                    new SqlParameter("@Tag", SqlDbType.NVarChar,100),
                    new SqlParameter("@Category", SqlDbType.NVarChar,20),
                    new SqlParameter("@IsFree", SqlDbType.Int,4),
                    new SqlParameter("@Url", SqlDbType.NVarChar,500),
                    new SqlParameter("@VedioLong", SqlDbType.NVarChar,20),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@Likes", SqlDbType.Int,4),
                    new SqlParameter("@Area", SqlDbType.NVarChar,100),
                    new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Actor", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddUser", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@FromVedioUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@FromPageUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@FromSite", SqlDbType.NVarChar,100),
                    new SqlParameter("@FromVedioM3u8", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Cover;
            parameters[2].Value = model.Tag;
            parameters[3].Value = model.Category;
            parameters[4].Value = model.IsFree;
            parameters[5].Value = model.Url;
            parameters[6].Value = model.VedioLong;
            parameters[7].Value = model.Hits;
            parameters[8].Value = model.Likes;
            parameters[9].Value = model.Area;
            parameters[10].Value = model.Introduce;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.Enable;
            parameters[13].Value = model.Actor;
            parameters[14].Value = model.AddUser;
            parameters[15].Value = model.Sort;
            parameters[16].Value = model.FromVedioUrl;
            parameters[17].Value = model.FromPageUrl;
            parameters[18].Value = model.FromSite;
            parameters[19].Value = model.FromVedioM3u8;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表AMH_Vedio)
        /// </summary>
        public int AMH_VedioUpdate(Model.AMH_Vedio model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AMH_Vedio SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Tag=@Tag,");
            strSql.Append("Category=@Category,");
            strSql.Append("IsFree=@IsFree,");
            strSql.Append("Url=@Url,");
            strSql.Append("VedioLong=@VedioLong,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("Likes=@Likes,");
            strSql.Append("Area=@Area,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Actor=@Actor,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("FromVedioUrl=@FromVedioUrl,");
            strSql.Append("FromPageUrl=@FromPageUrl,");
            strSql.Append("FromSite=@FromSite,");
            strSql.Append("FromVedioM3u8=@FromVedioM3u8");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@Tag", SqlDbType.NVarChar,100),
               new SqlParameter("@Category", SqlDbType.NVarChar,20),
               new SqlParameter("@IsFree", SqlDbType.Int,4),
               new SqlParameter("@Url", SqlDbType.NVarChar,500),
               new SqlParameter("@VedioLong", SqlDbType.NVarChar,20),
               new SqlParameter("@Hits", SqlDbType.Int,4),
               new SqlParameter("@Likes", SqlDbType.Int,4),
               new SqlParameter("@Area", SqlDbType.NVarChar,100),
               new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Actor", SqlDbType.NVarChar,100),
               new SqlParameter("@AddUser", SqlDbType.Int,4),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@FromVedioUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@FromPageUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@FromSite", SqlDbType.NVarChar,100),
               new SqlParameter("@FromVedioM3u8", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Cover;
            parameters[3].Value = model.Tag;
            parameters[4].Value = model.Category;
            parameters[5].Value = model.IsFree;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.VedioLong;
            parameters[8].Value = model.Hits;
            parameters[9].Value = model.Likes;
            parameters[10].Value = model.Area;
            parameters[11].Value = model.Introduce;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.Enable;
            parameters[14].Value = model.Actor;
            parameters[15].Value = model.AddUser;
            parameters[16].Value = model.Sort;
            parameters[17].Value = model.FromVedioUrl;
            parameters[18].Value = model.FromPageUrl;
            parameters[19].Value = model.FromSite;
            parameters[20].Value = model.FromVedioM3u8;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.AMH_Vedio GetModelByAMH_Vedio(int ID)
        {
            string sql = string.Format("SELECT * FROM AMH_Vedio WITH(NOLOCK) WHERE ID={0}", ID);
            Model.AMH_Vedio model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.AMH_Vedio();
                    }
                    model = ConvetToAMH_Vedio(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.AMH_Vedio> GetListAMH_Vedio(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.AMH_Vedio> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "AMH_Vedio", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.AMH_Vedio>();
                    }
                    list.Add(ConvetToAMH_Vedio(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.AMH_Vedio> GetPageAMH_Vedio(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.AMH_Vedio> list = new List<Yax.Model.AMH_Vedio>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "AMH_Vedio", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToAMH_Vedio(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
