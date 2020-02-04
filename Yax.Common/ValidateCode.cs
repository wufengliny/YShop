using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.Common
{
   public class ValidateCode
    {
        /// <summary>
        /// 生成指定长度的数字验证码
        /// </summary>
        /// <param name="length">验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 2; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 20; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }


        public byte[] CreateCodeKayimg(string codekay)
        {
            try
            {
                string text = codekay;
                int num = 45;
                int num2 = text.Length * 20;
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(num2 - 3, 40);
                System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
                graphics.Clear(System.Drawing.Color.AliceBlue);
                graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Gray, 0f), 0, 0, bitmap.Width - 1, bitmap.Height - 3);
                System.Random random = new System.Random();
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.LightGray, 0f);
                for (int i = 0; i < 50; i++)
                {
                    int x = random.Next(0, bitmap.Width);
                    int y = random.Next(0, bitmap.Height);
                    graphics.DrawRectangle(pen, x, y, 1, 1);
                }
                char[] array = text.ToCharArray();
                System.Drawing.StringFormat stringFormat = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
                stringFormat.Alignment = System.Drawing.StringAlignment.Center;
                stringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
                System.Drawing.Color[] array2 = new System.Drawing.Color[]
                {
                    System.Drawing.Color.Black,
                    System.Drawing.Color.Red,
                    System.Drawing.Color.DarkBlue,
                    System.Drawing.Color.Green,
                    System.Drawing.Color.Brown,
                    System.Drawing.Color.DarkCyan,
                    System.Drawing.Color.Purple,
                    System.Drawing.Color.DarkGreen
                };
                for (int j = 0; j < array.Length; j++)
                {
                    int num3 = random.Next(7);
                    random.Next(4);
                    System.Drawing.Font font = new System.Drawing.Font("Microsoft Sans Serif", 17f, System.Drawing.FontStyle.Bold);
                    System.Drawing.Brush brush = new System.Drawing.SolidBrush(array2[num3]);
                    System.Drawing.Point point = new System.Drawing.Point(14, 11);
                    float num4 = (float)random.Next(-num, num);
                    graphics.TranslateTransform((float)point.X, (float)point.Y);
                    graphics.RotateTransform(num4);
                    graphics.DrawString(array[j].ToString(), font, brush, 1f, 10f, stringFormat);
                    graphics.RotateTransform(-num4);
                    graphics.TranslateTransform(2f, (float)(-(float)point.Y));
                }
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Gif);
                graphics.Dispose();
                bitmap.Dispose();
                return memoryStream.ToArray();
            }
            catch
            {
                return null;
            }
           
        }

  
    }
}
