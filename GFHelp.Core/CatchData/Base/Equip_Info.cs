using GFHelp.Core.CatchData.Base.CMD;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class EquipInfo : tBaseData
    {
        public EquipInfo(JsonData jsonEquipInfo)
        {
            this.id = Convert.ToInt32((string)jsonEquipInfo["id"]);
            this.code = jsonEquipInfo["code"].String;
            this.name = (string)jsonEquipInfo["name"];
            this.introduction = jsonEquipInfo["equip_introduction"].String;
            this.type = (EquipType)jsonEquipInfo["type"].Int;
            this.category = (EquipCategory)jsonEquipInfo["category"].Int;
            this.SetRange(jsonEquipInfo["pow"].String.Split(new char[]
            {
            ','
            }), ref this.rangePow);
            this.SetRange(jsonEquipInfo["hit"].String.Split(new char[]
            {
            ','
            }), ref this.rangeHit);
            this.SetRange(jsonEquipInfo["dodge"].String.Split(new char[]
            {
            ','
            }), ref this.rangeDodge);
            this.SetRange(jsonEquipInfo["speed"].String.Split(new char[]
            {
            ','
            }), ref this.rangeSpeed);
            this.SetRange(jsonEquipInfo["rate"].String.Split(new char[]
            {
            ','
            }), ref this.rangeRate);
            this.SetRange(jsonEquipInfo["critical_harm_rate"].String.Split(new char[]
            {
            ','
            }), ref this.rangeCritHarm);
            this.SetRange(jsonEquipInfo["critical_percent"].String.Split(new char[]
            {
            ','
            }), ref this.rangeCrit);
            this.SetRange(jsonEquipInfo["armor_piercing"].String.Split(new char[]
            {
            ','
            }), ref this.rangePiercing);
            this.SetRange(jsonEquipInfo["armor"].String.Split(new char[]
            {
            ','
            }), ref this.rangeArmor);
            this.SetRange(jsonEquipInfo["shield"].String.Split(new char[]
            {
            ','
            }), ref this.rangeShiled);
            this.SetRange(jsonEquipInfo["damage_amplify"].String.Split(new char[]
            {
            ','
            }), ref this.rangeDamageAmplify);
            this.SetRange(jsonEquipInfo["damage_reduction"].String.Split(new char[]
            {
            ','
            }), ref this.rangeDamageReduction);
            this.SetRange(jsonEquipInfo["night_view_percent"].String.Split(new char[]
            {
            ','
            }), ref this.rangeNightResistance);
            this.SetRange(jsonEquipInfo["bullet_number_up"].String.Split(new char[]
            {
            ','
            }), ref this.rangeBulletNumberUp);
            this.rank = (EquipRank)jsonEquipInfo["rank"].Int;
            this.description = jsonEquipInfo["description"].String;
            this.developDuration = jsonEquipInfo["develop_duration"].Int;
            this.retireMp = jsonEquipInfo["retire_mp"].Int;
            this.retireAmmo = jsonEquipInfo["retire_ammo"].Int;
            this.retireMre = jsonEquipInfo["retire_mre"].Int;
            this.retirePart = jsonEquipInfo["retire_part"].Int;
            this.skillLevelUp = jsonEquipInfo["skill_level_up"].Int;
            this.skill = jsonEquipInfo["skill"].Int;
            this.powerupMp = float.Parse(jsonEquipInfo["powerup_mp"].String);
            this.powerupAmmo = float.Parse(jsonEquipInfo["powerup_ammo"].String);
            this.powerupMre = float.Parse(jsonEquipInfo["powerup_mre"].String);
            this.powerupPart = float.Parse(jsonEquipInfo["powerup_part"].String);
            this.exclusiveRate = float.Parse(jsonEquipInfo["exclusive_rate"].String);
            this.strBounsType = jsonEquipInfo["bonus_type"].String;
            string @string = jsonEquipInfo["fit_guns"].String;
            if (@string != string.Empty)
            {
                string[] array = @string.Split(new char[]
                {
                ','
                });
                for (int i = 0; i < array.Length; i++)
                {
                    this.listFitGunInfoId.Add(Convert.ToInt32(array[i]));
                }
            }
        }

        public string name
        {
            get
            {
                return this.nameID;
            }
            set
            {
                this.nameID = value;
            }
        }
        private void SetRange(string[] strRange, ref int[] intRange)
        {
            if (strRange.Length == 2)
            {
                intRange[0] = Convert.ToInt32(strRange[0]);
                intRange[1] = Convert.ToInt32(strRange[1]);
            }
        }

        // Token: 0x040019D5 RID: 6613
        public int id;

        // Token: 0x040019D6 RID: 6614
        public string code;

        // Token: 0x040019D7 RID: 6615
        private string nameID;

        // Token: 0x040019D8 RID: 6616
        private string introductionId;

        // Token: 0x040019D9 RID: 6617
        public EquipCategory category;

        // Token: 0x040019DA RID: 6618
        public EquipType type;

        // Token: 0x040019DB RID: 6619
        public EquipRank rank;

        // Token: 0x040019DC RID: 6620
        private string descriptionId;

        // Token: 0x040019DD RID: 6621
        public int retireMp;

        // Token: 0x040019DE RID: 6622
        public int retireAmmo;

        // Token: 0x040019DF RID: 6623
        public int retireMre;

        // Token: 0x040019E0 RID: 6624
        public int retirePart;

        // Token: 0x040019E1 RID: 6625
        public int developDuration;

        // Token: 0x040019E2 RID: 6626
        public int skillLevelUp;

        // Token: 0x040019E3 RID: 6627
        public List<int> listFitGunInfoId = new List<int>();

        // Token: 0x040019E4 RID: 6628
        public bool isLimit;

        // Token: 0x040019E5 RID: 6629
        public bool isTimeLimit;

        // Token: 0x040019E6 RID: 6630
        public int skill;

        // Token: 0x040019E7 RID: 6631
        public float powerupMp;

        // Token: 0x040019E8 RID: 6632
        public float powerupAmmo;

        // Token: 0x040019E9 RID: 6633
        public float powerupMre;

        // Token: 0x040019EA RID: 6634
        public float powerupPart;

        // Token: 0x040019EB RID: 6635
        public float exclusiveRate;

        // Token: 0x040019EC RID: 6636
        public string strBounsType;

        // Token: 0x040019ED RID: 6637
        public int[] rangePow = new int[2];

        // Token: 0x040019EE RID: 6638
        public int[] rangeHit = new int[2];

        // Token: 0x040019EF RID: 6639
        public int[] rangeDodge = new int[2];

        // Token: 0x040019F0 RID: 6640
        public int[] rangeSpeed = new int[2];

        // Token: 0x040019F1 RID: 6641
        public int[] rangeRate = new int[2];

        // Token: 0x040019F2 RID: 6642
        public int[] rangeCritHarm = new int[2];

        // Token: 0x040019F3 RID: 6643
        public int[] rangeCrit = new int[2];

        // Token: 0x040019F4 RID: 6644
        public int[] rangePiercing = new int[2];

        // Token: 0x040019F5 RID: 6645
        public int[] rangeArmor = new int[2];

        // Token: 0x040019F6 RID: 6646
        public int[] rangeShiled = new int[2];

        // Token: 0x040019F7 RID: 6647
        public int[] rangeDamageAmplify = new int[2];

        // Token: 0x040019F8 RID: 6648
        public int[] rangeDamageReduction = new int[2];

        // Token: 0x040019F9 RID: 6649
        public int[] rangeNightResistance = new int[2];

        // Token: 0x040019FA RID: 6650
        public int[] rangeBulletNumberUp = new int[2];

        public long GetID()
        {
            return (long)this.id;
        }
        public string introduction
        {
            get
            {
                return this.introductionId;
                //return PLTable.Instance.GetTableLang(this.introductionId);
            }
            set
            {
                this.introductionId = value;
            }
        }
        public string description
        {
            get
            {
                return this.descriptionId;
            }
            set
            {
                this.descriptionId = value;
            }
        }












    }



    public enum EquipType
    {
        // Token: 0x04001848 RID: 6216
        none,
        // Token: 0x04001849 RID: 6217
        LightSight,
        // Token: 0x0400184A RID: 6218
        QuanXiSight,
        // Token: 0x0400184B RID: 6219
        ACOGSight,
        // Token: 0x0400184C RID: 6220
        NightSight,
        // Token: 0x0400184D RID: 6221
        Silencer = 13,
        // Token: 0x0400184E RID: 6222
        ChuanJiaBullet = 5,
        // Token: 0x0400184F RID: 6223
        StateBullet,
        // Token: 0x04001850 RID: 6224
        ShotBullet,
        // Token: 0x04001851 RID: 6225
        ManningBullet,
        // Token: 0x04001852 RID: 6226
        Chip,
        // Token: 0x04001853 RID: 6227
        EXOSkeleton,
        // Token: 0x04001854 RID: 6228
        Armoured,
        // Token: 0x04001855 RID: 6229
        Medal,
        // Token: 0x04001856 RID: 6230
        BulletBox = 14,
        // Token: 0x04001857 RID: 6231
        Cloke,
        // Token: 0x04001858 RID: 6232
        SpPart,
        // Token: 0x04001859 RID: 6233
        SpClip
    }
    public enum EquipCategory
    {
        // Token: 0x04001843 RID: 6211
        none,
        // Token: 0x04001844 RID: 6212
        Part,
        // Token: 0x04001845 RID: 6213
        Clip,
        // Token: 0x04001846 RID: 6214
        BodyEquipment
    }
    public enum EquipRank
    {
        // Token: 0x04001950 RID: 6480
        All,
        // Token: 0x04001951 RID: 6481
        White = 2,
        // Token: 0x04001952 RID: 6482
        Blue,
        // Token: 0x04001953 RID: 6483
        Green,
        // Token: 0x04001954 RID: 6484
        Gold,
        // Token: 0x04001955 RID: 6485
        Fairy
    }
}
