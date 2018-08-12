using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_advanced_bonus : NullCmdStruct
    {// Token: 0x06004166 RID: 16742 RVA: 0x001D7CDC File Offset: 0x001D5EDC
        public StcSquad_advanced_bonus()
        {

        }

        // Token: 0x06004167 RID: 16743 RVA: 0x001D7D0C File Offset: 0x001D5F0C
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteInt(this.group_id);
            buffer.WriteInt(this.lv);
            buffer.WriteInt(this.unlock_number);
            buffer.WriteInt(this.assist_damage);
            buffer.WriteInt(this.assist_reload);
            buffer.WriteInt(this.assist_hit);
            buffer.WriteInt(this.assist_def_break);
            buffer.WriteInt(this.damage);
            buffer.WriteInt(this.atk_speed);
            buffer.WriteInt(this.hit);
            buffer.WriteInt(this.def);
        }

        // Token: 0x06004168 RID: 16744 RVA: 0x001D7DC8 File Offset: 0x001D5FC8
        protected override void _UnPack(ByteBuffer buffer)
        {

            this.id = buffer.ReadInt();
            this.group_id = buffer.ReadInt();
            this.lv = buffer.ReadInt();
            this.unlock_number = buffer.ReadInt();
            this.assist_damage = buffer.ReadInt();
            this.assist_reload = buffer.ReadInt();
            this.assist_hit = buffer.ReadInt();
            this.assist_def_break = buffer.ReadInt();
            this.damage = buffer.ReadInt();
            this.atk_speed = buffer.ReadInt();
            this.hit = buffer.ReadInt();
            this.def = buffer.ReadInt();
        }

        // Token: 0x04006E6E RID: 28270
        public int id;

        // Token: 0x04006E6F RID: 28271
        public int group_id;

        // Token: 0x04006E70 RID: 28272
        public int lv;

        // Token: 0x04006E71 RID: 28273
        public int unlock_number;

        // Token: 0x04006E72 RID: 28274
        public int assist_damage;

        // Token: 0x04006E73 RID: 28275
        public int assist_reload;

        // Token: 0x04006E74 RID: 28276
        public int assist_hit;

        // Token: 0x04006E75 RID: 28277
        public int assist_def_break;

        // Token: 0x04006E76 RID: 28278
        public int damage;

        // Token: 0x04006E77 RID: 28279
        public int atk_speed;

        // Token: 0x04006E78 RID: 28280
        public int hit;

        // Token: 0x04006E79 RID: 28281
        public int def;
    }
}
