using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_type : NullCmdStruct
    {
        public StcSquad_type()
        {
        }
        protected override void _Pack(ByteBuffer buffer)
        {
            buffer.WriteInt(this.type_id);
            buffer.WriteString(this.name);
            buffer.WriteString(this.en_name);
            buffer.WriteString(this.class_name);
            buffer.WriteString(this.class_en_name);
            buffer.WriteFloat(this.hp);
            buffer.WriteFloat(this.assist_damage);
            buffer.WriteFloat(this.assist_reload);
            buffer.WriteFloat(this.assist_hit);
            buffer.WriteFloat(this.assist_def_break);
            buffer.WriteFloat(this.damage);
            buffer.WriteFloat(this.atk_speed);
            buffer.WriteFloat(this.hit);
            buffer.WriteFloat(this.def);
            buffer.WriteInt(this.fix_type);
            buffer.WriteFloat(this.fix_time);
            buffer.WriteFloat(this.mp_fix);
            buffer.WriteFloat(this.part_fix);
        }
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.type_id = buffer.ReadInt();
            this.name = buffer.ReadString();
            this.en_name = buffer.ReadString();
            this.class_name = buffer.ReadString();
            this.class_en_name = buffer.ReadString();
            this.hp = buffer.ReadFloat();
            this.assist_damage = buffer.ReadFloat();
            this.assist_reload = buffer.ReadFloat();
            this.assist_hit = buffer.ReadFloat();
            this.assist_def_break = buffer.ReadFloat();
            this.damage = buffer.ReadFloat();
            this.atk_speed = buffer.ReadFloat();
            this.hit = buffer.ReadFloat();
            this.def = buffer.ReadFloat();
            this.fix_type = buffer.ReadInt();
            this.fix_time = buffer.ReadFloat();
            this.mp_fix = buffer.ReadFloat();
            this.part_fix = buffer.ReadFloat();
        }

        // Token: 0x04006F6B RID: 28523
        public int type_id;

        // Token: 0x04006F6C RID: 28524
        public string name;

        // Token: 0x04006F6D RID: 28525
        public string en_name;

        // Token: 0x04006F6E RID: 28526
        public string class_name;

        // Token: 0x04006F6F RID: 28527
        public string class_en_name;

        // Token: 0x04006F70 RID: 28528
        public float hp;

        // Token: 0x04006F71 RID: 28529
        public float assist_damage;

        // Token: 0x04006F72 RID: 28530
        public float assist_reload;

        // Token: 0x04006F73 RID: 28531
        public float assist_hit;

        // Token: 0x04006F74 RID: 28532
        public float assist_def_break;

        // Token: 0x04006F75 RID: 28533
        public float damage;

        // Token: 0x04006F76 RID: 28534
        public float atk_speed;

        // Token: 0x04006F77 RID: 28535
        public float hit;

        // Token: 0x04006F78 RID: 28536
        public float def;

        // Token: 0x04006F79 RID: 28537
        public int fix_type;

        // Token: 0x04006F7A RID: 28538
        public float fix_time;

        // Token: 0x04006F7B RID: 28539
        public float mp_fix;

        // Token: 0x04006F7C RID: 28540
        public float part_fix;



    }
}
