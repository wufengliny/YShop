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
    public class DC_Tags
    {
        public List<object> Pager(int pageIndex, int pageSize, string strOrder)
        {
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = strOrder,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "C_Tags",
                WhereString = ""
            };
            return AspNetPagerList.PagerLsit<MC_Tags>(modelp);
        }
        public MC_Tags GetModelByID(int ID)
        {
            string str = "select * from C_Tags where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MC_Tags>(CommandType.Text, str, param);
        }
        public MC_Tags GetModelByName(string Name)
        {
            string str = "select * from C_Tags where Name=@Name";
            SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
            param.Value = Name;
            return SQLHelper.ExecuteReaderObject<MC_Tags>(CommandType.Text, str, param);
        }
        public int Add(MC_Tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO C_Tags(");
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

        public int Delete(int id)
        {
            string str = " delete from C_Tags where ID=@ID ";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }


    }
}
