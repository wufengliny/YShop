using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// QiYe_Product
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表QiYe_Product)
        /// </summary>
        public static Model.QiYe_Product ConvertToQiYe_Product(DataRow dr)
        {

            Model.QiYe_Product model = new Model.QiYe_Product();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.ProductTypeID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ProductTypeID"]) ? 0 : int.Parse(dr["ProductTypeID"].ToString());
            model.Introduce = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Introduce"]) ? string.Empty : dr["Introduce"].ToString();//简介
            model.ProductNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ProductNO"]) ? string.Empty : dr["ProductNO"].ToString();//产品序列号
            model.Seokeyword = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Seokeyword"]) ? string.Empty : dr["Seokeyword"].ToString();
            model.SeoDescription = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SeoDescription"]) ? string.Empty : dr["SeoDescription"].ToString();
            model.IsIndex = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsIndex"]) ? 0 : int.Parse(dr["IsIndex"].ToString());
            model.Price = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Price"]) ? 0 : decimal.Parse(dr["Price"].ToString());
            model.Size = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Size"]) ? string.Empty : dr["Size"].ToString();//尺寸
            model.Color = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Color"]) ? string.Empty : dr["Color"].ToString();//颜色
            model.Cover = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cover"]) ? string.Empty : dr["Cover"].ToString();
            model.Hits = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Hits"]) ? 0 : int.Parse(dr["Hits"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Detail = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Detail"]) ? string.Empty : dr["Detail"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表QiYe_Product)
        /// </summary>
        public static Model.QiYe_Product ConvetToQiYe_Product(SqlDataReader reader, string extParam)
        {
            Model.QiYe_Product model = new Model.QiYe_Product();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.ProductTypeID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.Introduce = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//简介
            model.ProductNO = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//产品序列号
            model.Seokeyword = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.SeoDescription = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.IsIndex = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
            model.Price = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
            model.Size = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);//尺寸
            model.Color = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);//颜色
            model.Cover = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.Hits = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
            model.AddTime = reader.IsDBNull(13) ? System.DateTime.MinValue : reader.GetDateTime(13);
            model.Enable = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
            model.Detail = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表QiYe_Product)
        /// </summary>
        public int QiYe_ProductAdd(Model.QiYe_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO QiYe_Product(");
            strSql.Append("Name,ProductTypeID,Introduce,ProductNO,Seokeyword,SeoDescription,IsIndex,Price,Size,Color,Cover,Hits,AddTime,Enable,Detail)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@ProductTypeID,@Introduce,@ProductNO,@Seokeyword,@SeoDescription,@IsIndex,@Price,@Size,@Color,@Cover,@Hits,@AddTime,@Enable,@Detail)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,500),
                    new SqlParameter("@ProductTypeID", SqlDbType.Int,4),
                    new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ProductNO", SqlDbType.NVarChar,100),
                    new SqlParameter("@Seokeyword", SqlDbType.NVarChar,1000),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,1000),
                    new SqlParameter("@IsIndex", SqlDbType.Int,4),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Size", SqlDbType.NVarChar,100),
                    new SqlParameter("@Color", SqlDbType.NVarChar,100),
                    new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Detail", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ProductTypeID;
            parameters[2].Value = model.Introduce;
            parameters[3].Value = model.ProductNO;
            parameters[4].Value = model.Seokeyword;
            parameters[5].Value = model.SeoDescription;
            parameters[6].Value = model.IsIndex;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.Size;
            parameters[9].Value = model.Color;
            parameters[10].Value = model.Cover;
            parameters[11].Value = model.Hits;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.Enable;
            parameters[14].Value = model.Detail;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表QiYe_Product)
        /// </summary>
        public int QiYe_ProductUpdate(Model.QiYe_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE QiYe_Product SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("ProductTypeID=@ProductTypeID,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("ProductNO=@ProductNO,");
            strSql.Append("Seokeyword=@Seokeyword,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("IsIndex=@IsIndex,");
            strSql.Append("Price=@Price,");
            strSql.Append("Size=@Size,");
            strSql.Append("Color=@Color,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Detail=@Detail");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@ProductTypeID", SqlDbType.Int,4),
               new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
               new SqlParameter("@ProductNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Seokeyword", SqlDbType.NVarChar,1000),
               new SqlParameter("@SeoDescription", SqlDbType.NVarChar,1000),
               new SqlParameter("@IsIndex", SqlDbType.Int,4),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               new SqlParameter("@Size", SqlDbType.NVarChar,100),
               new SqlParameter("@Color", SqlDbType.NVarChar,100),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@Hits", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Detail", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ProductTypeID;
            parameters[3].Value = model.Introduce;
            parameters[4].Value = model.ProductNO;
            parameters[5].Value = model.Seokeyword;
            parameters[6].Value = model.SeoDescription;
            parameters[7].Value = model.IsIndex;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.Size;
            parameters[10].Value = model.Color;
            parameters[11].Value = model.Cover;
            parameters[12].Value = model.Hits;
            parameters[13].Value = model.AddTime;
            parameters[14].Value = model.Enable;
            parameters[15].Value = model.Detail;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int QiYe_ProductUpdate_hits(Model.QiYe_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE QiYe_Product SET ");
            strSql.Append("Hits=@Hits");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Hits", SqlDbType.Int,4)
              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Hits;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int QiYe_ProductUpdate_info(Model.QiYe_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE QiYe_Product SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("ProductTypeID=@ProductTypeID,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("ProductNO=@ProductNO,");
            strSql.Append("Seokeyword=@Seokeyword,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("IsIndex=@IsIndex,");
            strSql.Append("Price=@Price,");
            strSql.Append("Size=@Size,");
            strSql.Append("Color=@Color,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Hits=@Hits");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@ProductTypeID", SqlDbType.Int,4),
               new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
               new SqlParameter("@ProductNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Seokeyword", SqlDbType.NVarChar,1000),
               new SqlParameter("@SeoDescription", SqlDbType.NVarChar,1000),
               new SqlParameter("@IsIndex", SqlDbType.Int,4),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               new SqlParameter("@Size", SqlDbType.NVarChar,100),
               new SqlParameter("@Color", SqlDbType.NVarChar,100),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                new SqlParameter("@Hits", SqlDbType.Int,4),
                new SqlParameter("@Detail", SqlDbType.NVarChar,-1)

              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ProductTypeID;
            parameters[3].Value = model.Introduce;
            parameters[4].Value = model.ProductNO;
            parameters[5].Value = model.Seokeyword;
            parameters[6].Value = model.SeoDescription;
            parameters[7].Value = model.IsIndex;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.Size;
            parameters[10].Value = model.Color;
            parameters[11].Value = model.Cover;
            parameters[12].Value = model.Hits;
            parameters[13].Value = model.Detail;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.QiYe_Product GetModelByQiYe_Product(int ID)
        {
            string sql = string.Format("SELECT * FROM QiYe_Product WITH(NOLOCK) WHERE ID={0}", ID);
            Model.QiYe_Product model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.QiYe_Product();
                    }
                    model = ConvetToQiYe_Product(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.QiYe_Product> GetListQiYe_Product(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.QiYe_Product> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "QiYe_Product", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.QiYe_Product>();
                    }
                    list.Add(ConvetToQiYe_Product(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.QiYe_Product> GetPageQiYe_Product(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.QiYe_Product> list = new List<Yax.Model.QiYe_Product>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "QiYe_Product", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToQiYe_Product(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
