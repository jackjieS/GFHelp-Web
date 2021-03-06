﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x02000750 RID: 1872
    public class StcSquad : NullCmdStruct
    {
        // Token: 0x06003DE9 RID: 15849 RVA: 0x001E41A8 File Offset: 0x001E23A8
        public StcSquad()
        {

        }

        // Token: 0x06003DEA RID: 15850 RVA: 0x001E41D8 File Offset: 0x001E23D8
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
            buffer.WriteInt(this.basic_rate);
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
            buffer.WriteString(this.dynamic_passive_skill);
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
            buffer.WriteString(this.dorm_ai);
            buffer.WriteInt(this.normal_attack_description);
            buffer.WriteInt(this.attack_range);
            buffer.WriteInt(this.night_vision);
        }

        // Token: 0x06003DEB RID: 15851 RVA: 0x001E44B0 File Offset: 0x001E26B0
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
            this.basic_rate = buffer.ReadInt();
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
            this.dynamic_passive_skill = buffer.ReadString();
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
            this.dorm_ai = buffer.ReadString();
            this.normal_attack_description = buffer.ReadInt();
            this.attack_range = buffer.ReadInt();
            this.night_vision = buffer.ReadInt();
        }

        // Token: 0x04007008 RID: 28680
        public int id;

        // Token: 0x04007009 RID: 28681
        public string name;

        // Token: 0x0400700A RID: 28682
        public string en_name;

        // Token: 0x0400700B RID: 28683
        public string code;

        // Token: 0x0400700C RID: 28684
        public string introduce;

        // Token: 0x0400700D RID: 28685
        public string dialogue;

        // Token: 0x0400700E RID: 28686
        public string extra;

        // Token: 0x0400700F RID: 28687
        public string en_introduce;

        // Token: 0x04007010 RID: 28688
        public int type;

        // Token: 0x04007011 RID: 28689
        public int assist_type;

        // Token: 0x04007012 RID: 28690
        public int population;

        // Token: 0x04007013 RID: 28691
        public int cpu_id;

        // Token: 0x04007014 RID: 28692
        public int hp;

        // Token: 0x04007015 RID: 28693
        public int assist_damage;

        // Token: 0x04007016 RID: 28694
        public int assist_reload;

        // Token: 0x04007017 RID: 28695
        public int assist_hit;

        // Token: 0x04007018 RID: 28696
        public int assist_def_break;

        // Token: 0x04007019 RID: 28697
        public int damage;

        // Token: 0x0400701A RID: 28698
        public int atk_speed;

        // Token: 0x0400701B RID: 28699
        public int hit;

        // Token: 0x0400701C RID: 28700
        public int basic_rate;

        // Token: 0x0400701D RID: 28701
        public int cpu_rate;

        // Token: 0x0400701E RID: 28702
        public int crit_rate;

        // Token: 0x0400701F RID: 28703
        public int crit_damage;

        // Token: 0x04007020 RID: 28704
        public int armor_piercing;

        // Token: 0x04007021 RID: 28705
        public int dodge;

        // Token: 0x04007022 RID: 28706
        public int move;

        // Token: 0x04007023 RID: 28707
        public int assist_armor_piercing;

        // Token: 0x04007024 RID: 28708
        public string battle_assist_range;

        // Token: 0x04007025 RID: 28709
        public int display_assist_damage_area;

        // Token: 0x04007026 RID: 28710
        public int display_assist_area_coef;

        // Token: 0x04007027 RID: 28711
        public int skill1;

        // Token: 0x04007028 RID: 28712
        public int skill2;

        // Token: 0x04007029 RID: 28713
        public int skill3;

        // Token: 0x0400702A RID: 28714
        public int performance_skill;

        // Token: 0x0400702B RID: 28715
        public string passive_skill;

        // Token: 0x0400702C RID: 28716
        public string dynamic_passive_skill;

        // Token: 0x0400702D RID: 28717
        public int normal_attack;

        // Token: 0x0400702E RID: 28718
        public int advanced_bonus;

        // Token: 0x0400702F RID: 28719
        public int deploy_round;

        // Token: 0x04007030 RID: 28720
        public int assist_attack_round;

        // Token: 0x04007031 RID: 28721
        public int attack_round;

        // Token: 0x04007032 RID: 28722
        public int baseammo;

        // Token: 0x04007033 RID: 28723
        public int basemre;

        // Token: 0x04007034 RID: 28724
        public int ammo_part;

        // Token: 0x04007035 RID: 28725
        public int mre_part;

        // Token: 0x04007036 RID: 28726
        public sbyte is_additional;

        // Token: 0x04007037 RID: 28727
        public string launch_time;

        // Token: 0x04007038 RID: 28728
        public string obtain_ids;

        // Token: 0x04007039 RID: 28729
        public int piece_item_id;

        // Token: 0x0400703A RID: 28730
        public int destroy_coef;

        // Token: 0x0400703B RID: 28731
        public string mission_skill_repair;

        // Token: 0x0400703C RID: 28732
        public int develop_duration;

        // Token: 0x0400703D RID: 28733
        public string dorm_ai;

        // Token: 0x0400703E RID: 28734
        public int normal_attack_description;

        // Token: 0x0400703F RID: 28735
        public int attack_range;

        // Token: 0x04007040 RID: 28736
        public int night_vision;


    }
}
