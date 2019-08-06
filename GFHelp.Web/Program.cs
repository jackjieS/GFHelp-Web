using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GFHelp.Web
{

    public class Program
    {
        public delegate bool ControlCtrlDelegate(int CtrlType);
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ControlCtrlDelegate HandlerRoutine, bool Add);
        private static ControlCtrlDelegate cancelHandler = new ControlCtrlDelegate(HandlerRoutine);

        public static bool HandlerRoutine(int CtrlType)
        {
            switch (CtrlType)
            {
                case 0:
                    Console.WriteLine("0工具被强制关闭"); //Ctrl+C关闭  
                    break;
                case 2:
                    Core.Helper.Configer.ConfigManager.SetConfig("LogID", Core.SystemOthers.ConfigData.LogID);
                    Console.WriteLine("2工具被强制关闭");//按控制台关闭按钮关闭  
                    break;
            }

            return false;
        }
        public static void Main(string[] args)
        {
            SetConsoleCtrlHandler(cancelHandler, true);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .UseKestrel(options =>
                    {
                        options.ListenAnyIP(7776, listenOptions =>
                        {
                            listenOptions.UseHttps("2593924_mylocal.nai-ve.top.pfx", "XvVIvb2Q");
                        });
                        options.ListenAnyIP(7777, listenOptions =>
                        {

                            listenOptions.UseHttps("2590788_gfapi.nai-ve.top.pfx", "9g5KIiOL");

                        });


                    })
            .UseStartup<Startup>()
            .Build();

    }
}
