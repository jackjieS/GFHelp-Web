using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcSquad : NullCmdStruct
    {
        public StcSquad()
        {
            ;
        }
        protected override void _Pack(ByteBuffer buffer)
        {
            buffer.WriteInt(this.id);
            buffer.WriteString(this.name);
            buffer.WriteString(this.en_name);
            buffer.WriteString(this.code);
            buffer.WriteString(this.introduce);
            buffer.WriteString(this.dialogue);
            buffer.WriteString(this.extra);
            buffer.WriteString(this.en_introduce);
            buffer.WriteInt(this.type);
            buffer.WriteInt(this.assist_type);
            buffer.WriteInt(this.population);
            buffer.WriteInt(this.cpu_id);
            buffer.WriteInt(this.hp);
            buffer.WriteInt(this.assist_damage);
            buffer.WriteInt(this.assist_reload);
            buffer.WriteInt(this.assist_hit);
            buffer.WriteInt(this.assist_def_break);
            buffer.WriteInt(this.damage);
            buffer.WriteInt(this.atk_speed);
            buffer.WriteInt(this.hit);
            buffer.WriteInt(this.cpu_rate);
            buffer.WriteInt(this.crit_rate);
            buffer.WriteInt(this.crit_damage);
            buffer.WriteInt(this.armor_piercing);
            buffer.WriteInt(this.dodge);
            buffer.WriteInt(this.move);
            buffer.WriteInt(this.assist_armor_piercing);
            buffer.WriteString(this.battle_assist_range);
            buffer.WriteInt(this.display_assist_damage_area);
            buffer.WriteInt(this.display_assist_area_coef);
            buffer.WriteInt(this.skill1);
            buffer.WriteInt(this.skill2);
            buffer.WriteInt(this.skill3);
            buffer.WriteInt(this.performance_skill);
            buffer.WriteString(this.passive_skill);
            buffer.WriteInt(this.normal_attack);
            buffer.WriteInt(this.advanced_bonus);
            buffer.WriteInt(this.deploy_round);
            buffer.WriteInt(this.assist_attack_round);
            buffer.WriteInt(this.attack_round);
            buffer.WriteInt(this.baseammo);
            buffer.WriteInt(this.basemre);
            buffer.WriteInt(this.ammo_part);
            buffer.WriteInt(this.mre_part);
            buffer.WriteSbyte(this.is_additional);
            buffer.WriteString(this.launch_time);
            buffer.WriteString(this.obtain_ids);
            buffer.WriteInt(this.piece_item_id);
            buffer.WriteInt(this.destroy_coef);
            buffer.WriteString(this.mission_skill_repair);
            buffer.WriteInt(this.develop_duration);
            buffer.WriteInt(this.basic_rate);
            buffer.WriteString(this.dorm_ai);
        }
        protected override void _UnPack(ByteBuffer buffer)
        {
            this.id = buffer.ReadInt();
            this.name = buffer.ReadString();
            this.en_name = buffer.ReadString();
            this.code = buffer.ReadString();
            this.introduce = buffer.ReadString();
            this.dialogue = buffer.ReadString();
            this.extra = buffer.ReadString();
            this.en_introduce = buffer.ReadString();
            this.type = buffer.ReadInt();
            this.assist_type = buffer.ReadInt();
            this.population = buffer.ReadInt();
            this.cpu_id = buffer.ReadInt();
            this.hp = buffer.ReadInt();
            this.assist_damage = buffer.ReadInt();
            this.assist_reload = buffer.ReadInt();
            this.assist_hit = buffer.ReadInt();
            this.assist_def_break = buffer.ReadInt();
            this.damage = buffer.ReadInt();
            this.atk_speed = buffer.ReadInt();
            this.hit = buffer.ReadInt();
            this.cpu_rate = buffer.ReadInt();
            this.crit_rate = buffer.ReadInt();
            this.crit_damage = buffer.ReadInt();
            this.armor_piercing = buffer.ReadInt();
            this.dodge = buffer.ReadInt();
            this.move = buffer.ReadInt();
            this.assist_armor_piercing = buffer.ReadInt();
            this.battle_assist_range = buffer.ReadString();
            this.display_assist_damage_area = buffer.ReadInt();
            this.display_assist_area_coef = buffer.ReadInt();
            this.skill1 = buffer.ReadInt();
            this.skill2 = buffer.ReadInt();
            this.skill3 = buffer.ReadInt();
            this.performance_skill = buffer.ReadInt();
            this.passive_skill = buffer.ReadString();
            this.normal_attack = buffer.ReadInt();
            this.advanced_bonus = buffer.ReadInt();
            this.deploy_round = buffer.ReadInt();
            this.assist_attack_round = buffer.ReadInt();
            this.attack_round = buffer.ReadInt();
            this.baseammo = buffer.ReadInt();
            this.basemre = buffer.ReadInt();
            this.ammo_part = buffer.ReadInt();
            this.mre_part = buffer.ReadInt();
            this.is_additional = buffer.ReadSbyte();
            this.launch_time = buffer.ReadString();
            this.obtain_ids = buffer.ReadString();
            this.piece_item_id = buffer.ReadInt();
            this.destroy_coef = buffer.ReadInt();
            this.mission_skill_repair = buffer.ReadString();
            this.develop_duration = buffer.ReadInt();
            this.basic_rate = buffer.ReadInt();
            this.dorm_ai = buffer.ReadString();
        }
        // Token: 0x04006E36 RID: 28214
        public int id;

        // Token: 0x04006E37 RID: 28215
        public string name;

        // Token: 0x04006E38 RID: 28216
        public string en_name;

        // Token: 0x04006E39 RID: 28217
        public string code;

        // Token: 0x04006E3A RID: 28218
        public string introduce;

        // Token: 0x04006E3B RID: 28219
        public string dialogue;

        // Token: 0x04006E3C RID: 28220
        public string extra;

        // Token: 0x04006E3D RID: 28221
        public string en_introduce;

        // Token: 0x04006E3E RID: 28222
        public int type;

        // Token: 0x04006E3F RID: 28223
        public int assist_type;

        // Token: 0x04006E40 RID: 28224
        public int population;

        // Token: 0x04006E41 RID: 28225
        public int cpu_id;

        // Token: 0x04006E42 RID: 28226
        public int hp;

        // Token: 0x04006E43 RID: 28227
        public int assist_damage;

        // Token: 0x04006E44 RID: 28228
        public int assist_reload;

        // Token: 0x04006E45 RID: 28229
        public int assist_hit;

        // Token: 0x04006E46 RID: 28230
        public int assist_def_break;

        // Token: 0x04006E47 RID: 28231
        public int damage;

        // Token: 0x04006E48 RID: 28232
        public int atk_speed;

        // Token: 0x04006E49 RID: 28233
        public int hit;

        // Token: 0x04006E4A RID: 28234
        public int cpu_rate;

        // Token: 0x04006E4B RID: 28235
        public int crit_rate;

        // Token: 0x04006E4C RID: 28236
        public int crit_damage;

        // Token: 0x04006E4D RID: 28237
        public int armor_piercing;

        // Token: 0x04006E4E RID: 28238
        public int dodge;

        // Token: 0x04006E4F RID: 28239
        public int move;

        // Token: 0x04006E50 RID: 28240
        public int assist_armor_piercing;

        // Token: 0x04006E51 RID: 28241
        public string battle_assist_range;

        // Token: 0x04006E52 RID: 28242
        public int display_assist_damage_area;

        // Token: 0x04006E53 RID: 28243
        public int display_assist_area_coef;

        // Token: 0x04006E54 RID: 28244
        public int skill1;

        // Token: 0x04006E55 RID: 28245
        public int skill2;

        // Token: 0x04006E56 RID: 28246
        public int skill3;

        // Token: 0x04006E57 RID: 28247
        public int performance_skill;

        // Token: 0x04006E58 RID: 28248
        public string passive_skill;

        // Token: 0x04006E59 RID: 28249
        public int normal_attack;

        // Token: 0x04006E5A RID: 28250
        public int advanced_bonus;

        // Token: 0x04006E5B RID: 28251
        public int deploy_round;

        // Token: 0x04006E5C RID: 28252
        public int assist_attack_round;

        // Token: 0x04006E5D RID: 28253
        public int attack_round;

        // Token: 0x04006E5E RID: 28254
        public int baseammo;

        // Token: 0x04006E5F RID: 28255
        public int basemre;

        // Token: 0x04006E60 RID: 28256
        public int ammo_part;

        // Token: 0x04006E61 RID: 28257
        public int mre_part;

        // Token: 0x04006E62 RID: 28258
        public sbyte is_additional;

        // Token: 0x04006E63 RID: 28259
        public string launch_time;

        // Token: 0x04006E64 RID: 28260
        public string obtain_ids;

        // Token: 0x04006E65 RID: 28261
        public int piece_item_id;

        // Token: 0x04006E66 RID: 28262
        public int destroy_coef;

        // Token: 0x04006E67 RID: 28263
        public string mission_skill_repair;

        // Token: 0x04006E68 RID: 28264
        public int develop_duration;

        // Token: 0x04006E69 RID: 28265
        public int basic_rate;

        // Token: 0x04006E6A RID: 28266
        public string dorm_ai;
    }
}
