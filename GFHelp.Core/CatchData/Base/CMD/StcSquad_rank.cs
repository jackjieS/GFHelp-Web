using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_rank : NullCmdStruct
    {
        public StcSquad_rank()
        {

        }
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.star_id);
            buffer.WriteString(this.lv_unlock);
            buffer.WriteInt(this.cost_self_piece);
            buffer.WriteInt(this.cpu_rate);
        }
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.star_id = buffer.ReadInt();
            this.lv_unlock = buffer.ReadString();
            this.cost_self_piece = buffer.ReadInt();
            this.cpu_rate = buffer.ReadInt();
        }
        // Token: 0x04006F59 RID: 28505
        public int star_id;

        // Token: 0x04006F5A RID: 28506
        public string lv_unlock;

        // Token: 0x04006F5B RID: 28507
        public int cost_self_piece;

        // Token: 0x04006F5C RID: 28508
        public int cpu_rate;







































    }
}
