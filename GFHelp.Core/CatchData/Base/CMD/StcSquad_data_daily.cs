using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_data_daily : NullCmdStruct
    {
        public StcSquad_data_daily()
        {

        }

        // Token: 0x06004176 RID: 16758 RVA: 0x001D847C File Offset: 0x001D667C
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteString(this.title);
            buffer.WriteString(this.content);
            buffer.WriteString(this.type);
            buffer.WriteInt(this.count);
            buffer.WriteInt(this.rank);
            buffer.WriteString(this.prize);
        }

        // Token: 0x06004177 RID: 16759 RVA: 0x001D84FC File Offset: 0x001D66FC
        protected override void _UnPack(ByteBuffer buffer)
        {

            this.id = buffer.ReadInt();
            this.title = buffer.ReadString();
            this.content = buffer.ReadString();
            this.type = buffer.ReadString();
            this.count = buffer.ReadInt();
            this.rank = buffer.ReadInt();
            this.prize = buffer.ReadString();
        }

        // Token: 0x04006EB0 RID: 28336
        public int id;

        // Token: 0x04006EB1 RID: 28337
        public string title;

        // Token: 0x04006EB2 RID: 28338
        public string content;

        // Token: 0x04006EB3 RID: 28339
        public string type;

        // Token: 0x04006EB4 RID: 28340
        public int count;

        // Token: 0x04006EB5 RID: 28341
        public int rank;

        // Token: 0x04006EB6 RID: 28342
        public string prize;
    }
}
