using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yax.Common.DataModelHelper
{
    public class AdminMenu
    {
        public string ID;
        public string Title;
        public string Link;
        public string Mark;
        public Dictionary<string, AdminMenuChild> ItemList;
    }
    public class AdminMenuChild
    {
        public string ID;
        public string Title;
        public string Link;
        public string Icon;
        public string Mark;
    }
}
