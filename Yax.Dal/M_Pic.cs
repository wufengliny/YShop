using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// M_Pic
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表M_Pic)
        /// </summary>
        public static Model.M_Pic ConvertToM_Pic(DataRow dr)
        {
            Model.M_Pic model = new Model.M_Pic();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.ImgUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ImgUrl"]) ? string.Empty : dr["ImgUrl"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.ChapterID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ChapterID"]) ? 0 : int.Parse(dr["ChapterID"].ToString());
            model.PageNum = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PageNum"]) ? 0 : int.Parse(dr["PageNum"].ToString());//页数
            model.FromPic = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromPic"]) ? string.Empty : dr["FromPic"].ToString();//来源图片网址

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表M_Pic)
        /// </summary>
        public static Model.M_Pic ConvetToM_Pic(SqlDataReader reader, string extParam)
        {
            Model.M_Pic model = new Model.M_Pic();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.ImgUrl = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Enable = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.AddTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.Sort = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
            model.ChapterID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.PageNum = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);//页数
            model.FromPic = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//来源图片网址

            return model;
        }
        /// <summary>
        /// 增加一条数据(表M_Pic)
        /// </summary>
        public int M_PicAdd(Model.M_Pic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO M_Pic(");
            strSql.Append("ImgUrl,Enable,AddTime,Sort,ChapterID,PageNum,FromPic)");
            strSql.Append(" VALUES (");
            strSql.Append("@ImgUrl,@Enable,@AddTime,@Sort,@ChapterID,@PageNum,@FromPic)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@ChapterID", SqlDbType.Int,4),
                    new SqlParameter("@PageNum", SqlDbType.Int,4),
                    new SqlParameter("@FromPic", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ImgUrl;
            parameters[1].Value = model.Enable;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.ChapterID;
            parameters[5].Value = model.PageNum;
            parameters[6].Value = model.FromPic;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表M_Pic)
        /// </summary>
        public int M_PicUpdate(Model.M_Pic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE M_Pic SET ");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("ChapterID=@ChapterID,");
            strSql.Append("PageNum=@PageNum,");
            strSql.Append("FromPic=@FromPic");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@ImgUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@ChapterID", SqlDbType.Int,4),
               new SqlParameter("@PageNum", SqlDbType.Int,4),
               new SqlParameter("@FromPic", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ImgUrl;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.ChapterID;
            parameters[6].Value = model.PageNum;
            parameters[7].Value = model.FromPic;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.M_Pic GetModelByM_Pic(int ID)
        {
            string sql = string.Format("SELECT * FROM M_Pic WITH(NOLOCK) WHERE ID={0}", ID);
            Model.M_Pic model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.M_Pic();
                    }
                    model = ConvetToM_Pic(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_Pic> GetListM_Pic(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.M_Pic> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "M_Pic", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.M_Pic>();
                    }
                    list.Add(ConvetToM_Pic(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.M_Pic> GetPageM_Pic(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.M_Pic> list = new List<Yax.Model.M_Pic>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "M_Pic", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToM_Pic(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
