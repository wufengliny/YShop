using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ThoughtWorks.QRCode.Codec;

namespace Yax.Common
{
    public class MakePic
    {

        /// <summary>
        /// 生成二维码 URL
        /// </summary>
        /// <param name="Url">二维码地址</param>
        /// <param name="txt_size">(1-40) Size  这个也会控制生成二维码的大小</param>
        /// <param name="txt_ver">控制生成的二维码的大小(像素)</param>
        /// <param name="Level">Correction Level</param>
        /// <returns></returns>
        public static string MakeErWeiMa(string Url, string txt_size="4",string txt_ver="9",string Level="M")
        {
            string qrEncoding = "Btye";  //Encoding
            //string Level = "M"; //Correction Level
            //string txt_ver = "9"; //Correction Level 控制生成的二维码的大小(像素)
            //string txt_size = "4"; //(1-40) Size  这个也会控制生成二维码的大小
            string FilePath = PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            string FileName = "ErWeiMa" + Utils.RandomDateCard() + ".jpg";
            string ServerPath = System.Web.HttpContext.Current.Server.MapPath("~/");
            string FullPath = ServerPath + FilePath;
            FullPath = FullPath.Replace("/", "\\").Replace("\\\\", "\\");
            if (!System.IO.Directory.Exists(FullPath))
            {
                //如果路径不存在则创建
                System.IO.Directory.CreateDirectory(FullPath);
            }
            FullPath = FullPath + FileName;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            String encoding = qrEncoding;
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                int scale = Convert.ToInt16(txt_size);
                qrCodeEncoder.QRCodeScale = scale;
            }
            catch (Exception ex)
            {
                return "";
            }
            try
            {
                int version = Convert.ToInt16(txt_ver);
                qrCodeEncoder.QRCodeVersion = version;
            }
            catch (Exception ex)
            {
                return "";
            }
            try
            {
                string errorCorrect = Level;
                if (errorCorrect == "L")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                else if (errorCorrect == "M")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                else if (errorCorrect == "Q")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                else if (errorCorrect == "H")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                System.Drawing.Image image;
                image = qrCodeEncoder.Encode(Url, Encoding.UTF8);
       
                System.IO.FileStream fs = new System.IO.FileStream(FullPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();
                image.Dispose();
                return FilePath+FileName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 添加水印图片
        /// </summary>
        /// <param name="Path">源图片地址</param>
        /// <param name="WaterPic">水印图片地址</param>
        /// <param name="TouMingDu">透明度1-10</param>
        /// <param name="XPoint">水印X坐标</param>
        /// <param name="YPoint">水印Y坐标</param>
        /// <returns></returns>
        public static string MakeWaterPic(string Path,string WaterPic,int TouMingDu,int XPoint,int YPoint)
        {
            bool temp = false;
            int quality = 500;
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            Graphics graphics = Graphics.FromImage(image);
            System.Drawing.Image image2 = new Bitmap(WaterPic);
            //
            string FilePath = PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            string FileName = "WaterPic" + Utils.RandomDateCard() + ".jpg";
            string ServerPath = System.Web.HttpContext.Current.Server.MapPath("~/");
            string FullPath = ServerPath + FilePath;
            FullPath = FullPath.Replace("/", "\\").Replace("\\\\", "\\");
            if (!System.IO.Directory.Exists(FullPath))
            {
                //如果路径不存在则创建
                System.IO.Directory.CreateDirectory(FullPath);
            }
            FullPath = FullPath + FileName;
            //
            try
            {
                ImageAttributes imageAttr = new ImageAttributes();
                ColorMap map = new ColorMap();
                map.OldColor = Color.FromArgb(0xff, 0, 0xff, 0);
                map.NewColor = Color.FromArgb(0, 0, 0, 0);
                ColorMap[] mapArray = new ColorMap[] { map };
                imageAttr.SetRemapTable(mapArray, ColorAdjustType.Bitmap);
                float num = 0.5f;
                if ((TouMingDu >= 1) && (TouMingDu <= 10))
                {
                    num = ((float)TouMingDu) / 10f;
                }
                float[][] numArray3 = new float[5][];
                float[] numArray4 = new float[5];
                numArray4[0] = 1f;
                numArray3[0] = numArray4;
                numArray4 = new float[5];
                numArray4[1] = 1f;
                numArray3[1] = numArray4;
                numArray4 = new float[5];
                numArray4[2] = 1f;
                numArray3[2] = numArray4;
                numArray4 = new float[5];
                numArray4[3] = num;
                numArray3[3] = numArray4;
                numArray4 = new float[5];
                numArray4[4] = 1f;
                numArray3[4] = numArray4;
                float[][] newColorMatrix = numArray3;
                ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                int x = XPoint;
                int y = YPoint;
                graphics.DrawImage(image2, new Rectangle(x, y, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttr);
                ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo encoder = null;
                foreach (ImageCodecInfo info2 in imageEncoders)
                {
                    if (info2.MimeType.IndexOf("jpeg") > -1)
                    {
                        encoder = info2;
                    }
                }
                EncoderParameters encoderParams = new EncoderParameters();
                long[] numArray2 = new long[1];
                numArray2[0] = quality;
                EncoderParameter parameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, numArray2);
                encoderParams.Param[0] = parameter;
                if (encoder != null)
                {
                    image.Save(FullPath, encoder, encoderParams);
                }
                else
                {
                    image.Save(FullPath);
                }
                graphics.Dispose();
                image.Dispose();
                image2.Dispose();
                imageAttr.Dispose();
                temp = true;

            }
            //}
            catch (Exception ex)
            {
                graphics.Dispose();
                image.Dispose();
                image2.Dispose();
                temp = false;
            }
            finally
            {

            }
            return FilePath+FileName;
        }


        public static string MakeWaterFont(string Path,string title, float size,float XPoint,float Ypoint)
        {
            try
            {
                string FilePath = PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
                string FileName = "WaterFont" + Utils.RandomDateCard() + ".jpg";
                string ServerPath = System.Web.HttpContext.Current.Server.MapPath("~/");
                string FullPath = ServerPath + FilePath;
                FullPath = FullPath.Replace("/", "\\").Replace("\\\\", "\\");
                if (!System.IO.Directory.Exists(FullPath))
                {
                    //如果路径不存在则创建
                    System.IO.Directory.CreateDirectory(FullPath);
                }
                FullPath = FullPath + FileName;


                //创建一个图片对象用来装载要被添加水印的图片  
                Image imgPhoto = Image.FromFile(Path);

                //获取图片的宽和高  
                int phWidth = imgPhoto.Width;
                int phHeight = imgPhoto.Height;

                //建立一个bitmap，和我们需要加水印的图片一样大小  
                Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
                //SetResolution：设置此 Bitmap 的分辨率  
                //这里直接将我们需要添加水印的图片的分辨率赋给了bitmap  
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                //Graphics：封装一个 GDI+ 绘图图面。  
                Graphics grPhoto = Graphics.FromImage(bmPhoto);

                //http://blog.csdn.net/stone0419/article/details/1699696 C#使用GDI+绘制高质量图和字体
                //设置图形的品质  
                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality; //这两个测试了好效果
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //将我们要添加水印的图片按照原始大小描绘（复制）到图形中  
                grPhoto.DrawImage(
                 imgPhoto,                                           //   要添加水印的图片  
                 new Rectangle(0, 0, phWidth, phHeight), //  根据要添加的水印图片的宽和高  
                 0,                                                     //  X方向从0点开始描绘  
                 0,                                                     // Y方向   
                 phWidth,                                            //  X方向描绘长度  
                 phHeight,                                           //  Y方向描绘长度  
                 GraphicsUnit.Pixel);                              // 描绘的单位，这里用的是像素     

                //字体  
                Font crFont = null;
                crFont = new Font("arial", size, FontStyle.Regular);//定义字段为普通文本       

                //封装文本布局信息（如对齐、文字方向和 Tab 停靠位），显示操作（如省略号插入和国家标准 (National) 数字替换）和 OpenType 功能。  
                StringFormat StrFormat = new StringFormat();
                //  StrFormat.LineAlignment


                //定义需要印的文字居中对齐  
                StrFormat.Alignment = StringAlignment.Near; //此属性时x轴的坐标为文字最左边距图片左边的距离
                                                            // StrFormat.Alignment = StringAlignment.Center;//此属性时x轴的坐标为文字中间距图片左边的距离

                // StrFormat.LineAlignment = StringAlignment.Center;

                Brush semiTransBrush = Brushes.Black;//定义一个黑色的画笔

                //DrawString 在指定矩形并且用指定的 Brush 和 Font 对象绘制指定的文本字符串。   标题
                grPhoto.DrawString(title,                                    //string of text  
                                           crFont,                                         //font  
                                           semiTransBrush,                            //Brush  
                                           new PointF(XPoint, Ypoint),  //Position  
                                           StrFormat);


                //System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality; //这个是重点类, 
                //EncoderParameter myEncoderParameter;
                //EncoderParameters myEncoderParameters;
                ////请注意这里的myImageCodecInfo声名..可以修改为更通用的.看后面 
                //ImageCodecInfo myImageCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
                //myEncoderParameters = new EncoderParameters(1);
                //// 在这里设置图片的质量等级为95L.  这的等级设置了不起作用95或1都一样
                //myEncoderParameter = new EncoderParameter(myEncoder, 1L);
                //myEncoderParameters.Param[0] = myEncoderParameter;//将构建出来的EncoderParameter类赋给EncoderParameters数组
                //bmPhoto.Save(targetImage, myImageCodecInfo, myEncoderParameters);//保存图片 

                bmPhoto.Save(FullPath, ImageFormat.Jpeg);
                bmPhoto.Dispose();
                //释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满  
                grPhoto.Dispose();
                //将grPhoto保存  
                // imgPhoto.Save(targetImage, ImageFormat.Jpeg);        
                imgPhoto.Dispose();
                return FilePath+FileName;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>  
        /// 在图片上添加3行水印文字
        /// </summary>  
        /// <param name="sourcePicture">源图片文件</param>  
        /// <param name="title">标题</param>  
        /// <param name="alpha">透明度</param>     
        /// <param name="size">文字大小</param>  
        /// <param name="xPosOfWm">文字的中间位置距x右边的位置</param>  
        /// <param name="y1PosOfWm">标题文字y轴位置</param>  
        /// <param name="y2PosOfWm">使用时间文字y轴位置</param>
        /// <param name="y3PosOfWm">地址文字y轴位置</param>
        /// <returns></returns>  
        public static string DrawThridWords_ForFanPiao(string sourcePicture, string title, string usetime, string address, float alpha, float size, float xPosOfWm, float y1PosOfWm, float y2PosOfWm, float y3PosOfWm)
        {
            try
            {
                //string targetImage = "";
                string FilePath = PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
                string FileName = "WaterFont" + Utils.RandomDateCard() + ".jpg";
                string ServerPath = System.Web.HttpContext.Current.Server.MapPath("~/");
                string FullPath = ServerPath + FilePath;
                FullPath = FullPath.Replace("/", "\\").Replace("\\\\", "\\");
                if (!System.IO.Directory.Exists(FullPath))
                {
                    //如果路径不存在则创建
                    System.IO.Directory.CreateDirectory(FullPath);
                }
                FullPath = FullPath + FileName;

                //创建一个图片对象用来装载要被添加水印的图片  
                Image imgPhoto = Image.FromFile(sourcePicture);
                //获取图片的宽和高  
                int phWidth = imgPhoto.Width;
                int phHeight = imgPhoto.Height;
                //建立一个bitmap，和我们需要加水印的图片一样大小  
                Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
                //SetResolution：设置此 Bitmap 的分辨率  
                //这里直接将我们需要添加水印的图片的分辨率赋给了bitmap  
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
                //Graphics：封装一个 GDI+ 绘图图面。  
                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                //设置图形的品质  
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;
                //grPhoto.CompositingQuality = CompositingQuality.HighQuality; //这两个测试了好效果
                //grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //将我们要添加水印的图片按照原始大小描绘（复制）到图形中  
                grPhoto.DrawImage(
                 imgPhoto,                                           //   要添加水印的图片  
                 new Rectangle(0, 0, phWidth, phHeight), //  根据要添加的水印图片的宽和高  
                 0,                                                     //  X方向从0点开始描绘  
                 0,                                                     // Y方向   
                 phWidth,                                            //  X方向描绘长度  
                 phHeight,                                           //  Y方向描绘长度  
                 GraphicsUnit.Pixel);                              // 描绘的单位，这里用的是像素     

                //字体  
                Font crFont = null;
                crFont = new Font("arial", size, FontStyle.Regular);//定义字段为普通文本       

                //封装文本布局信息（如对齐、文字方向和 Tab 停靠位），显示操作（如省略号插入和国家标准 (National) 数字替换）和 OpenType 功能。  
                StringFormat StrFormat = new StringFormat();
                //  StrFormat.LineAlignment


                //定义需要印的文字居中对齐  
                StrFormat.Alignment = StringAlignment.Near; //此属性时x轴的坐标为文字最左边距图片左边的距离
                                                            // StrFormat.Alignment = StringAlignment.Center;//此属性时x轴的坐标为文字中间距图片左边的距离

                // StrFormat.LineAlignment = StringAlignment.Center;

                Brush semiTransBrush = Brushes.Black;//定义一个黑色的画笔



                //DrawString 在指定矩形并且用指定的 Brush 和 Font 对象绘制指定的文本字符串。   标题
                grPhoto.DrawString(title,                                    //string of text  
                                           crFont,                                         //font  
                                           semiTransBrush,                            //Brush  
                                           new PointF(xPosOfWm, y1PosOfWm),  //Position  
                                           StrFormat);

                //使用时间
                grPhoto.DrawString(usetime,                                    //string of text  
                                      crFont,                                         //font  
                                      semiTransBrush,                            //Brush  
                                      new PointF(xPosOfWm, y2PosOfWm),  //Position  
                                      StrFormat);

                //地址
                grPhoto.DrawString(address,                                    //string of text  
                                      crFont,                                         //font  
                                      semiTransBrush,                            //Brush  
                                      new PointF(xPosOfWm, y3PosOfWm),  //Position  
                                      StrFormat);

                //imgPhoto是我们建立的用来装载最终图形的Image对象  
                //bmPhoto是我们用来制作图形的容器，为Bitmap对象  

                //原来为下面这样，会导致源图被占用
                //imgPhoto = bmPhoto;
                ////释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满  
                //grPhoto.Dispose();
                ////将grPhoto保存  
                //imgPhoto.Save(targetImage, ImageFormat.Jpeg);
                //imgPhoto.Dispose();

                //bmPhoto.Save(targetImage, ImageFormat.Jpeg);
                //bmPhoto.Dispose();
                ////释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满  
                //grPhoto.Dispose();
                ////将grPhoto保存  
                //// imgPhoto.Save(targetImage, ImageFormat.Jpeg);        
                //imgPhoto.Dispose();


                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality; //这个是重点类, 
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;
                //请注意这里的myImageCodecInfo声名..可以修改为更通用的.看后面 
                ImageCodecInfo myImageCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
                myEncoderParameters = new EncoderParameters(1);
                // 在这里设置图片的质量等级为95L.  这的等级设置了不起作用95或1都一样
                myEncoderParameter = new EncoderParameter(myEncoder, 1L);
                myEncoderParameters.Param[0] = myEncoderParameter;//将构建出来的EncoderParameter类赋给EncoderParameters数组
                bmPhoto.Save(FullPath, myImageCodecInfo, myEncoderParameters);//保存图片 
                bmPhoto.Dispose();
                //释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满  
                grPhoto.Dispose();
                //将grPhoto保存  
                // imgPhoto.Save(targetImage, ImageFormat.Jpeg);        
                imgPhoto.Dispose();


                return FilePath+FileName;

            }
            catch (Exception ex)
            {
                return "";
            }
        }



    }
}
