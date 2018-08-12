using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad_chip : NullCmdStruct
    {
        public StcSquad_chip()
        {

        }

        protected override void _Pack(ByteBuffer buffer)
        {
            buffer.WriteInt(this.id);
            buffer.WriteString(this.name);
            buffer.WriteInt(this.rank);
            buffer.WriteString(this.color);
            buffer.WriteString(this.grid);
            buffer.WriteInt(this.is_random);
            buffer.WriteString(this.random_number);
            buffer.WriteInt(this.assist_damage);
            buffer.WriteInt(this.assist_def_break);
            buffer.WriteInt(this.assist_hit);
            buffer.WriteInt(this.assist_reload);
            buffer.WriteInt(this.intensity_ratio);
            buffer.WriteInt(this.grid_number);
            buffer.WriteInt(this.damage);
            buffer.WriteInt(this.atk_speed);
            buffer.WriteInt(this.hit);
            buffer.WriteInt(this.def);
            buffer.WriteString(this.bonus_type);
            buffer.WriteInt(this.type);
            buffer.WriteString(this.fit_squads);
            buffer.WriteInt(this.develop_duration);
        }
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.id = buffer.ReadInt();
            this.name = buffer.ReadString();
            this.rank = buffer.ReadInt();
            this.color = buffer.ReadString();
            this.grid = buffer.ReadString();
            this.is_random = buffer.ReadInt();
            this.random_number = buffer.ReadString();
            this.assist_damage = buffer.ReadInt();
            this.assist_def_break = buffer.ReadInt();
            this.assist_hit = buffer.ReadInt();
            this.assist_reload = buffer.ReadInt();
            this.intensity_ratio = buffer.ReadInt();
            this.grid_number = buffer.ReadInt();
            this.damage = buffer.ReadInt();
            this.atk_speed = buffer.ReadInt();
            this.hit = buffer.ReadInt();
            this.def = buffer.ReadInt();
            this.bonus_type = buffer.ReadString();
            this.type = buffer.ReadInt();
            this.fit_squads = buffer.ReadString();
            this.develop_duration = buffer.ReadInt();
        }
        // Token: 0x04006E7D RID: 28285
        public int id;

        // Token: 0x04006E7E RID: 28286
        public string name;

        // Token: 0x04006E7F RID: 28287
        public int rank;

        // Token: 0x04006E80 RID: 28288
        public string color;

        // Token: 0x04006E81 RID: 28289
        public string grid;

        // Token: 0x04006E82 RID: 28290
        public int is_random;

        // Token: 0x04006E83 RID: 28291
        public string random_number;

        // Token: 0x04006E84 RID: 28292
        public int assist_damage;

        // Token: 0x04006E85 RID: 28293
        public int assist_def_break;

        // Token: 0x04006E86 RID: 28294
        public int assist_hit;

        // Token: 0x04006E87 RID: 28295
        public int assist_reload;

        // Token: 0x04006E88 RID: 28296
        public int intensity_ratio;

        // Token: 0x04006E89 RID: 28297
        public int grid_number;

        // Token: 0x04006E8A RID: 28298
        public int damage;

        // Token: 0x04006E8B RID: 28299
        public int atk_speed;

        // Token: 0x04006E8C RID: 28300
        public int hit;

        // Token: 0x04006E8D RID: 28301
        public int def;

        // Token: 0x04006E8E RID: 28302
        public string bonus_type;

        // Token: 0x04006E8F RID: 28303
        public int type;

        // Token: 0x04006E90 RID: 28304
        public string fit_squads;

        // Token: 0x04006E91 RID: 28305
        public int develop_duration;













    }
}
