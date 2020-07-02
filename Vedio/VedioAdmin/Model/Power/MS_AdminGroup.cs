using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MS_AdminGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime AddTime { get; set; }
        public bool Enable { get; set; }

        public string Memo { get; set; }
    }
}
