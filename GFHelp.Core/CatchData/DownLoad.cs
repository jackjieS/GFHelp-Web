using GFHelp.Core.Helper;
using ICSharpCode.SharpZipLib.GZip;
using LitJson;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GFHelp.Core.CatchData
{
    class DownLoad
    {
        private static bool isCompleted=false;
        public static bool DownloadCatchdata(string version)
        {
            isCompleted = false;
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(GetDataFileFullUrl(version)),string.Format(SystemOthers.ConfigData.currentDirectory + @"\stc_data.dat"));
                    client.DownloadProgressChanged += client_DownloadProgressChanged;
                    client.DownloadFileCompleted += client_DownloadFileCompleted;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            while (!isCompleted)
            {
                Thread.Sleep(1000);
            }
            return true;
        }

        private static string GetMD5HashString(string origin)
        {
            MD5 md = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(origin);
            byte[] array = md.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
        private static string GetDataFileFullUrl(string version)
        {
            return string.Concat(new string[]
            {
            "http://oss-rescnf.gf.ppgame.com/data/",
            "stc_",
            version,
            GetMD5HashString(version),
            ".zip"
            });
        }
        private static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(string.Format("当前接收到{0}字节，文件大小总共{1}字节", e.BytesReceived, e.TotalBytesToReceive));
        }
        private static void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine(string.Format("文件下载被取消 {0} ", e.Error.ToString()));

            }
            if (e.Error == null && e.Cancelled == false)
            {
                Console.WriteLine(string.Format("文件下载完成"));
                SavezipDataTojosn();
                isCompleted = true;
            }


        }
        private static void SavezipDataTojosn()
        {
            int count = 0;
            var str1 = SystemOthers.ConfigData.currentDirectory + @"\stc_data.dat";
            var str2 = SystemOthers.ConfigData.currentDirectory + @"\stc";
            System.IO.Compression.ZipFile.ExtractToDirectory(str1, str2,true); //解压
            using (Stream stream = new FileStream(str2 + @"\catchdata.dat", FileMode.Open))
            {
                using (Stream stream2 = new SimpleEncryptStream(stream))
                {
                    (stream2 as SimpleEncryptStream).SetManualHeader(Encoding.ASCII.GetBytes("c88d016d261eb80ce4d6e41a510d4048"));
                    using (Stream stream3 = new GZipInputStream(stream2))
                    {
                        StreamReader streamReader = new StreamReader(stream3, Encoding.UTF8);
                        FileStream fs = new FileStream(str2 + @"\catchdata.json", FileMode.OpenOrCreate);
                        StreamWriter sw = new StreamWriter(fs);
                        while (streamReader.Peek() >= 0)
                        {
                            string text = streamReader.ReadLine();
                            sw.WriteLine(text);
                            FileStream f0 = new FileStream(str2 + @"\"+count++.ToString()+".json", FileMode.OpenOrCreate);
                            StreamWriter s0 = new StreamWriter(f0);
                            s0.WriteLine(text);
                            s0.Close();
                            f0.Close();
                            JsonData jsonData = JsonMapper.ToObject(text);
                        }
                        sw.Close();
                        fs.Close();
                        stream3.Close();
                        streamReader.Close();
                        stream3.Close();
                    }
                }
            }
        }
    }
}
