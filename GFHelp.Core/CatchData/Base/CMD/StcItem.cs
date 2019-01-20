using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x02000629 RID: 1577
    public class StcItem : NullCmdStruct
    {
        // Token: 0x06003DD7 RID: 15831 RVA: 0x001E2ED0 File Offset: 0x001E10D0
        public StcItem()
        {

        }

        // Token: 0x06003DD8 RID: 15832 RVA: 0x001E2F00 File Offset: 0x001E1100
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
            buffer.WriteString(this.initial_num);
            buffer.WriteString(this.daily_limit);
            buffer.WriteInt(this.upper_limit);
        }

        // Token: 0x06003DD9 RID: 15833 RVA: 0x001E2FB0 File Offset: 0x001E11B0
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
            this.initial_num = buffer.ReadString();
            this.daily_limit = buffer.ReadString();
            this.upper_limit = buffer.ReadInt();
        }

        // Token: 0x04006F4F RID: 28495
        public int id;

        // Token: 0x04006F50 RID: 28496
        public int type;

        // Token: 0x04006F51 RID: 28497
        public string arg;

        // Token: 0x04006F52 RID: 28498
        public string code;

        // Token: 0x04006F53 RID: 28499
        public string item_name;

        // Token: 0x04006F54 RID: 28500
        public string introduction;

        // Token: 0x04006F55 RID: 28501
        public int rank;

        // Token: 0x04006F56 RID: 28502
        public int sort;

        // Token: 0x04006F57 RID: 28503
        public string initial_num;

        // Token: 0x04006F58 RID: 28504
        public string daily_limit;

        // Token: 0x04006F59 RID: 28505
        public int upper_limit;

    }
}
