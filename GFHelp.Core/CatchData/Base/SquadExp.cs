using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadExp : StcSquad_exp, tBaseData
    {

        // Token: 0x06002419 RID: 9241 RVA: 0x000ED980 File Offset: 0x000EBB80
        public SquadExp()
        {

        }

        // Token: 0x0600241A RID: 9242 RVA: 0x000ED9B0 File Offset: 0x000EBBB0
        public long GetID()
        {

            return (long)this.lv;
        }





    }
}
