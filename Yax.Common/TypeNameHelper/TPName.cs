using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yax.Common.TypeNameHelper
{
    public class TPName
    {
        public static string GetMenuTypeName(int idex)
        {
            switch (idex)
            {
                case 1:
                    return "通用";
                case 2:
                    return "企业";
                case 3:
                    return "开发";
                case 4:
                    return "商城";
                case 5:
                    return "一级";
                case 6:
                    return "其他";
                default:
                    return "通用";
            }
        }
    }
}
