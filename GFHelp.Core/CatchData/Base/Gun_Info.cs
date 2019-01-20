using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.MulitePlayerData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class GunInfo : StcGun, IComparer<GunInfo>, tBaseData
    {
        // Token: 0x06001AEE RID: 6894 RVA: 0x000CCF28 File Offset: 0x000CB128
        public GunInfo()
        {

        }

        // Token: 0x06001AEF RID: 6895 RVA: 0x000CCFC8 File Offset: 0x000CB1C8
        public override void InitData()
        {

            if (this.rank_display == 0)
            {
                this.rank_display = this.rank;
            }
            this.type = (GunType)base.type;
            if (this.mindupdate_consume.Contains(";"))
            {
                string[] array = this.mindupdate_consume.Split(new char[]
                {
                ';'
                });
                if (array.Length == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        string[] array2 = array[i].Split(new char[]
                        {
                        ','
                        });
                    }
                    this.mindupdateCostItems = null;
                }
            }
            else
            {
                string[] array4 = this.mindupdate_consume.Split(new char[]
                {
                ','
                });
                if (array4.Length == 3)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        string[] array5 = array4[k].Split(new char[]
                        {
                        ':'
                        });
                        this.mindupdateCostItems[k, 0] = Convert.ToInt32(array5[0]);
                        this.mindupdateCostItems[k, 1] = Convert.ToInt32(array5[1]);
                    }
                }
            }
            this.InitSlots(this.type_equip1, 1);
            this.InitSlots(this.type_equip2, 2);
            this.InitSlots(this.type_equip3, 3);
            int item = this.normal_attack;
            this.GetMainSkills().Add(item);
            item = this.skill1;
            this.GetMainSkills().Add(item);
            item = this.skill2;
            this.GetMainSkills().Add(item);
            if (!string.IsNullOrEmpty(this.passive_skill))
            {
                string[] array6 = this.passive_skill.Split(new char[]
                {
                ','
                });
                for (int l = 0; l < array6.Length; l++)
                {
                    int item2 = 0;
                    if (int.TryParse(array6[l], out item2))
                    {
                        this.GetPassiveSkills(0).Add(item2);
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.dynamic_passive_skill))
            {
                if (!string.IsNullOrEmpty(this.dynamic_passive_skill))
                {
                    string[] array7 = this.dynamic_passive_skill.Split(new char[]
                    {
                    ','
                    });
                    int m = 0;
                    int num = array7.Length;
                    while (m < num)
                    {
                        if (string.IsNullOrEmpty(array7[m]))
                        {
                            break;
                        }
                        this.GetDynamicPassiveSkill(0).Add(Convert.ToInt32(array7[m]));
                        m++;
                    }
                }
            }
            this.aiId = this.ai;
            if (this.effect_grid_pos != string.Empty)
            {
                string[] array8 = this.effect_guntype.Split(new char[]
                {
                ','
                });
                this.listEffectGridGunType = new List<GunType>();
                for (int n = 0; n < array8.Length; n++)
                {
                    int num2;
                    if (int.TryParse(array8[n], out num2))
                    {
                        if (num2 == 0)
                        {
                            this.listEffectGridGunType.Clear();
                            this.listEffectGridGunType.Add(GunType.all);
                            break;
                        }
                        this.listEffectGridGunType.Add((GunType)num2);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("gun 影响格解析失败, id: {0}, effect_guntype: {1}", this.id, this.effect_guntype));
                    }
                }
                string[] array9 = this.effect_grid_pos.Split(new char[]
                {
                ','
                });
                int num3 = 0;
                int num4 = array9.Length;
                string[] array10 = this.effect_grid_effect.Split(new char[]
                {
                ';'
                });
                int num5 = 0;
                int num6 = array10.Length;
                while (num5 < num6)
                {
                    string text = array10[num5];
                    if (!string.IsNullOrEmpty(text))
                    {
                        string[] array11 = text.Split(new char[]
                        {
                        ','
                        });
                    }
                    num5++;
                }
            }

        }

        // Token: 0x06001AF0 RID: 6896 RVA: 0x000CD4F0 File Offset: 0x000CB6F0
        private void InitSlots(string typeEquip, int j)
        {

        }

        // Token: 0x170006B0 RID: 1712
        // (get) Token: 0x06001AF1 RID: 6897 RVA: 0x000CD5A0 File Offset: 0x000CB7A0
        public string uiId
        {
            get
            {
                if (this.isAdditional)
                {
                    return (this.id - Data.GetInt("offset_gun_id")).ToString();
                }
                if (this.isMindupdate)
                {
                    return (this.id - Data.GetInt("gun_mindupdate_indexs")).ToString();
                }
                return this.id.ToString();
            }
        }

        // Token: 0x170006B1 RID: 1713
        // (get) Token: 0x06001AF2 RID: 6898 RVA: 0x000CD634 File Offset: 0x000CB834
        // (set) Token: 0x06001AF3 RID: 6899 RVA: 0x000CD670 File Offset: 0x000CB870
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

        // Token: 0x170006B2 RID: 1714
        // (get) Token: 0x06001AF4 RID: 6900 RVA: 0x000CD6A4 File Offset: 0x000CB8A4
        public List<EquipInfo>[] arrListFitEquips
        {
            get
            {

                return this._arrListFitEquips;
            }
        }

        // Token: 0x170006B3 RID: 1715
        // (get) Token: 0x06001AF5 RID: 6901 RVA: 0x000CD73C File Offset: 0x000CB93C
        // (set) Token: 0x06001AF6 RID: 6902 RVA: 0x000CD7C8 File Offset: 0x000CB9C8
        public bool IsUnlockWithLive2DSkin
        {
            get
            {
                return false;

            }
            set
            {

            }
        }

        // Token: 0x170006B4 RID: 1716
        // (get) Token: 0x06001AF7 RID: 6903 RVA: 0x000CD7F4 File Offset: 0x000CB9F4
        public GunInfo gunInfoOtherMod
        {
            get
            {

                if (this._gunInfoOtherMod == null)
                {
                    if (this.id > 20000)
                    {
                        this._gunInfoOtherMod = GameData.listGunInfo.GetDataById((long)(this.id - 20000));
                    }
                    else
                    {
                        this._gunInfoOtherMod = GameData.listGunInfo.GetDataById((long)(this.id + 20000));
                    }
                }
                return this._gunInfoOtherMod;
            }
        }

        // Token: 0x170006B5 RID: 1717
        // (get) Token: 0x06001AF8 RID: 6904 RVA: 0x000CD880 File Offset: 0x000CBA80
        public int ratioCrit
        {
            get
            {

                return this.crit;
            }
        }

        // Token: 0x06001AF9 RID: 6905 RVA: 0x000CD8B0 File Offset: 0x000CBAB0
        public string GetSmallPicCode(int skinId, int mod)
        {

            return this.gunInfoOtherMod.code;
        }

        // Token: 0x06001AFA RID: 6906 RVA: 0x000CD990 File Offset: 0x000CBB90
        public string GetCode(int skinId)
        {

            return this.code;
        }

        // Token: 0x06001AFB RID: 6907 RVA: 0x000CDA18 File Offset: 0x000CBC18
        public string GetCode(int skinId, int mod)
        {
            return this.code;
        }

        // Token: 0x170006B6 RID: 1718
        // (get) Token: 0x06001AFD RID: 6909 RVA: 0x000CDAF4 File Offset: 0x000CBCF4
        // (set) Token: 0x06001AFC RID: 6908 RVA: 0x000CDAC0 File Offset: 0x000CBCC0
        public new string code
        {
            get
            {

                if (this.isMindupdate && this.maxMod < 3)
                {
                    return this.gunInfoOtherMod.code;
                }
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        // Token: 0x170006B7 RID: 1719
        // (get) Token: 0x06001AFE RID: 6910 RVA: 0x000CDB48 File Offset: 0x000CBD48
        // (set) Token: 0x06001AFF RID: 6911 RVA: 0x000CDB84 File Offset: 0x000CBD84
        public new string dialogue
        {
            get
            {

                return this.dialogue;
            }
            set
            {
                this.dialogue = value;
            }
        }

        // Token: 0x170006B8 RID: 1720
        // (get) Token: 0x06001B00 RID: 6912 RVA: 0x000CDBB8 File Offset: 0x000CBDB8
        // (set) Token: 0x06001B01 RID: 6913 RVA: 0x000CDBF4 File Offset: 0x000CBDF4
        public string enIntroduce
        {
            get
            {

                return this.en_introduce;
            }
            set
            {
                this.en_introduce = value;
            }
        }

        // Token: 0x06001B02 RID: 6914 RVA: 0x000CDC28 File Offset: 0x000CBE28
        public List<int> GetMainSkills()
        {

            return this._mainSkills;
        }

        // Token: 0x06001B03 RID: 6915 RVA: 0x000CDC58 File Offset: 0x000CBE58
        public List<int> GetPassiveSkills(int mod = 0)
        {

            return (mod != 1) ? this._passiveSkills : this.gunInfoOtherMod._passiveSkills;
        }

        // Token: 0x06001B04 RID: 6916 RVA: 0x000CDCA0 File Offset: 0x000CBEA0
        public List<int> GetDynamicPassiveSkill(int mod = 0)
        {

            return (mod != 1) ? this._dynamicPassiveSkill : this.gunInfoOtherMod._dynamicPassiveSkill;
        }

        // Token: 0x170006B9 RID: 1721
        // (get) Token: 0x06001B05 RID: 6917 RVA: 0x000CDCE8 File Offset: 0x000CBEE8
        // (set) Token: 0x06001B06 RID: 6918 RVA: 0x000CDD24 File Offset: 0x000CBF24
        public new string extra
        {
            get
            {
                return this.extra;
            }
            set
            {

                this.extra = value;
            }
        }

        // Token: 0x170006BA RID: 1722
        // (get) Token: 0x06001B07 RID: 6919 RVA: 0x000CDD58 File Offset: 0x000CBF58






        // Token: 0x170006BF RID: 1727
        // (get) Token: 0x06001B0D RID: 6925 RVA: 0x000CE044 File Offset: 0x000CC244
        public bool isAdditional
        {
            get
            {
                return (int)this.is_additional == 1;
            }
        }

        // Token: 0x170006C0 RID: 1728
        // (get) Token: 0x06001B0E RID: 6926 RVA: 0x000CE078 File Offset: 0x000CC278
        public bool isMindupdate
        {
            get
            {
                return this.id > 20000 && this.id < 30000;
            }
        }

        // Token: 0x06001B0F RID: 6927 RVA: 0x000CE0C4 File Offset: 0x000CC2C4
        public int Compare(GunInfo x, GunInfo y)
        {
            return x.id - y.id;
        }

        // Token: 0x06001B10 RID: 6928 RVA: 0x000CE100 File Offset: 0x000CC300
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x04002D1E RID: 11550
        public new GunType type;



        // Token: 0x04002D20 RID: 11552
        private List<EquipInfo>[] _arrListFitEquips = new List<EquipInfo>[3];

        // Token: 0x04002D21 RID: 11553
        public bool isWithLive2DSkin;



        // Token: 0x04002D23 RID: 11555
        private bool _IsUnlockWithLive2DSkin;

        // Token: 0x04002D24 RID: 11556
        private GunInfo _gunInfoOtherMod;

        // Token: 0x04002D25 RID: 11557
        public int maxMod;

        // Token: 0x04002D26 RID: 11558
        private List<int> _mainSkills = new List<int>();

        // Token: 0x04002D27 RID: 11559
        private List<int> _passiveSkills = new List<int>();

        // Token: 0x04002D28 RID: 11560
        private List<int> _dynamicPassiveSkill = new List<int>();

        // Token: 0x04002D29 RID: 11561
        public int aiId;

        // Token: 0x04002D2A RID: 11562
        public List<GunType> listEffectGridGunType;



        // Token: 0x04002D2D RID: 11565
        public bool isLimit;

        // Token: 0x04002D2E RID: 11566
        public bool isTimeLimit;



        // Token: 0x04002D30 RID: 11568
        public int launchTime;

        // Token: 0x04002D31 RID: 11569
        public int[,] mindupdateCostItems = new int[3, 2];




    }
}
