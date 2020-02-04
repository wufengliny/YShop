using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Address
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Address)
        /// </summary>
        public static Model.Address ConvertToAddress(DataRow dr, string view = "table")
        {
            Model.Address model = new Model.Address();
            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.ReceiveName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ReceiveName"]) ? string.Empty : dr["ReceiveName"].ToString();
            model.Country = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Country"]) ? string.Empty : dr["Country"].ToString();
            model.Province = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Province"]) ? string.Empty : dr["Province"].ToString();
            model.City = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["City"]) ? string.Empty : dr["City"].ToString();
            model.Town = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Town"]) ? string.Empty : dr["Town"].ToString();
            model.DetailAddress = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DetailAddress"]) ? string.Empty : dr["DetailAddress"].ToString();
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();
            model.AddressCode = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddressCode"]) ? string.Empty : dr["AddressCode"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.DefaltAdress = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DefaltAdress"]) ? 0 : int.Parse(dr["DefaltAdress"].ToString());//0  不是默认地址  1 是默认地址
            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Address)
        /// </summary>
        public static Model.Address ConvetToAddress(SqlDataReader reader, string extParam, string view = "table")
        {
            Model.Address model = new Model.Address();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.ReceiveName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Country = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Province = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.City = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Town = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.DetailAddress = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.Phone = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.AddressCode = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.Enable = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
            model.AddTime = reader.IsDBNull(10) ? System.DateTime.MinValue : reader.GetDateTime(10);
            model.UserID = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
            model.DefaltAdress = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);//0  不是默认地址  1 是默认地址
            if (view == "view")
            {
                model.Addressid = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
            }
            return model;
        }
        /// <summary>
        /// 增加一条数据(表Address)
        /// </summary>
        public int AddressAdd(Model.Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Address(");
            strSql.Append("ReceiveName,Country,Province,City,Town,DetailAddress,Phone,AddressCode,Enable,AddTime,UserID,DefaltAdress)");
            strSql.Append(" VALUES (");
            strSql.Append("@ReceiveName,@Country,@Province,@City,@Town,@DetailAddress,@Phone,@AddressCode,@Enable,@AddTime,@UserID,@DefaltAdress) SELECT  @@IDENTITY");
            SqlParameter[] parameters = {
		            new SqlParameter("@ReceiveName", SqlDbType.NVarChar,100),
		            new SqlParameter("@Country", SqlDbType.NVarChar,100),
		            new SqlParameter("@Province", SqlDbType.NVarChar,100),
		            new SqlParameter("@City", SqlDbType.NVarChar,100),
		            new SqlParameter("@Town", SqlDbType.NVarChar,100),
		            new SqlParameter("@DetailAddress", SqlDbType.NVarChar,500),
		            new SqlParameter("@Phone", SqlDbType.NVarChar,100),
		            new SqlParameter("@AddressCode", SqlDbType.NVarChar,100),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@UserID", SqlDbType.Int,4),
		            new SqlParameter("@DefaltAdress", SqlDbType.Int,4)};
            parameters[0].Value = model.ReceiveName;
            parameters[1].Value = model.Country;
            parameters[2].Value = model.Province;
            parameters[3].Value = model.City;
            parameters[4].Value = model.Town;
            parameters[5].Value = model.DetailAddress;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.AddressCode;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.UserID;
            parameters[11].Value = model.DefaltAdress;

            object obj= Yax.SqlHelper.SQLExecute.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            return int.Parse(obj.ToString());
        }


   
        /// <summary>
        /// 修改数据(表Address)
        /// </summary>
        public int AddressUpdate(Model.Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Address SET ");
            strSql.Append("ReceiveName=@ReceiveName,");
            strSql.Append("Country=@Country,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Town=@Town,");
            strSql.Append("DetailAddress=@DetailAddress,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("AddressCode=@AddressCode,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("DefaltAdress=@DefaltAdress");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@ReceiveName", SqlDbType.NVarChar,100),
               new SqlParameter("@Country", SqlDbType.NVarChar,100),
               new SqlParameter("@Province", SqlDbType.NVarChar,100),
               new SqlParameter("@City", SqlDbType.NVarChar,100),
               new SqlParameter("@Town", SqlDbType.NVarChar,100),
               new SqlParameter("@DetailAddress", SqlDbType.NVarChar,500),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@AddressCode", SqlDbType.NVarChar,100),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@UserID", SqlDbType.Int,4),
               new SqlParameter("@DefaltAdress", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ReceiveName;
            parameters[2].Value = model.Country;
            parameters[3].Value = model.Province;
            parameters[4].Value = model.City;
            parameters[5].Value = model.Town;
            parameters[6].Value = model.DetailAddress;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.AddressCode;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.UserID;
            parameters[12].Value = model.DefaltAdress;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int AddressUpdateEnable(Model.Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Address set ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where ID=@ID  and UserID=@UserID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            parameters[2].Value = model.UserID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int AddressUpdate_info(Model.Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Address SET ");
            strSql.Append("ReceiveName=@ReceiveName,");
            strSql.Append("Country=@Country,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Town=@Town,");
            strSql.Append("DetailAddress=@DetailAddress,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("AddressCode=@AddressCode");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@ReceiveName", SqlDbType.NVarChar,100),
               new SqlParameter("@Country", SqlDbType.NVarChar,100),
               new SqlParameter("@Province", SqlDbType.NVarChar,100),
               new SqlParameter("@City", SqlDbType.NVarChar,100),
               new SqlParameter("@Town", SqlDbType.NVarChar,100),
               new SqlParameter("@DetailAddress", SqlDbType.NVarChar,500),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@AddressCode", SqlDbType.NVarChar,100)
              
            
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ReceiveName;
            parameters[2].Value = model.Country;
            parameters[3].Value = model.Province;
            parameters[4].Value = model.City;
            parameters[5].Value = model.Town;
            parameters[6].Value = model.DetailAddress;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.AddressCode;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Address GetModelByAddress(int ID)
        {
            string sql = string.Format("SELECT * FROM Address WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Address model = null;
            using (SqlDataReader reader =Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Address();
                    }
                    model = ConvetToAddress(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Address> GetListAddress(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Address> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Address", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Address>();
                    }
                    list.Add(ConvetToAddress(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }


        public List<Model.Address> GetListAddress_view(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Address> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "View_Address", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Address>();
                    }
                    list.Add(ConvetToAddress(reader, "All", "view"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Address> GetPageAddress(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Address> list = new List<Yax.Model.Address>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Address", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToAddress(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
