using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// TPay_ZFBConfig
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表TPay_ZFBConfig)
        /// </summary>
        public static Model.TPay_ZFBConfig ConvertToTPay_ZFBConfig(DataRow dr)
        {
            Model.TPay_ZFBConfig model = new Model.TPay_ZFBConfig();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.APPID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["APPID"]) ? string.Empty : dr["APPID"].ToString();//支付宝 : APPID PC
            model.PrivateKeyPC = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PrivateKeyPC"]) ? string.Empty : dr["PrivateKeyPC"].ToString();//支付宝：商户私钥 PC端 
            model.PublicKeyPC = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PublicKeyPC"]) ? string.Empty : dr["PublicKeyPC"].ToString();//支付宝公钥 对应APPID下的支付宝公钥。
            model.Partner = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Partner"]) ? string.Empty : dr["Partner"].ToString();//合作身份者ID wap
            model.PrivateKeyWap = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PrivateKeyWap"]) ? string.Empty : dr["PrivateKeyWap"].ToString();
            model.PublicKeyWap = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PublicKeyWap"]) ? string.Empty : dr["PublicKeyWap"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());//1正常2维护3禁用
            model.MinMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MinMoney"]) ? 0 : decimal.Parse(dr["MinMoney"].ToString()); //此通道最低充值金额
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表TPay_ZFBConfig)
        /// </summary>
        public static Model.TPay_ZFBConfig ConvetToTPay_ZFBConfig(SqlDataReader reader, string extParam)
        {
            Model.TPay_ZFBConfig model = new Model.TPay_ZFBConfig();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.APPID = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//支付宝 : APPID PC
            model.PrivateKeyPC = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//支付宝：商户私钥 PC端 
            model.PublicKeyPC = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//支付宝公钥 对应APPID下的支付宝公钥。
            model.Partner = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);//合作身份者ID wap
            model.PrivateKeyWap = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.PublicKeyWap = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.AddTime = reader.IsDBNull(8) ? System.DateTime.MinValue : reader.GetDateTime(8);
            model.Enable = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);//1正常2维护3禁用
            model.MinMoney = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);//此通道最低充值金额
            model.Memo = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表TPay_ZFBConfig)
        /// </summary>
        public int TPay_ZFBConfigAdd(Model.TPay_ZFBConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TPay_ZFBConfig(");
            strSql.Append("Name,APPID,PrivateKeyPC,PublicKeyPC,Partner,PrivateKeyWap,PublicKeyWap,AddTime,Enable,MinMoney,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@APPID,@PrivateKeyPC,@PublicKeyPC,@Partner,@PrivateKeyWap,@PublicKeyWap,@AddTime,@Enable,@MinMoney,@Memo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@APPID", SqlDbType.NVarChar,100),
                    new SqlParameter("@PrivateKeyPC", SqlDbType.NVarChar,-1),
                    new SqlParameter("@PublicKeyPC", SqlDbType.NVarChar,-1),
                    new SqlParameter("@Partner", SqlDbType.NVarChar,100),
                    new SqlParameter("@PrivateKeyWap", SqlDbType.NVarChar,-1),
                    new SqlParameter("@PublicKeyWap", SqlDbType.NVarChar,-1),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@MinMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.APPID;
            parameters[2].Value = model.PrivateKeyPC;
            parameters[3].Value = model.PublicKeyPC;
            parameters[4].Value = model.Partner;
            parameters[5].Value = model.PrivateKeyWap;
            parameters[6].Value = model.PublicKeyWap;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.MinMoney;
            parameters[10].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表TPay_ZFBConfig)
        /// </summary>
        public int TPay_ZFBConfigUpdate(Model.TPay_ZFBConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TPay_ZFBConfig SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("APPID=@APPID,");
            strSql.Append("PrivateKeyPC=@PrivateKeyPC,");
            strSql.Append("PublicKeyPC=@PublicKeyPC,");
            strSql.Append("Partner=@Partner,");
            strSql.Append("PrivateKeyWap=@PrivateKeyWap,");
            strSql.Append("PublicKeyWap=@PublicKeyWap,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("MinMoney=@MinMoney,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@APPID", SqlDbType.NVarChar,100),
               new SqlParameter("@PrivateKeyPC", SqlDbType.NVarChar,-1),
               new SqlParameter("@PublicKeyPC", SqlDbType.NVarChar,-1),
               new SqlParameter("@Partner", SqlDbType.NVarChar,100),
               new SqlParameter("@PrivateKeyWap", SqlDbType.NVarChar,-1),
               new SqlParameter("@PublicKeyWap", SqlDbType.NVarChar,-1),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@MinMoney", SqlDbType.Decimal,9),
               new SqlParameter("@Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.APPID;
            parameters[3].Value = model.PrivateKeyPC;
            parameters[4].Value = model.PublicKeyPC;
            parameters[5].Value = model.Partner;
            parameters[6].Value = model.PrivateKeyWap;
            parameters[7].Value = model.PublicKeyWap;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.MinMoney;
            parameters[11].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.TPay_ZFBConfig GetModelByTPay_ZFBConfig(int ID)
        {
            string sql = string.Format("SELECT * FROM TPay_ZFBConfig WITH(NOLOCK) WHERE ID={0}", ID);
            Model.TPay_ZFBConfig model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TPay_ZFBConfig();
                    }
                    model = ConvetToTPay_ZFBConfig(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_ZFBConfig> GetListTPay_ZFBConfig(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.TPay_ZFBConfig> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "TPay_ZFBConfig", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.TPay_ZFBConfig>();
                    }
                    list.Add(ConvetToTPay_ZFBConfig(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.TPay_ZFBConfig> GetPageTPay_ZFBConfig(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.TPay_ZFBConfig> list = new List<Yax.Model.TPay_ZFBConfig>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "TPay_ZFBConfig", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTPay_ZFBConfig(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
