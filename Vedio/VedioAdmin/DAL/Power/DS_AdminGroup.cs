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
    public class DS_AdminGroup
    {
        public List<object> Pager(int pageIndex, int pageSize, string strOrder)
        {
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = strOrder,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "S_AdminGroup",
                WhereString = ""
            };
            return AspNetPagerList.PagerLsit<MS_AdminGroup>(modelp);
        }

        public DataTable GetAll()
        {
            string str = "select ID,Name from S_AdminGroup where Enable=1 ";
            return SQLHelper.ExecuteDataSet(CommandType.Text,str).Tables[0];
        }

        public int Add(MS_AdminGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_AdminGroup(");
            strSql.Append("Name,AddTime,Enable,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@AddTime,@Enable,@Memo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.Memo;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public MS_AdminGroup GetModelByID(int ID)
        {
            string str = "select * from S_AdminGroup where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_AdminGroup>(CommandType.Text, str, param);
        }
        public MS_AdminGroup GetModelByName(string Name)
        {
            string str = "select * from S_AdminGroup where Name=@Name";
            SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar,20);
            param.Value = Name;
            return SQLHelper.ExecuteReaderObject<MS_AdminGroup>(CommandType.Text, str, param);
        }
        public int Update(string Name, string Memo, int ID)
        {
            string str = " update S_AdminGroup set Name=@Name,Memo=@Memo where id=@id";
            SqlParameter[] paramters = {
                  new SqlParameter("@Name",SqlDbType.NVarChar,20),
                  new SqlParameter("@Memo",SqlDbType.NVarChar,100),
                  new SqlParameter("@id",SqlDbType.Int,4)
            };
            paramters[0].Value = Name;
            paramters[1].Value = Memo;
            paramters[2].Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, paramters);
        }
        public int Delete(int id)
        {
            string str = " delete from S_AdminGroup where ID=@ID ";
            SqlParameter param = new SqlParameter("@ID",SqlDbType.Int,4);
            param.Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }

    }
}
