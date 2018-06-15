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
            DataVersion = Action.Home.Index_version().ToLower();
            
            if (DataVersion != SysteOthers.ConfigData.DataVersion)
            {
                SysteOthers.ConfigData.DataVersion = DataVersion;
                Base.Asset_Textes.Read_ALL_CSV();
                Task updata = new Task(() => DownLoad.DownloadCatchdata(DataVersion));
                updata.Start();
                updata.Wait();
                updata.ContinueWith(p =>
                {
                    Helper.ConfigManager.SetConfig("catchdata", DataVersion);
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
