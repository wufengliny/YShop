using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ModelView
{
    public class S_AdminViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public int LoginCount { get; set; }

        public string RegIP { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool Enable { get; set; }
        public string Memo { get; set; }

        public int ErrorCount { get; set; }

        public DateTime LastErrTime { get; set; }

        public string RealName { get; set; }

        public string Phone { get; set; }
        public int AdminGroupID { get; set; }
        public string SecondPwd { get; set; }

        public string GroupName { get; set; }
    }
}
