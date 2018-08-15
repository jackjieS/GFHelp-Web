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
    public class Chip_With_User_Info
    {
        public Chip_With_User_Info(UserData UserData)
        {
            this.UserData = UserData;
        }

        public void Read(JsonData jsonData)
        {
            this.listSquadChip.Clear();
            this.listSquadChipRank5.Clear();
            if (jsonData.Contains("chip_with_user_info"))
            {
                JsonData jsonData16 = jsonData["chip_with_user_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2=null;
                    try
                    {
                        data2 = new Data(jsonData16[num8],this.UserData);
                    }
                    catch (Exception e)
                    {
                        new Log().systemInit("chip_with_user_info Error ", e.ToString()).coreInfo();
                    }
                    if (data2.chipInfo.rank == 5)
                    {
                        this.listSquadChipRank5.Add(data2);
                    }
                    this.listSquadChip.Add(data2);
                }
            }
        }





        private UserData UserData;
        public tBaseDatas<Data> listSquadChip = new tBaseDatas<Data>();
        public tBaseDatas<Data> listSquadChipRank5 = new tBaseDatas<Data>();
        public class Data : tBaseData
        {
            private UserData UserData;
            // Token: 0x060023BD RID: 9149 RVA: 0x000EAF9C File Offset: 0x000E919C
            public Data()
            {

            }

            // Token: 0x060023BE RID: 9150 RVA: 0x000EAFE4 File Offset: 0x000E91E4
            public Data(JsonData jsonData,UserData userData)
            {

                this.UserData = userData;
                this.id = jsonData["id"].Long;
                this.infoId = jsonData["chip_id"].Int;
                if (jsonData.Contains("chip_exp"))
                {
                    this.exp = jsonData["chip_exp"].Int;
                }
                this.colorId = jsonData["color_id"].Int;
                this.gridId = jsonData["grid_id"].Int;
                if (jsonData.Contains("squad_with_user_id"))
                {
                    this.squadId = (long)jsonData["squad_with_user_id"].Int;
                }
                if (jsonData.Contains("position"))
                {
                    this.position = new BoardVector(jsonData["position"].String);
                }
                this.rotation = new ChipRotation(jsonData["shape_info"].String);
                this.assist_damage = jsonData["assist_damage"].Int;
                this.assist_reload = jsonData["assist_reload"].Int;
                this.assist_hit = jsonData["assist_hit"].Int;
                this.assist_def_break = jsonData["assist_def_break"].Int;
                this.damage = jsonData["damge"].Int;
                this.atk_speed = jsonData["atk_speed"].Int;
                this.hit = jsonData["hit"].Int;
                this.def = jsonData["def"].Int;
                if (jsonData.Contains("is_locked"))
                {
                    this.isLock = (jsonData["is_locked"].Int != 0);//
                }

                this.ResetShape();
                this.UpdateData();


            }

            // Token: 0x060023BF RID: 9151 RVA: 0x000EB1C0 File Offset: 0x000E93C0
            public long GetID()
            {
                return this.id;
            }

            // Token: 0x1700074D RID: 1869
            // (get) Token: 0x060023C0 RID: 9152 RVA: 0x000EB1F0 File Offset: 0x000E93F0
            public SquadChipInfo chipInfo
            {
                get
                {
                    return GameData.listSquadChipInfo.GetDataById((long)this.infoId);
                }
            }

            // Token: 0x1700074E RID: 1870
            // (get) Token: 0x060023C1 RID: 9153 RVA: 0x000EB22C File Offset: 0x000E942C
            public SquadCPUGrid gridInfo
            {
                get
                {
                    return GameData.listSquadCPUGrid.GetDataById((long)this.gridId);
                }
            }

            // Token: 0x1700074F RID: 1871
            // (get) Token: 0x060023C2 RID: 9154 RVA: 0x000EB268 File Offset: 0x000E9468
            public SquadCPUColor colorInfo
            {
                get
                {

                    return GameData.listSquadCPUColor.GetDataById((long)this.colorId);
                }
            }

            // Token: 0x17000750 RID: 1872
            // (get) Token: 0x060023C3 RID: 9155 RVA: 0x000EB2A4 File Offset: 0x000E94A4
            public Squad_With_User_Info.Data squad
            {
                get
                {
                    if (this.squadId != 0L)
                    {
                        return UserData.squad_With_User_Info.listSquad.GetDataById(this.squadId);
                    }
                    return null;
                }
            }

            // Token: 0x17000751 RID: 1873
            // (get) Token: 0x060023C4 RID: 9156 RVA: 0x000EB2EC File Offset: 0x000E94EC
            // (set) Token: 0x060023C5 RID: 9157 RVA: 0x000EB31C File Offset: 0x000E951C
            public int exp
            {
                get
                {
                    return this._exp;
                }
                set
                {
                    this._exp = value;
                    this.level = CatchData.Base.Data.SquadChipLevelWithExp(this._exp, this.chipInfo.rank);
                }
            }

            // Token: 0x17000752 RID: 1874
            // (get) Token: 0x060023C6 RID: 9158 RVA: 0x000EB36C File Offset: 0x000E956C
            public string code
            {
                get
                {
                    if (!string.IsNullOrEmpty(this.gridInfo.code))
                    {
                        return this.gridInfo.code;
                    }
                    return "grid" + this.gridId;
                }
            }

            // Token: 0x060023C7 RID: 9159 RVA: 0x000EB3CC File Offset: 0x000E95CC
            public int GetFeedExp(float sameColorRatio)
            {
                return Mathf.CeilToIntTest(sameColorRatio * (float)this.basicFeedExp + (float)this.exp * CatchData.Base.Data.GetFloat("squad_chip_exp_change_ratio"));
            }

            // Token: 0x060023C8 RID: 9160 RVA: 0x000EB418 File Offset: 0x000E9618
            public void UpdateData()
            {
                this.strengthenCoef = CatchData.Base.Data.SquadChipStrengthenLevelCoef(this.level);
                int intensity_ratio = this.chipInfo.intensity_ratio;
                for (int i = 1; i <= 8; i++)
                {
                    SquadAttriType squadAttriType = (SquadAttriType)i;
                    SquadBaseAttribution squadBasicAttribute = CatchData.Base.Data.GetSquadBasicAttribute(squadAttriType);
                    this.dictRealAttrValueByType[squadAttriType] = Mathf.CeilToInt((float)this.GetUnitNumValue(squadAttriType) * squadBasicAttribute.cpu_standard_attribute * (float)intensity_ratio * this.strengthenCoef / 100f);
                }
                string[] array = CatchData.Base.Data.GetString("squad_chip_exp_basic_ratio").Split(new char[]
                {
            ','
                });
                for (int j = 0; j < array.Length; j++)
                {
                    string[] array2 = array[j].Split(new char[]
                    {
                ':'
                    });
                    int num;
                    int num2;
                    if (array2.Length >= 2 && int.TryParse(array2[0], out num) && int.TryParse(array2[1], out num2) && num == this.chipInfo.rank)
                    {
                        this.basicFeedExp = num2;
                        break;
                    }
                }
            }

            // Token: 0x060023C9 RID: 9161 RVA: 0x000EB540 File Offset: 0x000E9740
            public void ResetShape()
            {
                this.shape = this.gridInfo.shape.AppendRotation(this.rotation).TranslateTo(this.position);
                this.tempPosition = this.position;
                this.tempRotation = this.rotation;
                this.tempSquadId = this.squadId;
                this.tempConflict = false;
            }

            // Token: 0x060023CA RID: 9162 RVA: 0x000EB5C0 File Offset: 0x000E97C0
            public void ApplyTempShape()
            {
                this.position = this.tempPosition;
                this.rotation = this.tempRotation;
                this.squadId = this.tempSquadId;
                this.shape = this.gridInfo.shape.AppendRotation(this.rotation).TranslateTo(this.position);
                this.tempConflict = false;
            }

            // Token: 0x060023CB RID: 9163 RVA: 0x000EB640 File Offset: 0x000E9840
            public ChipShape GetTempShape()
            {
                return this.GetTempShape(this.tempPosition, this.tempRotation);
            }

            // Token: 0x060023CC RID: 9164 RVA: 0x000EB67C File Offset: 0x000E987C
            public ChipShape GetTempShape(BoardVector position)
            {
                return this.GetTempShape(position, this.tempRotation);
            }

            // Token: 0x060023CD RID: 9165 RVA: 0x000EB6B4 File Offset: 0x000E98B4
            public ChipShape GetTempShape(ChipRotation rotation)
            {
                return this.GetTempShape(this.tempPosition, rotation);
            }

            // Token: 0x060023CE RID: 9166 RVA: 0x000EB6EC File Offset: 0x000E98EC
            public ChipShape GetTempShape(BoardVector position, ChipRotation rotation)
            {
                return this.gridInfo.shape.AppendRotation(rotation).TranslateTo(position);
            }

            // Token: 0x060023CF RID: 9167 RVA: 0x000EB734 File Offset: 0x000E9934
            public int GetAttributeValue(SquadAttriType attr)
            {

                return this.dictRealAttrValueByType[attr];
            }

            // Token: 0x060023D0 RID: 9168 RVA: 0x000EB76C File Offset: 0x000E996C
            public int GetUnitNumValue(SquadAttriType attr)
            {

                bool flag = this.chipInfo.is_random != 0;
                switch (attr)
                {
                    case SquadAttriType.assist_damage:
                        return (!flag) ? this.chipInfo.assist_damage : this.assist_damage;
                    case SquadAttriType.assist_def_break:
                        return (!flag) ? this.chipInfo.assist_def_break : this.assist_def_break;
                    case SquadAttriType.assist_hit:
                        return (!flag) ? this.chipInfo.assist_hit : this.assist_hit;
                    case SquadAttriType.assist_reload:
                        return (!flag) ? this.chipInfo.assist_reload : this.assist_reload;
                    case SquadAttriType.atk_speed:
                        return (!flag) ? this.chipInfo.atk_speed : this.atk_speed;
                    case SquadAttriType.damage:
                        return (!flag) ? this.chipInfo.damage : this.damage;
                    case SquadAttriType.def:
                        return (!flag) ? this.chipInfo.def : this.def;
                    case SquadAttriType.hit:
                        return (!flag) ? this.chipInfo.hit : this.hit;
                    default:
                        return 0;
                }
            }

            // Token: 0x060023D1 RID: 9169 RVA: 0x000EB8C4 File Offset: 0x000E9AC4
            public string GetAttributeValueText(SquadAttriType attr)
            {

                int attributeValue = this.GetAttributeValue(attr);
                if (attributeValue <= 0 || this.level == 0)
                {
                    return attributeValue.ToString();
                }
                return string.Format("<color=#17CCA6>{0}</color>", attributeValue);
            }

            // Token: 0x040043A2 RID: 17314
            public long id;

            // Token: 0x040043A3 RID: 17315
            public int infoId;

            // Token: 0x040043A4 RID: 17316
            public int gridId;

            // Token: 0x040043A5 RID: 17317
            public int colorId;

            // Token: 0x040043A6 RID: 17318
            public ChipShape shape;

            // Token: 0x040043A7 RID: 17319
            public BoardVector position;

            // Token: 0x040043A8 RID: 17320
            public ChipRotation rotation;

            // Token: 0x040043A9 RID: 17321
            public long squadId;

            // Token: 0x040043AA RID: 17322
            private int _exp;

            // Token: 0x040043AB RID: 17323
            public int level;

            // Token: 0x040043AC RID: 17324
            public bool isLock;

            // Token: 0x040043AD RID: 17325
            public float strengthenCoef = 1f;

            // Token: 0x040043AE RID: 17326
            public int basicFeedExp;

            // Token: 0x040043AF RID: 17327
            public int assist_damage;

            // Token: 0x040043B0 RID: 17328
            public int assist_reload;

            // Token: 0x040043B1 RID: 17329
            public int assist_hit;

            // Token: 0x040043B2 RID: 17330
            public int assist_def_break;

            // Token: 0x040043B3 RID: 17331
            public int damage;

            // Token: 0x040043B4 RID: 17332
            public int atk_speed;

            // Token: 0x040043B5 RID: 17333
            public int hit;

            // Token: 0x040043B6 RID: 17334
            public int def;

            // Token: 0x040043B7 RID: 17335
            public Dictionary<SquadAttriType, int> dictRealAttrValueByType = new Dictionary<SquadAttriType, int>();

            // Token: 0x040043B8 RID: 17336
            public long tempSquadId;

            // Token: 0x040043B9 RID: 17337
            public ChipRotation tempRotation;

            // Token: 0x040043BA RID: 17338
            public BoardVector tempPosition;

            // Token: 0x040043BB RID: 17339
            public bool tempConflict;
        }
    }
}
