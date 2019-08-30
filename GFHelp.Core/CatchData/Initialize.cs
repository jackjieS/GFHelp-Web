
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.CatchData
{
    public class Seed
    {
        public static bool UpgradeUsing = false;

        public static void init()
        {
            new Helper.Log().systemInit("获取版本信息").coreInfo();
            SystemManager.ConfigData.DataVersion = SystemManager.ConfigData.DataVersion.ToLower();



        }
        public static void Updata()
        {


            if (UpgradeUsing)
            {
                new Helper.Log().systemInit("游戏数据正在更新").coreInfo();
                return;
            }
            UpgradeUsing = true;

            try
            {
                new Helper.Log().systemInit("获取版本信息").coreInfo();
                SystemManager.ConfigData.DataVersion = SystemManager.ConfigData.DataVersion.ToLower();
                new Helper.Log().systemInit("游戏数据开始更新").coreInfo();
                Task updata = new Task(() => DownLoad.DownloadCatchdata(SystemManager.ConfigData.DataVersion));
                updata.Start();
                updata.ContinueWith(p =>
                {
                    Helper.Configer.ConfigManager.SetConfig("catchdata", SystemManager.ConfigData.DataVersion);
                    CatachData.Seed();
                    UpgradeUsing = false;
                    new Helper.Log().systemInit("游戏数据更新完毕").coreInfo();
                });
            }
            catch (Exception e)
            {
                new Helper.Log().systemInit("数据更新出错",e.ToString()).coreInfo();
                UpgradeUsing = false;
            }




        }
    }
}
