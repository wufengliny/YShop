using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yax.BLL
{
    public class QiYeQuickInfo
    {
        private string siteName;

        public string SiteName
        {
            get
            {
                return new Yax.BLL.Config().GetModelBy_key("qiyewebname").Value ;
            }

            set
            {
                siteName = value;
            }
        }
    }
}
