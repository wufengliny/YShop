using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Yax.Common
{
    public class FileUtils
    {
        /// <summary>
        /// 删除目标文件
        /// </summary>
        /// <param name="filePath">要删除的文件路径</param>
        public static bool DeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }
            try
            {
                filePath = filePath.Contains(":\\") ? filePath : (new System.Web.UI.Page().Server.MapPath("~/") + filePath);
                filePath = filePath.Replace('/', '\\').Replace("\\\\", "\\");
                System.IO.File.Delete(filePath);
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 删除文件，相对路径+文件名
        /// </summary>
        /// <param name="serverMapPath"></param>
        /// <param name="fileName"></param>
        public static void DelFileByServerMapPath(string serverMapPath, string fileName)
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(serverMapPath) + fileName))
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(serverMapPath) + fileName);
            }
        }
        /// <summary>
        /// 删除文件，相对路径+文件名
        /// </summary>
        /// <param name="serverMapPath"></param>
        /// <param name="fileName"></param>
        public static void DelFileByServerMapPath(string serverMapPath)
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(serverMapPath)))
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(serverMapPath) );
            }
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        public static void CreateFolder(string folderPathName)
        {
            if (folderPathName.Trim().Length > 0)
            {
                try
                {
                    string createPath = folderPathName.ToString();
                    if (!Directory.Exists(createPath))
                    {
                        Directory.CreateDirectory(createPath);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="FolderPathName"></param>
        public static void DeleteChildFolder(string folderPathName)
        {
            if (folderPathName.Trim().Length > 0)
            {
                try
                {
                    string createPath = folderPathName.ToString();
                    if (Directory.Exists(createPath))
                    {
                        Directory.Delete(createPath, true);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="srcPath">源文件夹</param>
        /// <param name="aimPath">目录文件夹</param>
        public static void CopyFolder(string srcPath, string aimPath)
        {

            if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
            {
                aimPath += Path.DirectorySeparatorChar;
            }
            // 判断目标目录是否存在如果不存在则新建之
            if (!Directory.Exists(aimPath))
            {
                Directory.CreateDirectory(aimPath);
            }

            string[] fileList = Directory.GetFileSystemEntries(srcPath);
            // 遍历所有的文件和目录
            foreach (string file in fileList)
            {
                // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                if (Directory.Exists(file))
                {
                    CopyFolder(file, aimPath + Path.GetFileName(file));
                }
                // 否则直接Copy文件
                else
                {
                    File.Copy(file, aimPath + Path.GetFileName(file), true);
                }
            }

        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }




    }
}
