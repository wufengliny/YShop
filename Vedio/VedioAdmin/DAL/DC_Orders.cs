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
    public class DC_Orders
    {
        public MC_Orders GetModelByVedioID(int VedioID,int UID)
        {
            string str = "select top 1 * from C_Orders where VedioID=@VedioID and UID=@UID and Statu=2";
            SqlParameter[] parameters = {
                    new SqlParameter("@VedioID", SqlDbType.Int,4),
                    new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = VedioID;
            parameters[1].Value = UID;
            return SQLHelper.ExecuteReaderObject<MC_Orders>(CommandType.Text, str, parameters);
        }
    }
}
