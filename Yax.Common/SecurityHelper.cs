using System;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Yax.Common
{
    /// <summary>
    /// 安全相关信息。
    /// </summary>
    public class SecurityHelper
    {

        #region  加密解密 （1）
        /// <summary>
        /// 加密 （1）
        /// </summary>
        /// <param name="pEncrypt">要加密的字符串</param>
        /// <returns></returns>
        public static string Encrypt(string pEncrypt)
        {
            try
            {
                string key = "abcdefgH";
                DESCryptoServiceProvider oDESCryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(pEncrypt);
                oDESCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
                oDESCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream oMemoryStream = new MemoryStream();
                CryptoStream oCryptoStream = new CryptoStream(oMemoryStream, oDESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
                oCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                oCryptoStream.FlushFinalBlock();
                StringBuilder sb = new StringBuilder();
                foreach (byte b in oMemoryStream.ToArray())
                {
                    sb.AppendFormat("{0:X2}", b);
                }
                sb.ToString();
                return sb.ToString();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 解密 （1）
        /// </summary>
        /// <param name="pDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string pDecrypt)
        {
            try
            {
                string key = "abcdefgH";
                DESCryptoServiceProvider oDESCryptoServiceProvider = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pDecrypt.Length / 2];
                for (int x = 0; x < pDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                oDESCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
                oDESCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream oMemoryStream = new MemoryStream();
                CryptoStream oCryptoStream = new CryptoStream(oMemoryStream, oDESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
                oCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                oCryptoStream.FlushFinalBlock();
                return System.Text.Encoding.Default.GetString(oMemoryStream.ToArray());
            }
            catch (System.Exception ex)
            {
                //throw ex;
                return "";
            }
        }
        #endregion

        #region 加密解密（2）
        static string KEY_64 = "!ssblog!";
        const string IV_64 = "!sshuai!"; //注意了，是8个字符，64位 
        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <returns></returns>
        public static string DesEncode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }
        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <returns></returns>
        public static string DesDecode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
        #endregion

        #region 加密解密（3）
  
        public static string Base64Encrypt(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            string res = Convert.ToBase64String(bytes);
            return res;
        }
        public static string Base64Decrypt(string str)
        {
            byte[] outputb = Convert.FromBase64String(str);
            string res = Encoding.Default.GetString(outputb);
            return res;
        }


        #endregion

        /// SHA1加密
        #region 单向加密  
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="text">要加密的字符串</param>
        /// <returns></returns>
        public static string MD5(string text)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(text, "MD5").ToLower();
        }
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="text">要加密的字符串</param>
        /// <returns></returns>
        public static string SHA1(string text)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(text, "SHA1");
        } 
        #endregion


        /// <summary>
        ///  Yax:生成处理过的MD5字符串 
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string DifferentMD5(string str)
        {
            string Md5Str = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            string SHA1Str = SHA1(str);
            return Md5Str.Substring(2, 8) + "y"+SHA1Str.Substring(4,6).ToLower() + Md5Str.Substring(13, 11);
        }
      
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strPassWord">要加密的字符串</param>
        /// <returns>要返回的字符串</returns>
        public static string FanpiaoMd5(string strPassWord)
        {
            string str = "";
            str = FormsAuthentication.HashPasswordForStoringInConfigFile(strPassWord, "MD5");
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Substring(1, 2) + str.Substring(4, 6) + str.Substring(8, 2) + str.Substring(0x16, 4) + str.Substring(0x1b, 2), "MD5");
        }
        #region  加密解密 （5）

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEncrypt"></param>
        /// <param name="key">8位</param>
        /// <returns></returns>
        public static string Encrypt_jia(string pEncrypt,string key)
        {
            try
            {
                
                DESCryptoServiceProvider oDESCryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(pEncrypt);
                oDESCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
                oDESCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream oMemoryStream = new MemoryStream();
                CryptoStream oCryptoStream = new CryptoStream(oMemoryStream, oDESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
                oCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                oCryptoStream.FlushFinalBlock();
                StringBuilder sb = new StringBuilder();
                foreach (byte b in oMemoryStream.ToArray())
                {
                    sb.AppendFormat("{0:X2}", b);
                }
                sb.ToString();
                return sb.ToString();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt_jie(string pDecrypt,string key)
        {
            try
            {
                DESCryptoServiceProvider oDESCryptoServiceProvider = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pDecrypt.Length / 2];
                for (int x = 0; x < pDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                oDESCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
                oDESCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream oMemoryStream = new MemoryStream();
                CryptoStream oCryptoStream = new CryptoStream(oMemoryStream, oDESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
                oCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                oCryptoStream.FlushFinalBlock();
                return System.Text.Encoding.Default.GetString(oMemoryStream.ToArray());
            }
            catch (System.Exception ex)
            {
                //throw ex;
                return "";
            }
        }
        #endregion



        public static string EncryptKay(string val)
        {
            return Encrypt_jia(val,"kay965ou");
        }
        public static string DecrypKay(string val)
        {
            return Decrypt_jie(val, "kay965ou");
        }

        public static string EncryptTian(string val)
        {
            return Encrypt_jia(val, "Tian89di");
        }
        public static string DecrypTian(string val)
        {
            return Decrypt_jie(val, "Tian89di");
        }


    }
}
