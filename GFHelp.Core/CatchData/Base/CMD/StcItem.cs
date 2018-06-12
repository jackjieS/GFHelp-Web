using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x02000629 RID: 1577
    public class StcItem : NullCmdStruct
    {
        // Token: 0x06003D09 RID: 15625 RVA: 0x0017299C File Offset: 0x00170B9C
        protected override void _Pack(ByteBuffer buffer)
        {
            buffer.WriteInt(this.id);
            buffer.WriteInt(this.type);
            buffer.WriteString(this.arg);
            buffer.WriteString(this.code);
            buffer.WriteString(this.item_name);
            buffer.WriteString(this.introduction);
            buffer.WriteInt(this.rank);
            buffer.WriteInt(this.sort);
        }

        // Token: 0x06003D0A RID: 15626 RVA: 0x00172A0C File Offset: 0x00170C0C
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.id = buffer.ReadInt();
            this.type = buffer.ReadInt();
            this.arg = buffer.ReadString();
            this.code = buffer.ReadString();
            this.item_name = buffer.ReadString();
            this.introduction = buffer.ReadString();
            this.rank = buffer.ReadInt();
            this.sort = buffer.ReadInt();
        }

        // Token: 0x04003DF6 RID: 15862
        public int id;

        // Token: 0x04003DF7 RID: 15863
        public int type;

        // Token: 0x04003DF8 RID: 15864
        public string arg;

        // Token: 0x04003DF9 RID: 15865
        public string code;

        // Token: 0x04003DFA RID: 15866
        public string item_name;

        // Token: 0x04003DFB RID: 15867
        public string introduction;

        // Token: 0x04003DFC RID: 15868
        public int rank;

        // Token: 0x04003DFD RID: 15869
        public int sort;
    }
}
