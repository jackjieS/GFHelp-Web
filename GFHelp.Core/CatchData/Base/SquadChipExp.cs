using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadChipExp : StcSquad_chip_exp, tBaseData
    {
        // Token: 0x06002432 RID: 9266 RVA: 0x000EE0BC File Offset: 0x000EC2BC
        public SquadChipExp()
        {

        }

        // Token: 0x06002433 RID: 9267 RVA: 0x000EE0EC File Offset: 0x000EC2EC
        public long GetID()
        {
            return (long)this.lv;
        }
    }
}
