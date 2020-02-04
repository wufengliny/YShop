using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// ShopGood
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表ShopGood)
        /// </summary>
        public static Model.ShopGood ConvertToShopGood(DataRow dr, string view = "table")
        {
            Model.ShopGood model = new Model.ShopGood();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();//商品名称
            model.SearchName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SearchName"]) ? string.Empty : dr["SearchName"].ToString();//搜索名称
            model.GoodNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodNO"]) ? string.Empty : dr["GoodNO"].ToString();//商品编码
            model.Color = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Color"]) ? string.Empty : dr["Color"].ToString();//颜色
            model.Size = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Size"]) ? string.Empty : dr["Size"].ToString();//尺寸
            model.Source = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Source"]) ? string.Empty : dr["Source"].ToString();//商品来源
            model.CID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CID"]) ? 0 : int.Parse(dr["CID"].ToString());//商品的分类ＩＤ
            model.Detail = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Detail"]) ? string.Empty : dr["Detail"].ToString();//商品的详细描述
            model.Price = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Price"]) ? 0 : decimal.Parse(dr["Price"].ToString()); //商品的原价格
            model.SalePrice = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SalePrice"]) ? 0 : decimal.Parse(dr["SalePrice"].ToString()); //打折后的售卖价格
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Cover = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Cover"]) ? string.Empty : dr["Cover"].ToString();//商品的图片封面
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();//备注
            model.JiFen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JiFen"]) ? 0 : int.Parse(dr["JiFen"].ToString());//够买改商品赠送的积分
            model.IsHot = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsHot"]) ? 0 : int.Parse(dr["IsHot"].ToString());//是否热销
            model.IsTop = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsTop"]) ? 0 : int.Parse(dr["IsTop"].ToString());//置顶
            model.IsRecomand = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsRecomand"]) ? 0 : int.Parse(dr["IsRecomand"].ToString());//是否推荐
            model.IsNew = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsNew"]) ? 0 : int.Parse(dr["IsNew"].ToString());
            model.CoverSmall = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CoverSmall"]) ? string.Empty : dr["CoverSmall"].ToString();//封面缩略图
            model.IsDown = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsDown"]) ? 0 : int.Parse(dr["IsDown"].ToString());//是否下架  1 下架 0：上架
            model.PostFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PostFee"]) ? 0 : decimal.Parse(dr["PostFee"].ToString()); //邮费
            model.IP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IP"]) ? string.Empty : dr["IP"].ToString();
            model.CategaryName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CategaryName"]) ? string.Empty : dr["CategaryName"].ToString();//暂时没有用处
            model.StockNum = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["StockNum"]) ? 0 : int.Parse(dr["StockNum"].ToString());
            model.Hits = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Hits"]) ? 0 : int.Parse(dr["Hits"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表ShopGood)
        /// </summary>
        public static Model.ShopGood ConvetToShopGood(SqlDataReader reader, string extParam)
        {
            Model.ShopGood model = new Model.ShopGood();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//商品名称
            model.SearchName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//搜索名称
            model.GoodNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//商品编码
            model.Color = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//颜色
            model.Size = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);//尺寸
            model.Source = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//商品来源
            model.CID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);//商品的分类ＩＤ
            model.Detail = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);//商品的详细描述
            model.Price = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);//商品的原价格
            model.SalePrice = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);//打折后的售卖价格
            model.AddTime = reader.IsDBNull(11) ? System.DateTime.MinValue : reader.GetDateTime(11);
            model.UpdateTime = reader.IsDBNull(12) ? System.DateTime.MinValue : reader.GetDateTime(12);
            model.Enable = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
            model.Cover = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);//商品的图片封面
            model.Memo = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);//备注
            model.JiFen = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);//够买改商品赠送的积分
            model.IsHot = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);//是否热销
            model.IsTop = reader.IsDBNull(18) ? 0 : reader.GetInt32(18);//置顶
            model.IsRecomand = reader.IsDBNull(19) ? 0 : reader.GetInt32(19);//是否推荐
            model.IsNew = reader.IsDBNull(20) ? 0 : reader.GetInt32(20);//置顶
            model.CoverSmall = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);//封面缩略图
            model.IsDown = reader.IsDBNull(22) ? 0 : reader.GetInt32(22);//是否下架  1 下架 0：上架
            model.PostFee = reader.IsDBNull(23) ? 0 : reader.GetDecimal(23);//邮费
            model.IP = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
            model.CategaryName = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
            model.StockNum = reader.IsDBNull(26) ? 0 : reader.GetInt32(26);
            model.Hits = reader.IsDBNull(27) ? 0 : reader.GetInt32(27);
            

            return model;
        }
        /// <summary>
        /// 增加一条数据(表ShopGood)
        /// </summary>
        public int ShopGoodAdd(Model.ShopGood model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ShopGood(");
            strSql.Append("Name,SearchName,GoodNO,Color,Size,Source,CID,Detail,Price,SalePrice,AddTime,UpdateTime,Enable,Cover,Memo,JiFen,IsHot,IsTop,IsNew,IsRecomand,CoverSmall,IsDown,PostFee,IP,CategaryName,Hits,StockNum)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@SearchName,@GoodNO,@Color,@Size,@Source,@CID,@Detail,@Price,@SalePrice,@AddTime,@UpdateTime,@Enable,@Cover,@Memo,@JiFen,@IsHot,@IsTop,@IsNew,@IsRecomand,@CoverSmall,@IsDown,@PostFee,@IP,@CategaryName,@Hits,@StockNum)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.NVarChar,500),
		            new SqlParameter("@SearchName", SqlDbType.NVarChar,1000),
		            new SqlParameter("@GoodNO", SqlDbType.NVarChar,100),
		            new SqlParameter("@Color", SqlDbType.NVarChar,100),
		            new SqlParameter("@Size", SqlDbType.NVarChar,100),
		            new SqlParameter("@Source", SqlDbType.NVarChar,100),
		            new SqlParameter("@CID", SqlDbType.Int,4),
		            new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
		            new SqlParameter("@Price", SqlDbType.Decimal,9),
		            new SqlParameter("@SalePrice", SqlDbType.Decimal,9),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@Cover", SqlDbType.NVarChar,1000),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
		            new SqlParameter("@JiFen", SqlDbType.Int,4),
		            new SqlParameter("@IsHot", SqlDbType.Int,4),
		            new SqlParameter("@IsTop", SqlDbType.Int,4),
                     new SqlParameter("@IsNew", SqlDbType.Int,4),
		            new SqlParameter("@IsRecomand", SqlDbType.Int,4),
		            new SqlParameter("@CoverSmall", SqlDbType.NVarChar,500),
		            new SqlParameter("@IsDown", SqlDbType.Int,4),
		            new SqlParameter("@PostFee", SqlDbType.Decimal,9),
		            new SqlParameter("@IP", SqlDbType.NVarChar,100),
		            new SqlParameter("@CategaryName", SqlDbType.NVarChar,300),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                     new SqlParameter("@StockNum", SqlDbType.Int,4)                
                                        };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.SearchName;
            parameters[2].Value = model.GoodNO;
            parameters[3].Value = model.Color;
            parameters[4].Value = model.Size;
            parameters[5].Value = model.Source;
            parameters[6].Value = model.CID;
            parameters[7].Value = model.Detail;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.SalePrice;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.UpdateTime;
            parameters[12].Value = model.Enable;
            parameters[13].Value = model.Cover;
            parameters[14].Value = model.Memo;
            parameters[15].Value = model.JiFen;
            parameters[16].Value = model.IsHot;
            parameters[17].Value = model.IsTop;
            parameters[18].Value = model.IsNew;
            parameters[19].Value = model.IsRecomand;
            parameters[20].Value = model.CoverSmall;
            parameters[21].Value = model.IsDown;
            parameters[22].Value = model.PostFee;
            parameters[23].Value = model.IP;
            parameters[24].Value = model.CategaryName;
            parameters[25].Value = model.Hits;
            parameters[26].Value = model.StockNum;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表ShopGood)
        /// </summary>
        public int ShopGoodUpdate(Model.ShopGood model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ShopGood SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("SearchName=@SearchName,");
            strSql.Append("GoodNO=@GoodNO,");
            strSql.Append("Color=@Color,");
            strSql.Append("Size=@Size,");
            strSql.Append("Source=@Source,");
            strSql.Append("CID=@CID,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Price=@Price,");
            strSql.Append("SalePrice=@SalePrice,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("JiFen=@JiFen,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("IsRecomand=@IsRecomand,");
            strSql.Append("CoverSmall=@CoverSmall,");
            strSql.Append("IsDown=@IsDown,");
            strSql.Append("PostFee=@PostFee,");
            strSql.Append("IP=@IP");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@SearchName", SqlDbType.NVarChar,1000),
               new SqlParameter("@GoodNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Color", SqlDbType.NVarChar,100),
               new SqlParameter("@Size", SqlDbType.NVarChar,100),
               new SqlParameter("@Source", SqlDbType.NVarChar,100),
               new SqlParameter("@CID", SqlDbType.Int,4),
               new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               new SqlParameter("@SalePrice", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Cover", SqlDbType.NVarChar,1000),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@JiFen", SqlDbType.Int,4),
               new SqlParameter("@IsHot", SqlDbType.Int,4),
               new SqlParameter("@IsTop", SqlDbType.Int,4),
               new SqlParameter("@IsRecomand", SqlDbType.Int,4),
               new SqlParameter("@CoverSmall", SqlDbType.NVarChar,500),
               new SqlParameter("@IsDown", SqlDbType.Int,4),
               new SqlParameter("@PostFee", SqlDbType.Decimal,9),
               new SqlParameter("@IP", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.SearchName;
            parameters[3].Value = model.GoodNO;
            parameters[4].Value = model.Color;
            parameters[5].Value = model.Size;
            parameters[6].Value = model.Source;
            parameters[7].Value = model.CID;
            parameters[8].Value = model.Detail;
            parameters[9].Value = model.Price;
            parameters[10].Value = model.SalePrice;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.UpdateTime;
            parameters[13].Value = model.Enable;
            parameters[14].Value = model.Cover;
            parameters[15].Value = model.Memo;
            parameters[16].Value = model.JiFen;
            parameters[17].Value = model.IsHot;
            parameters[18].Value = model.IsTop;
            parameters[19].Value = model.IsRecomand;
            parameters[20].Value = model.CoverSmall;
            parameters[21].Value = model.IsDown;
            parameters[22].Value = model.PostFee;
            parameters[23].Value = model.IP;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int ShopGoodUpdateEnable(Model.ShopGood model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ShopGood SET ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ShopGoodUpdateHits(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ShopGood SET ");
            strSql.Append("Hits=Hits+1");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4)
              };
            parameters[0].Value = id;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int ShopGoodUpdateInfo(Model.ShopGood model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ShopGood SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("SearchName=@SearchName,");
            strSql.Append("GoodNO=@GoodNO,");
            strSql.Append("Color=@Color,");
            strSql.Append("Size=@Size,");
            strSql.Append("Source=@Source,");
            strSql.Append("CID=@CID,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Price=@Price,");
            strSql.Append("SalePrice=@SalePrice,");
   
            strSql.Append("UpdateTime=@UpdateTime,");
          
            strSql.Append("Cover=@Cover,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("JiFen=@JiFen,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("IsNew=@IsNew,");
            strSql.Append("IsRecomand=@IsRecomand,");
            strSql.Append("CoverSmall=@CoverSmall,");
            strSql.Append("IsDown=@IsDown,");
            strSql.Append("PostFee=@PostFee,");
            strSql.Append("CategaryName=@CategaryName,");
            strSql.Append("StockNum=@StockNum");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@SearchName", SqlDbType.NVarChar,1000),
               new SqlParameter("@GoodNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Color", SqlDbType.NVarChar,100),
               new SqlParameter("@Size", SqlDbType.NVarChar,100),
               new SqlParameter("@Source", SqlDbType.NVarChar,100),
               new SqlParameter("@CID", SqlDbType.Int,4),
               new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               new SqlParameter("@SalePrice", SqlDbType.Decimal,9),

               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
        
               new SqlParameter("@Cover", SqlDbType.NVarChar,1000),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@JiFen", SqlDbType.Int,4),
               new SqlParameter("@IsHot", SqlDbType.Int,4),
               new SqlParameter("@IsTop", SqlDbType.Int,4),
                new SqlParameter("@IsNew", SqlDbType.Int,4),
               new SqlParameter("@IsRecomand", SqlDbType.Int,4),
               new SqlParameter("@CoverSmall", SqlDbType.NVarChar,500),
               new SqlParameter("@IsDown", SqlDbType.Int,4),
               new SqlParameter("@PostFee", SqlDbType.Decimal,9),
               new SqlParameter("@CategaryName", SqlDbType.NVarChar,500),
               new SqlParameter("@StockNum", SqlDbType.Int,4)                 
                                        };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.SearchName;
            parameters[3].Value = model.GoodNO;
            parameters[4].Value = model.Color;
            parameters[5].Value = model.Size;
            parameters[6].Value = model.Source;
            parameters[7].Value = model.CID;
            parameters[8].Value = model.Detail;
            parameters[9].Value = model.Price;
            parameters[10].Value = model.SalePrice;
          
            parameters[11].Value = model.UpdateTime;
      
            parameters[12].Value = model.Cover;
            parameters[13].Value = model.Memo;
            parameters[14].Value = model.JiFen;
            parameters[15].Value = model.IsHot;
            parameters[16].Value = model.IsTop;
            parameters[17].Value = model.IsNew;
            parameters[18].Value = model.IsRecomand;
            parameters[19].Value = model.CoverSmall;
            parameters[20].Value = model.IsDown;
            parameters[21].Value = model.PostFee;
            parameters[22].Value = model.CategaryName;
            parameters[23].Value = model.StockNum; 
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.ShopGood GetModelByShopGood(int ID)
        {
            string sql = string.Format("SELECT * FROM ShopGood WITH(NOLOCK) WHERE ID={0}", ID);
            Model.ShopGood model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.ShopGood();
                    }
                    model = ConvetToShopGood(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ShopGood> GetListShopGood(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.ShopGood> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "ShopGood", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.ShopGood>();
                    }
                    list.Add(ConvetToShopGood(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.ShopGood> GetPageShopGood(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.ShopGood> list = new List<Yax.Model.ShopGood>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "ShopGood", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToShopGood(dt.Rows[i]));
                }
            }
            return list;
        }
        public List<Yax.Model.ShopGood> GetPageShopGood_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.ShopGood> list = new List<Yax.Model.ShopGood>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View＿ShopGoods", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToShopGood(dt.Rows[i], "view"));
                }
            }
            return list;
        }




    }
}
