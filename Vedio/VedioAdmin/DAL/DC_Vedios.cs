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
        string Fiels = "ID,Name,Cover,Tag,Category,SeriousID,Price,PreUrl,Url,VedioLong,Hits,Likes,Goods,Introduce,AddTime,Enable,Actor,Sort,FromVedioUrl,FromPageUrl,FromSite,FromCoverUrl,Memo,FreePartUrl,SinglePayDownLoadNum,VIPDownNum,FreeDownNum";
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
        public MC_Vedios GetModelByID(int ID)
        {
            string str = "select * from C_Vedios where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MC_Vedios>(CommandType.Text, str, param);
        }
    }
}
