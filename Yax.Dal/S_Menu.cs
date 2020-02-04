using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// S_Menu
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表S_Menu)
        /// </summary>
        public static Model.S_Menu ConvertToS_Menu(DataRow dr,string view="table")
        {
            Model.S_Menu model = new Model.S_Menu();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());//ID
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();//菜单名/菜单类型
            model.ParentID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ParentID"]) ? 0 : int.Parse(dr["ParentID"].ToString());//父级
            model.Href = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Href"]) ? string.Empty : dr["Href"].ToString();//Url链接目标
            model.Type = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Type"]) ? 0 : int.Parse(dr["Type"].ToString());//1.前台，2.会员中心，3.管理后台，4.代理
            model.Icon = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Icon"]) ? string.Empty : dr["Icon"].ToString();
            model.Target = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Target"]) ? string.Empty : dr["Target"].ToString();//页面类型
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());//排序
            model.AddUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddUser"]) ? 0 : int.Parse(dr["AddUser"].ToString());//添加人
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString()); //添加时间
            model.LastModifyUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastModifyUser"]) ? 0 : int.Parse(dr["LastModifyUser"].ToString());//最新修改人
            model.LastModifyTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastModifyTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastModifyTime"].ToString()); //最新修改时间
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());//启用状态
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();//备注
            return model;
        }
        /// <summary>
        /// 数据转换成实体(表S_Menu)
        /// </summary>
        public static Model.S_Menu ConvetToS_Menu(SqlDataReader reader, string extParam)
        {
            Model.S_Menu model = new Model.S_Menu();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);//ID
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//菜单名/菜单类型
            model.ParentID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);//父级
            model.Href = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//Url链接目标
            model.Type = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);//1.前台，2.会员中心，3.管理后台，4.代理
            model.Icon = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.Target = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//页面类型
            model.Sort = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);//排序
            model.AddUser = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);//添加人
            model.AddTime = reader.IsDBNull(9) ? System.DateTime.MinValue : reader.GetDateTime(9);//添加时间
            model.LastModifyUser = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);//最新修改人
            model.LastModifyTime = reader.IsDBNull(11) ? System.DateTime.MinValue : reader.GetDateTime(11);//最新修改时间
            model.Enable = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);//启用状态
            model.Memo = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);//备注
            try
            {
                model.NameParent = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);//备注
            }
            catch
            { 
            }
            return model;
        }
        /// <summary>
        /// 增加一条数据(表S_Menu)
        /// </summary>
        public int S_MenuAdd(Model.S_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_Menu(");
            strSql.Append("Name,ParentID,Href,Type,Icon,Target,Sort,AddUser,AddTime,LastModifyUser,LastModifyTime,Enable,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@ParentID,@Href,@Type,@Icon,@Target,@Sort,@AddUser,@AddTime,@LastModifyUser,@LastModifyTime,@Enable,@Memo)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.VarChar,100),
		            new SqlParameter("@ParentID", SqlDbType.Int,4),
		            new SqlParameter("@Href", SqlDbType.VarChar,1000),
		            new SqlParameter("@Type", SqlDbType.Int,4),
		            new SqlParameter("@Icon", SqlDbType.VarChar,50),
		            new SqlParameter("@Target", SqlDbType.VarChar,100),
		            new SqlParameter("@Sort", SqlDbType.Int,4),
		            new SqlParameter("@AddUser", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
		            new SqlParameter("@LastModifyTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@Memo", SqlDbType.VarChar,5000)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Href;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Icon;
            parameters[5].Value = model.Target;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.AddUser;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.LastModifyUser;
            parameters[10].Value = model.LastModifyTime;
            parameters[11].Value = model.Enable;
            parameters[12].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表S_Menu)
        /// </summary>
        public int S_MenuUpdate(Model.S_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Menu SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Href=@Href,");
            strSql.Append("Type=@Type,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Target=@Target,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("LastModifyUser=@LastModifyUser,");
            strSql.Append("LastModifyTime=@LastModifyTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.VarChar,100),
               new SqlParameter("@ParentID", SqlDbType.Int,4),
               new SqlParameter("@Href", SqlDbType.VarChar,1000),
               new SqlParameter("@Type", SqlDbType.Int,4),
               new SqlParameter("@Icon", SqlDbType.VarChar,50),
               new SqlParameter("@Target", SqlDbType.VarChar,100),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@AddUser", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
               new SqlParameter("@LastModifyTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.VarChar,5000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Href;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Icon;
            parameters[6].Value = model.Target;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.AddUser;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.LastModifyUser;
            parameters[11].Value = model.LastModifyTime;
            parameters[12].Value = model.Enable;
            parameters[13].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }



        public int S_MenuUpdate_ht(Model.S_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Menu SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Href=@Href,");
            strSql.Append("Type=@Type,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Target=@Target,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("LastModifyUser=@LastModifyUser,");
            strSql.Append("LastModifyTime=@LastModifyTime,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.VarChar,100),
               new SqlParameter("@ParentID", SqlDbType.Int,4),
               new SqlParameter("@Href", SqlDbType.VarChar,1000),
               new SqlParameter("@Type", SqlDbType.Int,4),
               new SqlParameter("@Icon", SqlDbType.VarChar,50),
               new SqlParameter("@Target", SqlDbType.VarChar,100),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
               new SqlParameter("@LastModifyTime", SqlDbType.DateTime,8),
               new SqlParameter("@Memo", SqlDbType.VarChar,5000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Href;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Icon;
            parameters[6].Value = model.Target;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.LastModifyUser;
            parameters[9].Value = model.LastModifyTime;
            parameters[10].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }



        public int S_MenuUpdate_enable(Model.S_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Menu SET ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.S_Menu GetModelByS_Menu(int ID)
        {
            string sql = string.Format("SELECT * FROM S_Menu WITH(NOLOCK) WHERE ID={0}", ID);
            Model.S_Menu model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.S_Menu();
                    }
                    model = ConvetToS_Menu(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.S_Menu> GetListS_Menu(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.S_Menu> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "S_Menu", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.S_Menu>();
                    }
                    list.Add(ConvetToS_Menu(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.S_Menu> GetPageS_Menu(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.S_Menu> list = new List<Yax.Model.S_Menu>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "S_Menu", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToS_Menu(dt.Rows[i]));
                }
            }
            return list;
        }

        //with ParentName
        public DataTable GetPageS_Menu_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View_S_menu", out TotalRecord);
            return dt;
        }



    }
}
