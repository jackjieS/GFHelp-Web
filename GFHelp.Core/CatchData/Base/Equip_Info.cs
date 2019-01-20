using GFHelp.Core.CatchData.Base.CMD;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class EquipInfo : StcEquip, tBaseData
    {
        // Token: 0x06001714 RID: 5908 RVA: 0x000A8148 File Offset: 0x000A6348
        public EquipInfo()
        {

        }

        // Token: 0x06001715 RID: 5909 RVA: 0x000A822C File Offset: 0x000A642C
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x17000591 RID: 1425
        // (get) Token: 0x06001716 RID: 5910 RVA: 0x000A8260 File Offset: 0x000A6460
        // (set) Token: 0x06001717 RID: 5911 RVA: 0x000A829C File Offset: 0x000A649C
        public new string name
        {
            get
            {

                return this.name;
            }
            set
            {

                this.name = value;
            }
        }

        // Token: 0x17000592 RID: 1426
        // (get) Token: 0x06001718 RID: 5912 RVA: 0x000A82D0 File Offset: 0x000A64D0
        // (set) Token: 0x06001719 RID: 5913 RVA: 0x000A830C File Offset: 0x000A650C
        public string introduction
        {
            get
            {
                return this.equip_introduction;
            }
            set
            {
                this.equip_introduction = value;
            }
        }

        // Token: 0x17000593 RID: 1427
        // (get) Token: 0x0600171A RID: 5914 RVA: 0x000A8340 File Offset: 0x000A6540
        // (set) Token: 0x0600171B RID: 5915 RVA: 0x000A837C File Offset: 0x000A657C
        public new string description
        {
            get
            {

                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        // Token: 0x0600171C RID: 5916 RVA: 0x000A83B0 File Offset: 0x000A65B0
        public override void InitData()
        {

            this.category = (EquipCategory)base.category;
            this.type = (EquipType)base.type;
            this.rank = (EquipRank)base.rank;
            this.SetRange(this.pow.Split(new char[]
            {
            ','
            }), ref this.rangePow);
            this.SetRange(this.hit.Split(new char[]
            {
            ','
            }), ref this.rangeHit);
            this.SetRange(this.dodge.Split(new char[]
            {
            ','
            }), ref this.rangeDodge);
            this.SetRange(this.speed.Split(new char[]
            {
            ','
            }), ref this.rangeSpeed);
            this.SetRange(this.rate.Split(new char[]
            {
            ','
            }), ref this.rangeRate);
            this.SetRange(this.critical_harm_rate.Split(new char[]
            {
            ','
            }), ref this.rangeCritHarm);
            this.SetRange(this.critical_percent.Split(new char[]
            {
            ','
            }), ref this.rangeCrit);
            this.SetRange(this.armor_piercing.Split(new char[]
            {
            ','
            }), ref this.rangePiercing);
            this.SetRange(this.armor.Split(new char[]
            {
            ','
            }), ref this.rangeArmor);
            this.SetRange(this.shield.Split(new char[]
            {
            ','
            }), ref this.rangeShiled);
            this.SetRange(this.damage_amplify.Split(new char[]
            {
            ','
            }), ref this.rangeDamageAmplify);
            this.SetRange(this.damage_reduction.Split(new char[]
            {
            ','
            }), ref this.rangeDamageReduction);
            this.SetRange(this.night_view_percent.Split(new char[]
            {
            ','
            }), ref this.rangeNightResistance);
            this.SetRange(this.bullet_number_up.Split(new char[]
            {
            ','
            }), ref this.rangeBulletNumberUp);
            if (this.fit_guns != string.Empty)
            {
                string[] array = this.fit_guns.Split(new char[]
                {
                ','
                });
                for (int i = 0; i < array.Length; i++)
                {
                    this.listFitGunInfoId.Add(Convert.ToInt32(array[i]));
                }
            }
        }

        // Token: 0x0600171D RID: 5917 RVA: 0x000A8630 File Offset: 0x000A6830
        private void SetRange(string[] strRange, ref int[] intRange)
        {
            if (strRange.Length == 2)
            {
                intRange[0] = Convert.ToInt32(strRange[0]);
                intRange[1] = Convert.ToInt32(strRange[1]);
            }
        }

        // Token: 0x0400243B RID: 9275
        public new EquipCategory category;

        // Token: 0x0400243C RID: 9276
        public new EquipType type;

        // Token: 0x0400243D RID: 9277
        public new EquipRank rank;

        // Token: 0x0400243E RID: 9278
        public List<int> listFitGunInfoId = new List<int>();

        // Token: 0x0400243F RID: 9279
        public bool isLimit;

        // Token: 0x04002440 RID: 9280
        public bool isTimeLimit;

        // Token: 0x04002441 RID: 9281
        public int[] rangePow = new int[2];

        // Token: 0x04002442 RID: 9282
        public int[] rangeHit = new int[2];

        // Token: 0x04002443 RID: 9283
        public int[] rangeDodge = new int[2];

        // Token: 0x04002444 RID: 9284
        public int[] rangeSpeed = new int[2];

        // Token: 0x04002445 RID: 9285
        public int[] rangeRate = new int[2];

        // Token: 0x04002446 RID: 9286
        public int[] rangeCritHarm = new int[2];

        // Token: 0x04002447 RID: 9287
        public int[] rangeCrit = new int[2];

        // Token: 0x04002448 RID: 9288
        public int[] rangePiercing = new int[2];

        // Token: 0x04002449 RID: 9289
        public int[] rangeArmor = new int[2];

        // Token: 0x0400244A RID: 9290
        public int[] rangeShiled = new int[2];

        // Token: 0x0400244B RID: 9291
        public int[] rangeDamageAmplify = new int[2];

        // Token: 0x0400244C RID: 9292
        public int[] rangeDamageReduction = new int[2];

        // Token: 0x0400244D RID: 9293
        public int[] rangeNightResistance = new int[2];

        // Token: 0x0400244E RID: 9294
        public int[] rangeBulletNumberUp = new int[2];

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
