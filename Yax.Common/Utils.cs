using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Yax.Common
{
    public class Utils
    {
        #region 获取随机字符串
        /// <summary>
        /// 获取当前时间字符串
        /// </summary>
        /// <returns>指定格式的当前日期字符串</returns>
        public static string RandomDateCard()
        {
            string _format = "yyyyMMddHHmmss_ffff";
            _format = DateTime.Now.ToString(_format);
            return _format;
        }
        /// <summary>
        /// 获取当前时间字符串
        /// </summary>
        /// <param name="_format">日期格式EgyyyyMMddHHmmss_ffff</param>
        /// <returns>指定格式的当前日期字符串</returns>
        public static string RandomDateCard(string _format)
        {
            _format = string.IsNullOrEmpty(_format) ? "yyyyMMddHHmmss_ffff" : _format;
            try
            {
                _format = DateTime.Now.ToString(_format);
            }
            catch
            {
                _format = DateTime.Now.ToString("yyyyMMddHHmmss_ffff");
            }
            return _format;
        }

        public static string RandomPhone()
        {
            //到188 中国移动   到186  中国联通 
            string[] strs = {"134","135","136","137","138","139","150","151","152","157","158","159","187","188","130","131","132","155","156","185","186","133","153","180","189" };
            int count = strs.Length;
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int randIndex= r.Next(count);
            string phone_A = strs[randIndex];
            string phone_B = "****";
            string phone_C = RandNum(4);
            return phone_A+ phone_B+ phone_C;
        }

        /// <summary>
        /// 万数倍的金额
        /// </summary>
        /// <returns></returns>
        public static string GetRanomMoney()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int res= r.Next(1, 9);
            return res.ToString() + "0000";
        }

        /// <summary>
        /// 取指定长度的随机字符串(取一次)
        /// </summary>
        public static string RandStr(int strLength)
        {
            string allowStr = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random r = new Random();
            string returnStr = "";
            for (int i = 0; i < strLength; i++)
            {
                returnStr += allowStr.Substring(Convert.ToInt16(r.Next(allowStr.Length)), 1);

            }
            return returnStr;
        }

        public static string RandNum(int number)
        {
            string checkCode = String.Empty;
            string Vchar = "0,1,2,3,4,5,6,7,8,9";
            string[] VcArray = Vchar.Split(',');
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 1; i < number + 1; i++)
            {
                int t = rand.Next(VcArray.Length);
                checkCode += VcArray[t];
            }
            return checkCode;
        }

        public static string RandCodestr(int length)
        {
            string rescode = string.Empty;
            string Vchar = "2,3,4,5,6,7,8,9,Q,W,E,R,T,Y,U,P,A,D,F,G,H,J,K,Z,X,C,B,N,M";
            string[] VcArray = Vchar.Split(',');
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 1; i < length + 1; i++)
            {
                int t = rand.Next(VcArray.Length);
                rescode += VcArray[t];
            }
            return rescode;
        }
        /// <summary>
        /// 1-49
        /// </summary>
        /// <returns></returns>
        public static string Make7RandNum()
        {
            string str = "";
            List<string> res = new List<string>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            while(res.Count<=6)
            {
                str = PadNum(rand.Next(1,50).ToString(),2);
                if(!res.Contains(str))
                {
                    res.Add(str);
                }
            }
            string data = string.Empty;
            for(int i=0;i<res.Count;i++)
            {
                if(string.IsNullOrEmpty(data))
                {
                    data = res[i];
                }
                else
                {
                    data += ","+res[i];
                }
            }
            return data;
        }

        public static string Make5RandNum()
        {
            string str = "";
            List<string> res = new List<string>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            while (res.Count <5)
            {
                str = rand.Next(1, 10).ToString();
                res.Add(str);
            }
            string data = string.Empty;
            for (int i = 0; i < res.Count; i++)
            {
                if (string.IsNullOrEmpty(data))
                {
                    data = res[i];
                }
                else
                {
                    data += "," + res[i];
                }
            }
            return data;
        }
        #endregion

        #region 数据转换
        /// <summary>
        /// 将字符串转换为 Int  转换失败返回0
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>Int数据</returns>
        public static int StrToInt(string str)
        {
            int res;
            if (int.TryParse(str, out res))
            {
                return res;
            }
            return 0;
        }

        /// <summary>
        /// 将字符串转换为 Int 转换失败返回defaultVal
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns>Int数据</returns>
        public static int StrToInt(string str, int defaultVal)
        {
            int res;
            if (int.TryParse(str, out res))
            {
                return res;
            }
            return defaultVal;
        }
        /// <summary>
        /// 将字符串转换为 decimal 转换失败返回defaultVal
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ObjToDecimal(object obj, decimal defaultVal)
        {
            decimal res;
            if (obj != null)
            {
                if (decimal.TryParse(obj.ToString(), out res))
                {
                    return res;
                }
            }
            return defaultVal;
        }
        /// <summary>
        /// 将字符串转换为 decimal 转换失败返回0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ObjToDecimal(object obj)
        {
            return ObjToDecimal(obj, 0);
        }

        /// <summary>
        /// 将对象转换为 DateTime 转换失败返回  当前时间减去200年
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ObjToDateTime(object obj)
        {
            DateTime res;
            if (obj != null)
            {
                if (DateTime.TryParse(obj.ToString(), out res))
                {
                    return res;
                }
            }
            return DateTime.Now.AddYears(-200);
        }
        #endregion
        
        #region 序列化操作
        /// <summary>
        /// 序列化一个Object为String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>序列化后的字符串</returns>
        public static string Serializer(Object obj)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                MemoryStream ms = new MemoryStream();
                XmlTextWriter xtw = new XmlTextWriter(ms, System.Text.Encoding.UTF8);
                xtw.Formatting = Formatting.Indented;
                xs.Serialize(xtw, obj);
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                string str = sr.ReadToEnd();
                xtw.Close();
                ms.Close();
                return str;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 反序列化 从字符串
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <param name="type">要生成的对象类型</param>
        /// <returns>反序列化后的对象</returns>
        public static object Deserialize(string str, Type type)
        {
            //try
            //{
            XmlSerializer xs = new XmlSerializer(type);
            StringReader sr = new StringReader(str);
            object obj = xs.Deserialize(sr);
            return obj;
            //}
            //catch { return null; }
        }
        #endregion

        #region 字符串过滤
        /// <summary>
        /// 防Sql入注过滤
        /// </summary>
        public static string GetSafeString(string fString)
        {
            if (string.IsNullOrEmpty(fString))
            {
                return string.Empty;
            }
            fString = fString.ToLower();
            fString = fString.Replace(">", "");
            fString = fString.Replace("<", "");
            //过滤sql注入，暂时先用此函数过滤
            fString = fString.Replace("exec", "");
            fString = fString.Replace("insert", "");
            fString = fString.Replace("delete%20from", "");
            fString = fString.Replace("delete", "");
            fString = fString.Replace("update", "");
            fString = fString.Replace("*", "");
            fString = fString.Replace("%", "");
            fString = fString.Replace("chr", "");
            fString = fString.Replace("mid", "");
            fString = fString.Replace("truncate", "");
            fString = fString.Replace("char", "");
            fString = fString.Replace("declare", "");
            fString = fString.Replace("drop%20table", "");
            fString = fString.Replace("net%20user", "");
            fString = fString.Replace("xp_cmdshell", "");
            fString = fString.Replace("/add", "");
            fString = fString.Replace("net%20localgroup%20administrators", "");
            fString = fString.Replace("Asc", "");
            fString = fString.Replace("char", "");
            fString = fString.Replace("dbcc", "");
            fString = fString.Replace("alter", "");
            fString = fString.Replace("mid(", "");
            fString = fString.Replace("0x4400", "");
            fString = fString.Replace("cast", "");
            return fString;
        }

        /// <summary>
        /// 过滤所有的Html  
        /// </summary>
        public static string HtmlFilter(string htmlString)
        {
            if (htmlString != null)
            {
                string temp = System.Text.RegularExpressions.Regex.Replace(htmlString, "<[^>]+>", "");
                temp = temp.Replace("&nbsp;", " ");
                temp = temp.Replace("<br>", "");
                return temp;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 过滤 script  有空好好研究
        /// </summary>
        public static string HtmlFilterScript(string htmlString)
        {
            if (htmlString != null)
            {
                string temp = System.Text.RegularExpressions.Regex.Replace(htmlString, "<script+>", "");
                return temp;
            }
            else
            {
                return string.Empty;
            }
        }
        public static string HtmlFilterImg(string htmlString)
        {
            if (htmlString != null)
            {
                string temp = System.Text.RegularExpressions.Regex.Replace(htmlString, "<img[^>]+>", "");
                return temp;
            }
            else
            {
                return string.Empty;
            }
        }

        
        #endregion

        #region 取中文汉字的第一个拼音字母GetPYM

        /// <summary>
        /// 取中文汉字的第一个拼音字母
        /// </summary>
        /// <param name="fString">你好>返回> NH</param>
        /// <returns></returns>
        public static string GetPYM(string fString)
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            byte[] buf = gb2312.GetBytes(fString);
            StringBuilder sbResult = new StringBuilder(" ");
            for (int i = 0; i < buf.Length; )
            {
                if (i + 1 == buf.Length)
                {
                    if ((buf[i] >= '!') && (buf[i] <= '~'))
                    {
                        sbResult.Append((char)buf[i]);
                    }
                    break;
                }
                if ((buf[i] > 128) && (buf[i + 1] > 128))
                {
                    sbResult.Append(GetPYM(buf[i], buf[i + 1]));
                    i += 2;
                }
                else
                {
                    if ((buf[i] >= '!') && (buf[i] <= '~'))
                    {
                        sbResult.Append((char)buf[i]);
                    }
                    i++;
                }
            }

            return sbResult.ToString();

        }
        ///<summary> 
        ///获得一个双字节字符的拼音码 
        ///</summary> 
        ///<paramname= "_byte0 "> 第一位 </param> 
        ///<paramname= "_byte1 "> 第二位 </param> 
        ///<returns> 拼音码（生母） </returns> 
        private static char GetPYM(byte _byte0, byte _byte1)
        {
            int int0 = _byte0 - 176;
            int int1 = _byte1 - 161;
            int intASCII = int0 * 94 + int1;

            if (int0 < 0) return ' ';
            if (int0 > 71) return ' ';
            if (int1 < 0) return ' ';
            if (int1 > 93) return ' ';

            //处理一级字库 
            if ((0 <= intASCII) && (intASCII < 36)) return 'A';
            if (intASCII < 220) return 'B';
            if (intASCII < 453) return 'C';
            if (intASCII < 637) return 'D';
            if (intASCII < 659) return 'E';
            if (intASCII < 784) return 'F';
            if (intASCII < 939) return 'G';
            if (intASCII < 1120) return 'H';
            if (intASCII < 1415) return 'J';
            if (intASCII < 1515) return 'K';
            if (intASCII < 1763) return 'L';
            if (intASCII < 1914) return 'M';
            if (intASCII < 1995) return 'N';
            if (intASCII < 2003) return 'O';
            if (intASCII < 2125) return 'P';
            if (intASCII < 2282) return 'Q';
            if (intASCII < 2341) return 'R';
            if (intASCII < 2627) return 'S';
            if (intASCII < 2783) return 'T';
            if (intASCII < 2903) return 'W';
            if (intASCII < 3126) return 'X';
            if (intASCII < 3432) return 'Y';
            if (intASCII == 3496) return 'N';
            if (intASCII < 3757) return 'Z';

            //处理二级字库
            string[] arrChars = new string[32];
            arrChars[0] = "CJWGNSPGCGNE Y BTYYZDXYKYGT JNNJQMBSGZSCYJSYY PGKBZGY YWYKGKLJSWKPJQHY W DZLSGMRYPYWWCCKZNKYYG";
            arrChars[1] = "TTNJJEYKKZYTCJNMCYLQLYPYQFQRPZSLWBTGKJFYXJWZLTBNCXJJJJZXDTTSQZYCDXXHGCK PHFFSS YBGMXLPBYLL HLX";
            arrChars[2] = "S ZM JHSOJNGHDZQYKLGJHXGQZHXQGKEZZWYSCSCJXYEYXADZPMDSSMZJZQJYZC J WQJBDZBXGZNZCPWHKXHQKMWFBPBY";
            arrChars[3] = "DTJZZKQHYLYGXFPTYJYYZPSZLFCHMQSHGMXXSXJ DCSBBQBEFSJYHXWGZKPYLQBGLDLCCTNMAYDDKSSNGYCSGXLYZAYBN";
            arrChars[4] = "PTSDKDYLHGYMYLCXPY JNDQJWXQXFYYFJLEJPZRXCCQWQQSBZKYMGPLBMJRQCFLNYMYQMSQYRBCJTHZTQFRXQHXMJJCJLX";
            arrChars[5] = "XGJMSHZKBSWYEMYLTXFSYDSGLYCJQXSJNQBSCTYHBFTDCYZDJWYGHQFRXWCKQKXEBPTLPXJZSRMEBWHJLBJSLYYSMDXLCL";
            arrChars[6] = "QKXLHXJRZJMFQHXHWYWSBHTRXXGLHQHFNM YKLDYXZPWLGG MTCFPAJJZYLJTYANJGBJPLQGDZYQYAXBKYSECJSZNSLYZH";
            arrChars[7] = "ZXLZCGHPXZHZNYTDSBCJKDLZAYFMYDLEBBGQYZKXGLDNDNYSKJSHDLYXBCGHXYPKDQMMZNGMMCLGWZSZXZJFZNMLZZTHCS";
            arrChars[8] = "YDBDLLSCDDNLKJYKJSYCJLKOHQASDKNHCSGANHDAASHTCPLCPQYBSDMPJLPZJOQLCDHJJYSPRCHN NNLHLYYQYHWZPTCZG";
            arrChars[9] = "WWMZFFJQQQQYXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMSSJZLDBYDCPCXYHLXCHYZJQ QAGMNYXPFRKSSBJLYXY";
            arrChars[10] = "SYGLNSCMHSWWMNZJJLXXHCHSY CTXRYCYXBYHCSMXJSZNPWGPXXTAYBGAJCXLY DCCWZOCWKCCSBNHCPDYZNFCYYTYCKX";
            arrChars[11] = "KYBSQKKYTQQXFCWCHCYKELZQBSQYJQCCLMTHSYWHMKTLKJLYCXWHYQQHTQH PQ QSCFYMMDMGBWHWLGSLLYSDLMLXPTHMJ";
            arrChars[12] = "HWLJZYHZJXHTXJLHXRSWLWZJCBXMHZQXSDZPMGFCSGLSXYMQSHXPJXWMYQKSMYPLRTHBXFTPMHYXLCHLHLZYLXGSSSSTCL";
            arrChars[13] = "SLTCLRPBHZHXYYFHB GDMYCNQQWLQHJJ YWJZYEJJDHPBLQXTQKWHLCHQXAGTLXLJXMSL HTZKZJECXJCJNMFBY SFYWYB";
            arrChars[14] = "JZGNYSDZSQYRSLJPCLPWXSDWEJBJCBCNAYTWGMPABCLYQPCLZXSBNMSGGFNZJJBZSFZYNDXHPLQKZCZWALSBCCJX YZHWK";
            arrChars[15] = "YPSGXFZFCDKHJGXDLQFSGDSLQWZKXTMHSBGZMJZRGLYJBPMLMSXLZJQSHZYJ ZYDJWBMJKLDDPMJEGXYHYLXHLQYQHKYCW";
            arrChars[16] = "CJMYYXNATJHYCCXZPCQLBZWWYTWBQCMLPMYRJCCCXFPZNZZLJPLXXYZTZLGDLDCKLYRZZGQTGJHHGJLJAXFGFJZSLCFDQZ";
            arrChars[17] = "LCLGJDJCSNCLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCTZHGYQTJQQLZXJYLYLBCYAMCSTYLPDJBYREGKJZYZHLYSZQLZNW";
            arrChars[18] = "CZCLLWJQJJJKDGJZOLBBZPPGLGHTGZXYGHZMYCNQSYCYHBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKQSB";
            arrChars[19] = "GBMMCJSSCLPQPDXCDYYKY CJDDYYGYWRHJRTGZNYQLDKLJSZZGZQZJGDYKSHPZMTLCPWNJAFYZDJCNMWESCYGLBTZCGMSS";
            arrChars[20] = "LLYXQSXSBSJSBBSGGHFJLYPMZJNLYYWDQSHZXTYYWHMZYHYWDBXBTLMSYYYFSXJC TXXLHJHF SXZQHFZMZCZTQCXZXRTT";
            arrChars[21] = "DJHNNYZQQMNQDMMG YTXMJGDHCDYZBFFALLZTDLTFXMXQZDNGWQDBDCZJDXBZGSQQDDJCMBKZFFXMKDMDSYYSZCMLJDSYN";
            arrChars[22] = "SPRSKMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJ GYPZLTCSMCNBTJBQFKTHBYZGKPBBYMTDSSXTBNPDKLEYCJNYDDYKZTDHQH";
            arrChars[23] = "SDZSCTARLLTKZLGECLLKJLQJAQNBDKKGHPJTZQKSECSHALQFMMGJNLYJBBTMLYZXDCJPLDLPCQDHZYCBZSCZBZMSLJFLKR";
            arrChars[24] = "ZJSNFRGJHXPDHYJYBZGDLJCSEZGXLBLHYXTWMABCHECMWYJYZLLJJYHLG DJLSLYGKDZPZXJYYZLWCXSZFGWYYDLYHCLJS";
            arrChars[25] = "CMBJHBLYZLYCBLYDPDQYSXQZBYTDKYYJY CNRJMPDJGKLCLJBCTBJDDBBLBLCZQRPPXJCGLZCSHLTOLJNMDDDLNGKAQHQH";
            arrChars[26] = "JHYKHEZNMSHRP QQJCHGMFPRXHJGDYCHGHLYRZQLCYQJNZSQTKQJYMSZSWLCFQQQXYFGGYPTQWLMCRNFKKFSYYLQBMQAMM";
            arrChars[27] = "MYXCTPSHCPTXXZZSMPHPSHMCLMLDQFYQFSZYJDJJZZHQPDSZGLSTJBCKBXYQZJSGPSXQZQZRQTBDKYXZKHHGFLBCSMDLDG";
            arrChars[28] = "DZDBLZYYCXNNCSYBZBFGLZZXSWMSCCMQNJQSBDQSJTXXMBLTXZCLZSHZCXRQJGJYLXZFJPHY ZQQYDFQJJLZZNZJCDGZYG";
            arrChars[29] = "CTXMZYSCTLKPHTXHTLBJXJLXSCDQXCBBTJFQZFSLTJBTKQBXXJJLJCHCZDBZJDCZJDCPRNPQCJPFCZLCLZXZDMXMPHJSGZ";
            arrChars[30] = "GSZZQLYLWTJPFSYAXMCJBTZYYCWMYTCSJJLQCQLWZMALBXYFBPNLSFHTGJWEJJXXGLLJSTGSHJQLZFKCGNNDSZFDEQFHBS";
            arrChars[31] = "AQTGYLBXMMYGSZLDYDQMJJRGBJTKGDHGKBLQKBDMBYLXWCXYTTYBKMRTJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";
            return arrChars[int0 - 40][int1];

        }
        #endregion

        #region IP相关
        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 服务器IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string AddressIP = string.Empty;
            try
            {
                foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        AddressIP = _IPAddress.ToString();
                    }
                }
            }
            catch
            {

            }
            return AddressIP;
        }
        /// <summary>
        /// 客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result = String.Empty;
            try
            {
                HttpRequest request = HttpContext.Current.Request;
                result = request.Headers["Cdn-Src-Ip"];//CDN附加的原客户端IP
                if (String.IsNullOrEmpty(result))
                {
                    ////可以透过代理服务器
                    if (request.ServerVariables["HTTP_VIA"] != null)
                    {
                        result = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                    }
                }
                if (String.IsNullOrEmpty(result))
                {
                    //没有代理服务器,如果有代理服务器获取的是代理服务器的IP
                    result = request.ServerVariables["REMOTE_ADDR"];
                }
                if (String.IsNullOrEmpty(result))
                {
                    result = request.UserHostAddress;
                }

                if (String.IsNullOrEmpty(result) || !IsIPAddress(result))
                {
                    return "0.0.0.0";
                }
            }
            catch
            {

            }
            return result;
        }
        /// <summary>
        /// 从IP转换为Int32
        /// </summary>
        /// <param name="IpValue"></param>
        /// <returns></returns>
        public static UInt32 IPToUInt32(string IpValue)
        {
            string[] IpByte = IpValue.Split('.');
            Int32 nUpperBound = IpByte.GetUpperBound(0);
            if (nUpperBound != 3)
            {
                IpByte = new string[4];
                for (Int32 i = 1; i <= 3 - nUpperBound; i++)
                    IpByte[nUpperBound + i] = "0";
            }

            byte[] TempByte4 = new byte[4];
            for (Int32 i = 0; i <= 3; i++)
            {
                if (ValidateHelper.IsNumber(IpByte[i]))
                {
                    TempByte4[3 - i] = (byte)(Convert.ToInt32(IpByte[i]) & 0xff);
                }
            }
            return BitConverter.ToUInt32(TempByte4, 0);
        }

        /// <summary> 
        /// 将Int型转换为IP字符串 
        /// </summary> 
        /// <param name="ipAddress"></param> 
        /// <returns></returns> 
        public static string UInt32ToIP(uint ipAddress)
        {
            uint uint1 = (ipAddress & 0xFF000000) >> 24;
            uint uint2 = (ipAddress & 0x00FF0000) >> 16;
            uint uint3 = (ipAddress & 0x0000FF00) >> 8;
            uint uint4 = ipAddress & 0x000000FF;
            return string.Format("{0}.{1}.{2}.{3}", uint1, uint2, uint3, uint4);
        }
        #endregion

        #region 时间相关
        /// <summary>
        /// 取当前时间在本年之中第几周
        /// </summary>
        /// <returns></returns>
        public static int GetWeekByNow()
        {
            int i = new System.Globalization.GregorianCalendar().GetWeekOfYear(System.DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            return i;
        }
        /// <summary>
        /// 计算两个日期的时间间隔dateTime1-dateTime2
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        public static int DayDiff(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts1 = new TimeSpan(dateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts.Days;
        }
        /// <summary>
        /// 计算两个日期的时间间隔dateTime1-dateTime2
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        public static int HourDiff(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts1 = new TimeSpan(dateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return (int)ts.TotalHours;
        }


        /// <summary>
        /// 有些计算机带有 星期几 2019/9/12 星期四 下午 6:28:31 时间无法转换 
        /// </summary>
        /// <returns>这里返回正规时间格式</returns>
        public static DateTime GetDateTimeNow()
        {
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return DateTime.Parse(str);
        }
        #endregion

        #region 获取Url数据相关
        /// <summary>
        /// 获取Get传参过来的参数String值
        /// </summary>
        /// <param name="QueryName">参数名</param>
        /// <returns></returns>
        public static string GetQurryString(string QueryName)
        {
            return GetQurryString(QueryName, "");
        }
        /// <summary>
        /// 获取Get传参过来的参数String值
        /// </summary>
        /// <param name="QueryName">参数名</param>
        /// <param name="DefaultVal">默认值</param>
        /// <returns></returns>
        public static string GetQurryString(string QueryName,string DefaultVal)
        {
            string res = HttpContext.Current.Request.QueryString[QueryName];
            if (string.IsNullOrEmpty(res))
            {
                res = DefaultVal;
            }
            return res.Trim();
        }
        public static string GetSafeQueryString(string name)
        {
            string res = HttpContext.Current.Request.QueryString[name];
            if (string.IsNullOrEmpty(res))
            {
                res = "";
            }
            else
            {
                res= Yax.Common.Utils.GetSafeString(res);
            }
            return res.Trim();
        }
        public static string GetSafeFormString(string name)
        {
            string res = HttpContext.Current.Request.Form[name];
            if (string.IsNullOrEmpty(res))
            {
                res = "";
            }
            else
            {
                res = Yax.Common.Utils.GetSafeString(res);
            }
            return res.Trim();
        }
        /// <summary>
        /// 获取Psot传参过来的参数String值
        /// </summary>
        /// <param name="txtName"></param>
        /// <param name="DefaultVal"></param>
        /// <returns></returns>
        public static string GetFormString(string txtName, string DefaultVal)
        {
            string res = HttpContext.Current.Request.Form[txtName];
            if (string.IsNullOrEmpty(res))
            {
                res = DefaultVal;
            }
            return res.Trim();
        }
        /// <summary>
        /// 获取Psot传参过来的参数String值
        /// </summary>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public static string GetFormString(string txtName)
        {
            return GetFormString(txtName,"");
        }
        /// <summary>
        /// 获取Get传参过来的参数Int值
        /// </summary>
        /// <param name="QueryName">参数名</param>
        /// <param name="DefaultVal"></param>
        /// <returns></returns>
        public static int GetQueryInt(string QueryName, int DefaultVal)
        {
            string str = HttpContext.Current.Request.QueryString[QueryName];
            int res = 0;
            if (int.TryParse(str, out res))
            {
                return res;
            }
            else
            {
                return DefaultVal;
            }
        }
        /// <summary>
        ///  获取Post传参过来的参数Int值
        /// </summary>
        /// <param name="QueryName">参数名</param>
        /// <returns></returns>
        public static int GetQueryInt(string QueryName)
        {
            return GetQueryInt(QueryName,0);
        }
        public static int GetFormInt(string txtName, int DefaultVal)
        {
            string str = HttpContext.Current.Request.Form[txtName];
            int res = 0;
            if (int.TryParse(str, out res))
            {
                return res;
            }
            else
            {
                return DefaultVal;
            }
        }
        /// <summary>
        /// 获取Post传参过来的参数Int值
        /// </summary>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public static int GetFormInt(string txtName)
        {
            return GetFormInt(txtName,0);
        }



        //

        public static decimal GetQueryDecimal(string QueryName, decimal DefaultVal)
        {
            string str = HttpContext.Current.Request.QueryString[QueryName];
            decimal res = 0;
            if (decimal.TryParse(str, out res))
            {
                return res;
            }
            else
            {
                return DefaultVal;
            }
        }
        /// <summary>
        ///  获取Post传参过来的参数Int值
        /// </summary>
        /// <param name="QueryName">参数名</param>
        /// <returns></returns>
        public static decimal GetQueryDecimal(string QueryName)
        {
            return GetQueryDecimal(QueryName, 0);
        }
        public static decimal GetFormDecimal(string txtName, decimal DefaultVal)
        {
            string str = HttpContext.Current.Request.Form[txtName];
            decimal res = 0;
            if (decimal.TryParse(str, out res))
            {
                return res;
            }
            else
            {
                return DefaultVal;
            }
        }
        /// <summary>
        /// 获取Post传参过来的参数Int值
        /// </summary>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public static decimal GetFormDecimal(string txtName)
        {
            return GetFormDecimal(txtName, 0);
        }
      

        public static DateTime GetQueryDate(string txtName)
        {
           return GetQueryDate(txtName, "1912-12-12 12:12:12");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtName">参数名</param>
        /// <param name="DefaultVal">转换时间失败 传出默认时间</param>
        /// <returns></returns>
        public static DateTime GetQueryDate(string txtName,string DefaultVal)
        {
            try
            {
                string str = HttpContext.Current.Request.QueryString[txtName];
                if(string.IsNullOrEmpty(str))
                {
                    str = DefaultVal;
                }
                DateTime dt = DateTime.Parse(str);
                return dt;
            }
            catch
            {
                return DateTime.Parse("1912-12-12 12:12:12");
            }
        
        }
        public static DateTime GetQueryDate(string txtName, DateTime DefaultVal)
        {
            try
            {
                string str = HttpContext.Current.Request.QueryString[txtName];
                if (string.IsNullOrEmpty(str))
                {
                    return DefaultVal;
                }
                DateTime dt = DateTime.Parse(str);
                return dt;
            }
            catch
            {
                return DefaultVal;
            }
        }
        public static DateTime GetFormDate(string txtName)
        {
            return GetFormDate(txtName, "1912-12-12 12:12:12");
        }
        public static DateTime GetFormDate(string txtName, string DefaultVal)
        {
            try
            {
                string str = HttpContext.Current.Request.Form[txtName];
                if(string.IsNullOrEmpty(str))
                {
                    str = DefaultVal;
                }
                DateTime dt = DateTime.Parse(str);//1912-12-12 12:12:12
                return dt;
            }
            catch
            {
                return DateTime.Parse("1912-12-12 12:12:12");
            }
        }
        public static DateTime GetFormDate(string txtName, DateTime DefaultVal)
        {
            try
            {
                string str = HttpContext.Current.Request.Form[txtName];
                if(string.IsNullOrEmpty(str))
                {
                    return DefaultVal;
                }
                DateTime dt = DateTime.Parse(str);
                return dt;
            }
            catch
            {
                return DefaultVal;
            }
        }
        #endregion


        #region  从html代码中提取image地址
        /// <summary>
        /// 从html代码中提取image地址,index为索引
        /// </summary>
        /// <param name="html"></param>
        /// <param name="_ImgIndex"></param>
        /// <returns></returns>
        public static string GetImgUrlFromHtml(string html, int _ImgIndex)
        {
            string strReg = "src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png|jpeg))(?:\"|\')?";
            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(html, strReg, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (matches.Count > 0 && _ImgIndex < matches.Count)
            {
                return matches[_ImgIndex].Groups["imgSrc"].ToString();
            }
            return "";
        }
        /// <summary>
        /// 从html代码中提取第一个image地址
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string GetImgUrlFromHtml(string html)
        {
            return GetImgUrlFromHtml(html, 0);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="html"></param>
        /// <returns>返回整个img 标签 集合</returns>
        public static MatchCollection GetImgsFromHTml(string html)
        {
            //https://www.cnblogs.com/sosoft/archive/2015/12/06/HvtHtmlImage.html
            Regex m_hvtRegImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection matches = m_hvtRegImg.Matches(html);
            //<img src="/uploadimages/pic/2018041901350907518.png" alt="饭票logo" />
            return matches;
        }
        #endregion


        #region 字符串截取
        /// <summary>
        /// 根据所需长度截取字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">字符串所需长度</param>
        /// <returns></returns>
        public static string GetSubstring(string value, int length)
        {
            return GetSubstring(value, length, "");
        }
        /// <summary>
        /// 根据所需长度截取字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">字符串所需长度</param>
        /// <returns></returns>
        public static string GetSubstring(string value, int length, string tailstring)
        {
            if (value != null)
            {
                if (value.Length > length)
                {
                    return value.Substring(0, length) + tailstring;
                }
            }
            return value;
        }
        #endregion


        /// <summary>
        /// 格式化显示容量大小GB  MB KB Byte  传进来的是Byte大小数据
        /// </summary>
        public static string FormatSize(double iSize)
        {
            if (iSize >= 1073741824)
            {
                return String.Format("{0:N}", iSize / 1073741824) + "GB";
            }
            else if (iSize >= 1048576)
            {
                return String.Format("{0:N}", iSize / 1048576) + "MB";
            }
            else if (iSize >= 1024)
            {
                return String.Format("{0:N}", iSize / 1024) + "KB";
            }
            else
            {
                return iSize + "Byte";
            }
        }
        /// <summary>
        /// 获取客户端浏览器操作系统
        /// </summary>
        public static string GetSystem()
        {
            return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
        }


        /// <summary>
        /// 取得生肖
        /// </summary>
        public static string Zodiac(int iBirthDay_Year)
        {
            string[] temp_arr = new string[12] { "猴", "鸡", "狗", "猪", "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊" };
            return temp_arr[iBirthDay_Year % 12];
        }


        #region 时间戳

        public static string ToUnixStamp(DateTime serverTime)
        {
            var ts = serverTime - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        /// <summary>
        /// 转换时间戳
        /// </summary>
        /// <param name="unixStamp">时间戳</param>
        /// <param name="isMillisecond">是否精确到毫秒</param>
        /// <returns></returns>
        public static DateTime FromUnixStamp(long unixStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(unixStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        } 

        public static string CMD(string strcmd)
        {
            try
            {
                //创建一个进程
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                string strCMD = strcmd;
                p.StandardInput.WriteLine(strCMD + "&exit");
                p.StandardInput.AutoFlush = true;
                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
                return output;
            }
            catch (Exception ex)
            {
                return "err";
            }
        }
        #endregion


        public static void WriteFileLog_Form(string msg)
        {
            try
            {
                string fileNamet = Directory.GetCurrentDirectory() + "\\logs";
                if (!System.IO.Directory.Exists(fileNamet))
                {
                    System.IO.Directory.CreateDirectory(fileNamet);
                }
                string path = fileNamet + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                System.IO.StreamWriter sw = System.IO.File.AppendText(path);
                using (sw)
                {
                    if (System.IO.File.Exists(path))
                    {
                        sw.WriteLine(msg);
                    }
                    else
                    {
                        System.IO.File.Create(path);
                        sw.WriteLine(msg);
                    }
                }
            }
            catch
            {

            }
        }


        public static void WriteFileLog_Web(string msg)
        {
            try
            {
                string fileNamet = System.Web.HttpContext.Current.Server.MapPath("/logs");
                if (!System.IO.Directory.Exists(fileNamet))
                {
                    System.IO.Directory.CreateDirectory(fileNamet);
                }
                string path = fileNamet + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                System.IO.StreamWriter sw = System.IO.File.AppendText(path);
                using (sw)
                {
                    if (System.IO.File.Exists(path))
                    {
                        sw.WriteLine(msg);
                    }
                    else
                    {
                        System.IO.File.Create(path);
                        sw.WriteLine(msg);
                    }
                }
            }
            catch
            {

            }
        }
        //

        //
        public static string GetTimeStrFromStr(string time, string formatstr)
        {
            DateTime dt;
            if (!string.IsNullOrEmpty(time))
            {
                try
                {
                    dt = DateTime.Parse(time);
                    return dt.ToString(formatstr);
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }

        public static string PadNum(string str, int num)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            int length = str.Length;
            int padnum = num - length;
            string res = "";
            for (int i = 0; i < padnum; i++)
            {
                res += "0";
            }
            return res + str;

        }


        /// <summary>
        /// 不含http
        /// </summary>
        /// <param name="url"></param>
        /// <returns>返回格式：www.baidu.com</returns>
        public static string GetHostFromUrl(string url)
        {
            string rehost = "([a-z0-9--]{1,200})\\.([a-z]{2,10})(\\.[a-z]{2,10})?";
            string Host = new Regex(rehost).Match(url).Value;
            return Host;
        }
        /// <summary>
        /// 含http
        /// </summary>
        /// <param name="url"></param>
        /// <returns>返回格式：http://www.baidu.com</returns>
        public static string GetDoaminFromUrl(string url)
        {
            string host= GetHostFromUrl(url);
            url = url.ToLower();
            if(url.Contains("http://"))
            {
                return "http://"+host+"/";
            }
            else if (url.Contains("https://"))
            {
                return "https://" + host + "/";
            }
            else
            {
                return host;
            }
        }

    

        //
    }
}
