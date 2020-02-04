using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// M_Chapter
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表M_Chapter)
        /// </summary>
        public static Model.M_Chapter ConvertToM_Chapter(DataRow dr)
        {
            Model.M_Chapter model = new Model.M_Chapter();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.ManHuaID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ManHuaID"]) ? 0 : int.Parse(dr["ManHuaID"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.FromUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromUrl"]) ? string.Empty : dr["FromUrl"].ToString();//来源网址

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表M_Chapter)
        /// </summary>
        public static Model.M_Chapter ConvetToM_Chapter(SqlDataReader reader, string extParam)
        {
            Model.M_Chapter model = new Model.M_Chapter();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.ManHuaID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.AddTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);
            model.Sort = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.FromUrl = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//来源网址

            return model;
        }
        /// <summary>
        /// 增加一条数据(表M_Chapter)
        /// </summary>
        public int M_ChapterAdd(Model.M_Chapter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO M_Chapter(");
            strSql.Append("Name,ManHuaID,Enable,AddTime,Sort,FromUrl)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@ManHuaID,@Enable,@AddTime,@Sort,@FromUrl)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@ManHuaID", SqlDbType.Int,4),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@FromUrl", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ManHuaID;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.FromUrl;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表M_Chapter)
        /// </summary>
        public int M_ChapterUpdate(Model.M_Chapter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE M_Chapter SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("ManHuaID=@ManHuaID,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("FromUrl=@FromUrl");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@ManHuaID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@FromUrl", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ManHuaID;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.FromUrl;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.M_Chapter GetModelByM_Chapter(int ID)
        {
            string sql = string.Format("SELECT * FROM M_Chapter WITH(NOLOCK) WHERE ID={0}", ID);
            Model.M_Chapter model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.M_Chapter();
                    }
                    model = ConvetToM_Chapter(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_Chapter> GetListM_Chapter(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.M_Chapter> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "M_Chapter", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.M_Chapter>();
                    }
                    list.Add(ConvetToM_Chapter(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.M_Chapter> GetPageM_Chapter(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.M_Chapter> list = new List<Yax.Model.M_Chapter>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "M_Chapter", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToM_Chapter(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
