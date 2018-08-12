using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadChipInfo : StcSquad_chip, tBaseData
    {
        public long GetID()
        {
            return (long)this.id;
        }

        public string Name;

        public override void InitData()
        {
        }








    }
}
