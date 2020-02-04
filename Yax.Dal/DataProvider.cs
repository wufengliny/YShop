using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace Yax.SQLServerDAL
{
    public partial class DataProvider
    {
        private static DataProvider _instance = null;
        /// <summary>
        /// 返回数据层唯一的一个实例
        /// </summary>
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataProvider();
                }
                return _instance;
            }
        }
    }
}

