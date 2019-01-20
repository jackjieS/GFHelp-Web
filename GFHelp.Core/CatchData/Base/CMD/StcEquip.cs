using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcEquip : NullCmdStruct
    {
        // Token: 0x06003E46 RID: 15942 RVA: 0x001E8568 File Offset: 0x001E6768
        public StcEquip()
        {

        }

        // Token: 0x06003E47 RID: 15943 RVA: 0x001E8598 File Offset: 0x001E6798
        protected override void _Pack(ByteBuffer buffer)
        {

            buffer.WriteInt(this.id);
            buffer.WriteString(this.name);
            buffer.WriteString(this.description);
            buffer.WriteInt(this.rank);
            buffer.WriteInt(this.category);
            buffer.WriteInt(this.type);
            buffer.WriteString(this.pow);
            buffer.WriteString(this.hit);
            buffer.WriteString(this.dodge);
            buffer.WriteString(this.speed);
            buffer.WriteString(this.rate);
            buffer.WriteString(this.critical_harm_rate);
            buffer.WriteString(this.critical_percent);
            buffer.WriteString(this.armor_piercing);
            buffer.WriteString(this.armor);
            buffer.WriteString(this.shield);
            buffer.WriteString(this.damage_amplify);
            buffer.WriteString(this.damage_reduction);
            buffer.WriteString(this.night_view_percent);
            buffer.WriteString(this.bullet_number_up);
            buffer.WriteInt(this.skill_effect_per);
            buffer.WriteInt(this.skill_effect);
            buffer.WriteInt(this.slow_down_percent);
            buffer.WriteInt(this.slow_down_rate);
            buffer.WriteInt(this.slow_down_time);
            buffer.WriteInt(this.dot_percent);
            buffer.WriteInt(this.dot_damage);
            buffer.WriteInt(this.dot_time);
            buffer.WriteInt(this.retire_mp);
            buffer.WriteInt(this.retire_ammo);
            buffer.WriteInt(this.retire_mre);
            buffer.WriteInt(this.retire_part);
            buffer.WriteString(this.code);
            buffer.WriteInt(this.develop_duration);
            buffer.WriteString(this.company);
            buffer.WriteInt(this.skill_level_up);
            buffer.WriteString(this.fit_guns);
            buffer.WriteString(this.equip_introduction);
            buffer.WriteFloat(this.powerup_mp);
            buffer.WriteFloat(this.powerup_ammo);
            buffer.WriteFloat(this.powerup_mre);
            buffer.WriteFloat(this.powerup_part);
            buffer.WriteFloat(this.exclusive_rate);
            buffer.WriteString(this.bonus_type);
            buffer.WriteInt(this.skill);
            buffer.WriteInt(this.passive_skill);
            buffer.WriteInt(this.max_level);
        }

        // Token: 0x06003E48 RID: 15944 RVA: 0x001E87F8 File Offset: 0x001E69F8
        protected override void _UnPack(ByteBuffer buffer)
        {

            this.id = buffer.ReadInt();
            this.name = buffer.ReadString();
            this.description = buffer.ReadString();
            this.rank = buffer.ReadInt();
            this.category = buffer.ReadInt();
            this.type = buffer.ReadInt();
            this.pow = buffer.ReadString();
            this.hit = buffer.ReadString();
            this.dodge = buffer.ReadString();
            this.speed = buffer.ReadString();
            this.rate = buffer.ReadString();
            this.critical_harm_rate = buffer.ReadString();
            this.critical_percent = buffer.ReadString();
            this.armor_piercing = buffer.ReadString();
            this.armor = buffer.ReadString();
            this.shield = buffer.ReadString();
            this.damage_amplify = buffer.ReadString();
            this.damage_reduction = buffer.ReadString();
            this.night_view_percent = buffer.ReadString();
            this.bullet_number_up = buffer.ReadString();
            this.skill_effect_per = buffer.ReadInt();
            this.skill_effect = buffer.ReadInt();
            this.slow_down_percent = buffer.ReadInt();
            this.slow_down_rate = buffer.ReadInt();
            this.slow_down_time = buffer.ReadInt();
            this.dot_percent = buffer.ReadInt();
            this.dot_damage = buffer.ReadInt();
            this.dot_time = buffer.ReadInt();
            this.retire_mp = buffer.ReadInt();
            this.retire_ammo = buffer.ReadInt();
            this.retire_mre = buffer.ReadInt();
            this.retire_part = buffer.ReadInt();
            this.code = buffer.ReadString();
            this.develop_duration = buffer.ReadInt();
            this.company = buffer.ReadString();
            this.skill_level_up = buffer.ReadInt();
            this.fit_guns = buffer.ReadString();
            this.equip_introduction = buffer.ReadString();
            this.powerup_mp = buffer.ReadFloat();
            this.powerup_ammo = buffer.ReadFloat();
            this.powerup_mre = buffer.ReadFloat();
            this.powerup_part = buffer.ReadFloat();
            this.exclusive_rate = buffer.ReadFloat();
            this.bonus_type = buffer.ReadString();
            this.skill = buffer.ReadInt();
            this.passive_skill = buffer.ReadInt();
            this.max_level = buffer.ReadInt();
        }

        // Token: 0x04007288 RID: 29320
        public int id;

        // Token: 0x04007289 RID: 29321
        public string name;

        // Token: 0x0400728A RID: 29322
        public string description;

        // Token: 0x0400728B RID: 29323
        public int rank;

        // Token: 0x0400728C RID: 29324
        public int category;

        // Token: 0x0400728D RID: 29325
        public int type;

        // Token: 0x0400728E RID: 29326
        public string pow;

        // Token: 0x0400728F RID: 29327
        public string hit;

        // Token: 0x04007290 RID: 29328
        public string dodge;

        // Token: 0x04007291 RID: 29329
        public string speed;

        // Token: 0x04007292 RID: 29330
        public string rate;

        // Token: 0x04007293 RID: 29331
        public string critical_harm_rate;

        // Token: 0x04007294 RID: 29332
        public string critical_percent;

        // Token: 0x04007295 RID: 29333
        public string armor_piercing;

        // Token: 0x04007296 RID: 29334
        public string armor;

        // Token: 0x04007297 RID: 29335
        public string shield;

        // Token: 0x04007298 RID: 29336
        public string damage_amplify;

        // Token: 0x04007299 RID: 29337
        public string damage_reduction;

        // Token: 0x0400729A RID: 29338
        public string night_view_percent;

        // Token: 0x0400729B RID: 29339
        public string bullet_number_up;

        // Token: 0x0400729C RID: 29340
        public int skill_effect_per;

        // Token: 0x0400729D RID: 29341
        public int skill_effect;

        // Token: 0x0400729E RID: 29342
        public int slow_down_percent;

        // Token: 0x0400729F RID: 29343
        public int slow_down_rate;

        // Token: 0x040072A0 RID: 29344
        public int slow_down_time;

        // Token: 0x040072A1 RID: 29345
        public int dot_percent;

        // Token: 0x040072A2 RID: 29346
        public int dot_damage;

        // Token: 0x040072A3 RID: 29347
        public int dot_time;

        // Token: 0x040072A4 RID: 29348
        public int retire_mp;

        // Token: 0x040072A5 RID: 29349
        public int retire_ammo;

        // Token: 0x040072A6 RID: 29350
        public int retire_mre;

        // Token: 0x040072A7 RID: 29351
        public int retire_part;

        // Token: 0x040072A8 RID: 29352
        public string code;

        // Token: 0x040072A9 RID: 29353
        public int develop_duration;

        // Token: 0x040072AA RID: 29354
        public string company;

        // Token: 0x040072AB RID: 29355
        public int skill_level_up;

        // Token: 0x040072AC RID: 29356
        public string fit_guns;

        // Token: 0x040072AD RID: 29357
        public string equip_introduction;

        // Token: 0x040072AE RID: 29358
        public float powerup_mp;

        // Token: 0x040072AF RID: 29359
        public float powerup_ammo;

        // Token: 0x040072B0 RID: 29360
        public float powerup_mre;

        // Token: 0x040072B1 RID: 29361
        public float powerup_part;

        // Token: 0x040072B2 RID: 29362
        public float exclusive_rate;

        // Token: 0x040072B3 RID: 29363
        public string bonus_type;

        // Token: 0x040072B4 RID: 29364
        public int skill;

        // Token: 0x040072B5 RID: 29365
        public int passive_skill;

        // Token: 0x040072B6 RID: 29366
        public int max_level;


    }
}
