using System;

namespace GFHelp.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("GFHelp辅助控制台启动");
            System.Threading.Thread.Sleep(500000);
        }
        public static void Print(string message)
        {
            string text = "【" + DateTime.Now.ToString("HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message;
            System.Console.WriteLine(text);
        }
    }



}
