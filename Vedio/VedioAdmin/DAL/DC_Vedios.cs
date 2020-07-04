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

        public MC_Vedios GetModelByID(int ID)
        {
            string str = "select * from C_Vedios where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MC_Vedios>(CommandType.Text, str, param);
        }
    }
}
