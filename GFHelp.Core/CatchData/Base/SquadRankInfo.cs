using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadRankInfo : StcSquad_rank, tBaseData
    {
        public SquadRankInfo()
        {

        }

        // Token: 0x0600243D RID: 9277 RVA: 0x000EE3D4 File Offset: 0x000EC5D4
        public long GetID()
        {
            return (long)this.star_id;
        }
    }
}
