using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x0200074F RID: 1871
    public class StcGun : NullCmdStruct
    {
        // Token: 0x06003DE6 RID: 15846 RVA: 0x001E3C10 File Offset: 0x001E1E10
        public StcGun()
        {

        }

        // Token: 0x06003DE7 RID: 15847 RVA: 0x001E3C40 File Offset: 0x001E1E40
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
            buffer.WriteString(this.effect_guntype);
            buffer.WriteString(this.effect_grid_pos);
            buffer.WriteString(this.effect_grid_effect);
            buffer.WriteInt(this.max_equip);
            buffer.WriteString(this.type_equip1);
            buffer.WriteString(this.type_equip2);
            buffer.WriteString(this.type_equip3);
            buffer.WriteString(this.type_equip4);
            buffer.WriteInt(this.ai);
            buffer.WriteSbyte(this.is_additional);
            buffer.WriteString(this.launch_time);
            buffer.WriteString(this.obtain_ids);
            buffer.WriteInt(this.rank_display);
            buffer.WriteInt(this.prize_id);
            buffer.WriteString(this.mindupdate_consume);
            buffer.WriteString(this.explore_tag);
        }

        // Token: 0x06003DE8 RID: 15848 RVA: 0x001E3EF4 File Offset: 0x001E20F4
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
            this.effect_guntype = buffer.ReadString();
            this.effect_grid_pos = buffer.ReadString();
            this.effect_grid_effect = buffer.ReadString();
            this.max_equip = buffer.ReadInt();
            this.type_equip1 = buffer.ReadString();
            this.type_equip2 = buffer.ReadString();
            this.type_equip3 = buffer.ReadString();
            this.type_equip4 = buffer.ReadString();
            this.ai = buffer.ReadInt();
            this.is_additional = buffer.ReadSbyte();
            this.launch_time = buffer.ReadString();
            this.obtain_ids = buffer.ReadString();
            this.rank_display = buffer.ReadInt();
            this.prize_id = buffer.ReadInt();
            this.mindupdate_consume = buffer.ReadString();
            this.explore_tag = buffer.ReadString();
        }

        // Token: 0x04006FCF RID: 28623
        public int id;

        // Token: 0x04006FD0 RID: 28624
        public string name;

        // Token: 0x04006FD1 RID: 28625
        public string en_name;

        // Token: 0x04006FD2 RID: 28626
        public string code;

        // Token: 0x04006FD3 RID: 28627
        public string introduce;

        // Token: 0x04006FD4 RID: 28628
        public string dialogue;

        // Token: 0x04006FD5 RID: 28629
        public string extra;

        // Token: 0x04006FD6 RID: 28630
        public string en_introduce;

        // Token: 0x04006FD7 RID: 28631
        public string character;

        // Token: 0x04006FD8 RID: 28632
        public int type;

        // Token: 0x04006FD9 RID: 28633
        public int rank;

        // Token: 0x04006FDA RID: 28634
        public int develop_duration;

        // Token: 0x04006FDB RID: 28635
        public int baseammo;

        // Token: 0x04006FDC RID: 28636
        public int basemre;

        // Token: 0x04006FDD RID: 28637
        public int ammo_add_withnumber;

        // Token: 0x04006FDE RID: 28638
        public int mre_add_withnumber;

        // Token: 0x04006FDF RID: 28639
        public int retiremp;

        // Token: 0x04006FE0 RID: 28640
        public int retireammo;

        // Token: 0x04006FE1 RID: 28641
        public int retiremre;

        // Token: 0x04006FE2 RID: 28642
        public int retirepart;

        // Token: 0x04006FE3 RID: 28643
        public int ratio_life;

        // Token: 0x04006FE4 RID: 28644
        public int ratio_pow;

        // Token: 0x04006FE5 RID: 28645
        public int ratio_rate;

        // Token: 0x04006FE6 RID: 28646
        public int ratio_speed;

        // Token: 0x04006FE7 RID: 28647
        public int ratio_hit;

        // Token: 0x04006FE8 RID: 28648
        public int ratio_dodge;

        // Token: 0x04006FE9 RID: 28649
        public int ratio_armor;

        // Token: 0x04006FEA RID: 28650
        public int armor_piercing;

        // Token: 0x04006FEB RID: 28651
        public int crit;

        // Token: 0x04006FEC RID: 28652
        public int special;

        // Token: 0x04006FED RID: 28653
        public int eat_ratio;

        // Token: 0x04006FEE RID: 28654
        public int ratio_range;

        // Token: 0x04006FEF RID: 28655
        public int skill1;

        // Token: 0x04006FF0 RID: 28656
        public int skill2;

        // Token: 0x04006FF1 RID: 28657
        public int normal_attack;

        // Token: 0x04006FF2 RID: 28658
        public string passive_skill;

        // Token: 0x04006FF3 RID: 28659
        public string dynamic_passive_skill;

        // Token: 0x04006FF4 RID: 28660
        public int effect_grid_center;

        // Token: 0x04006FF5 RID: 28661
        public string effect_guntype;

        // Token: 0x04006FF6 RID: 28662
        public string effect_grid_pos;

        // Token: 0x04006FF7 RID: 28663
        public string effect_grid_effect;

        // Token: 0x04006FF8 RID: 28664
        public int max_equip;

        // Token: 0x04006FF9 RID: 28665
        public string type_equip1;

        // Token: 0x04006FFA RID: 28666
        public string type_equip2;

        // Token: 0x04006FFB RID: 28667
        public string type_equip3;

        // Token: 0x04006FFC RID: 28668
        public string type_equip4;

        // Token: 0x04006FFD RID: 28669
        public int ai;

        // Token: 0x04006FFE RID: 28670
        public sbyte is_additional;

        // Token: 0x04006FFF RID: 28671
        public string launch_time;

        // Token: 0x04007000 RID: 28672
        public string obtain_ids;

        // Token: 0x04007001 RID: 28673
        public int rank_display;

        // Token: 0x04007002 RID: 28674
        public int prize_id;

        // Token: 0x04007003 RID: 28675
        public string mindupdate_consume;

        // Token: 0x04007004 RID: 28676
        public string explore_tag;

    }
}
