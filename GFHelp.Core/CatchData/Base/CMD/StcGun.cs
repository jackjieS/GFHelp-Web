using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x0200062E RID: 1582
    public class StcGun : NullCmdStruct
    {
        // Token: 0x06003D18 RID: 15640 RVA: 0x00173454 File Offset: 0x00171654
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
            buffer.WriteString(this.character);
            buffer.WriteInt(this.type);
            buffer.WriteInt(this.rank);
            buffer.WriteInt(this.develop_duration);
            buffer.WriteInt(this.baseammo);
            buffer.WriteInt(this.basemre);
            buffer.WriteInt(this.ammo_add_withnumber);
            buffer.WriteInt(this.mre_add_withnumber);
            buffer.WriteInt(this.retiremp);
            buffer.WriteInt(this.retireammo);
            buffer.WriteInt(this.retiremre);
            buffer.WriteInt(this.retirepart);
            buffer.WriteInt(this.ratio_life);
            buffer.WriteInt(this.ratio_pow);
            buffer.WriteInt(this.ratio_rate);
            buffer.WriteInt(this.ratio_speed);
            buffer.WriteInt(this.ratio_hit);
            buffer.WriteInt(this.ratio_dodge);
            buffer.WriteInt(this.ratio_armor);
            buffer.WriteInt(this.armor_piercing);
            buffer.WriteInt(this.crit);
            buffer.WriteInt(this.special);
            buffer.WriteInt(this.eat_ratio);
            buffer.WriteInt(this.ratio_range);
            buffer.WriteInt(this.skill1);
            buffer.WriteInt(this.skill2);
            buffer.WriteInt(this.normal_attack);
            buffer.WriteString(this.passive_skill);
            buffer.WriteString(this.dynamic_passive_skill);
            buffer.WriteInt(this.effect_grid_center);
            buffer.WriteInt(this.effect_guntype);
            buffer.WriteString(this.effect_grid_pos);
            buffer.WriteString(this.effect_grid_effect);
            buffer.WriteInt(this.max_equip);
            buffer.WriteString(this.type_equip1);
            buffer.WriteString(this.type_equip2);
            buffer.WriteString(this.type_equip3);
            buffer.WriteInt(this.type_equip4);
            buffer.WriteInt(this.ai);
            buffer.WriteSbyte(this.is_additional);
            buffer.WriteString(this.launch_time);
            buffer.WriteString(this.obtain_ids);
            buffer.WriteInt(this.rank_display);
            buffer.WriteInt(this.prize_id);
            buffer.WriteString(this.mindupdate_consume);
        }

        // Token: 0x06003D19 RID: 15641 RVA: 0x001736E0 File Offset: 0x001718E0
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
            this.character = buffer.ReadString();
            this.type = buffer.ReadInt();
            this.rank = buffer.ReadInt();
            this.develop_duration = buffer.ReadInt();
            this.baseammo = buffer.ReadInt();
            this.basemre = buffer.ReadInt();
            this.ammo_add_withnumber = buffer.ReadInt();
            this.mre_add_withnumber = buffer.ReadInt();
            this.retiremp = buffer.ReadInt();
            this.retireammo = buffer.ReadInt();
            this.retiremre = buffer.ReadInt();
            this.retirepart = buffer.ReadInt();
            this.ratio_life = buffer.ReadInt();
            this.ratio_pow = buffer.ReadInt();
            this.ratio_rate = buffer.ReadInt();
            this.ratio_speed = buffer.ReadInt();
            this.ratio_hit = buffer.ReadInt();
            this.ratio_dodge = buffer.ReadInt();
            this.ratio_armor = buffer.ReadInt();
            this.armor_piercing = buffer.ReadInt();
            this.crit = buffer.ReadInt();
            this.special = buffer.ReadInt();
            this.eat_ratio = buffer.ReadInt();
            this.ratio_range = buffer.ReadInt();
            this.skill1 = buffer.ReadInt();
            this.skill2 = buffer.ReadInt();
            this.normal_attack = buffer.ReadInt();
            this.passive_skill = buffer.ReadString();
            this.dynamic_passive_skill = buffer.ReadString();
            this.effect_grid_center = buffer.ReadInt();
            this.effect_guntype = buffer.ReadInt();
            this.effect_grid_pos = buffer.ReadString();
            this.effect_grid_effect = buffer.ReadString();
            this.max_equip = buffer.ReadInt();
            this.type_equip1 = buffer.ReadString();
            this.type_equip2 = buffer.ReadString();
            this.type_equip3 = buffer.ReadString();
            this.type_equip4 = buffer.ReadInt();
            this.ai = buffer.ReadInt();
            this.is_additional = buffer.ReadSbyte();
            this.launch_time = buffer.ReadString();
            this.obtain_ids = buffer.ReadString();
            this.rank_display = buffer.ReadInt();
            this.prize_id = buffer.ReadInt();
            this.mindupdate_consume = buffer.ReadString();
        }

        // Token: 0x04003E60 RID: 15968
        public int id;

        // Token: 0x04003E61 RID: 15969
        public string name;

        // Token: 0x04003E62 RID: 15970
        public string en_name;

        // Token: 0x04003E63 RID: 15971
        public string code;

        // Token: 0x04003E64 RID: 15972
        public string introduce;

        // Token: 0x04003E65 RID: 15973
        public string dialogue;

        // Token: 0x04003E66 RID: 15974
        public string extra;

        // Token: 0x04003E67 RID: 15975
        public string en_introduce;

        // Token: 0x04003E68 RID: 15976
        public string character;

        // Token: 0x04003E69 RID: 15977
        public int type;

        // Token: 0x04003E6A RID: 15978
        public int rank;

        // Token: 0x04003E6B RID: 15979
        public int develop_duration;

        // Token: 0x04003E6C RID: 15980
        public int baseammo;

        // Token: 0x04003E6D RID: 15981
        public int basemre;

        // Token: 0x04003E6E RID: 15982
        public int ammo_add_withnumber;

        // Token: 0x04003E6F RID: 15983
        public int mre_add_withnumber;

        // Token: 0x04003E70 RID: 15984
        public int retiremp;

        // Token: 0x04003E71 RID: 15985
        public int retireammo;

        // Token: 0x04003E72 RID: 15986
        public int retiremre;

        // Token: 0x04003E73 RID: 15987
        public int retirepart;

        // Token: 0x04003E74 RID: 15988
        public int ratio_life;

        // Token: 0x04003E75 RID: 15989
        public int ratio_pow;

        // Token: 0x04003E76 RID: 15990
        public int ratio_rate;

        // Token: 0x04003E77 RID: 15991
        public int ratio_speed;

        // Token: 0x04003E78 RID: 15992
        public int ratio_hit;

        // Token: 0x04003E79 RID: 15993
        public int ratio_dodge;

        // Token: 0x04003E7A RID: 15994
        public int ratio_armor;

        // Token: 0x04003E7B RID: 15995
        public int armor_piercing;

        // Token: 0x04003E7C RID: 15996
        public int crit;

        // Token: 0x04003E7D RID: 15997
        public int special;

        // Token: 0x04003E7E RID: 15998
        public int eat_ratio;

        // Token: 0x04003E7F RID: 15999
        public int ratio_range;

        // Token: 0x04003E80 RID: 16000
        public int skill1;

        // Token: 0x04003E81 RID: 16001
        public int skill2;

        // Token: 0x04003E82 RID: 16002
        public int normal_attack;

        // Token: 0x04003E83 RID: 16003
        public string passive_skill;

        // Token: 0x04003E84 RID: 16004
        public string dynamic_passive_skill;

        // Token: 0x04003E85 RID: 16005
        public int effect_grid_center;

        // Token: 0x04003E86 RID: 16006
        public int effect_guntype;

        // Token: 0x04003E87 RID: 16007
        public string effect_grid_pos;

        // Token: 0x04003E88 RID: 16008
        public string effect_grid_effect;

        // Token: 0x04003E89 RID: 16009
        public int max_equip;

        // Token: 0x04003E8A RID: 16010
        public string type_equip1;

        // Token: 0x04003E8B RID: 16011
        public string type_equip2;

        // Token: 0x04003E8C RID: 16012
        public string type_equip3;

        // Token: 0x04003E8D RID: 16013
        public int type_equip4;

        // Token: 0x04003E8E RID: 16014
        public int ai;

        // Token: 0x04003E8F RID: 16015
        public sbyte is_additional;

        // Token: 0x04003E90 RID: 16016
        public string launch_time;

        // Token: 0x04003E91 RID: 16017
        public string obtain_ids;

        // Token: 0x04003E92 RID: 16018
        public int rank_display;

        // Token: 0x04003E93 RID: 16019
        public int prize_id;

        // Token: 0x04003E94 RID: 16020
        public string mindupdate_consume;
    }
}
