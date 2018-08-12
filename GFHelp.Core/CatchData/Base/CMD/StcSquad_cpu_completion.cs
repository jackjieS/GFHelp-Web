using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_cpu_completion : NullCmdStruct
    {// Token: 0x06004187 RID: 16775 RVA: 0x001D943C File Offset: 0x001D763C
        public StcSquad_cpu_completion()
        {
        }

        // Token: 0x06004188 RID: 16776 RVA: 0x001D946C File Offset: 0x001D766C
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

        // Token: 0x06004189 RID: 16777 RVA: 0x001D9528 File Offset: 0x001D7728
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

        // Token: 0x04006F4A RID: 28490
        public int id;

        // Token: 0x04006F4B RID: 28491
        public int group_id;

        // Token: 0x04006F4C RID: 28492
        public int lv;

        // Token: 0x04006F4D RID: 28493
        public int unlock_number;

        // Token: 0x04006F4E RID: 28494
        public int assist_damage;

        // Token: 0x04006F4F RID: 28495
        public int assist_reload;

        // Token: 0x04006F50 RID: 28496
        public int assist_hit;

        // Token: 0x04006F51 RID: 28497
        public int assist_def_break;

        // Token: 0x04006F52 RID: 28498
        public int damage;

        // Token: 0x04006F53 RID: 28499
        public int atk_speed;

        // Token: 0x04006F54 RID: 28500
        public int hit;

        // Token: 0x04006F55 RID: 28501
        public int def;
    }
}
