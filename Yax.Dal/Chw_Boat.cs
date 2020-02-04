using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Chw_Boat
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Chw_Boat)
        /// </summary>
        public static Model.Chw_Boat ConvertToChw_Boat(DataRow dr)
        {
            Model.Chw_Boat model = new Model.Chw_Boat();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();//游艇名称
            model.Introduce = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Introduce"]) ? string.Empty : dr["Introduce"].ToString();//游艇介绍
            model.Attention = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Attention"]) ? string.Empty : dr["Attention"].ToString();//注意事项
            model.Hit = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Hit"]) ? 0 : int.Parse(dr["Hit"].ToString());
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.ContactMan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ContactMan"]) ? string.Empty : dr["ContactMan"].ToString();//联系人，负责人
            model.ContantPhone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ContantPhone"]) ? string.Empty : dr["ContantPhone"].ToString();//联系电话
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? string.Empty : dr["State"].ToString();//上架状态1 待审核  2上架中  3 已下架
            model.MaxNum = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MaxNum"]) ? 0 : int.Parse(dr["MaxNum"].ToString());//最多几人
            model.Cover = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cover"]) ? string.Empty : dr["Cover"].ToString();
            model.PriceMemo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PriceMemo"]) ? string.Empty : dr["PriceMemo"].ToString();//价格说明

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Chw_Boat)
        /// </summary>
        public static Model.Chw_Boat ConvetToChw_Boat(SqlDataReader reader, string extParam)
        {
            Model.Chw_Boat model = new Model.Chw_Boat();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//游艇名称
            model.Introduce = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//游艇介绍
            model.Attention = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//注意事项
            model.Hit = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
            model.Sort = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.AddTime = reader.IsDBNull(6) ? System.DateTime.MinValue : reader.GetDateTime(6);
            model.Memo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.ContactMan = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);//联系人，负责人
            model.ContantPhone = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);//联系电话
            model.State = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);//上架状态1 待审核  2上架中  3 已下架
            model.MaxNum = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);//最多几人
            model.Cover = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            model.PriceMemo = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);//价格说明

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Chw_Boat)
        /// </summary>
        public int Chw_BoatAdd(Model.Chw_Boat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Chw_Boat(");
            strSql.Append("Name,Introduce,Attention,Hit,Sort,AddTime,Memo,ContactMan,ContantPhone,State,MaxNum,Cover,PriceMemo)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Introduce,@Attention,@Hit,@Sort,@AddTime,@Memo,@ContactMan,@ContantPhone,@State,@MaxNum,@Cover,@PriceMemo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,500),
                    new SqlParameter("@Introduce", SqlDbType.NVarChar,-1),
                    new SqlParameter("@Attention", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Hit", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ContactMan", SqlDbType.NVarChar,100),
                    new SqlParameter("@ContantPhone", SqlDbType.NVarChar,100),
                    new SqlParameter("@State", SqlDbType.NVarChar,6),
                    new SqlParameter("@MaxNum", SqlDbType.Int,4),
                    new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                    new SqlParameter("@PriceMemo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Introduce;
            parameters[2].Value = model.Attention;
            parameters[3].Value = model.Hit;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Memo;
            parameters[7].Value = model.ContactMan;
            parameters[8].Value = model.ContantPhone;
            parameters[9].Value = model.State;
            parameters[10].Value = model.MaxNum;
            parameters[11].Value = model.Cover;
            parameters[12].Value = model.PriceMemo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Chw_Boat)
        /// </summary>
        public int Chw_BoatUpdate(Model.Chw_Boat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Chw_Boat SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("Attention=@Attention,");
            strSql.Append("Hit=@Hit,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("ContactMan=@ContactMan,");
            strSql.Append("ContantPhone=@ContantPhone,");
            strSql.Append("State=@State,");
            strSql.Append("MaxNum=@MaxNum,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("PriceMemo=@PriceMemo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@Introduce", SqlDbType.NVarChar,-1),
               new SqlParameter("@Attention", SqlDbType.NVarChar,1000),
               new SqlParameter("@Hit", SqlDbType.Int,4),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@ContactMan", SqlDbType.NVarChar,100),
               new SqlParameter("@ContantPhone", SqlDbType.NVarChar,100),
               new SqlParameter("@State", SqlDbType.NVarChar,6),
               new SqlParameter("@MaxNum", SqlDbType.Int,4),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@PriceMemo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Introduce;
            parameters[3].Value = model.Attention;
            parameters[4].Value = model.Hit;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.ContactMan;
            parameters[9].Value = model.ContantPhone;
            parameters[10].Value = model.State;
            parameters[11].Value = model.MaxNum;
            parameters[12].Value = model.Cover;
            parameters[13].Value = model.PriceMemo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Chw_Boat GetModelByChw_Boat(int ID)
        {
            string sql = string.Format("SELECT * FROM Chw_Boat WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Chw_Boat model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Chw_Boat();
                    }
                    model = ConvetToChw_Boat(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Chw_Boat> GetListChw_Boat(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Chw_Boat> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Chw_Boat", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Chw_Boat>();
                    }
                    list.Add(ConvetToChw_Boat(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Chw_Boat> GetPageChw_Boat(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Chw_Boat> list = new List<Yax.Model.Chw_Boat>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Chw_Boat", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToChw_Boat(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
