using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_exp : NullCmdStruct
    {
        public StcSquad_exp()
        {

        }

        // Token: 0x06004179 RID: 16761 RVA: 0x001D85AC File Offset: 0x001D67AC
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.lv);
            buffer.WriteInt(this.exp);
            buffer.WriteInt(this.precise);
        }

        // Token: 0x0600417A RID: 16762 RVA: 0x001D85FC File Offset: 0x001D67FC
        protected override void _UnPack(ByteBuffer buffer)
        {

            this.lv = buffer.ReadInt();
            this.exp = buffer.ReadInt();
            this.precise = buffer.ReadInt();
        }

        // Token: 0x04006EBA RID: 28346
        public int lv;

        // Token: 0x04006EBB RID: 28347
        public int exp;

        // Token: 0x04006EBC RID: 28348
        public int precise;













    }
}
