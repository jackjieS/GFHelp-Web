using GFHelp.Core.CatchData.Base;
using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GFHelp.Core.MulitePlayerData
{
    public class Equip 
    {
        public Equip(JsonData jsonEquip)
        {

        }
        public Equip(UserData userData)
        {
            this.userData = userData;
            Equip_SortList.Clear();
            Set_Equip_SortList();

        }
        public List<int> Equip_SortList = new List<int>();
        private void Set_Equip_SortList()
        {
            this.Equip_SortList.Add(4);
            this.Equip_SortList.Add(20);
            this.Equip_SortList.Add(32);
            this.Equip_SortList.Add(40);
            this.Equip_SortList.Add(58);
            this.Equip_SortList.Add(68);
            this.Equip_SortList.Add(66);
            this.Equip_SortList.Add(90);
        }
        public void Read(JsonData jsonData)
        {
            this.listEquip.Clear();
            if (jsonData.Contains("equip_with_user_info"))
            {
                JsonData jsonData16 = jsonData["equip_with_user_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2 = new Data(jsonData16[num8]);
                    this.listEquip.Add(data2);
                }
            }
        }




        private UserData userData;
        /// <summary>
        /// 获取需要升级的装备
        /// </summary>
        public void Read_Equipment_Upgrade()
        {
            dicUpgrade.Clear();

            foreach (var item in listEquip)
            {

                //5级装备等级小于10 没有被人形装备
                if(item.info.id==16) continue;
                if (item.info.id == 59) continue;
                if (item.info.id == 117) continue;
                if (item.info.id == 118) continue;
                if (item.equip_level < 10 && item.gunId == 0 && (int)item.info.rank==5)
                {
                    Equip.Data ewui_upgrade = new Equip.Data();
                    ewui_upgrade = item;
                    dicUpgrade.Add(dicUpgrade.Count, ewui_upgrade);
                }
            }
            SortEquipment_Upgrade();
        }

        private void SortEquipment_Upgrade()
        {
            Dictionary<int, Data> temp = new Dictionary<int, Data>();
            foreach (var ID in Equip_SortList)
            {
                foreach (var item in dicUpgrade)
                {
                    if (ID == item.Value.info.id)
                    {
                        Data data = item.Value;
                        temp.Add(temp.Count, data);
                    }
                }
            }
            foreach (var item in dicUpgrade)
            {
                if (!Equip_SortList.Contains(item.Value.info.id))
                {
                    Data data = item.Value;
                    temp.Add(temp.Count, data);
                }
            }
        }
        public List<long> Get_Equipment_Food()
        {
            //string[] strFood =new string[24];
            List<long> list = new List<long>();
            int rankLevel = 2;
            while (list.Count <= 24)
            {
                if (rankLevel == 5) return list;
                foreach (var item in listEquip)
                {
                    if ((int)item.info.rank == rankLevel && item.gunId == 0)
                    {
                        list.Add(item.id);
                    }
                    if (list.Count > 24)
                    {
                        return list;
                    }
                }
                rankLevel++;
            }
            return list;
        }

        /// <summary>
        /// 升级装备后删除对应的表
        /// </summary>
        /// <param name="id_with_user"></param>
        public void Del_Equip_IN_Dict(List<long> listID)
        {
            foreach (var item0 in listID)
            {
                listEquip.Remove(item0);
            }
        }

        public void Check_Equipment_Update(long id, int exp)
        {

            long key = -1;

            //当前装备的经验值
            foreach (var item in listEquip)
            {
                if (item.id == id)
                {
                    key = item.id;
                    break;
                }
            }

            ////开始比较 分别是需要升级或者不需要升级
            //listEquip.GetDataById(key).equip_level
            //listEquip[key].equip_level += dicEquip[key].GetLevelToBeAdded(exp);
            //dicEquip[key].equip_exp += exp;

            ////10级处理
            //if (listEquip[key].equip_level == 10)
            //{
            //    //10级处理
            //}


        }



        public tBaseDatas<Data> listEquip = new tBaseDatas<Data>();
        public Dictionary<int, Data> dicUpgrade = new Dictionary<int, Data>();



        public class Data : tBaseData
        {
            public Data(JsonData jsonEquip)
            {
                try
                {
                    this.info = GameData.listEquipInfo.GetDataById((long)jsonEquip["equip_id"].Int);
                    this.id = jsonEquip["id"].Long;
                    this.isLocked = jsonEquip["is_locked"].Bool;
                    this.gunId = (long)jsonEquip["gun_with_user_id"].Int;
                    this.pow = this.GetRealAttr(jsonEquip["pow"].Int, this.info.rangePow);
                    this.hit = this.GetRealAttr(jsonEquip["hit"].Int, this.info.rangeHit);
                    this.dodge = this.GetRealAttr(jsonEquip["dodge"].Int, this.info.rangeDodge);
                    this.speed = this.GetRealAttr(jsonEquip["speed"].Int, this.info.rangeSpeed);
                    this.rate = this.GetRealAttr(jsonEquip["rate"].Int, this.info.rangeRate);
                    this.critical_percent = this.GetRealAttr(jsonEquip["critical_percent"].Int, this.info.rangeCrit);
                    this.critical_harm_rate = this.GetRealAttr(jsonEquip["critical_harm_rate"].Int, this.info.rangeCritHarm);
                    this.armor_piercing = this.GetRealAttr(jsonEquip["armor_piercing"].Int, this.info.rangePiercing);
                    this.armor = this.GetRealAttr(jsonEquip["armor"].Int, this.info.rangeArmor);
                    this.shield = this.GetRealAttr(jsonEquip["shield"].Int, this.info.rangeShiled);
                    this.damage_amplify = this.GetRealAttr(jsonEquip["damage_amplify"].Int, this.info.rangeDamageAmplify);
                    this.damage_reduction = this.GetRealAttr(jsonEquip["damage_reduction"].Int, this.info.rangeDamageReduction);
                    this.nightResistance = this.GetRealAttr(jsonEquip["night_view_percent"].Int, this.info.rangeNightResistance);
                    this.bullet_number_up = this.GetRealAttr(jsonEquip["bullet_number_up"].Int, this.info.rangeBulletNumberUp);
                    this.equip_level = jsonEquip["equip_level"].Int;
                    this.equip_exp = jsonEquip["equip_exp"].Int;
                    this.adjust_count = jsonEquip["adjust_count"].Int;
                }
                catch (Exception e)
                {
                    new Log().systemInit("Equip_With_User_Info ctor Error. data = " + jsonEquip.ToString(), e.ToString()).coreError();
                }

            }
            public Data()
            {

            }
            public int GetRealAttr(int baseAttr, int[] range)
            {
                return Mathf.RoundToInt((float)baseAttr / 10000f * (float)(range[1] - range[0]) + (float)range[0]);
            }
            public long GetID()
            {
                return this.id;
            }
            public int pow
            {
                get
                {
                    return this.GetBounsProperty("pow", this._pow);
                }
                set
                {
                    this._pow = value;
                }
            }
            public int hit
            {
                get
                {
                    return this.GetBounsProperty("hit", this._hit);
                }
                set
                {
                    this._hit = value;
                }
            }
            public int dodge
            {
                get
                {
                    return this.GetBounsProperty("dodge", this._dodge);
                }
                set
                {
                    this._dodge = value;
                }
            }
            public int speed
            {
                get
                {
                    return this.GetBounsProperty("speed", this._speed);
                }
                set
                {
                    this._speed = value;
                }
            }
            public int rate
            {
                get
                {
                    return this.GetBounsProperty("rate", this._rate);
                }
                set
                {
                    this._rate = value;
                }
            }
            public int critical_percent
            {
                get
                {
                    return this.GetBounsProperty("critical_percent", this._critical_percent);
                }
                set
                {
                    this._critical_percent = value;
                }
            }
            public int critical_harm_rate
            {
                get
                {
                    return this.GetBounsProperty("critical_harm_rate", this._critical_harm_rate);
                }
                set
                {
                    this._critical_harm_rate = value;
                }
            }
            public int armor_piercing
            {
                get
                {
                    return this.GetBounsProperty("armor_piercing", this._armor_piercing);
                }
                set
                {
                    this._armor_piercing = value;
                }
            }
            public int armor
            {
                get
                {
                    return this.GetBounsProperty("armor", this._armor);
                }
                set
                {
                    this._armor = value;
                }
            }
            public int shield
            {
                get
                {
                    return this.GetBounsProperty("shield", this._shield);
                }
                set
                {
                    this._shield = value;
                }
            }
            public int bullet_number_up
            {
                get
                {
                    return this.GetBounsProperty("bullet_number_up", this._bullet_number_up);
                }
                set
                {
                    this._bullet_number_up = value;
                }
            }





            public long id;

            // Token: 0x04001B3B RID: 6971
            public EquipInfo info;

            // Token: 0x04001B3C RID: 6972

            // Token: 0x04001B3D RID: 6973
            public long gunId;

            // Token: 0x04001B3E RID: 6974
            public EquipSortStatus currentSortStatus;

            // Token: 0x04001B3F RID: 6975
            public int slotWithGun;

            // Token: 0x04001B40 RID: 6976
            public bool isLocked;

            // Token: 0x04001B41 RID: 6977
            private int _pow;

            // Token: 0x04001B42 RID: 6978
            private int _hit;

            // Token: 0x04001B43 RID: 6979
            private int _dodge;

            // Token: 0x04001B44 RID: 6980
            public float range;

            // Token: 0x04001B45 RID: 6981
            private int _speed;

            // Token: 0x04001B46 RID: 6982
            private int _rate;

            // Token: 0x04001B47 RID: 6983
            private int _critical_percent;

            // Token: 0x04001B48 RID: 6984
            private int _critical_harm_rate;

            // Token: 0x04001B49 RID: 6985
            private int _armor_piercing;

            // Token: 0x04001B4A RID: 6986
            private int _armor;

            // Token: 0x04001B4B RID: 6987
            private int _shield;

            // Token: 0x04001B4C RID: 6988
            public int damage_amplify;

            // Token: 0x04001B4D RID: 6989
            public int damage_reduction;

            // Token: 0x04001B4E RID: 6990
            private int _nightResistance;

            // Token: 0x04001B4F RID: 6991
            private int _bullet_number_up;

            // Token: 0x04001B50 RID: 6992
            private int _skillLevelUp;

            // Token: 0x04001B51 RID: 6993
            public int equip_level;

            // Token: 0x04001B52 RID: 6994
            public int equip_exp;

            // Token: 0x04001B53 RID: 6995
            public int adjust_count;
            public int nightResistance
            {
                get
                {
                    return this.GetBounsProperty("night_view_percent", this._nightResistance);
                }
                set
                {
                    this._nightResistance = value;
                }
            }
            // Token: 0x060017BA RID: 6074 RVA: 0x0007B71C File Offset: 0x0007991C
            private int GetBounsProperty(string type, int value)
            {
                if (this.equip_level == 0)
                {
                    return value;
                }
                string[] array = this.info.strBounsType.Split(new char[]
                {
            ','
                });
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string text = array2[i];
                    string[] array3 = text.Split(new char[]
                    {
                ':'
                    });
                    if (array3[0].Equals(type))
                    {
                        float num = (float)int.Parse(array3[1]) / 100f;
                        float num2 = 1f + (float)this.equip_level * num;
                        return Mathf.FloorToInt((float)value * num2);
                    }
                }
                return value;
            }
            public int night_view_percent;
            public int GetCurrentLevelExp()
            {
                return this.equip_exp - this.GetTotalExpToLevel(this.equip_level);
            }
            public int GetTotalExpToLevel(int level)
            {
                int num;
                if (level >= 1)
                {
                    num = GameData.dictEquipmentExpInfo[level];
                }
                else
                {
                    num = 0;
                }
                float equipLevelUpRate = CatchData.Base.Data.GetEquipLevelUpRate((int)this.info.rank);
                float exclusiveRate = this.info.exclusiveRate;
                return Mathf.CeilToInt((float)num * equipLevelUpRate * exclusiveRate);
            }
            public int CalculateExpToNextLevel(int nextLevel)
            {
                int num;
                if (nextLevel > 1)
                {
                    if (nextLevel - 1 < GameData.dictEquipmentExpInfo.Count)
                    {
                        num = GameData.dictEquipmentExpInfo[nextLevel] - GameData.dictEquipmentExpInfo[nextLevel - 1];
                    }
                    else
                    {
                        num = 99999;
                    }
                }
                else if (nextLevel == 1)
                {
                    num = GameData.dictEquipmentExpInfo[nextLevel];
                }
                else
                {
                    num = 0;
                }
                float equipLevelUpRate = CatchData.Base.Data.GetEquipLevelUpRate((int)this.info.rank);
                float exclusiveRate = this.info.exclusiveRate;
                return Mathf.CeilToInt((float)num * equipLevelUpRate * exclusiveRate);
            }
            public int GetLevelToBeAdded(int expAdded)
            {
                int i = expAdded + GetCurrentLevelExp();
                int num = equip_level + 1;
                int num2 = 0;
                while (i >= 0)
                {
                    i -= CalculateExpToNextLevel(num);
                    num++;
                    if (i >= 0)
                    {
                        num2++;
                    }
                }
                return num2;
            }
        }



    }

    public enum EquipSortStatus
    {
        // Token: 0x0400185B RID: 6235
        Normal = 11,
        // Token: 0x0400185C RID: 6236
        EquipInGun,
        // Token: 0x0400185D RID: 6237
        EquipInMissionGun = 70,
        // Token: 0x0400185E RID: 6238
        LevelLimit = 80,
        // Token: 0x0400185F RID: 6239
        SameType = 90,
        // Token: 0x04001860 RID: 6240
        CanNotEquip = 100
    }



}
