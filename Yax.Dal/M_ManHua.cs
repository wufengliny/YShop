using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// M_ManHua
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表M_ManHua)
        /// </summary>
        public static Model.M_ManHua ConvertToM_ManHua(DataRow dr)
        {
            Model.M_ManHua model = new Model.M_ManHua();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.SearchName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SearchName"]) ? string.Empty : dr["SearchName"].ToString();
            model.UpSate = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpSate"]) ? string.Empty : dr["UpSate"].ToString();//1 连载中 2 完结
            model.Author = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Author"]) ? string.Empty : dr["Author"].ToString();//作者
            model.Hits = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Hits"]) ? 0 : int.Parse(dr["Hits"].ToString());//点击数
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.LatestChapter = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LatestChapter"]) ? string.Empty : dr["LatestChapter"].ToString();//最新章节
            model.IsIndex = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsIndex"]) ? 0 : int.Parse(dr["IsIndex"].ToString());//是否首页
            model.Introduce = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Introduce"]) ? string.Empty : dr["Introduce"].ToString();//简介
            model.Cagegory = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cagegory"]) ? string.Empty : dr["Cagegory"].ToString();//类型
            model.AddUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddUser"]) ? 0 : int.Parse(dr["AddUser"].ToString());//添加人
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.Cover = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cover"]) ? string.Empty : dr["Cover"].ToString();
            model.FromUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromUrl"]) ? string.Empty : dr["FromUrl"].ToString();//来源网址
            model.DownUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DownUrl"]) ? string.Empty : dr["DownUrl"].ToString();//下载地址
            model.DownName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DownName"]) ? string.Empty : dr["DownName"].ToString();//下载名称
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表M_ManHua)
        /// </summary>
        public static Model.M_ManHua ConvetToM_ManHua(SqlDataReader reader, string extParam)
        {
            Model.M_ManHua model = new Model.M_ManHua();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.SearchName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.UpSate = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//1 连载中 2 完结
            model.Author = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//作者
            model.Hits = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);//点击数
            model.Sort = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            model.LatestChapter = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//最新章节
            model.IsIndex = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);//是否首页
            model.Introduce = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);//简介
            model.Cagegory = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);//类型
            model.AddUser = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);//添加人
            model.Memo = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            model.Cover = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
            model.FromUrl = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);//来源网址
            model.DownUrl = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);//下载地址
            model.DownName = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);//下载名称
            model.Enable = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
            model.AddTime = reader.IsDBNull(18) ? System.DateTime.MinValue : reader.GetDateTime(18);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表M_ManHua)
        /// </summary>
        public int M_ManHuaAdd(Model.M_ManHua model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO M_ManHua(");
            strSql.Append("Name,SearchName,UpSate,Author,Hits,Sort,LatestChapter,IsIndex,Introduce,Cagegory,AddUser,Memo,Cover,FromUrl,DownUrl,DownName,Enable,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@SearchName,@UpSate,@Author,@Hits,@Sort,@LatestChapter,@IsIndex,@Introduce,@Cagegory,@AddUser,@Memo,@Cover,@FromUrl,@DownUrl,@DownName,@Enable,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@SearchName", SqlDbType.NVarChar,500),
                    new SqlParameter("@UpSate", SqlDbType.NChar,20),
                    new SqlParameter("@Author", SqlDbType.NChar,20),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@LatestChapter", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsIndex", SqlDbType.Int,4),
                    new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Cagegory", SqlDbType.NChar,20),
                    new SqlParameter("@AddUser", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                    new SqlParameter("@FromUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@DownUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@DownName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.SearchName;
            parameters[2].Value = model.UpSate;
            parameters[3].Value = model.Author;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.LatestChapter;
            parameters[7].Value = model.IsIndex;
            parameters[8].Value = model.Introduce;
            parameters[9].Value = model.Cagegory;
            parameters[10].Value = model.AddUser;
            parameters[11].Value = model.Memo;
            parameters[12].Value = model.Cover;
            parameters[13].Value = model.FromUrl;
            parameters[14].Value = model.DownUrl;
            parameters[15].Value = model.DownName;
            parameters[16].Value = model.Enable;
            parameters[17].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表M_ManHua)
        /// </summary>
        public int M_ManHuaUpdate(Model.M_ManHua model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE M_ManHua SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("SearchName=@SearchName,");
            strSql.Append("UpSate=@UpSate,");
            strSql.Append("Author=@Author,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("LatestChapter=@LatestChapter,");
            strSql.Append("IsIndex=@IsIndex,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("Cagegory=@Cagegory,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("FromUrl=@FromUrl,");
            strSql.Append("DownUrl=@DownUrl,");
            strSql.Append("DownName=@DownName,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,200),
               new SqlParameter("@SearchName", SqlDbType.NVarChar,500),
               new SqlParameter("@UpSate", SqlDbType.NChar,20),
               new SqlParameter("@Author", SqlDbType.NChar,20),
               new SqlParameter("@Hits", SqlDbType.Int,4),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@LatestChapter", SqlDbType.NVarChar,100),
               new SqlParameter("@IsIndex", SqlDbType.Int,4),
               new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
               new SqlParameter("@Cagegory", SqlDbType.NChar,20),
               new SqlParameter("@AddUser", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@FromUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@DownUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@DownName", SqlDbType.NVarChar,100),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.SearchName;
            parameters[3].Value = model.UpSate;
            parameters[4].Value = model.Author;
            parameters[5].Value = model.Hits;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.LatestChapter;
            parameters[8].Value = model.IsIndex;
            parameters[9].Value = model.Introduce;
            parameters[10].Value = model.Cagegory;
            parameters[11].Value = model.AddUser;
            parameters[12].Value = model.Memo;
            parameters[13].Value = model.Cover;
            parameters[14].Value = model.FromUrl;
            parameters[15].Value = model.DownUrl;
            parameters[16].Value = model.DownName;
            parameters[17].Value = model.Enable;
            parameters[18].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.M_ManHua GetModelByM_ManHua(int ID)
        {
            string sql = string.Format("SELECT * FROM M_ManHua WITH(NOLOCK) WHERE ID={0}", ID);
            Model.M_ManHua model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.M_ManHua();
                    }
                    model = ConvetToM_ManHua(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_ManHua> GetListM_ManHua(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.M_ManHua> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "M_ManHua", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.M_ManHua>();
                    }
                    list.Add(ConvetToM_ManHua(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.M_ManHua> GetPageM_ManHua(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.M_ManHua> list = new List<Yax.Model.M_ManHua>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "M_ManHua", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToM_ManHua(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
