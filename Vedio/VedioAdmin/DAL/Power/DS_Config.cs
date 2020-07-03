using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using CommSQLHelper;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DS_Config
    {
        /// <summary>
        /// 更新系统配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateByKey(string key,string Val)
        {
            string str = " UPDATE [S_Config] SET [Value]=@Value WHERE [key]=@Key  ";
            SqlParameter[] parameters = {
                new SqlParameter("@Value", SqlDbType.NVarChar,5000),
               new SqlParameter("@Key", SqlDbType.NVarChar,100),
             };
            parameters[0].Value =Val;
            parameters[1].Value =key;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, parameters);
        }

        public int UpdateByID(int id, string val,string memo)
        {
            string str = " UPDATE [S_Config] SET [Value]=@Value,[Memo]=@Memo WHERE [ID]=@ID ";
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@Value", SqlDbType.NVarChar,1000),
             };
            parameters[0].Value = id;
            parameters[1].Value = memo;
            parameters[2].Value = val;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, parameters);
        }
        public int Add(MS_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_Config(");
            strSql.Append("[key],Name,[Value],[Group],CanEdit,CanDelete,AddUser,AddTime,LastModifyUser,LastModifyTime,Enable,Memo,[sort])");
            strSql.Append(" VALUES (");
            strSql.Append("@key,@Name,@Value,@Group,@CanEdit,@CanDelete,@AddUser,@AddTime,@LastModifyUser,@LastModifyTime,@Enable,@Memo,@sort)");
            SqlParameter[] parameters = {
                    new SqlParameter("@key", SqlDbType.VarChar,100),
                    new SqlParameter("@Name", SqlDbType.VarChar,1000),
                    new SqlParameter("@Value", SqlDbType.VarChar,5000),
                    new SqlParameter("@Group", SqlDbType.VarChar,500),
                    new SqlParameter("@CanEdit", SqlDbType.Int,4),
                    new SqlParameter("@CanDelete", SqlDbType.Int,4),
                    new SqlParameter("@AddUser", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
                    new SqlParameter("@LastModifyTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.VarChar,5000),
                    new SqlParameter("@sort", SqlDbType.Int,4)};
            parameters[0].Value = model.key;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Value;
            parameters[3].Value = model.Group;
            parameters[4].Value = model.CanEdit;
            parameters[5].Value = model.CanDelete;
            parameters[6].Value = model.AddUser;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.LastModifyUser;
            parameters[9].Value = model.LastModifyTime;
            parameters[10].Value = model.Enable;
            parameters[11].Value = model.Memo;
            parameters[12].Value = model.Sort;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }


        /// <summary>
        /// kay
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public MS_Config GetModelByKey(string key)
        {
            string Fileds = "ID,[key],Name,Value,[Group],CanEdit,CanDelete,AddUser,AddTime,LastModifyUser,LastModifyTime,Enable,Memo,[sort]";
            string str = " SELECT  " + Fileds + "  FROM [S_Config] where [key]=@key";
            SqlParameter param = new SqlParameter("@key", SqlDbType.NVarChar, 100);
            param.Value = key;
            return SQLHelper.ExecuteReaderObject<MS_Config>(CommandType.Text, str, param);
        }
        /// <summary>
        /// kay 根据ID查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MS_Config GetModelByID(int id)
        {
            string Fileds = "ID,[key],Name,Value,[Group],CanEdit,CanDelete,AddUser,AddTime,LastModifyUser,LastModifyTime,Enable,Memo,[sort]";
            string str = " SELECT  " + Fileds + "  FROM [S_Config] where [ID]=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = id;
            return SQLHelper.ExecuteReaderObject<MS_Config>(CommandType.Text, str, param);
        }

        /// <summary>
        /// kay
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public IList<MS_Config> GetListByGroup(string group)
        {
            string Fileds = "ID,[key],Name,Value,[Group],CanEdit,CanDelete,AddUser,AddTime,LastModifyUser,LastModifyTime,Enable,Memo,[sort]";
            string str = " SELECT  " + Fileds + "  FROM [S_Config] where [Group]=@Group";
            SqlParameter param = new SqlParameter("@Group", SqlDbType.NVarChar, 100);
            param.Value = group;
            return SQLHelper.ExecuteReaderList<MS_Config>(CommandType.Text, str, param);
        }

        /// <summary>
        /// kay
        /// </summary>
        /// <returns></returns>
        public IList<MS_Config> GetALL()
        {
            string Fileds = "ID,[key],Name,Value,[Group],CanEdit,CanDelete,AddUser,AddTime,LastModifyUser,LastModifyTime,Enable,Memo,[sort]";
            string str = " SELECT  " + Fileds + "  FROM [S_Config] ";
            return SQLHelper.ExecuteReaderList<MS_Config>(CommandType.Text, str);
        }




    }
}
