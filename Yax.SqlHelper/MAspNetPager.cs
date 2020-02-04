using System;
using System.Collections.Generic;
using System.Text;

namespace Yax.SqlHelper
{
    /// <summary>
    /// 分页实体类
    /// </summary>
    public class MAspNetPager
    {

        private string _TableName;
        private string _ReFieldsStr;
        private string _OrderString;
        private string _WhereString;
        private int _PageSize;
        private int _PageIndex;
        private int _TotalRecord;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecord
        {
            get { return _TotalRecord; }
            set { _TotalRecord = value; }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string WhereString
        {
            get { return _WhereString; }
            set { _WhereString = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderString
        {
            get { return _OrderString; }
            set { _OrderString = value; }
        }

        /// <summary>
        /// 要查询出来的字段
        /// </summary>
        public string ReFieldsStr
        {
            get { return _ReFieldsStr; }
            set { _ReFieldsStr = value; }
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

    }
}
