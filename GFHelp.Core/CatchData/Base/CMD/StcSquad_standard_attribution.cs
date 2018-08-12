using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_standard_attribution : NullCmdStruct
    {
        // Token: 0x0600418D RID: 16781 RVA: 0x001D96CC File Offset: 0x001D78CC
        public StcSquad_standard_attribution()
        {

        }

        // Token: 0x0600418E RID: 16782 RVA: 0x001D96FC File Offset: 0x001D78FC
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteString(this.attribute_type);
            buffer.WriteString(this.name);
            buffer.WriteFloat(this.standard_attribute);
            buffer.WriteFloat(this.cpu_standard_attribute);
            buffer.WriteInt(this.basic_rate);
            buffer.WriteInt(this.cpu_rate);
            buffer.WriteInt(this.role_id);
        }

        // Token: 0x0600418F RID: 16783 RVA: 0x001D9788 File Offset: 0x001D7988
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.id = buffer.ReadInt();
            this.attribute_type = buffer.ReadString();
            this.name = buffer.ReadString();
            this.standard_attribute = buffer.ReadFloat();
            this.cpu_standard_attribute = buffer.ReadFloat();
            this.basic_rate = buffer.ReadInt();
            this.cpu_rate = buffer.ReadInt();
            this.role_id = buffer.ReadInt();
        }

        // Token: 0x04006F60 RID: 28512
        public int id;

        // Token: 0x04006F61 RID: 28513
        public string attribute_type;

        // Token: 0x04006F62 RID: 28514
        public string name;

        // Token: 0x04006F63 RID: 28515
        public float standard_attribute;

        // Token: 0x04006F64 RID: 28516
        public float cpu_standard_attribute;

        // Token: 0x04006F65 RID: 28517
        public int basic_rate;

        // Token: 0x04006F66 RID: 28518
        public int cpu_rate;

        // Token: 0x04006F67 RID: 28519
        public int role_id;
    }
}
