using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.Common.DataModelHelper
{
    public class BankCardAPIRes
    {
        private string showapi_res_error;
        private string showapi_res_id;
        private string showapi_res_code;
        private BankCardBody showapi_res_body;

        public string Showapi_res_error
        {
            get
            {
                return showapi_res_error;
            }

            set
            {
                showapi_res_error = value;
            }
        }

        public string Showapi_res_id
        {
            get
            {
                return showapi_res_id;
            }

            set
            {
                showapi_res_id = value;
            }
        }

        public string Showapi_res_code
        {
            get
            {
                return showapi_res_code;
            }

            set
            {
                showapi_res_code = value;
            }
        }

        public BankCardBody Showapi_res_body
        {
            get
            {
                return showapi_res_body;
            }

            set
            {
                showapi_res_body = value;
            }
        }
    }
}
