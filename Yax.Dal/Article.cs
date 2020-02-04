using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Article
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Article)
        /// </summary>
        public static Model.Article ConvertToArticle(DataRow dr)
        {
            Model.Article model = new Model.Article();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Mark = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Mark"]) ? string.Empty : dr["Mark"].ToString();//标识文章 的唯一性
            model.Hits = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Hits"]) ? 0 : int.Parse(dr["Hits"].ToString());
            model.IP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IP"]) ? string.Empty : dr["IP"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.ArticleTypeID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ArticleTypeID"]) ? 0 : int.Parse(dr["ArticleTypeID"].ToString());
            model.Cover = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cover"]) ? string.Empty : dr["Cover"].ToString();
            model.CoverSmall = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CoverSmall"]) ? string.Empty : dr["CoverSmall"].ToString();
            model.Autho = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Autho"]) ? string.Empty : dr["Autho"].ToString();
            model.IsIndex = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsIndex"]) ? 0 : int.Parse(dr["IsIndex"].ToString());
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.Detail = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Detail"]) ? string.Empty : dr["Detail"].ToString();
            model.AddUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddUser"]) ? 0 : int.Parse(dr["AddUser"].ToString());
            model.SeoKeywords = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SeoKeywords"]) ? string.Empty : dr["SeoKeywords"].ToString();
            model.SeoDescription = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SeoDescription"]) ? string.Empty : dr["SeoDescription"].ToString();
            model.IsRecoommend = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsRecoommend"]) ? 0 : int.Parse(dr["IsRecoommend"].ToString());
            model.IsHot = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsHot"]) ? 0 : int.Parse(dr["IsHot"].ToString());
            model.Category = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Category"]) ? string.Empty : dr["Category"].ToString();//1 （固定  不能添加 可修改 ）2 新闻资讯 
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Article)
        /// </summary>
        public static Model.Article ConvetToArticle(SqlDataReader reader, string extParam)
        {
            Model.Article model = new Model.Article();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Mark = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//标识文章 的唯一性
            model.Hits = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.IP = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Enable = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.AddTime = reader.IsDBNull(6) ? System.DateTime.MinValue : reader.GetDateTime(6);
            model.ArticleTypeID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
            model.Cover = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.CoverSmall = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.Autho = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.IsIndex = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
            model.UpdateTime = reader.IsDBNull(12) ? System.DateTime.MinValue : reader.GetDateTime(12);
            model.Detail = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
            model.AddUser = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
            model.SeoKeywords = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
            model.SeoDescription = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
            model.IsRecoommend = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
            model.IsHot = reader.IsDBNull(18) ? 0 : reader.GetInt32(18);
            model.Category = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);//1 （固定  不能添加 可修改 ）2 新闻资讯 
            model.Sort = reader.IsDBNull(20) ? 0 : reader.GetInt32(20);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Article)
        /// </summary>
        public int ArticleAdd(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Article(");
            strSql.Append("Name,Mark,Hits,IP,Enable,AddTime,ArticleTypeID,Cover,CoverSmall,Autho,IsIndex,UpdateTime,Detail,AddUser,SeoKeywords,SeoDescription,IsRecoommend,IsHot,Category,Sort)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Mark,@Hits,@IP,@Enable,@AddTime,@ArticleTypeID,@Cover,@CoverSmall,@Autho,@IsIndex,@UpdateTime,@Detail,@AddUser,@SeoKeywords,@SeoDescription,@IsRecoommend,@IsHot,@Category,@Sort)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,500),
                    new SqlParameter("@Mark", SqlDbType.NVarChar,4000),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@IP", SqlDbType.NVarChar,100),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@ArticleTypeID", SqlDbType.Int,4),
                    new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                    new SqlParameter("@CoverSmall", SqlDbType.NVarChar,500),
                    new SqlParameter("@Autho", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsIndex", SqlDbType.Int,4),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
                    new SqlParameter("@AddUser", SqlDbType.Int,4),
                    new SqlParameter("@SeoKeywords", SqlDbType.NVarChar,1000),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,1000),
                    new SqlParameter("@IsRecoommend", SqlDbType.Int,4),
                    new SqlParameter("@IsHot", SqlDbType.Int,4),
                    new SqlParameter("@Category", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Mark;
            parameters[2].Value = model.Hits;
            parameters[3].Value = model.IP;
            parameters[4].Value = model.Enable;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.ArticleTypeID;
            parameters[7].Value = model.Cover;
            parameters[8].Value = model.CoverSmall;
            parameters[9].Value = model.Autho;
            parameters[10].Value = model.IsIndex;
            parameters[11].Value = model.UpdateTime;
            parameters[12].Value = model.Detail;
            parameters[13].Value = model.AddUser;
            parameters[14].Value = model.SeoKeywords;
            parameters[15].Value = model.SeoDescription;
            parameters[16].Value = model.IsRecoommend;
            parameters[17].Value = model.IsHot;
            parameters[18].Value = model.Category;
            parameters[19].Value = model.Sort;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Article)
        /// </summary>
        public int ArticleUpdate(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Mark=@Mark,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("IP=@IP,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("ArticleTypeID=@ArticleTypeID,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("CoverSmall=@CoverSmall,");
            strSql.Append("Autho=@Autho,");
            strSql.Append("IsIndex=@IsIndex,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("SeoKeywords=@SeoKeywords,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("IsRecoommend=@IsRecoommend,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("Category=@Category,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@Mark", SqlDbType.NVarChar,4000),
               new SqlParameter("@Hits", SqlDbType.Int,4),
               new SqlParameter("@IP", SqlDbType.NVarChar,100),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@ArticleTypeID", SqlDbType.Int,4),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@CoverSmall", SqlDbType.NVarChar,500),
               new SqlParameter("@Autho", SqlDbType.NVarChar,100),
               new SqlParameter("@IsIndex", SqlDbType.Int,4),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
               new SqlParameter("@AddUser", SqlDbType.Int,4),
               new SqlParameter("@SeoKeywords", SqlDbType.NVarChar,1000),
               new SqlParameter("@SeoDescription", SqlDbType.NVarChar,1000),
               new SqlParameter("@IsRecoommend", SqlDbType.Int,4),
               new SqlParameter("@IsHot", SqlDbType.Int,4),
               new SqlParameter("@Category", SqlDbType.NVarChar,100),
               new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Mark;
            parameters[3].Value = model.Hits;
            parameters[4].Value = model.IP;
            parameters[5].Value = model.Enable;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.ArticleTypeID;
            parameters[8].Value = model.Cover;
            parameters[9].Value = model.CoverSmall;
            parameters[10].Value = model.Autho;
            parameters[11].Value = model.IsIndex;
            parameters[12].Value = model.UpdateTime;
            parameters[13].Value = model.Detail;
            parameters[14].Value = model.AddUser;
            parameters[15].Value = model.SeoKeywords;
            parameters[16].Value = model.SeoDescription;
            parameters[17].Value = model.IsRecoommend;
            parameters[18].Value = model.IsHot;
            parameters[19].Value = model.Category;
            parameters[20].Value = model.Sort;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int ArticleUpdateInfo(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Mark=@Mark,");
            strSql.Append("IP=@IP,");
            strSql.Append("ArticleTypeID=@ArticleTypeID,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("CoverSmall=@CoverSmall,");
            strSql.Append("Autho=@Autho,");
            strSql.Append("IsIndex=@IsIndex,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("SeoKeywords=@SeoKeywords,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("IsRecoommend=@IsRecoommend,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@Mark", SqlDbType.NVarChar,4000),
               new SqlParameter("@IP", SqlDbType.NVarChar,100),
               new SqlParameter("@ArticleTypeID", SqlDbType.Int,4),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@CoverSmall", SqlDbType.NVarChar,500),
               new SqlParameter("@Autho", SqlDbType.NVarChar,100),
               new SqlParameter("@IsIndex", SqlDbType.Int,4),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
               new SqlParameter("@SeoKeywords", SqlDbType.NVarChar,500),
               new SqlParameter("@SeoDescription", SqlDbType.NVarChar,500),
                new SqlParameter("@AddTime", SqlDbType.DateTime,8),
              new SqlParameter("@IsRecoommend", SqlDbType.Int,4),
                          new SqlParameter("@IsHot", SqlDbType.Int,4),
                           new SqlParameter("@Hits", SqlDbType.Int,4),
                            new SqlParameter("@Sort", SqlDbType.Int,4)
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Mark;
            parameters[3].Value = model.IP;
            parameters[4].Value = model.ArticleTypeID;
            parameters[5].Value = model.Cover;
            parameters[6].Value = model.CoverSmall;
            parameters[7].Value = model.Autho;
            parameters[8].Value = model.IsIndex;
            parameters[9].Value = model.UpdateTime;
            parameters[10].Value = model.Detail;
            parameters[11].Value = model.SeoKeywords;
            parameters[12].Value = model.SeoDescription;
            parameters[13].Value = model.AddTime;
            parameters[14].Value = model.IsRecoommend;
            parameters[15].Value = model.IsHot;
            parameters[16].Value = model.Hits;
            parameters[17].Value = model.Sort;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int ArticleUpdate_enable(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4),
      };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ArticleUpdate_Index(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("IsIndex=@IsIndex");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@IsIndex", SqlDbType.Int,4),
      };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IsIndex;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ArticleUpdate_hot(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("IsHot=@IsHot");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@IsHot", SqlDbType.Int,4),
      };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IsHot;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int ArticleUpdate_Hits(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("Hits=@Hits");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Hits", SqlDbType.Int,4),
      };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Hits;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ArticleUpdate_Recommend(Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append("IsRecoommend=@IsRecoommend");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@IsRecoommend", SqlDbType.Int,4),
      };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IsRecoommend;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Article GetModelByArticle(int ID)
        {
            string sql = string.Format("SELECT * FROM Article WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Article model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Article();
                    }
                    model = ConvetToArticle(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Article> GetListArticle(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Article> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Article", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Article>();
                    }
                    list.Add(ConvetToArticle(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Article> GetPageArticle(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Article> list = new List<Yax.Model.Article>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Article", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToArticle(dt.Rows[i]));
                }
            }
            return list;
        }
        public DataTable GetPageArticle_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View_Article", out TotalRecord);
            return dt;
        }


    }
}
