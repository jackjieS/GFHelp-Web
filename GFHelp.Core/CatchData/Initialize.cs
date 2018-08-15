using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.CatchData
{
    public class Seed
    {
        public static string DataVersion;
        public static void Updata()
        {


            DataVersion = Action.Home.Index_version(true).ToLower();

            if (DataVersion != SystemOthers.ConfigData.DataVersion.ToLower())
            {
                SystemOthers.ConfigData.DataVersion = DataVersion;
                Task updata = new Task(() => DownLoad.DownloadCatchdata(DataVersion));
                updata.Start();
                updata.Wait();
                updata.ContinueWith(p =>
                {
                    Helper.Configer.ConfigManager.SetConfig("catchdata", DataVersion);
                    CatachData.Seed();
                });
            }
            else
            {
                CatachData.Seed();
            }



        }
    }
}
