using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Yax.Common
{
    /// <summary>
    /// 上传图片  音乐操作
    /// </summary>
    public class UploadPic
    {
        #region NET 控件上传

        #region 上传图片 外部调用的方法

        #region 保存原图
        /// <summary>
        /// 上传图片 保存原图  默认最大图片10M
        /// </summary>
        /// <returns>原图保存的路径</returns>
        public static string UpLoadPicBig(FileUpload fileUP)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowPicExtNames, PubStr.UpPicMaxSize10M);
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }
        /// <summary>
        /// 上传原图片 可设置最大图片大小
        /// </summary>
        /// <param name="fileUP">上传文件控件</param>
        /// <param name="PicMaxSize">最大图片大小单位为KB</param>
        /// <returns>原图保存的路径</returns>
        public static string UpLoadPicBig(FileUpload fileUP, int PicMaxSize)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowPicExtNames, PicMaxSize);
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }
        #endregion


        #region 上传的图片加水印
        /// <summary>
        /// 上传的图片加水印  默认最大图片10M
        /// </summary>
        /// <param name="fileUP">上传上来的图片</param>
        /// <param name="waterUrl">水印图片路径</param>
        /// <param name="toumingdu">水印透明度</param>
        /// <returns>水印图片保存路径</returns>
        public static string UpLoadWatrerPic(FileUpload fileUP, string waterUrl, string toumingdu)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    string water1 = _pDir + _FileName + "w" + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowPicExtNames, PubStr.UpPicMaxSize10M);
                    //水印
                    if (!string.IsNullOrEmpty(waterUrl))
                    {
                        try
                        {
                            ImageManager im = new ImageManager();
                            //im.SaveWatermark(原图地址, 水印地址, 透明度, 水印位置, 边距, 保存位置); 
                            im.SaveWatermark(System.Web.HttpContext.Current.Server.MapPath(virvalpath), //原图地址
                                System.Web.HttpContext.Current.Server.MapPath(waterUrl), //水印地址
                                Convert.ToSingle(toumingdu),  //透明度
                                ImageManager.WatermarkPosition.RigthBottom, 10,//水印位置, 边距,
                                System.Web.HttpContext.Current.Server.MapPath(water1));// 保存位置
                            FileUtils.DeleteFile(virvalpath);
                            virvalpath = water1;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }
        //

        /// <summary>
        /// 上传的图片加水印  默认最大图片10M
        /// </summary>
        /// <param name="fileUP">上传上来的图片</param>
        /// <param name="waterUrl">水印图片路径</param>
        /// <param name="toumingdu">水印透明度</param>
        /// <returns>水印图片保存路径</returns>
        public static string UpLoadWatrerPic(FileUpload fileUP, string waterUrl, string toumingdu, ImageManager.WatermarkPosition wposition, int borderDistance)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    string water1 = _pDir + _FileName + "w" + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowPicExtNames, PubStr.UpPicMaxSize10M);
                    //水印
                    if (!string.IsNullOrEmpty(waterUrl))
                    {
                        try
                        {
                            ImageManager im = new ImageManager();
                            //im.SaveWatermark(原图地址, 水印地址, 透明度, 水印位置, 边距, 保存位置); 
                            im.SaveWatermark(System.Web.HttpContext.Current.Server.MapPath(virvalpath), //原图地址
                                System.Web.HttpContext.Current.Server.MapPath(waterUrl), //水印地址
                                Convert.ToSingle(toumingdu),  //透明度
                                wposition,//水印位置
                                borderDistance,// 边距
                                System.Web.HttpContext.Current.Server.MapPath(water1));// 保存位置
                            FileUtils.DeleteFile(virvalpath);
                            virvalpath = water1;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }
        #endregion


        #region 上传的图片保存为缩略图
        /// <summary>
        /// 上传的图片保存为缩略图,默认裁剪方式HW_Mode.HW_FIXITY,默认图片质量50L（1-100）
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <returns>保存的缩略图路径</returns>
        public static string UpLoadSmallPic(FileUpload fileUP, string _SmallImgFormat)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP.PostedFile.InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, HW_Mode.HW_FIXITY, 50L);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }
        //

        /// <summary>
        /// 上传的图片保存为缩略图  默认裁剪方式HW_Mode.HW_FIXITY
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="qulity">图片质量 1—100 数字越高压缩图片质量越好占用空间也越大Eg40L</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(FileUpload fileUP, string _SmallImgFormat, long qulity)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP.PostedFile.InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, HW_Mode.HW_FIXITY, qulity);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }

        /// <summary>
        /// 上传的图片保存为缩略图  默认图片质量50L（1-100）
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="hw_mode">裁剪方式</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(FileUpload fileUP, string _SmallImgFormat, HW_Mode hw_mode)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP.PostedFile.InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, hw_mode, 50L);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }




        /// <summary>
        /// 上传的图片保存为缩略图
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="hw_mode">裁剪方式</param>
        /// <param name="qulity">图片质量 1—100 数字越高压缩图片质量越好占用空间也越大Eg40L</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(FileUpload fileUP, string _SmallImgFormat, HW_Mode hw_mode, long qulity)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP.PostedFile.InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, hw_mode, qulity);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }
        #endregion

        #endregion

        #region 上传音乐文件 UpMusicFile
        /// <summary>
        /// 上传音乐文件 
        /// </summary>
        /// <param name="fileUP">上传文件的控件</param>
        /// <returns>保存的虚拟路径</returns>
        public static string UpMusicFile(FileUpload fileUP)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.HasFile)
            {
                string _ExtName = fileUP.PostedFile.FileName.Substring(fileUP.PostedFile.FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowMusicExtNames, PubStr.UpPicMaxSize10M);
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }
        #endregion

        #region 上传图片    Help

        #region  文件上传
        /// <summary>
        /// 文件上传 
        /// </summary>
        /// <param name="fileUpload">文件上传控件</param>
        /// <param name="savePath">目标保存路径</param>
        /// <param name="allowFileExtNames">允许文件类型(多个以,隔开;默认"jpg,gif,png",如果是null则代表不限制文件类型)</param>
        /// <param name="allowFileSize">允许文件大小(以K为单位,为0则不限制大小,默认1024K(1M))</param>
        /// <returns>返回文件保存路径</returns>
        public static string SaveFile(FileUpload fileUpload, string savePath, string allowFileExtNames, int allowFileSize)
        {
            string serverDir = new System.Web.UI.Page().Server.MapPath("~/");
            if (!string.IsNullOrEmpty(allowFileExtNames))
            {
                string extName = fileUpload.PostedFile.FileName.Substring(fileUpload.PostedFile.FileName.LastIndexOf('.') + 1).ToLower();
                if (!allowFileExtNames.ToLower().Contains(extName.ToLower()))
                {
                    JscriptHelper.AlertReturn("上传文件类型只支持：" + allowFileExtNames);
                    throw new Exception("上传文件类型只支持：" + allowFileExtNames);
                }
            }
            allowFileSize = allowFileSize * 1024;//以K为单位计算文件大小
            if (0 < allowFileSize && allowFileSize < fileUpload.PostedFile.ContentLength)
            {
                //如果上传的文件大小超过限制
                JscriptHelper.AlertReturn("上传的文件大小为：" + (fileUpload.PostedFile.ContentLength / 1024) + "K，允许的文件大小不能超过" + (allowFileSize / 1024).ToString() + "K");
            }
            int idx = savePath.LastIndexOf('/') == -1 ? savePath.LastIndexOf('\\') : savePath.LastIndexOf('/');

            string saveDir = serverDir + savePath.Remove(idx);
            saveDir = saveDir.Replace('/', '\\').Replace("\\\\", "\\");

            if (!System.IO.Directory.Exists(saveDir))
            {
                //如果路径不存在则创建
                System.IO.Directory.CreateDirectory(saveDir);
            }

            saveDir = (serverDir + savePath).Replace('/', '\\').Replace("\\\\", "\\");

            fileUpload.PostedFile.SaveAs(saveDir);
            fileUpload.Dispose();

            //_tmpCount加1,防止同一毫秒内因为上传多个文件造成文件覆盖
            //_tmpCount++;

            return savePath;//返回文件保存路径，以便保存到数据库

        }
        #endregion


        #region 产生缩略图
        /// <summary>
        /// 产生缩略图保存到当前目录的指定位置
        /// </summary>
        /// <param name="sourceStream">原图片文件流</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="targetWidth">缩略图宽</param>
        /// <param name="targetHeight">缩略图高</param>
        /// <param name="hw_mode">裁剪方式</param>
        public static void BringSmallImage(Stream sourceStream, string savePath, int targetWidth, int targetHeight, HW_Mode hw_mode, long quality)
        {
            string serverDir = new System.Web.UI.Page().Server.MapPath("~/");
            System.Drawing.Image image;
            try
            {
                image = System.Drawing.Image.FromStream(sourceStream);
            }
            catch (OutOfMemoryException)
            {
                throw new Exception("请选择正确的图片文件!");
            }

            int sWidth = image.Width;
            int sHeight = image.Height;

            int tWidth = targetWidth;
            int tHeight = targetHeight;

            int x = 0;
            int y = 0;

            #region 缩略方式
            switch (hw_mode)
            {
                case HW_Mode.HW_FIXITY://指定固定高宽缩放（可能变形）   
                    tWidth = targetWidth;
                    tHeight = targetHeight;
                    break;
                case HW_Mode.HW_SCALE://指定宽高的最大值(并按比例缩放,不变形)
                    tWidth = targetWidth;
                    tHeight = image.Height * tWidth / image.Width;
                    if (tHeight > targetHeight)
                    {
                        tHeight = targetHeight;
                        tWidth = (image.Width * tHeight / image.Height) > targetWidth ? targetWidth : (image.Width * tHeight / image.Height);
                        tHeight = (image.Height * tWidth / image.Width) > targetHeight ? targetHeight : (image.Height * tWidth / image.Width);
                    }
                    if (tWidth > image.Width)
                    {
                        tWidth = image.Width;
                        tHeight = (image.Height * tWidth / image.Width) > targetHeight ? targetHeight : (image.Height * tWidth / image.Width);
                        tWidth = (image.Width * tHeight / image.Height) > targetWidth ? targetWidth : (image.Width * tHeight / image.Height);
                    }
                    break;
                case HW_Mode.WIDTH://指定宽，高按比例获取(如果超过最大允许值则按最大允许值) 
                    tWidth = image.Width > targetWidth ? targetWidth : image.Width;
                    tHeight = image.Height * tWidth / image.Width;
                    break;
                case HW_Mode.HEIGHT://指定高，宽按比例获取(如果超过最大允许值则按最大允许值)
                    tHeight = image.Height > targetHeight ? targetHeight : image.Height;
                    tWidth = image.Width * tHeight / image.Height;
                    break;
                case HW_Mode.CUT://指定高宽裁减（不变形）                
                    if ((double)image.Width / (double)image.Height > (double)targetWidth / (double)targetHeight)
                    {
                        sHeight = image.Height;
                        sWidth = image.Height * targetWidth / targetHeight;
                        y = 0;
                        x = (image.Width - sWidth) / 2;
                    }
                    else
                    {
                        sWidth = image.Width;
                        sHeight = image.Width * targetHeight / targetWidth;
                        x = 0;
                        y = (image.Height - sHeight) / 2;
                    }
                    break;
                default:
                    break;
            }
            #endregion

            #region
            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(tWidth, tHeight);
            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(image, new System.Drawing.Rectangle(0, 0, tWidth, tHeight),
                new System.Drawing.Rectangle(x, y, sWidth, sHeight),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {

                #region 保存路径不存在则创建
                int idx = savePath.LastIndexOf('/') == -1 ? savePath.LastIndexOf('\\') : savePath.LastIndexOf('/');
                string saveDir = serverDir + savePath.Remove(idx);
                saveDir = saveDir.Replace('/', '\\').Replace("\\\\", "\\");
                if (!System.IO.Directory.Exists(saveDir))
                {
                    //如果路径不存在则创建
                    System.IO.Directory.CreateDirectory(saveDir);
                }
                #endregion

                saveDir = (serverDir + savePath).Replace('/', '\\').Replace("\\\\", "\\");

                //以jpg格式保存缩略图
                //bitmap.Save(saveDir, System.Drawing.Imaging.ImageFormat.Jpeg);

                #region  修改缩略图质量的操作
                System.Drawing.Imaging.ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo codec in codecs)
                {
                    if ("image/jpeg".Equals(codec.MimeType.ToLower()))
                    {
                        ici = codec;
                        break;
                    }
                }
                System.Drawing.Imaging.Encoder ecd = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameter ept = new EncoderParameter(ecd, quality); //  图片质量1-100
                EncoderParameters eptS = new EncoderParameters(1);
                eptS.Param[0] = ept;
                bitmap.Save(saveDir, ici, eptS);
                #endregion
            }
            catch
            {
                throw new Exception("产生缩略图失败!");
            }
            finally
            {
                image.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
            #endregion
        }
        #endregion



        #endregion

        #region  获取上传的图片的长和宽
        /// <summary>
        /// 获取上传的图片的长和宽
        /// </summary>
        /// <param name="PicUp"></param>
        /// <returns></returns>
        public static string GetUpPicWidthAndHeight(FileUpload PicUp)
        {
            Stream stream = PicUp.PostedFile.InputStream;
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                return image.Width + "*" + image.Height;
            }
            catch
            {
                JscriptHelper.AlertReturn("请上传正确的图片文件");
            }
            return "";
        }
        #endregion

        
        #endregion

        #region input 上传
        #region 保存原图
        /// <summary>
        /// 上传图片 保存原图  默认最大图片10M   只上传第一个文件
        /// </summary>
        /// <returns>原图保存的路径</returns>
        public static string UpLoadPicBig(HttpFileCollection fileUP )
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count>0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowPicExtNames, PubStr.UpPicMaxSize10M);
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }

        /// <summary>
        /// 上传原图片 可设置最大图片大小  只上传第一个文件
        /// </summary>
        /// <param name="fileUP">上传文件控件</param>
        /// <param name="PicMaxSize">最大图片大小单位为KB</param>
        /// <returns>原图保存的路径</returns>
        public static string UpLoadPicBig(HttpFileCollection fileUP, int PicMaxSize)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count>0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    SaveFile(fileUP, virvalpath, PubStr.AllowPicExtNames, PicMaxSize);
                }
                catch (Exception ex)
                {
                    return "";
                }
                return virvalpath;
            }
            return "";
        }



        /// <summary>
        /// Mvc上传原图片 可设置最大图片大小  只上传第一个文件
        /// </summary>
        /// <param name="fileUP">上传文件控件</param>
        /// <param name="PicMaxSize">最大图片大小单位为KB</param>
        /// <param name="RootDir"></param>
        /// <returns>原图保存的路径</returns>
        public static string UpLoadPicBig(HttpFileCollectionBase fileUP,string RootDir="")
        {
            if(string.IsNullOrEmpty(RootDir))
            {
                RootDir = Yax.Common.PubStr.UpLoadPath;
            }
            string _pDir = RootDir + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count > 0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                string virvalpath;
                try
                {
                    //上传原文件
                    virvalpath = _pDir + _FileName + _ExtName;
                    SaveFile(fileUP, virvalpath);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                return virvalpath;
            }
            return "";
        }

        #endregion

        #region 上传的图片保存为缩略图
        /// <summary>
        /// 上传的图片保存为缩略图,默认裁剪方式HW_Mode.HW_FIXITY,默认图片质量50L（1-100）
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <returns>保存的缩略图路径</returns>
        public static string UpLoadSmallPic(HttpFileCollection fileUP, string _SmallImgFormat)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count>0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP[0].InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, HW_Mode.HW_FIXITY, 50L);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }
        //

        /// <summary>
        /// 上传的图片保存为缩略图  默认裁剪方式HW_Mode.HW_FIXITY
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="qulity">图片质量 1—100 数字越高压缩图片质量越好占用空间也越大Eg40L</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(HttpFileCollection fileUP, string _SmallImgFormat, long qulity)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count>0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP[0].InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, HW_Mode.HW_FIXITY, qulity);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }

        /// <summary>
        /// 上传的图片保存为缩略图  默认图片质量50L（1-100）
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="hw_mode">裁剪方式</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(HttpFileCollection fileUP, string _SmallImgFormat, HW_Mode hw_mode)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count>0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP[0].InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, hw_mode, 50L);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }




        /// <summary>
        /// 上传的图片保存为缩略图
        /// </summary>
        /// <param name="fileUP">上传的图片</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="hw_mode">裁剪方式</param>
        /// <param name="qulity">图片质量 1—100 数字越高压缩图片质量越好占用空间也越大Eg40L</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(HttpFileCollection fileUP, string _SmallImgFormat, HW_Mode hw_mode, long qulity)
        {
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            if (fileUP.Count>0)
            {
                string _ExtName = fileUP[0].FileName.Substring(fileUP[0].FileName.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();
                try
                {
                    Stream stream = fileUP[0].InputStream;
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(stream, virturlpath, _tmpW, _tmpH, hw_mode, qulity);
                        return virturlpath;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return "";
        }
        #endregion

        #region 上传图片 input    Help
        #region  文件上传
        /// <summary>
        /// 文件上传  input type=file  方式  只上传第一个文件
        /// </summary>
        /// <param name="fileUpload">文件上传控件</param>
        /// <param name="savePath">目标保存路径</param>
        /// <param name="allowFileExtNames">允许文件类型(多个以,隔开;默认"jpg,gif,png",如果是null则代表不限制文件类型)</param>
        /// <param name="allowFileSize">允许文件大小(以K为单位,为0则不限制大小,默认1024K(1M))</param>
        /// <returns>返回文件保存路径</returns>
        public static string SaveFile(HttpFileCollection fileUpload, string savePath, string allowFileExtNames, int allowFileSize)
        {
            string serverDir = new System.Web.UI.Page().Server.MapPath("~/");
            if (!string.IsNullOrEmpty(allowFileExtNames))
            {
                string extName = fileUpload[0].FileName.Substring(fileUpload[0].FileName.LastIndexOf('.') + 1).ToLower();
                if (!allowFileExtNames.ToLower().Contains(extName.ToLower()))
                {
                    JscriptHelper.AlertReturn("上传文件类型只支持：" + allowFileExtNames);
                    throw new Exception("上传文件类型只支持：" + allowFileExtNames);
                }
            }
            allowFileSize = allowFileSize * 1024;//以K为单位计算文件大小
            if (0 < allowFileSize && allowFileSize < fileUpload[0].ContentLength)
            {
                //如果上传的文件大小超过限制
                JscriptHelper.AlertReturn("上传的文件大小为：" + (fileUpload[0].ContentLength / 1024) + "K，允许的文件大小不能超过" + (allowFileSize / 1024).ToString() + "K");
            }
            int idx = savePath.LastIndexOf('/') == -1 ? savePath.LastIndexOf('\\') : savePath.LastIndexOf('/');

            string saveDir = serverDir + savePath.Remove(idx);
            saveDir = saveDir.Replace('/', '\\').Replace("\\\\", "\\");

            if (!System.IO.Directory.Exists(saveDir))
            {
                //如果路径不存在则创建
                System.IO.Directory.CreateDirectory(saveDir);
            }
            saveDir = (serverDir + savePath).Replace('/', '\\').Replace("\\\\", "\\");
            fileUpload[0].SaveAs(saveDir);

            //_tmpCount加1,防止同一毫秒内因为上传多个文件造成文件覆盖
            //_tmpCount++;

            return savePath;//返回文件保存路径，以便保存到数据库

        }


        /// <summary>
        /// 文件上传  input type=file  方式  只上传第一个文件
        /// </summary>
        /// <param name="fileUpload">文件上传控件</param>
        /// <param name="savePath">目标保存路径</param>
        /// <param name="allowFileExtNames">允许文件类型(多个以,隔开;默认"jpg,gif,png",如果是null则代表不限制文件类型)</param>
        /// <param name="allowFileSize">允许文件大小(以K为单位,为0则不限制大小,默认1024K(1M))</param>
        /// <returns>返回文件保存路径</returns>
        public static string SaveFile(HttpFileCollectionBase fileUpload, string savePath)
        {
            string serverDir = new System.Web.UI.Page().Server.MapPath("~/");
            int idx = savePath.LastIndexOf('/') == -1 ? savePath.LastIndexOf('\\') : savePath.LastIndexOf('/');
            string saveDir = serverDir + savePath.Remove(idx);
            saveDir = saveDir.Replace('/', '\\').Replace("\\\\", "\\");
            if (!System.IO.Directory.Exists(saveDir))
            {
                //如果路径不存在则创建
                System.IO.Directory.CreateDirectory(saveDir);
            }
            saveDir = (serverDir + savePath).Replace('/', '\\').Replace("\\\\", "\\");
            fileUpload[0].SaveAs(saveDir);
            return savePath;//返回文件保存路径，以便保存到数据库
        }
        /// <summary>
        /// 文件上传  input type=file  方式  上传多个文件
        /// </summary>
        /// <param name="fileUpload">文件上传控件</param>
        /// <param name="savePath">目标保存路径</param>
        /// <param name="allowFileExtNames">允许文件类型(多个以,隔开;默认"jpg,gif,png",如果是null则代表不限制文件类型)</param>
        /// <param name="allowFileSize">允许文件大小(以K为单位,为0则不限制大小,默认1024K(1M))</param>
        /// <returns>返回文件保存路径</returns>
        public static List<string> SaveFileMulty(HttpFileCollection fileUpload, string allowFileExtNames, int allowFileSize)
        {
            string serverDir = new System.Web.UI.Page().Server.MapPath("~/");
            string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
            string _ExtName;
            string _FileName;
            string savePath;
            List<string> res = new List<string>();
            for (int i = 0; i < fileUpload.Count; i++)
            {
                if (fileUpload[i].ContentLength > 0)
                {
                    _ExtName = fileUpload[i].FileName.Substring(fileUpload[i].FileName.LastIndexOf('.'));
                    _FileName = Utils.RandomDateCard();
                    savePath = _pDir + _FileName + i + _ExtName;
                    if (!string.IsNullOrEmpty(allowFileExtNames))
                    {
                        string extName = fileUpload[i].FileName.Substring(fileUpload[i].FileName.LastIndexOf('.') + 1).ToLower();
                        if (!allowFileExtNames.ToLower().Contains(extName.ToLower()))
                        {
                            JscriptHelper.AlertReturn("上传文件类型只支持：" + allowFileExtNames);
                            throw new Exception("上传文件类型只支持：" + allowFileExtNames);
                        }
                    }
                    allowFileSize = allowFileSize * 1024;//以K为单位计算文件大小
                    if (0 < allowFileSize && allowFileSize < fileUpload[i].ContentLength)
                    {
                        //如果上传的文件大小超过限制
                        JscriptHelper.AlertReturn("上传的文件大小为：" + (fileUpload[i].ContentLength / 1024) + "K，允许的文件大小不能超过" + (allowFileSize / 1024).ToString() + "K");
                    }
                    int idx = savePath.LastIndexOf('/') == -1 ? savePath.LastIndexOf('\\') : savePath.LastIndexOf('/');
                    string saveDir = serverDir + savePath.Remove(idx);
                    saveDir = saveDir.Replace('/', '\\').Replace("\\\\", "\\");
                    if (!System.IO.Directory.Exists(saveDir))
                    {
                        //如果路径不存在则创建
                        System.IO.Directory.CreateDirectory(saveDir);
                    }
                    saveDir = (serverDir + savePath).Replace('/', '\\').Replace("\\\\", "\\");
                    fileUpload[i].SaveAs(saveDir);
                    res.Add(savePath);
                }
            }
            return res;//返回文件保存路径的集合，以便保存到数据库
        }




        #endregion

        #endregion 





        /// <summary>
        /// 图片保存为缩略图,默认裁剪方式HW_Mode.HW_FIXITY,默认图片质量90L（1-100）
        /// </summary>
        /// <param name="imgpath">图片路径(传进来之前要先转为绝对路径)</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(string imgpath, string _SmallImgFormat)
        {
            try
            {
                string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
                string _ExtName = imgpath.Substring(imgpath.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();

                FileStream fs = new FileStream(imgpath, FileMode.Open);
                using (fs)
                {
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(fs, virturlpath, _tmpW, _tmpH, HW_Mode.HW_FIXITY, 90L);
                        return virturlpath;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// 图片保存为缩略图
        /// </summary>
        /// <param name="imgpath">图片路径(传进来之前要先转为绝对路径)</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="quailty">1-100</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(string imgpath, string _SmallImgFormat,long quailty)
        {
            try
            {
                string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
                string _ExtName = imgpath.Substring(imgpath.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();

                FileStream fs = new FileStream(imgpath, FileMode.Open);
                using (fs)
                {
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(fs, virturlpath, _tmpW, _tmpH, HW_Mode.HW_FIXITY, quailty);
                        return virturlpath;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
        /// <summary>
        /// 图片保存为缩略图
        /// </summary>
        /// <param name="imgpath">图片路径(传进来之前要先转为绝对路径)</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="quailty">1-100</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(string imgpath, string _SmallImgFormat, HW_Mode mode)
        {
            try
            {
                string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
                string _ExtName = imgpath.Substring(imgpath.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();

                FileStream fs = new FileStream(imgpath, FileMode.Open);
                using (fs)
                {
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(fs, virturlpath, _tmpW, _tmpH, mode, 90L);
                        return virturlpath;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// 图片保存为缩略图
        /// </summary>
        /// <param name="imgpath">图片路径(传进来之前要先转为绝对路径)</param>
        /// <param name="_SmallImgFormat">缩略图规格大小Eg228*174</param>
        /// <param name="quailty">1-100</param>
        /// <returns></returns>
        public static string UpLoadSmallPic(string imgpath, string _SmallImgFormat, HW_Mode mode,long quailty)
        {
            try
            {
                string _pDir = Yax.Common.PubStr.UpLoadPath + DateTime.Now.ToString("yyyyMM") + "/";
                string _ExtName = imgpath.Substring(imgpath.LastIndexOf('.'));
                string _FileName = Utils.RandomDateCard();

                FileStream fs = new FileStream(imgpath, FileMode.Open);
                using (fs)
                {
                    string virturlpath;
                    int _tmpW = 0;
                    int _tmpH = 0;
                    if (!string.IsNullOrEmpty(_SmallImgFormat))
                    {
                        virturlpath = _pDir + _FileName + "_s" + _ExtName;
                        _tmpW = Utils.StrToInt(_SmallImgFormat.Split('*')[0]);
                        _tmpH = Utils.StrToInt(_SmallImgFormat.Split('*')[1]);
                        BringSmallImage(fs, virturlpath, _tmpW, _tmpH, mode, quailty);
                        return virturlpath;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
        #endregion
        //
    }

    public enum HW_Mode
    {
        /// <summary>
        /// 指定固定高宽缩放（可能变形）
        /// </summary>
        HW_FIXITY,
        /// <summary>
        /// 指定宽高的最大值(并按比例缩放,不变形)
        /// </summary>
        HW_SCALE,
        /// <summary>
        /// 指定宽，高按比例获取(如果超过最大允许值则按最大允许值) 
        /// </summary>
        WIDTH,
        /// <summary>
        /// 指定高，宽按比例获取(如果超过最大允许值则按最大允许值)
        /// </summary>
        HEIGHT,
        /// <summary>
        /// 指定高宽裁减（不变形） 
        /// </summary>
        CUT
    }


}
