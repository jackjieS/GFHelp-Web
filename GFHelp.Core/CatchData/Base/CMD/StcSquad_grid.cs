using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_grid : NullCmdStruct
    {
        // Token: 0x06004172 RID: 16754 RVA: 0x001D834C File Offset: 0x001D654C
        public StcSquad_grid()
        {

        }

        // Token: 0x06004173 RID: 16755 RVA: 0x001D837C File Offset: 0x001D657C
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteString(this.grid);
            buffer.WriteInt(this.grid_number);
            buffer.WriteString(this.rank_weight);
            buffer.WriteString(this.code);
        }

        // Token: 0x06004174 RID: 16756 RVA: 0x001D83E4 File Offset: 0x001D65E4
        protected override void _UnPack(ByteBuffer buffer)
        {

            this.id = buffer.ReadInt();
            this.grid = buffer.ReadString();
            this.grid_number = buffer.ReadInt();
            this.rank_weight = buffer.ReadString();
            this.code = buffer.ReadString();
        }

        // Token: 0x04006EA8 RID: 28328
        public int id;

        // Token: 0x04006EA9 RID: 28329
        public string grid;

        // Token: 0x04006EAA RID: 28330
        public int grid_number;

        // Token: 0x04006EAB RID: 28331
        public string rank_weight;

        // Token: 0x04006EAC RID: 28332
        public string code;
    }
}
