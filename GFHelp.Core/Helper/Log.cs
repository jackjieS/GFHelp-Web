using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.Helper
{
    class Log
    {
        private static StreamWriter streamWriter; //写文件  
        private static UserData userData;
        private static string directPath;
        public Log(UserData ud)
        {
            userData = ud;
            directPath = Directory.GetCurrentDirectory() + @"\Log\" + userData.GameAccount.Base.Accountid.ToString();    //获得文件夹路径
            if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
            {
                Directory.CreateDirectory(directPath);
            }
        }
        public void Error(string message)
        {
            string path = directPath + string.Format(@"\Error.log");
            if (streamWriter == null)
            {
                streamWriter = !File.Exists(path) ? File.CreateText(path) : File.AppendText(path);    //判断文件是否存在如果不存在则创建，如果存在则添加。
            }
            if (message != null)
            {
                streamWriter.WriteLine("【" + DateTime.Now.ToString("HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message);
            }
            streamWriter.Flush();
            streamWriter.Dispose();
            streamWriter = null;
        }
        public void Info(string message)
        {
            try
            {
                directPath += string.Format(@"\Info.log");
                if (streamWriter == null)
                {
                    streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                }

                if (message != null)
                {
                    streamWriter.WriteLine("【" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message);
                }
            }

            catch (Exception ex)
            {

                Error("记录输出异常：" + ex.Message);
            }

            finally
            {
                if (streamWriter != null)
                {
                    try
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                    catch (Exception ex)
                    {

                        Error("记录输出异常：" + ex.Message);
                    }

                }
            }
        }





















    }

}
