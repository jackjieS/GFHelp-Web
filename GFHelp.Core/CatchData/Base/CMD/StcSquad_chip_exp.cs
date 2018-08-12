using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_chip_exp : NullCmdStruct
    {
        public StcSquad_chip_exp()
        {

        }

        // Token: 0x06004185 RID: 16773 RVA: 0x001D939C File Offset: 0x001D759C
        protected override void _Pack(ByteBuffer buffer)
        {
            buffer.WriteInt(this.lv);
            buffer.WriteInt(this.exp);
            buffer.WriteInt(this.strength_coef);
        }

        // Token: 0x06004186 RID: 16774 RVA: 0x001D93EC File Offset: 0x001D75EC
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.lv = buffer.ReadInt();
            this.exp = buffer.ReadInt();
            this.strength_coef = buffer.ReadInt();
        }

        // Token: 0x04006F44 RID: 28484
        public int lv;

        // Token: 0x04006F45 RID: 28485
        public int exp;

        // Token: 0x04006F46 RID: 28486
        public int strength_coef;
    }
}
