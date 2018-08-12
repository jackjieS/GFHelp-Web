using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadTypeInfo : StcSquad_type, tBaseData
    {   // Token: 0x0600243E RID: 9278 RVA: 0x000EE408 File Offset: 0x000EC608
        public SquadTypeInfo()
        {

        }

        // Token: 0x0600243F RID: 9279 RVA: 0x000EE438 File Offset: 0x000EC638
        public long GetID()
        {
            return (long)this.type_id;
        }
        public float GetAttributeValue(SquadAttriType attr)
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
                case SquadAttriType.hp:
                    return this.hp;
                default:
                    return 0f;
            }
        }
    }
    public enum SquadAttriType
    {
        // Token: 0x04004399 RID: 17305
        assist_damage = 1,
        // Token: 0x0400439A RID: 17306
        assist_def_break,
        // Token: 0x0400439B RID: 17307
        assist_hit,
        // Token: 0x0400439C RID: 17308
        assist_reload,
        // Token: 0x0400439D RID: 17309
        atk_speed,
        // Token: 0x0400439E RID: 17310
        damage,
        // Token: 0x0400439F RID: 17311
        def,
        // Token: 0x040043A0 RID: 17312
        hit,
        // Token: 0x040043A1 RID: 17313
        hp
    }
}
