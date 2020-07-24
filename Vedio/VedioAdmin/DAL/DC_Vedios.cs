using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommSQLHelper;
using Entity;


namespace DAL
{
    public class DC_Vedios
    {
        string Fiels = "ID,Name,Cover,Tag,Category,SeriousID,Price,PreUrl,Url,VedioLong,Hits,Likes,Goods,Introduce,AddTime,Enable,Actor,Sort,FromVedioUrl,FromPageUrl,FromSite,FromCoverUrl,Memo,FreePartUrl,SinglePayDownLoadNum,VIPDownNum,FreeDownNum,IsTop";
        public List<object> Pager(int pageIndex,int pageSize,string strWhere,string strOrder)
        {
            string str = " select cv.*,cs.Name SeriousName from C_Vedios cv  ";
            str += " left join C_Serious cs on  cv.SeriousID=cs.ID ";
            str += strWhere;
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = strOrder,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "(" + str + ") rest",
                WhereString = ""
            };
            return AspNetPagerList.PagerLsit<MC_Vedios>(modelp);
        }
        public int Add(MC_Vedios model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO C_Vedios(");
            strSql.Append("Name,Cover,Tag,Category,SeriousID,Price,PreUrl,Url,VedioLong,Hits,Likes,Goods,Introduce,AddTime,Enable,Actor,Sort,FromVedioUrl,FromPageUrl,FromSite,FromCoverUrl,Memo,FreePartUrl,SinglePayDownLoadNum,VIPDownNum,FreeDownNum,IsTop)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Cover,@Tag,@Category,@SeriousID,@Price,@PreUrl,@Url,@VedioLong,@Hits,@Likes,@Goods,@Introduce,@AddTime,@Enable,@Actor,@Sort,@FromVedioUrl,@FromPageUrl,@FromSite,@FromCoverUrl,@Memo,@FreePartUrl,@SinglePayDownLoadNum,@VIPDownNum,@FreeDownNum,@IsTop)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,500),
                    new SqlParameter("@Cover", SqlDbType.NVarChar,500),
                    new SqlParameter("@Tag", SqlDbType.NVarChar,500),
                    new SqlParameter("@Category", SqlDbType.NVarChar,100),
                    new SqlParameter("@SeriousID", SqlDbType.Int,4),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@PreUrl", SqlDbType.NVarChar,100),
                    new SqlParameter("@Url", SqlDbType.NVarChar,500),
                    new SqlParameter("@VedioLong", SqlDbType.NVarChar,100),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@Likes", SqlDbType.Int,4),
                    new SqlParameter("@Goods", SqlDbType.Int,4),
                    new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Actor", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@FromVedioUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@FromPageUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@FromSite", SqlDbType.NVarChar,100),
                    new SqlParameter("@FromCoverUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@FreePartUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@SinglePayDownLoadNum", SqlDbType.Int,4),
                    new SqlParameter("@VIPDownNum", SqlDbType.Int,4),
                    new SqlParameter("@FreeDownNum", SqlDbType.Int,4),
                    new SqlParameter("@IsTop", SqlDbType.Int,4)
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Cover;
            parameters[2].Value = model.Tag;
            parameters[3].Value = model.Category;
            parameters[4].Value = model.SeriousID;
            parameters[5].Value = model.Price;
            parameters[6].Value = model.PreUrl;
            parameters[7].Value = model.Url;
            parameters[8].Value = model.VedioLong;
            parameters[9].Value = model.Hits;
            parameters[10].Value = model.Likes;
            parameters[11].Value = model.Goods;
            parameters[12].Value = model.Introduce;
            parameters[13].Value = model.AddTime;
            parameters[14].Value = model.Enable;
            parameters[15].Value = model.Actor;
            parameters[16].Value = model.Sort;
            parameters[17].Value = model.FromVedioUrl;
            parameters[18].Value = model.FromPageUrl;
            parameters[19].Value = model.FromSite;
            parameters[20].Value = model.FromCoverUrl;
            parameters[21].Value = model.Memo;
            parameters[22].Value = model.FreePartUrl;
            parameters[23].Value = model.SinglePayDownLoadNum;
            parameters[24].Value = model.VIPDownNum;
            parameters[25].Value = model.FreeDownNum;
            parameters[26].Value = model.IsTop;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int Update(MC_Vedios model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_Vedios SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Tag=@Tag,");
            strSql.Append("Category=@Category,");
            strSql.Append("SeriousID=@SeriousID,");
            strSql.Append("Url=@Url,");
            strSql.Append("VedioLong=@VedioLong,");
            strSql.Append("Price=@Price");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,500),
               new SqlParameter("@Cover", SqlDbType.NVarChar,500),
               new SqlParameter("@Tag", SqlDbType.NVarChar,500),
               new SqlParameter("@Category", SqlDbType.NVarChar,100),
               new SqlParameter("@SeriousID", SqlDbType.Int,4),
               new SqlParameter("@Url", SqlDbType.NVarChar,500),
               new SqlParameter("@VedioLong", SqlDbType.NVarChar,100),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Cover;
            parameters[3].Value = model.Tag;
            parameters[4].Value = model.Category;
            parameters[5].Value = model.SeriousID;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.VedioLong;
            parameters[8].Value = model.Price;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

       




        public MC_Vedios GetModelByID(int ID)
        {
            string str = " select cv.*,cs.Name SeriousName from C_Vedios cv  ";
            str += " left join C_Serious cs on  cv.SeriousID=cs.ID where cv.ID=@ID ";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MC_Vedios>(CommandType.Text, str, param);
        }
        public MC_Vedios GetModelByUrl(string Url)
        {
            string str = " select * from C_Vedios where Url=@Url ";
            SqlParameter param = new SqlParameter("@Url", SqlDbType.NVarChar, 500);
            param.Value = Url;
            return SQLHelper.ExecuteReaderObject<MC_Vedios>(CommandType.Text, str, param);
        }

        public MC_Vedios GetMaxSort()
        {
            string str = "select top 1 * from C_Vedios order by Sort Desc";
            return SQLHelper.ExecuteReaderObject<MC_Vedios>(CommandType.Text, str);
        }
        /// <summary>
        /// 软删除 或还原 进回收站
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateEnable(int ID, int Enable)
        {
            string str = " update C_Vedios set Enable="+Enable+" where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }
        /// <summary>
        /// 硬删除  无法恢复
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteHard(int ID)
        {
            string str = " Delete from C_Vedios where Enable=0 and  ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }
        public int UpdatePrice(int ID, decimal price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_Vedios SET ");
            strSql.Append("Price=@Price");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               };
            parameters[0].Value = ID;
            parameters[1].Value = price;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int UpdateTop(int ID, int  istop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_Vedios SET ");
            strSql.Append("IsTop=@IsTop");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@IsTop", SqlDbType.Int,4),
               };
            parameters[0].Value = ID;
            parameters[1].Value = istop;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int UpdateHit(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_Vedios SET Hits+=1 where  ID=@ID");
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), param);
        }

        public int UpdateOther(int ID, int Hits,int Goods,int Likes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_Vedios SET ");
            strSql.Append("Hits=@Hits,");
            strSql.Append("Goods=@Goods,");
            strSql.Append("Likes=@Likes ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Hits", SqlDbType.Int,9),
                new SqlParameter("@Goods", SqlDbType.Int,9),
                 new SqlParameter("@Likes", SqlDbType.Int,9)
               };
            parameters[0].Value = ID;
            parameters[1].Value = Hits;
            parameters[2].Value = Goods;
            parameters[3].Value = Likes;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="AddOrCancel">1 加 2 减</param>
        /// <returns></returns>
        public int UpdateLike(int ID,int AddOrCancel)
        {
            StringBuilder strSql = new StringBuilder();
            string strac = "";
            if(AddOrCancel==1)
            {
                strac = "+=";
            }
            else
            {
                strac = "-=";
            }
            strSql.Append("UPDATE C_Vedios SET Likes "+ strac + " 1 where  ID=@ID");
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="AddOrCancel">1 加 2 减</param>
        /// <returns></returns>
        public int UpdateGoods(int ID, int AddOrCancel)
        {
            StringBuilder strSql = new StringBuilder();
            string strac = "";
            if (AddOrCancel == 1)
            {
                strac = "+=";
            }
            else
            {
                strac = "-=";
            }
            strSql.Append("UPDATE C_Vedios SET Goods " + strac + " 1 where  ID=@ID");
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), param);
        }

        public int DataNumSet(string setType, int Hits , int Goods , int Likes , decimal Price)
        {
            StringBuilder sb = new StringBuilder("");
            string sign = string.Empty;
            switch(setType)
            {
                case "val":
                    sign = "";
                    break;
                case "add":
                    sign = "+";
                    break;
                case "minus":
                    sign = "-";
                    break;
            }
            if(Hits>-1)
            {
                sb.AppendLine(" update C_Vedios set Hits "+ sign + "="+Hits +" ;");
            }
            if (Goods > -1)
            {
                sb.AppendLine(" update C_Vedios set Goods " + sign + "=" + Goods + " ;");
            }
            if(Likes>-1)
            {
                sb.AppendLine(" update C_Vedios set Likes " + sign + "=" + Likes + " ;");
            }
            if(Price>-1)
            {
                sb.AppendLine(" update C_Vedios set Price " + sign + "=" + Price + " ;");
            }
            string sqltxt = sb.ToString();
            if (!string.IsNullOrEmpty(sqltxt))
            {
                return SQLHelper.ExecuteNonQuery(CommandType.Text, sqltxt);
            }
            else
            {
                return 0;
            }
        }

    }
}
