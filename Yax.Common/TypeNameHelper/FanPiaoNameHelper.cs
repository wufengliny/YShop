using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yax.Common.TypeNameHelper
{
    public class FanPiaoNameHelper
    {
        public  static string GetHXState(int val)
        {
            if(val==1)
            {
                return "未核销";
            }
            else if(val==2)
            {
                return "已核销";
            }
            else if (val == 3)
            {
                return "已退款";
            }
            else if (val == 4)
            {
                return "逾期票 ";
            }
            else if (val == 5)
            {
                return "部分核销 ";
            }
            else
            {
                return "未核销";
            }
        }
    }
}
