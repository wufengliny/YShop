using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Comment
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Comment)
        /// </summary>
        public static Model.Comment ConvertToComment(DataRow dr, string view = "table")
        {
            Model.Comment model = new Model.Comment();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.GoodID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodID"]) ? 0 : int.Parse(dr["GoodID"].ToString());
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.CommentType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CommentType"]) ? 0 : int.Parse(dr["CommentType"].ToString());//1:好评 2 中评   3差评
            model.Message = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Message"]) ? string.Empty : dr["Message"].ToString();
            model.PID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PID"]) ? 0 : int.Parse(dr["PID"].ToString());
            model.UName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UName"]) ? string.Empty : dr["UName"].ToString();//评论者名称
            model.UType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UType"]) ? 0 : int.Parse(dr["UType"].ToString());//1:会员评论 2 管理员回复
            model.Img = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Img"]) ? string.Empty : dr["Img"].ToString();
            model.Img2 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Img2"]) ? string.Empty : dr["Img2"].ToString();
            model.Img3 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Img3"]) ? string.Empty : dr["Img3"].ToString();
            model.Stars = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Stars"]) ? 0 : int.Parse(dr["Stars"].ToString());//星星 
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();
            model.OrderItemID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderItemID"]) ? 0 : int.Parse(dr["OrderItemID"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Comment)
        /// </summary>
        public static Model.Comment ConvetToComment(SqlDataReader reader, string extParam)
        {
            Model.Comment model = new Model.Comment();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.GoodID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            model.UID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.CommentType = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);//1:好评 2 中评   3差评
            model.Message = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.PID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.UName = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//评论者名称
            model.UType = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);//1:会员评论 2 管理员回复
            model.Img = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.Img2 = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.Img3 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.Stars = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);//星星 
            model.Enable = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
            model.AddTime = reader.IsDBNull(13) ? System.DateTime.MinValue : reader.GetDateTime(13);
            model.OrderNO = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
            model.OrderItemID = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Comment)
        /// </summary>
        public int CommentAdd(Model.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Comment(");
            strSql.Append("GoodID,UID,CommentType,Message,PID,UName,UType,Img,Img2,Img3,Stars,Enable,AddTime,OrderNO,OrderItemID)");
            strSql.Append(" VALUES (");
            strSql.Append("@GoodID,@UID,@CommentType,@Message,@PID,@UName,@UType,@Img,@Img2,@Img3,@Stars,@Enable,@AddTime,@OrderNO,@OrderItemID)");
            SqlParameter[] parameters = {
		            new SqlParameter("@GoodID", SqlDbType.Int,4),
		            new SqlParameter("@UID", SqlDbType.Int,4),
		            new SqlParameter("@CommentType", SqlDbType.Int,4),
		            new SqlParameter("@Message", SqlDbType.NVarChar,1000),
		            new SqlParameter("@PID", SqlDbType.Int,4),
		            new SqlParameter("@UName", SqlDbType.NVarChar,100),
		            new SqlParameter("@UType", SqlDbType.Int,4),
		            new SqlParameter("@Img", SqlDbType.NVarChar,500),
		            new SqlParameter("@Img2", SqlDbType.NVarChar,500),
		            new SqlParameter("@Img3", SqlDbType.NVarChar,500),
		            new SqlParameter("@Stars", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
		            new SqlParameter("@OrderItemID", SqlDbType.Int,4)};
            parameters[0].Value = model.GoodID;
            parameters[1].Value = model.UID;
            parameters[2].Value = model.CommentType;
            parameters[3].Value = model.Message;
            parameters[4].Value = model.PID;
            parameters[5].Value = model.UName;
            parameters[6].Value = model.UType;
            parameters[7].Value = model.Img;
            parameters[8].Value = model.Img2;
            parameters[9].Value = model.Img3;
            parameters[10].Value = model.Stars;
            parameters[11].Value = model.Enable;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.OrderNO;
            parameters[14].Value = model.OrderItemID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Comment)
        /// </summary>
        public int CommentUpdate(Model.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Comment SET ");
            strSql.Append("GoodID=@GoodID,");
            strSql.Append("UID=@UID,");
            strSql.Append("CommentType=@CommentType,");
            strSql.Append("Message=@Message,");
            strSql.Append("PID=@PID,");
            strSql.Append("UName=@UName,");
            strSql.Append("UType=@UType,");
            strSql.Append("Img=@Img,");
            strSql.Append("Img2=@Img2,");
            strSql.Append("Img3=@Img3,");
            strSql.Append("Stars=@Stars,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@GoodID", SqlDbType.Int,4),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@CommentType", SqlDbType.Int,4),
               new SqlParameter("@Message", SqlDbType.NVarChar,1000),
               new SqlParameter("@PID", SqlDbType.Int,4),
               new SqlParameter("@UName", SqlDbType.NVarChar,100),
               new SqlParameter("@UType", SqlDbType.Int,4),
               new SqlParameter("@Img", SqlDbType.NVarChar,500),
               new SqlParameter("@Img2", SqlDbType.NVarChar,500),
               new SqlParameter("@Img3", SqlDbType.NVarChar,500),
               new SqlParameter("@Stars", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.GoodID;
            parameters[2].Value = model.UID;
            parameters[3].Value = model.CommentType;
            parameters[4].Value = model.Message;
            parameters[5].Value = model.PID;
            parameters[6].Value = model.UName;
            parameters[7].Value = model.UType;
            parameters[8].Value = model.Img;
            parameters[9].Value = model.Img2;
            parameters[10].Value = model.Img3;
            parameters[11].Value = model.Stars;
            parameters[12].Value = model.Enable;
            parameters[13].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Comment GetModelByComment(int ID)
        {
            string sql = string.Format("SELECT * FROM Comment WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Comment model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Comment();
                    }
                    model = ConvetToComment(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Comment> GetListComment(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Comment> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Comment", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Comment>();
                    }
                    list.Add(ConvetToComment(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Comment> GetPageComment(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Comment> list = new List<Yax.Model.Comment>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Comment", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToComment(dt.Rows[i]));
                }
            }
            return list;
        }
        public List<Yax.Model.Comment> GetPageCommentView(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Comment> list = new List<Yax.Model.Comment>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View_Comment", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToComment(dt.Rows[i],"view"));
                }
            }
            return list;
        }




    }
}
