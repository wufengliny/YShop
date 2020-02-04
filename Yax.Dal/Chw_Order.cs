using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Chw_Order
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Chw_Order)
        /// </summary>
        public static Model.Chw_Order ConvertToChw_Order(DataRow dr)
        {
            Model.Chw_Order model = new Model.Chw_Order();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.BeginTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BeginTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["BeginTime"].ToString());
            model.EndTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["EndTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["EndTime"].ToString());
            model.BoatID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BoatID"]) ? 0 : int.Parse(dr["BoatID"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();//订单备注
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? string.Empty : dr["State"].ToString();//1 待审核  2已审核 3 已取消
            model.PeopleNum = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PeopleNum"]) ? 0 : int.Parse(dr["PeopleNum"].ToString());//人数
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Chw_Order)
        /// </summary>
        public static Model.Chw_Order ConvetToChw_Order(SqlDataReader reader, string extParam)
        {
            Model.Chw_Order model = new Model.Chw_Order();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.OrderNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.UID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.BeginTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.EndTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);
            model.BoatID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.Memo = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//订单备注
            model.AddTime = reader.IsDBNull(7) ? System.DateTime.MinValue : reader.GetDateTime(7);
            model.State = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);//1 待审核  2已审核 3 已取消
            model.PeopleNum = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);//人数
            model.Phone = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Chw_Order)
        /// </summary>
        public int Chw_OrderAdd(Model.Chw_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Chw_Order(");
            strSql.Append("OrderNO,UID,BeginTime,EndTime,BoatID,Memo,AddTime,State,PeopleNum,Phone)");
            strSql.Append(" VALUES (");
            strSql.Append("@OrderNO,@UID,@BeginTime,@EndTime,@BoatID,@Memo,@AddTime,@State,@PeopleNum,@Phone)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@BeginTime", SqlDbType.DateTime,8),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,8),
                    new SqlParameter("@BoatID", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@State", SqlDbType.NVarChar,100),
                    new SqlParameter("@PeopleNum", SqlDbType.Int,4),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.OrderNO;
            parameters[1].Value = model.UID;
            parameters[2].Value = model.BeginTime;
            parameters[3].Value = model.EndTime;
            parameters[4].Value = model.BoatID;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.State;
            parameters[8].Value = model.PeopleNum;
            parameters[9].Value = model.Phone;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Chw_Order)
        /// </summary>
        public int Chw_OrderUpdate(Model.Chw_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Chw_Order SET ");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("UID=@UID,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("BoatID=@BoatID,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("State=@State,");
            strSql.Append("PeopleNum=@PeopleNum,");
            strSql.Append("Phone=@Phone");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@BeginTime", SqlDbType.DateTime,8),
               new SqlParameter("@EndTime", SqlDbType.DateTime,8),
               new SqlParameter("@BoatID", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@State", SqlDbType.NVarChar,100),
               new SqlParameter("@PeopleNum", SqlDbType.Int,4),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderNO;
            parameters[2].Value = model.UID;
            parameters[3].Value = model.BeginTime;
            parameters[4].Value = model.EndTime;
            parameters[5].Value = model.BoatID;
            parameters[6].Value = model.Memo;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.State;
            parameters[9].Value = model.PeopleNum;
            parameters[10].Value = model.Phone;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Chw_Order GetModelByChw_Order(int ID)
        {
            string sql = string.Format("SELECT * FROM Chw_Order WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Chw_Order model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Chw_Order();
                    }
                    model = ConvetToChw_Order(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Chw_Order> GetListChw_Order(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Chw_Order> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Chw_Order", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Chw_Order>();
                    }
                    list.Add(ConvetToChw_Order(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Chw_Order> GetPageChw_Order(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Chw_Order> list = new List<Yax.Model.Chw_Order>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Chw_Order", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToChw_Order(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
