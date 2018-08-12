using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadCPUCompletion : StcSquad_cpu_completion, tBaseData
    {// Token: 0x06002434 RID: 9268 RVA: 0x000EE120 File Offset: 0x000EC320
        public SquadCPUCompletion()
        {

        }

        // Token: 0x06002435 RID: 9269 RVA: 0x000EE150 File Offset: 0x000EC350
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x06002436 RID: 9270 RVA: 0x000EE184 File Offset: 0x000EC384
        public int GetAttributeValue(SquadAttriType attr)
        {

            switch (attr)
            {
                case SquadAttriType.assist_damage:
                    return this.assist_damage;
                case SquadAttriType.assist_def_break:
                    return this.assist_def_break;
                case SquadAttriType.assist_hit:
                    return this.assist_hit;
                case SquadAttriType.assist_reload:
                    return this.assist_reload;
                case SquadAttriType.atk_speed:
                    return this.atk_speed;
                case SquadAttriType.damage:
                    return this.damage;
                case SquadAttriType.def:
                    return this.def;
                case SquadAttriType.hit:
                    return this.hit;
                default:
                    return 0;
            }
        }
    }
}
