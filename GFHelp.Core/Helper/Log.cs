using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.Helper
{

    public class logWriter
    {
        //Log 分系统和User

        private static StreamWriter coreErrorWriter; //写文件  
        private static StreamWriter coreInfoWriter; //写文件  
        private static StreamWriter signarlWriter; //写文件  
        private static StreamWriter webWriter; //写文件  
        private static object userLock = new object();
        private static object systemLock = new object();
        private static string systemDic;
        private static string userDic;
        private static string coreErrorPath;
        private static string coreInfoPath;
        private static string signarlPath;
        private static string webPath;

        public static void initLogWriter()
        {
            systemDic = SystemOthers.ConfigData.currentDirectory + @"\Log\system";
            if (!Directory.Exists(systemDic))//判断文件夹是否存在，如果不存在则创建
            {
                Directory.CreateDirectory(systemDic);
            }
            userDic = SystemOthers.ConfigData.currentDirectory + @"\Log\user";
            if (!Directory.Exists(userDic))//判断文件夹是否存在，如果不存在则创建
            {
                Directory.CreateDirectory(userDic);
            }

            coreErrorPath = SystemOthers.ConfigData.currentDirectory + @"\Log\system\coreError.log";
            coreErrorWriter = !File.Exists(coreErrorPath) ? File.CreateText(coreErrorPath) : File.AppendText(coreErrorPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
            coreInfoPath = SystemOthers.ConfigData.currentDirectory + @"\Log\system\coreInfo.log";
            coreInfoWriter = !File.Exists(coreInfoPath) ? File.CreateText(coreInfoPath) : File.AppendText(coreInfoPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
            signarlPath = SystemOthers.ConfigData.currentDirectory + @"\Log\system\SignarlError.log";
            signarlWriter = !File.Exists(signarlPath) ? File.CreateText(signarlPath) : File.AppendText(signarlPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
            webPath = SystemOthers.ConfigData.currentDirectory + @"\Log\system\webError.log";
            webWriter = !File.Exists(webPath) ? File.CreateText(webPath) : File.AppendText(webPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。



        }
        public static void SignarlError(string message)
        {
            write(signarlWriter, message);
        }
        public static void CoreError(string message)
        {
            write(coreErrorWriter, message);
            write(coreInfoWriter, message);
        }
        public static void CoreInfo(string message)
        {
            write(coreInfoWriter, message);
        }
        public static void WebInfo(string message)
        {
            write(webWriter, message);
        }


        private static void write(StreamWriter writer, string message)
        {
            lock (systemLock)
            {
                writer.WriteLine("【" + DateTime.Now.ToString("HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message);
                writer.Flush();
            }
        }

        public static void userInfo(string id,string message)
        {
            lock (userLock)
            {
                string path = userDic + string.Format(@"\{0}.log", id);
                StreamWriter streamWriter = !File.Exists(path) ? File.CreateText(path) : File.AppendText(path);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                streamWriter.WriteLine("【" + DateTime.Now.ToString("HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message);
                streamWriter.Flush();
                streamWriter.Dispose();
            }

        }

    }
    public struct Data
    {
        public int ID;
        public string AccountID;
        public string message;
        public string exception;
        public string timestamp;
        public string text;
    }



    public class Log
    {

        public static int getLogID()
        {
            return SystemOthers.ConfigData.LogID++;
        }


        public Data data;
        //private Log log;
        public Log systemInit(string m, string e=null)
        {
            //log = new Log();
            data = new Data();
            data.ID = getLogID();
            data.AccountID = "system";
            data.message = m;
            data.exception = e;
            data.timestamp = DateTime.Now.ToString();
            if (e == null)
            {
                data.text = string.Format("message = {0} ", data.message);
            }
            else
            {
                data.text = string.Format("message = {0} , exception = {1}", data.message, data.exception);
            }
            ConsolePrint(data.AccountID, data.text);
            return this;
        }

        public Log userInit(string id,string m, string e=null)
        {
            data = new Data();
            data.ID = getLogID();
            data.AccountID = id;
            data.message = m;
            data.exception = e;
            data.timestamp = DateTime.Now.ToString();
            if (e == null)
            {
                data.text = string.Format("message = {0} ", data.message);
            }
            else
            {
                data.text = string.Format("message = {0} , exception = {1}", data.message, data.exception);
            }
            ConsolePrint(data.AccountID, data.text);
            return this;
        }

        public Log coreInfo()
        {
            logWriter.CoreInfo(data.text);
            Add(Viewer.systemLogs, data);
            return this;
        }
        public Log coreError()
        {
            logWriter.CoreError(data.text);
            Add(Viewer.systemLogs, data);
            return this;
        }
        public Log signarlError()
        {
            logWriter.SignarlError(data.text);
            Add(Viewer.systemLogs, data);
            return this;
        }
        public Log webInfo()
        {
            logWriter.WebInfo(data.text);
            Add(Viewer.systemLogs, data);
            return this;
        }
        public Log userInfo()
        {
            logWriter.userInfo(data.AccountID, data.text);
            if (Viewer.usersLogs.ContainsKey(data.AccountID))
            {
                Viewer.usersLogs[data.AccountID].Add(data);
            }
            else
            {
                List<Data> list = new List<Data>();
                list.Add(data);
                Viewer.usersLogs.Add(data.AccountID, list);
            }
            SignaIRClient.SendGameNotice(data.AccountID, data);
            return this;
        }
        private void ConsolePrint(string id,string m)
        {
            string text = string.Format("【{0}】 {1} {2}", DateTime.Now.ToString("HH:mm:ss"), id, m);
            Console.WriteLine(text);
        }
        private void Add<T>(List<T> list,T data)
        {
            if (list.Count >= SystemOthers.ConfigData.ListStoreNum)
            {
                list.RemoveAt(0);
                list.Add(data);
            }
            else
            {
                list.Add(data);
            }
        }

    }

    public class Viewer
    {
        public void test()
        {
           new Log().systemInit("测试", "舒服").coreInfo();
        }
        public static List<Data> systemLogs = new List<Data>();
        //public static List<Data> FrontsystemLogs = new List<Data>();
        public static Dictionary<string,List<Data>> usersLogs = new Dictionary<string, List<Data>>();
    }


































}
