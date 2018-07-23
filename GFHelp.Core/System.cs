using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace GFHelp.Core.SystemOthers
{
   

    public class ConfigData
    {
        static dynamic type = (new Program()).GetType();
        public static string currentDirectory = Path.GetDirectoryName(type.Assembly.Location);
        public static string DataVersion;
        public static int tomorrow_zero;
        public static int weekday;

        public static List<string> BattleMap = new List<string>()
        {
            "-map0_2",
            "-map5_2N",
            "-map10_4E"
        };
        public static int Error_num =3;
        public static int BL_ReLogin_num = 20;
        public static int ListStoreNum = 999;
        public static List<AccountInfo> WebUserData = new List<AccountInfo>();
        public static int LogID;
        public static void Initialize()
        {
            logWriter.initLogWriter();
            ConfigManager.getConfig();
            new Log().systemInit("读取config配置").coreInfo();
            new Log().systemInit("读取文字解析").coreInfo();
            CatchData.Base.Asset_Textes.Read_ALL_CSV();

            new Log().systemInit("updataCatchData").coreInfo();
            CatchData.Seed.Updata();
            new Log().systemInit("引用作战dll").coreInfo();
            Action.Mission.initialize();
        }

    }

    /// <summary>
    /// 网站账户信息
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Key]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Policy { get; set; }
    }


}
