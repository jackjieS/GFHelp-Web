using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_cpu : NullCmdStruct
    {// Token: 0x0600416C RID: 16748 RVA: 0x001D8104 File Offset: 0x001D6304
        public StcSquad_cpu()
        {

        }

        // Token: 0x0600416D RID: 16749 RVA: 0x001D8134 File Offset: 0x001D6334
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteInt(this.color);
            buffer.WriteInt(this.grid1);
            buffer.WriteInt(this.grid2);
            buffer.WriteInt(this.grid3);
            buffer.WriteInt(this.grid4);
            buffer.WriteInt(this.grid5);
            buffer.WriteInt(this.cpu_bonus);
        }

        // Token: 0x0600416E RID: 16750 RVA: 0x001D81C0 File Offset: 0x001D63C0
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.id = buffer.ReadInt();
            this.color = buffer.ReadInt();
            this.grid1 = buffer.ReadInt();
            this.grid2 = buffer.ReadInt();
            this.grid3 = buffer.ReadInt();
            this.grid4 = buffer.ReadInt();
            this.grid5 = buffer.ReadInt();
            this.cpu_bonus = buffer.ReadInt();
        }

        // Token: 0x04006E95 RID: 28309
        public int id;

        // Token: 0x04006E96 RID: 28310
        public int color;

        // Token: 0x04006E97 RID: 28311
        public int grid1;

        // Token: 0x04006E98 RID: 28312
        public int grid2;

        // Token: 0x04006E99 RID: 28313
        public int grid3;

        // Token: 0x04006E9A RID: 28314
        public int grid4;

        // Token: 0x04006E9B RID: 28315
        public int grid5;

        // Token: 0x04006E9C RID: 28316
        public int cpu_bonus;

        // Token: 0x04006E9D RID: 28317
    }
}
