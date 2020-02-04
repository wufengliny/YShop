using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Power
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Power)
        /// </summary>
        public static Model.Power ConvertToPower(DataRow dr)
        {
            Model.Power model = new Model.Power();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.MenuID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MenuID"]) ? string.Empty : dr["MenuID"].ToString();//菜单ID
            model.MenuType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MenuType"]) ? string.Empty : dr["MenuType"].ToString();//企业后台 聊天后台  商城后台 或者其他
            model.AdminGroupID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AdminGroupID"]) ? 0 : int.Parse(dr["AdminGroupID"].ToString());
            model.Mark = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Mark"]) ? string.Empty : dr["Mark"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Power)
        /// </summary>
        public static Model.Power ConvetToPower(SqlDataReader reader, string extParam)
        {
            Model.Power model = new Model.Power();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.MenuID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//菜单ID
            model.MenuType = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//企业后台 聊天后台  商城后台 或者其他
            model.AdminGroupID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.Mark = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Power)
        /// </summary>
        public int PowerAdd(Model.Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Power(");
            strSql.Append("MenuID,MenuType,AdminGroupID,Mark)");
            strSql.Append(" VALUES (");
            strSql.Append("@MenuID,@MenuType,@AdminGroupID,@Mark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.NVarChar,100),
                    new SqlParameter("@MenuType", SqlDbType.NVarChar,100),
                    new SqlParameter("@AdminGroupID", SqlDbType.Int,4),
                    new SqlParameter("@Mark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.MenuType;
            parameters[2].Value = model.AdminGroupID;
            parameters[3].Value = model.Mark;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int PowerAdd_list(string SQLPower)
        {
            int res = 0;
            res = Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, SQLPower);
            return res;
        }
        /// <summary>
        /// 修改数据(表Power)
        /// </summary>
        public int PowerUpdate(Model.Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Power SET ");
            strSql.Append("MenuID=@MenuID,");
            strSql.Append("MenuType=@MenuType,");
            strSql.Append("AdminGroupID=@AdminGroupID,");
            strSql.Append("Mark=@Mark");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@MenuID", SqlDbType.NVarChar,100),
               new SqlParameter("@MenuType", SqlDbType.NVarChar,100),
               new SqlParameter("@AdminGroupID", SqlDbType.Int,4),
               new SqlParameter("@Mark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MenuID;
            parameters[2].Value = model.MenuType;
            parameters[3].Value = model.AdminGroupID;
            parameters[4].Value = model.Mark;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Power GetModelByPower(int ID)
        {
            string sql = string.Format("SELECT * FROM Power WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Power model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Power();
                    }
                    model = ConvetToPower(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Power> GetListPower(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Power> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Power", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Power>();
                    }
                    list.Add(ConvetToPower(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Power> GetPagePower(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Power> list = new List<Yax.Model.Power>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Power", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToPower(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
