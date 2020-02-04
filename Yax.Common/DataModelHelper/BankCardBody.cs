using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.Common.DataModelHelper
{
    public class BankCardBody
    {
        private string area;
        private string bankName;
        private string brand;
        private string cardNum;
        private string cardType;
        private string ret_code;
        private string simpleCode;
        private string tel;
        private string url;

        public string Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public string BankName
        {
            get
            {
                return bankName;
            }

            set
            {
                bankName = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
            }
        }

        public string CardNum
        {
            get
            {
                return cardNum;
            }

            set
            {
                cardNum = value;
            }
        }

        public string CardType
        {
            get
            {
                return cardType;
            }

            set
            {
                cardType = value;
            }
        }

        public string Ret_code
        {
            get
            {
                return ret_code;
            }

            set
            {
                ret_code = value;
            }
        }

        public string SimpleCode
        {
            get
            {
                return simpleCode;
            }

            set
            {
                simpleCode = value;
            }
        }

        public string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
    }
}
