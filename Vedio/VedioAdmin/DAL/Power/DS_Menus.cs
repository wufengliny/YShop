using CommSQLHelper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DS_Menus
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public IList<MS_Menus> List()
        {
            string Fileds = "ID,Name,ParentID,URL,Icon,Target,Sort,AddUser,AddTime,Enable,Memo,MenuType,Mark";
            string str = " select "+ Fileds + " from S_Menus where Enable=1  order by ParentID asc, Sort asc";
            return SQLHelper.ExecuteReaderList<MS_Menus>(CommandType.Text, str);
        }
        /// <summary>
        /// 获取除按钮外的所有菜单
        /// </summary>
        /// <returns></returns>
        public IList<MS_Menus> ListParentMenu()
        {
            string Fileds = "ID,Name,ParentID";
            string str = " select " + Fileds + " from S_Menus where Enable=1 and MenuType=1 order by ParentID asc, Sort asc";
            return SQLHelper.ExecuteReaderList<MS_Menus>(CommandType.Text, str);
        }

        public MS_Menus GetModelByMark(string Mark)
        {
            string str = "select * from S_Menus where Mark=@Mark";
            SqlParameter param = new SqlParameter("@Mark", SqlDbType.NVarChar, 100);
            param.Value = Mark;
            return SQLHelper.ExecuteReaderObject<MS_Menus>(CommandType.Text, str, param);
        }
        public MS_Menus GetModelById(int  id)
        {
            string str = "select * from S_Menus where id=@id";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Int, 4);
            param.Value = id;
            return SQLHelper.ExecuteReaderObject<MS_Menus>(CommandType.Text, str, param);
        }
        public int Update(MS_Menus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Menus SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("URL=@URL,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Target=@Target,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("MenuType=@MenuType ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,20),
               new SqlParameter("@ParentID", SqlDbType.Int,4),
               new SqlParameter("@URL", SqlDbType.NVarChar,100),
               new SqlParameter("@Icon", SqlDbType.NVarChar,100),
               new SqlParameter("@Target", SqlDbType.NVarChar,16),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,100),
               new SqlParameter("@MenuType", SqlDbType.Int,4),
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.URL;
            parameters[4].Value = model.Icon;
            parameters[5].Value = model.Target;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.MenuType;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int Delete(int id)
        {
            string str = " delete from S_Menus where id=@id ";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Int, 4);
            param.Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }
        public int CountNumByPid(int ParentID)
        {
            string str = " select count(id) from S_Menus where ParentID=@ParentID";
            SqlParameter param = new SqlParameter("@ParentID", SqlDbType.Int, 4);
            param.Value = ParentID;
            object obj= SQLHelper.ExecuteScalar(CommandType.Text, str, param);
            return int.Parse(obj.ToString());
        }

        public int Add(MS_Menus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_Menus(");
            strSql.Append("Name,ParentID,URL,Icon,Target,Sort,AddUser,AddTime,Enable,Memo,MenuType,Mark)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@ParentID,@URL,@Icon,@Target,@Sort,@AddUser,@AddTime,@Enable,@Memo,@MenuType,@Mark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@URL", SqlDbType.NVarChar,100),
                    new SqlParameter("@Icon", SqlDbType.NVarChar,100),
                    new SqlParameter("@Target", SqlDbType.NVarChar,16),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@AddUser", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100),
                    new SqlParameter("@MenuType", SqlDbType.Int,4),
                    new SqlParameter("@Mark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.URL;
            parameters[3].Value = model.Icon;
            parameters[4].Value = model.Target;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.AddUser;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.Memo;
            parameters[10].Value = model.MenuType;
            parameters[11].Value = model.Mark;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
