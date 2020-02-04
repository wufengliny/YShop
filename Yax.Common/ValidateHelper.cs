using System;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Yax.Common
{
    public class ValidateHelper
    {
        private static Regex RegPhone = new Regex("^1[3458][0-9]{9}$");   //是否手机号码
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");   //是否数字，可带正负号
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");  //是否浮点数
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");  //检测是否有中文字符
        private static Regex RegHasChar = new Regex("[a-zA-Z]+");      //检测是否有字母
        private static Regex RegHasNumber = new Regex("[0-9]");        //检测是否含有数字
        private static Regex RegCardID = new Regex(@"^\d{14}(\d{1}|\d{4}|(\d{3}[xX]))$");    //检测是否身份证号码

       


        #region 数字字符串检查
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            if (inputData == null) return false;
            Regex reg = new Regex(@"^[\d\.]+$");
            Match ma = reg.Match(inputData);
            return ma.Success;
        }
       
        #endregion

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 检测是否有字母
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasChar(string inputData)
        {
            Match m = RegHasChar.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 检测是否有字母
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasNumber(string inputData)
        {
            Match m = RegHasNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 检测是否身份证号码
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsCardID(string inputData)
        {
            Match m = RegCardID.Match(inputData);
            return m.Success;
        }
        #endregion

       

        
    }
}
