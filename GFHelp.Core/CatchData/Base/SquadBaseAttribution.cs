using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadBaseAttribution : StcSquad_standard_attribution, tBaseData
    {
        // Token: 0x06002441 RID: 9281 RVA: 0x000EE510 File Offset: 0x000EC710
        public SquadBaseAttribution()
        {

        }

        // Token: 0x06002442 RID: 9282 RVA: 0x000EE540 File Offset: 0x000EC740
        public long GetID()
        {
            return (long)this.id;
        }



    }
}
