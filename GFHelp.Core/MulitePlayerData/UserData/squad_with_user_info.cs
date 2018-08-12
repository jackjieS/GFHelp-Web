using GFHelp.Core.CatchData.Base;
using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
   public class Squad_With_User_Info
    {
        public Squad_With_User_Info(UserData UserData)
        {
            this.UserData = UserData;
        }
        public void Read(JsonData jsonData)
        {
            this.listSquad.Clear();
            if (jsonData.Contains("squad_with_user_info"))
            {
                JsonData jsonData16 = jsonData["squad_with_user_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2;
                    try
                    {
                        data2 = new Data(jsonData16[num8],this.UserData);
                    }
                    catch (Exception e)
                    {
                        new Log().systemInit("squad_with_user_info Error ",e.ToString()).coreInfo();
                        throw;
                    }

                    this.listSquad.Add(data2);
                }
            }
        }

        public tBaseDatas<Data> listSquad = new tBaseDatas<Data>();
        private UserData UserData;
        public class Data:tBaseData
        {
            private UserData userData;
            public Data(JsonData jsonData,UserData userData)
            {
                this.userData = userData;
                this.id = jsonData["id"].Long;
                this.infoId = jsonData["squad_id"].Int;
                this.rank = jsonData["rank"].Int;
                this.advancedLevel = jsonData["advanced_level"].Int;
                this.canUserGrid = jsonData["can_user_gird"].String;
                this.life = jsonData["life"].Int;
                this.curDef = jsonData["cur_def"].Int;
                this.ammo = jsonData["ammo"].Int;
                this.mre = jsonData["mre"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.assist_damage] = jsonData["assist_damage"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.assist_reload] = jsonData["assist_reload"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.assist_hit] = jsonData["assist_hit"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.assist_def_break] = jsonData["assist_def_break"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.damage] = jsonData["damage"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.atk_speed] = jsonData["atk_speed"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.hit] = jsonData["hit"].Int;
                this.dictAddAttrByAttrType[SquadAttriType.def] = jsonData["def"].Int;
                this.skill1 = jsonData["skill1"].Int;
                this.skill2 = jsonData["skill2"].Int;
                this.skill3 = jsonData["skill3"].Int;
                this.fixEndTime = jsonData["fix_end_time"].Int;
                this.listSquadChip = userData.chip_With_User_Info.listSquadChip.FindAll((Chip_With_User_Info.Data chip) => chip.squadId == this.id);
                this.exp = jsonData["squad_exp"].Int;
            }
            public Data(SquadInfo info)
            {
                this.infoId = info.id;
                this._info = info;
                for (int i = 1; i <= 8; i++)
                {
                    this.dictAddAttrByAttrType[(SquadAttriType)i] = 0;
                }
                this.skill1 = 1;
                this.skill2 = 1;
                this.skill3 = 1;
            }
            public Data(int id)
            {
                this.infoId = id;
                for (int i = 1; i <= 8; i++)
                {
                    this.dictAddAttrByAttrType[(SquadAttriType)i] = 0;
                }
            }
            public long GetID()
            {
                return this.id;
            }


            public void UpdateData()
            {
                //float num = (float)CatchData.Base.Data.GetInt("squad_basic_lv");
                //float num2 = (float)Data.GetInt("squad_lv_max");
                //float num3 = (float)GameData.listSquadRankInfo.GetDataById((long)this.rank).cpu_rate;
                //for (int i = 1; i <= 8; i++)
                //{
                //    SquadAttriType squadAttriType = (SquadAttriType)i;
                //    float num4 = (float)this.info.GetAttributeValue(squadAttriType);
                //    SquadBaseAttribution squadBasicAttribute = Data.GetSquadBasicAttribute(squadAttriType);
                //    float attributeValue = this.info.typeInfo.GetAttributeValue(squadAttriType);
                //    float num5 = num;
                //    float num6 = num4 * squadBasicAttribute.standard_attribute * attributeValue;
                //    this.dictBaseAttrByAttrType[squadAttriType] = Mathf.CeilToInt(num5 * num6 * (float)squadBasicAttribute.basic_rate * (float)this.info.basic_rate / 1E+08f);
                //    num5 = num + (float)this.level - 1f;
                //    this.dictBasicLimitAttrByAttrType[squadAttriType] = Mathf.CeilToInt(num5 * num6 * (float)squadBasicAttribute.basic_rate * (float)this.info.basic_rate / 1E+08f);
                //    if (this.bonus != null)
                //    {
                //        Dictionary<SquadAttriType, int> dictionary2;
                //        Dictionary<SquadAttriType, int> dictionary = dictionary2 = this.dictBasicLimitAttrByAttrType;
                //        SquadAttriType key2;
                //        SquadAttriType key = key2 = squadAttriType;
                //        int num7 = dictionary2[key2];
                //        dictionary[key] = num7 + this.bonus.dictBonusAttrByAttrType[squadAttriType];
                //    }
                //    this.dictCpuLimitByAttrType[squadAttriType] = Mathf.CeilToInt((num + num2 - 1f) * num6 * (float)squadBasicAttribute.cpu_rate * (float)this.info.cpu_rate * num3 / 1E+10f);
                //    this.dictCpuBaseAttrByAttrType[squadAttriType] = 0;
                //    int j = 0;
                //    int count = this.listSquadChip.Count;
                //    while (j < count)
                //    {
                //        Dictionary<SquadAttriType, int> dictionary4;
                //        Dictionary<SquadAttriType, int> dictionary3 = dictionary4 = this.dictCpuBaseAttrByAttrType;
                //        SquadAttriType key2;
                //        SquadAttriType key3 = key2 = squadAttriType;
                //        int num7 = dictionary4[key2];
                //        dictionary3[key3] = num7 + this.listSquadChip[j].GetAttributeValue(squadAttriType);
                //        j++;
                //    }
                //    this.dictCpuBaseAttrByAttrType[squadAttriType] = Mathf.Min(new int[]
                //    {
                //this.dictCpuLimitByAttrType[squadAttriType],
                //this.dictCpuBaseAttrByAttrType[squadAttriType]
                //    });
                //    this.dictCpuBonusAttrByAttrType[squadAttriType] = 0;
                //}
                //this.sameColorGridNum = 0;
                //int k = 0;
                //int count2 = this.listSquadChip.Count;
                //while (k < count2)
                //{
                //    if (this.listSquadChip[k].colorId == this.cpuInfo.color)
                //    {
                //        this.sameColorGridNum += this.listSquadChip[k].gridInfo.grid_number;
                //    }
                //    k++;
                //}
                //List<SquadCPUCompletion> completionList = this.cpuInfo.GetCompletionList();
                //int l = 0;
                //int count3 = completionList.Count;
                //while (l < count3)
                //{
                //    SquadCPUCompletion squadCPUCompletion = completionList[l];
                //    if (squadCPUCompletion.unlock_number <= this.sameColorGridNum)
                //    {
                //        for (int m = 1; m <= 8; m++)
                //        {
                //            SquadAttriType squadAttriType2 = (SquadAttriType)m;
                //            Dictionary<SquadAttriType, int> dictionary6;
                //            Dictionary<SquadAttriType, int> dictionary5 = dictionary6 = this.dictCpuBonusAttrByAttrType;
                //            SquadAttriType key2;
                //            SquadAttriType key4 = key2 = squadAttriType2;
                //            int num7 = dictionary6[key2];
                //            dictionary5[key4] = num7 + squadCPUCompletion.GetAttributeValue(squadAttriType2);
                //        }
                //    }
                //    l++;
                //}
                //for (int n = 1; n <= 8; n++)
                //{
                //    SquadAttriType key5 = (SquadAttriType)n;
                //    this.dictPanelAttrByAttrType[key5] = this.dictBaseAttrByAttrType[key5] + this.dictAddAttrByAttrType[key5] + this.dictCpuBaseAttrByAttrType[key5] + this.dictCpuBonusAttrByAttrType[key5];
                //}
                //SquadAttriType squadAttriType3 = SquadAttriType.hp;
                //float num8 = (float)this.info.GetAttributeValue(squadAttriType3);
                //SquadBaseAttribution squadBasicAttribute2 = Data.GetSquadBasicAttribute(squadAttriType3);
                //float attributeValue2 = this.info.typeInfo.GetAttributeValue(squadAttriType3);
                //float num9 = num8 * squadBasicAttribute2.standard_attribute * attributeValue2;
                //this.dictBaseAttrByAttrType[squadAttriType3] = Mathf.CeilToInt(num * num9 * (float)squadBasicAttribute2.basic_rate * (float)this.info.basic_rate / 1E+08f);
                //this.dictBasicLimitAttrByAttrType[squadAttriType3] = Mathf.CeilToInt((num + (float)this.level - 1f) * num9 * (float)squadBasicAttribute2.basic_rate * (float)this.info.basic_rate / 1E+08f);
            }

            public string name
            {
                get
                {

                    return this.nameId;
                }
                set
                {
                    this.nameId = value;
                }
            }

            // Token: 0x17000754 RID: 1876
            // (get) Token: 0x060023D8 RID: 9176 RVA: 0x000EBE14 File Offset: 0x000EA014
            // (set) Token: 0x060023D9 RID: 9177 RVA: 0x000EBE44 File Offset: 0x000EA044
            public int exp
            {
                get
                {

                    return this._exp;
                }
                set
                {
                    this._exp = value;
                    this.level = CatchData.Base.Data.SquadExpToLevel(this._exp);
                }
            }

            // Token: 0x17000755 RID: 1877
            // (get) Token: 0x060023DA RID: 9178 RVA: 0x000EBE88 File Offset: 0x000EA088
            // (set) Token: 0x060023DB RID: 9179 RVA: 0x000EBEB8 File Offset: 0x000EA0B8
            public int level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                    this.UpdateData();
                }
            }

            // Token: 0x17000756 RID: 1878
            // (get) Token: 0x060023DC RID: 9180 RVA: 0x000EBEF0 File Offset: 0x000EA0F0
            public SquadCPUInfo cpuInfo
            {
                get
                {
                    return GameData.listSquadCPUInfo.GetDataById((long)this.info.cpu_id);
                }
            }

            // Token: 0x17000757 RID: 1879
            // (get) Token: 0x060023DD RID: 9181 RVA: 0x000EBF30 File Offset: 0x000EA130
            public int assistAP
            {
                get
                {
                    return this.info.assist_armor_piercing;
                }
            }

            // Token: 0x17000758 RID: 1880
            // (get) Token: 0x060023DE RID: 9182 RVA: 0x000EBF68 File Offset: 0x000EA168
            public SquadInfo info
            {
                get
                {
                    if (this._info == null)
                    {
                        this._info = GameData.listSquadInfo.GetDataById((long)this.infoId);
                    }
                    return this._info;
                }
            }

            // Token: 0x17000759 RID: 1881
            // (get) Token: 0x060023DF RID: 9183 RVA: 0x000EBFBC File Offset: 0x000EA1BC
            //public SquadAdvancedBonus bonus
            //{
            //    get
            //    {
            //        int num = this.info.advanced_bonus * 100 + this.advancedLevel;
            //        if (GameData.listSquadAdvancedBonus.ContainsKey((long)num))
            //        {
            //            return GameData.listSquadAdvancedBonus.GetDataById((long)num);
            //        }
            //        return null;
            //    }
            //}

            // Token: 0x1700075A RID: 1882
            // (get) Token: 0x060023E0 RID: 9184 RVA: 0x000EC01C File Offset: 0x000EA21C
            public int maxLife
            {
                get
                {
                    return this.dictBasicLimitAttrByAttrType[SquadAttriType.hp];
                }
            }

            // Token: 0x1700075B RID: 1883
            // (get) Token: 0x060023E1 RID: 9185 RVA: 0x000EC054 File Offset: 0x000EA254
            public int maxDef
            {
                get
                {

                    return this.dictBasicLimitAttrByAttrType[SquadAttriType.def];
                }
            }
            public int GetPoint()
            {
                return Core.CatchData.Base.Data.GetSquadPoint(this, true);
            }

            // Token: 0x1700075C RID: 1884
            // (get) Token: 0x060023E4 RID: 9188 RVA: 0x000EC51C File Offset: 0x000EA71C
            public bool isDamaged
            {
                get
                {
                    return (float)this.life < (float)this.maxLife * 0.3f;
                }
            }

            // Token: 0x1700075D RID: 1885
            // (get) Token: 0x060023E5 RID: 9189 RVA: 0x000EC55C File Offset: 0x000EA75C
            //public int GetPieceQuantity
            //{
            //    get
            //    {
            //        return GameData.GetItem(this.info.piece_item_id);
            //    }
            //}

            // Token: 0x1700075E RID: 1886
            // (get) Token: 0x060023E6 RID: 9190 RVA: 0x000EC598 File Offset: 0x000EA798
            //public string strRankPercent
            //{
            //    get
            //    {
            //        return (this.RankPercent * 100f).ToString("f0");
            //    }
            //}
            // Token: 0x1700075F RID: 1887
            // (get) Token: 0x060023E8 RID: 9192 RVA: 0x000ECA14 File Offset: 0x000EAC14
            //public float RankPercent
            //{
            //    get
            //    {
            //        int num = this.GetPieceQuantity;
            //        float num2 = 0f;
            //        for (int i = this.rank; i < 5; i++)
            //        {
            //            SquadRankInfo dataById = GameData.listSquadRankInfo.GetDataById((long)(i + 1));
            //            float num3 = Mathf.Clamp01((float)num / (float)dataById.cost_self_piece);
            //            num2 += num3;
            //            if (num3 < 1f)
            //            {
            //                break;
            //            }
            //            num -= dataById.cost_self_piece;
            //        }
            //        return num2;
            //    }
            //}

            // Token: 0x17000760 RID: 1888
            // (get) Token: 0x060023E9 RID: 9193 RVA: 0x000ECAA8 File Offset: 0x000EACA8
            public int rankUpNeedPiece
            {
                get
                {

                    return GameData.listSquadRankInfo.GetDataById((long)((this.rank >= GameData.listSquadRankInfo.Count) ? this.rank : (this.rank + 1))).cost_self_piece;
                }
            }

            // Token: 0x17000761 RID: 1889
            // (get) Token: 0x060023EA RID: 9194 RVA: 0x000ECB0C File Offset: 0x000EAD0C
            public int curLevelExp
            {
                get
                {
                    return CatchData.Base.Data.CurrentSquadLevelExp(this.level, this._exp);
                }
            }

            // Token: 0x17000762 RID: 1890
            // (get) Token: 0x060023EB RID: 9195 RVA: 0x000ECB48 File Offset: 0x000EAD48
            public int curLevelUpNeedExp
            {
                get
                {
                    return CatchData.Base.Data.CurrentSquadLevelUpNeedExp(this.level);
                }
            }

            // Token: 0x17000763 RID: 1891
            // (get) Token: 0x060023EC RID: 9196 RVA: 0x000ECB80 File Offset: 0x000EAD80
            public int maxRank
            {
                get
                {
                    return GameData.listSquadRankInfo.Count;
                }
            }

            // Token: 0x17000764 RID: 1892
            // (get) Token: 0x060023ED RID: 9197 RVA: 0x000ECBB4 File Offset: 0x000EADB4
            public int maxLevel
            {
                get
                {

                    return GameData.listSquadExp.Count;
                }
            }

            // Token: 0x17000765 RID: 1893
            // (get) Token: 0x060023EE RID: 9198 RVA: 0x000ECBE8 File Offset: 0x000EADE8
            public bool IsMaxLevel
            {
                get
                {
                    return this.level >= this.maxLevel;
                }
            }

            // Token: 0x17000766 RID: 1894
            // (get) Token: 0x060023EF RID: 9199 RVA: 0x000ECC24 File Offset: 0x000EAE24
            //public BattleSkillCfg battleSkill1
            //{
            //    get
            //    {
            //        return this.info.GetBattleSkillCfg(this.info.skill1.ToString(), this.skill1, true);
            //    }
            //}

            // Token: 0x17000767 RID: 1895
            // (get) Token: 0x060023F0 RID: 9200 RVA: 0x000ECC70 File Offset: 0x000EAE70
            //public BattleSkillCfg battleSkill2
            //{
            //    get
            //    {
            //        return this.info.GetBattleSkillCfg(this.info.skill2.ToString(), this.skill2, true);
            //    }
            //}

            // Token: 0x17000768 RID: 1896
            // (get) Token: 0x060023F1 RID: 9201 RVA: 0x000ECCBC File Offset: 0x000EAEBC
            //public BattleSkillCfg battleSkill3
            //{
            //    get
            //    {
            //        return this.info.GetBattleSkillCfg(this.info.skill3.ToString(), this.skill3, true);
            //    }
            //}

            // Token: 0x17000769 RID: 1897
            // (get) Token: 0x060023F2 RID: 9202 RVA: 0x000ECD08 File Offset: 0x000EAF08
            //public MissionSkillCfg destroyBuildSkillCfg
            //{
            //    get
            //    {
            //        return this.info.GetMissionSkillCfg(this.info.destroyBuildSkill, this.level, true);
            //    }
            //}

            // Token: 0x1700076A RID: 1898
            // (get) Token: 0x060023F3 RID: 9203 RVA: 0x000ECD50 File Offset: 0x000EAF50
            //public MissionSkillCfg rebuildBuildSkillCfg
            //{
            //    get
            //    {
            //        return this.info.GetMissionSkillCfg(this.info.rebuildBuildSkill, this.level, true);
            //    }
            //}

            // Token: 0x040043D6 RID: 17366
            public long id;

            // Token: 0x040043D7 RID: 17367
            public int infoId;

            // Token: 0x040043D8 RID: 17368
            public string nameId;

            // Token: 0x040043D9 RID: 17369
            public int _exp;

            // Token: 0x040043DA RID: 17370
            public int _level = 1;

            // Token: 0x040043DB RID: 17371
            public int rank;

            // Token: 0x040043DC RID: 17372
            public int advancedLevel;

            // Token: 0x040043DD RID: 17373
            public string canUserGrid;

            // Token: 0x040043DE RID: 17374
            public int life;

            // Token: 0x040043DF RID: 17375
            public int curDef;

            // Token: 0x040043E0 RID: 17376
            public int ammo;

            // Token: 0x040043E1 RID: 17377
            public int mre;

            // Token: 0x040043E2 RID: 17378
            public int skill1;

            // Token: 0x040043E3 RID: 17379
            public int skill2;

            // Token: 0x040043E4 RID: 17380
            public int skill3;

            // Token: 0x040043E5 RID: 17381
            public int fixEndTime;

            // Token: 0x040043E6 RID: 17382
            private SquadInfo _info;

            // Token: 0x040043E7 RID: 17383
            public SquadStatus status;

            // Token: 0x040043E8 RID: 17384
            public List<Chip_With_User_Info.Data> listSquadChip = new List<Chip_With_User_Info.Data>();

            // Token: 0x040043E9 RID: 17385
            public Dictionary<SquadAttriType, int> dictBaseAttrByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043EA RID: 17386
            public Dictionary<SquadAttriType, int> dictPanelAttrByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043EB RID: 17387
            public Dictionary<SquadAttriType, int> dictAddAttrByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043EC RID: 17388
            public Dictionary<SquadAttriType, int> dictBasicLimitAttrByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043ED RID: 17389
            public Dictionary<SquadAttriType, int> dictCpuLimitByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043EE RID: 17390
            public Dictionary<SquadAttriType, int> dictCpuBaseAttrByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043EF RID: 17391
            public Dictionary<SquadAttriType, int> dictCpuBonusAttrByAttrType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043F0 RID: 17392
            public int sameColorGridNum;

            // Token: 0x040043F1 RID: 17393
            private int fixType;

















        }
        public enum SquadStatus
        {
            // Token: 0x040043D2 RID: 17362
            normal,
            // Token: 0x040043D3 RID: 17363
            trainning,
            // Token: 0x040043D4 RID: 17364
            fix,
            // Token: 0x040043D5 RID: 17365
            fight
        }
    }
}
