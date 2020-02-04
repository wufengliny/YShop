using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Web_Img
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Web_Img)
        /// </summary>
        public static Model.Web_Img ConvertToWeb_Img(DataRow dr)
        {
            Model.Web_Img model = new Model.Web_Img();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Imgurl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Imgurl"]) ? string.Empty : dr["Imgurl"].ToString();
            model.ImgUlrSmall = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ImgUlrSmall"]) ? string.Empty : dr["ImgUlrSmall"].ToString();
            model.Href = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Href"]) ? string.Empty : dr["Href"].ToString();
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enabale = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enabale"]) ? 0 : int.Parse(dr["Enabale"].ToString());
            model.ImgType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ImgType"]) ? 0 : int.Parse(dr["ImgType"].ToString());
            model.OpenType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OpenType"]) ? string.Empty : dr["OpenType"].ToString();
            model.Category = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Category"]) ? string.Empty : dr["Category"].ToString();//图片第二个类型 用于区分 系统添加 和其他用途的图片上传
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Web_Img)
        /// </summary>
        public static Model.Web_Img ConvetToWeb_Img(SqlDataReader reader, string extParam)
        {
            Model.Web_Img model = new Model.Web_Img();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Imgurl = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.ImgUlrSmall = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Href = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Memo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.AddTime = reader.IsDBNull(6) ? System.DateTime.MinValue : reader.GetDateTime(6);
            model.Enabale = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
            model.ImgType = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            model.OpenType = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.Category = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);//图片第二个类型 用于区分 系统添加 和其他用途的图片上传
            model.Sort = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Web_Img)
        /// </summary>
        public int Web_ImgAdd(Model.Web_Img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Web_Img(");
            strSql.Append("Name,Imgurl,ImgUlrSmall,Href,Memo,AddTime,Enabale,ImgType,OpenType,Category,Sort)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Imgurl,@ImgUlrSmall,@Href,@Memo,@AddTime,@Enabale,@ImgType,@OpenType,@Category,@Sort)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,500),
                    new SqlParameter("@Imgurl", SqlDbType.NVarChar,500),
                    new SqlParameter("@ImgUlrSmall", SqlDbType.NVarChar,500),
                    new SqlParameter("@Href", SqlDbType.NVarChar,500),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enabale", SqlDbType.Int,4),
                    new SqlParameter("@ImgType", SqlDbType.Int,4),
                    new SqlParameter("@OpenType", SqlDbType.NVarChar,100),
                    new SqlParameter("@Category", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Imgurl;
            parameters[2].Value = model.ImgUlrSmall;
            parameters[3].Value = model.Href;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Enabale;
            parameters[7].Value = model.ImgType;
            parameters[8].Value = model.OpenType;
            parameters[9].Value = model.Category;
            parameters[10].Value = model.Sort;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Web_Img)
        /// </summary>
        public int Web_ImgUpdate(Model.Web_Img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Web_Img SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Imgurl=@Imgurl,");
            strSql.Append("ImgUlrSmall=@ImgUlrSmall,");
            strSql.Append("Href=@Href,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enabale=@Enabale,");
            strSql.Append("ImgType=@ImgType,");
            strSql.Append("OpenType=@OpenType,");
            strSql.Append("Category=@Category,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@Imgurl", SqlDbType.NVarChar,500),
               new SqlParameter("@ImgUlrSmall", SqlDbType.NVarChar,500),
               new SqlParameter("@Href", SqlDbType.NVarChar,500),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enabale", SqlDbType.Int,4),
               new SqlParameter("@ImgType", SqlDbType.Int,4),
               new SqlParameter("@OpenType", SqlDbType.NVarChar,100),
               new SqlParameter("@Category", SqlDbType.NVarChar,100),
               new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Imgurl;
            parameters[3].Value = model.ImgUlrSmall;
            parameters[4].Value = model.Href;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Enabale;
            parameters[8].Value = model.ImgType;
            parameters[9].Value = model.OpenType;
            parameters[10].Value = model.Category;
            parameters[11].Value = model.Sort;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int Web_ImgUpdate_sortImg(Model.Web_Img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Web_Img SET ");
            strSql.Append("Imgurl=@Imgurl,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Imgurl", SqlDbType.NVarChar,500),
               new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Imgurl;
            parameters[2].Value = model.Sort;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Web_ImgUpdate_Enable(Model.Web_Img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Web_Img set ");
            strSql.Append("Enabale=@Enabale");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Enabale", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enabale;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Web_ImgUpdate_info(Model.Web_Img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Web_Img set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Imgurl=@Imgurl,");
            strSql.Append("ImgUlrSmall=@ImgUlrSmall,");
            strSql.Append("Href=@Href,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("OpenType=@OpenType");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Name", SqlDbType.NVarChar,500),
		            new SqlParameter("@Imgurl", SqlDbType.NVarChar,500),
		            new SqlParameter("@ImgUlrSmall", SqlDbType.NVarChar,500),
		            new SqlParameter("@Href", SqlDbType.NVarChar,500),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,500),
		            new SqlParameter("@OpenType", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Imgurl;
            parameters[3].Value = model.ImgUlrSmall;
            parameters[4].Value = model.Href;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.OpenType;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Web_Img GetModelByWeb_Img(int ID)
        {
            string sql = string.Format("SELECT * FROM Web_Img WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Web_Img model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Web_Img();
                    }
                    model = ConvetToWeb_Img(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Web_Img> GetListWeb_Img(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Web_Img> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Web_Img", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Web_Img>();
                    }
                    list.Add(ConvetToWeb_Img(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Web_Img> GetPageWeb_Img(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Web_Img> list = new List<Yax.Model.Web_Img>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Web_Img", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToWeb_Img(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
