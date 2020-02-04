using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.Common.DataModelHelper
{
    public class PhoneMsgRes_FG
    {
        private string sendId;
        private string invalidCount;
        private string successCount;
        private string blackCount;
        private string code;
        private string message;

        public string SendId
        {
            get
            {
                return sendId;
            }

            set
            {
                sendId = value;
            }
        }

        public string InvalidCount
        {
            get
            {
                return invalidCount;
            }

            set
            {
                invalidCount = value;
            }
        }

        public string SuccessCount
        {
            get
            {
                return successCount;
            }

            set
            {
                successCount = value;
            }
        }

        public string BlackCount
        {
            get
            {
                return blackCount;
            }

            set
            {
                blackCount = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
    }
}
