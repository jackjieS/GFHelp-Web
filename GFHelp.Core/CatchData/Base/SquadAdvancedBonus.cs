using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadAdvancedBonus : StcSquad_advanced_bonus, tBaseData
    {
        // Token: 0x0600241B RID: 9243 RVA: 0x000ED9E4 File Offset: 0x000EBBE4
        public SquadAdvancedBonus()
        {

        }

        // Token: 0x17000778 RID: 1912
        // (get) Token: 0x0600241C RID: 9244 RVA: 0x000EDA20 File Offset: 0x000EBC20
        public Dictionary<SquadAttriType, int> dictDisplayAttrByAttrType
        {
            get
            {

                if (this._dictDisplayAttrByAttrType == null)
                {
                    if (GameData.listSquadAdvancedBonus.ContainsKey((long)(this.id - 1)))
                    {
                        SquadAdvancedBonus dataById = GameData.listSquadAdvancedBonus.GetDataById((long)(this.id - 1));
                        this._dictDisplayAttrByAttrType = new Dictionary<SquadAttriType, int>();
                        for (int i = 1; i <= 8; i++)
                        {
                            SquadAttriType key = (SquadAttriType)i;
                            this._dictDisplayAttrByAttrType[key] = this.dictBonusAttrByAttrType[key] - dataById.dictBonusAttrByAttrType[key];
                        }
                    }
                    else
                    {
                        this._dictDisplayAttrByAttrType = this.dictBonusAttrByAttrType;
                    }
                }
                return this._dictDisplayAttrByAttrType;
            }
        }

        // Token: 0x0600241D RID: 9245 RVA: 0x000EDADC File Offset: 0x000EBCDC
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x0600241E RID: 9246 RVA: 0x000EDB10 File Offset: 0x000EBD10
        public override void InitData()
        {
            this.dictBonusAttrByAttrType[SquadAttriType.assist_damage] = this.assist_damage;
            this.dictBonusAttrByAttrType[SquadAttriType.assist_def_break] = this.assist_def_break;
            this.dictBonusAttrByAttrType[SquadAttriType.assist_hit] = this.assist_hit;
            this.dictBonusAttrByAttrType[SquadAttriType.assist_reload] = this.assist_reload;
            this.dictBonusAttrByAttrType[SquadAttriType.atk_speed] = this.atk_speed;
            this.dictBonusAttrByAttrType[SquadAttriType.damage] = this.damage;
            this.dictBonusAttrByAttrType[SquadAttriType.def] = this.def;
            this.dictBonusAttrByAttrType[SquadAttriType.hit] = this.hit;
        }

        // Token: 0x04004459 RID: 17497
        public Dictionary<SquadAttriType, int> dictBonusAttrByAttrType = new Dictionary<SquadAttriType, int>();

        // Token: 0x0400445A RID: 17498
        private Dictionary<SquadAttriType, int> _dictDisplayAttrByAttrType;




    }
}
