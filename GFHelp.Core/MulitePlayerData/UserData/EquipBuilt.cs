using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    class EquipBuilt
    {
        public int StartTime;//utx
        public int continuedTime;
        public int time
        {
            get
            {
                DateTime t = new DateTime(1970, 1, 1);
                double second = (DateTime.UtcNow - t).TotalSeconds;
                return StartTime + continuedTime - (int)second;
            }
        }
        public bool Finish_add;
        public bool Start_add;
        public List<EquipBuilt> list;

    }

}
