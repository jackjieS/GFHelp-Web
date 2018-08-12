using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_color : NullCmdStruct
    {// Token: 0x0600416F RID: 16751 RVA: 0x001D824C File Offset: 0x001D644C
        public StcSquad_color()
        {

        }

        // Token: 0x06004170 RID: 16752 RVA: 0x001D827C File Offset: 0x001D647C
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteString(this.rgb);
            buffer.WriteString(this.fliter_text);
            buffer.WriteString(this.fliter_pic);
            buffer.WriteString(this.rank_weight);
        }

        // Token: 0x06004171 RID: 16753 RVA: 0x001D82E4 File Offset: 0x001D64E4
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.id = buffer.ReadInt();
            this.rgb = buffer.ReadString();
            this.fliter_text = buffer.ReadString();
            this.fliter_pic = buffer.ReadString();
            this.rank_weight = buffer.ReadString();
        }

        // Token: 0x04006EA0 RID: 28320
        public int id;

        // Token: 0x04006EA1 RID: 28321
        public string rgb;

        // Token: 0x04006EA2 RID: 28322
        public string fliter_text;

        // Token: 0x04006EA3 RID: 28323
        public string fliter_pic;

        // Token: 0x04006EA4 RID: 28324
        public string rank_weight;
    }
}
