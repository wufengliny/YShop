using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// JieKuan
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表JieKuan)
        /// </summary>
        public static Model.JieKuan ConvertToJieKuan(DataRow dr)
        {
            Model.JieKuan model = new Model.JieKuan();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();
            model.UserName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserName"]) ? string.Empty : dr["UserName"].ToString();
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString());
            model.JieTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JieTime"]) ? 0 : int.Parse(dr["JieTime"].ToString());//借款 借多久  3个月 6个月  12个月 24个月等等 单位月
            model.MonthFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MonthFee"]) ? 0 : decimal.Parse(dr["MonthFee"].ToString()); //每月利息 
            model.AllFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AllFee"]) ? 0 : decimal.Parse(dr["AllFee"].ToString()); //总利息
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? 0 : int.Parse(dr["State"].ToString());//1 未审核 2 审核通过  3 审核不通过
            model.ApproveTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproveTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["ApproveTime"].ToString()); //管理员操作时间
            model.TiKuanPWD = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["TiKuanPWD"]) ? string.Empty : dr["TiKuanPWD"].ToString();
            model.BankCardID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankCardID"]) ? 0 : int.Parse(dr["BankCardID"].ToString());
            model.BankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankName"]) ? string.Empty : dr["BankName"].ToString();
            model.BankNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankNO"]) ? string.Empty : dr["BankNO"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.ApproveID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproveID"]) ? 0 : int.Parse(dr["ApproveID"].ToString());
            model.ApproveName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproveName"]) ? string.Empty : dr["ApproveName"].ToString();
            model.FeePercent = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FeePercent"]) ? string.Empty : dr["FeePercent"].ToString();//利率%
            model.JieTpye = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JieTpye"]) ? 0 : int.Parse(dr["JieTpye"].ToString());//1 每月等额 2 先息后本

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表JieKuan)
        /// </summary>
        public static Model.JieKuan ConvetToJieKuan(SqlDataReader reader, string extParam)
        {
            Model.JieKuan model = new Model.JieKuan();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.OrderNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.UserName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.UserID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.RealName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Money = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
            model.JieTime = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);//借款 借多久  3个月 6个月  12个月 24个月等等 单位月
            model.MonthFee = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);//每月利息 
            model.AllFee = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);//总利息
            model.AddTime = reader.IsDBNull(9) ? System.DateTime.MinValue : reader.GetDateTime(9);
            model.State = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);//1 未审核 2 审核通过  3 审核不通过
            model.ApproveTime = reader.IsDBNull(11) ? System.DateTime.MinValue : reader.GetDateTime(11);//管理员操作时间
            model.TiKuanPWD = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            model.BankCardID = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
            model.BankName = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
            model.BankNO = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
            model.Enable = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
            model.Memo = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
            model.ApproveID = reader.IsDBNull(18) ? 0 : reader.GetInt32(18);
            model.ApproveName = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
            model.FeePercent = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);//利率%
            model.JieTpye = reader.IsDBNull(21) ? 0 : reader.GetInt32(21);//1 每月等额 2 先息后本

            return model;
        }
        /// <summary>
        /// 增加一条数据(表JieKuan)
        /// </summary>
        public int JieKuanAdd(Model.JieKuan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO JieKuan(");
            strSql.Append("OrderNO,UserName,UserID,RealName,Money,JieTime,MonthFee,AllFee,AddTime,State,ApproveTime,TiKuanPWD,BankCardID,BankName,BankNO,Enable,Memo,ApproveID,ApproveName,FeePercent,JieTpye)");
            strSql.Append(" VALUES (");
            strSql.Append("@OrderNO,@UserName,@UserID,@RealName,@Money,@JieTime,@MonthFee,@AllFee,@AddTime,@State,@ApproveTime,@TiKuanPWD,@BankCardID,@BankName,@BankNO,@Enable,@Memo,@ApproveID,@ApproveName,@FeePercent,@JieTpye)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@JieTime", SqlDbType.Int,4),
                    new SqlParameter("@MonthFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AllFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@ApproveTime", SqlDbType.DateTime,8),
                    new SqlParameter("@TiKuanPWD", SqlDbType.NVarChar,100),
                    new SqlParameter("@BankCardID", SqlDbType.Int,4),
                    new SqlParameter("@BankName", SqlDbType.NVarChar,100),
                    new SqlParameter("@BankNO", SqlDbType.NVarChar,100),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ApproveID", SqlDbType.Int,4),
                    new SqlParameter("@ApproveName", SqlDbType.NVarChar,100),
                    new SqlParameter("@FeePercent", SqlDbType.NVarChar,100),
                    new SqlParameter("@JieTpye", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNO;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.Money;
            parameters[5].Value = model.JieTime;
            parameters[6].Value = model.MonthFee;
            parameters[7].Value = model.AllFee;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.State;
            parameters[10].Value = model.ApproveTime;
            parameters[11].Value = model.TiKuanPWD;
            parameters[12].Value = model.BankCardID;
            parameters[13].Value = model.BankName;
            parameters[14].Value = model.BankNO;
            parameters[15].Value = model.Enable;
            parameters[16].Value = model.Memo;
            parameters[17].Value = model.ApproveID;
            parameters[18].Value = model.ApproveName;
            parameters[19].Value = model.FeePercent;
            parameters[20].Value = model.JieTpye;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表JieKuan)
        /// </summary>
        public int JieKuanUpdate(Model.JieKuan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JieKuan SET ");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Money=@Money,");
            strSql.Append("JieTime=@JieTime,");
            strSql.Append("MonthFee=@MonthFee,");
            strSql.Append("AllFee=@AllFee,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("State=@State,");
            strSql.Append("ApproveTime=@ApproveTime,");
            strSql.Append("TiKuanPWD=@TiKuanPWD,");
            strSql.Append("BankCardID=@BankCardID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankNO=@BankNO,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("ApproveID=@ApproveID,");
            strSql.Append("ApproveName=@ApproveName,");
            strSql.Append("FeePercent=@FeePercent,");
            strSql.Append("JieTpye=@JieTpye");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
               new SqlParameter("@UserName", SqlDbType.NVarChar,100),
               new SqlParameter("@UserID", SqlDbType.Int,4),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@JieTime", SqlDbType.Int,4),
               new SqlParameter("@MonthFee", SqlDbType.Decimal,9),
               new SqlParameter("@AllFee", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@State", SqlDbType.Int,4),
               new SqlParameter("@ApproveTime", SqlDbType.DateTime,8),
               new SqlParameter("@TiKuanPWD", SqlDbType.NVarChar,100),
               new SqlParameter("@BankCardID", SqlDbType.Int,4),
               new SqlParameter("@BankName", SqlDbType.NVarChar,100),
               new SqlParameter("@BankNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@ApproveID", SqlDbType.Int,4),
               new SqlParameter("@ApproveName", SqlDbType.NVarChar,100),
               new SqlParameter("@FeePercent", SqlDbType.NVarChar,100),
               new SqlParameter("@JieTpye", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderNO;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.RealName;
            parameters[5].Value = model.Money;
            parameters[6].Value = model.JieTime;
            parameters[7].Value = model.MonthFee;
            parameters[8].Value = model.AllFee;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.State;
            parameters[11].Value = model.ApproveTime;
            parameters[12].Value = model.TiKuanPWD;
            parameters[13].Value = model.BankCardID;
            parameters[14].Value = model.BankName;
            parameters[15].Value = model.BankNO;
            parameters[16].Value = model.Enable;
            parameters[17].Value = model.Memo;
            parameters[18].Value = model.ApproveID;
            parameters[19].Value = model.ApproveName;
            parameters[20].Value = model.FeePercent;
            parameters[21].Value = model.JieTpye;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int JieKuanUpdate_Money(Model.JieKuan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JieKuan SET ");
            strSql.Append("Money=@Money,");
            strSql.Append("JieTime=@JieTime,");
            strSql.Append("MonthFee=@MonthFee,");
            strSql.Append("FeePercent=@FeePercent");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@JieTime", SqlDbType.Int,4),
               new SqlParameter("@MonthFee", SqlDbType.Decimal,9),
              
               new SqlParameter("@FeePercent", SqlDbType.NVarChar,100)
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Money;
            parameters[2].Value = model.JieTime;
            parameters[3].Value = model.MonthFee;
            parameters[4].Value = model.FeePercent;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int JieKuanUpdate_state(int state,int id,string memo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JieKuan SET ");
            strSql.Append("State=@State, ");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
              
               new SqlParameter("@State", SqlDbType.Int,4),
                 new SqlParameter("@Memo", SqlDbType.NVarChar,1000)

               };
            parameters[0].Value =id;
            
            parameters[1].Value = state;
            parameters[2].Value = memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int JieKuanUpdate_state_pwd_memo(int state, int id, string memo,string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JieKuan SET ");
            strSql.Append("State=@State, ");
            strSql.Append("Memo=@Memo,");
            strSql.Append("TiKuanPWD=@TiKuanPWD ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),

               new SqlParameter("@State", SqlDbType.Int,4),
                 new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                  new SqlParameter("@TiKuanPWD", SqlDbType.NVarChar,100)

               };
            parameters[0].Value = id;

            parameters[1].Value = state;
            parameters[2].Value = memo;
            parameters[3].Value = pwd;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int JieKuanUpdate_pwd(string TiKuanPWD, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JieKuan SET ");
            strSql.Append("TiKuanPWD=@TiKuanPWD ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@TiKuanPWD", SqlDbType.NVarChar,100)

               };
            parameters[0].Value = id;
            parameters[1].Value = TiKuanPWD;


            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int JieKuanUpdate_enable(int enable, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JieKuan SET ");
            strSql.Append("enable=@enable ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
              
               new SqlParameter("@enable", SqlDbType.Int,4)
             
               };
            parameters[0].Value = id;

            parameters[1].Value = enable;


            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.JieKuan GetModelByJieKuan(int ID)
        {
            string sql = string.Format("SELECT * FROM JieKuan WITH(NOLOCK) WHERE ID={0}", ID);
            Model.JieKuan model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.JieKuan();
                    }
                    model = ConvetToJieKuan(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.JieKuan> GetListJieKuan(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.JieKuan> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "JieKuan", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.JieKuan>();
                    }
                    list.Add(ConvetToJieKuan(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.JieKuan> GetPageJieKuan(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.JieKuan> list = new List<Yax.Model.JieKuan>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "JieKuan", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToJieKuan(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
