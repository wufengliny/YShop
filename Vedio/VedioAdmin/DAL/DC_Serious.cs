using CommSQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DC_Serious
    {
        public List<object> Pager(int pageIndex, int pageSize, string strOrder)
        {
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = strOrder,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "C_Serious",
                WhereString = ""
            };
            return AspNetPagerList.PagerLsit<MC_Serious>(modelp);
        }
        public IList<MC_Serious> List()
        {
            string str = " select * from C_Serious order by Sort ";
            return SQLHelper.ExecuteReaderList<MC_Serious>(CommandType.Text, str);
        }
        public MC_Serious GetModelByID(int ID)
        {
            string str = "select * from C_Serious where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MC_Serious>(CommandType.Text, str, param);
        }
        public MC_Serious GetModelByName(string Name)
        {
            string str = "select * from C_Serious where Name=@Name";
            SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
            param.Value = Name;
            return SQLHelper.ExecuteReaderObject<MC_Serious>(CommandType.Text, str, param);
        }
        public int Add(MC_Serious model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO C_Serious(");
            strSql.Append("Name,Sort)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Sort)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sort;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Edit(MC_Serious model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_Serious SET ");
            strSql.Append("Name=@Name");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
             };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Delete(int id)
        {
            string str = " delete from C_Serious where ID=@ID ";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }


    }
}
