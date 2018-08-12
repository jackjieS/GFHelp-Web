using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class BattleSkillCfg : StcBattle_skill_config, tBaseData
    {

        // Token: 0x06001BC2 RID: 7106 RVA: 0x000A3F48 File Offset: 0x000A2148
        public BattleSkillCfg()
        {
        }

        // Token: 0x17000522 RID: 1314
        // (get) Token: 0x06001BC3 RID: 7107 RVA: 0x000A3F78 File Offset: 0x000A2178
        // (set) Token: 0x06001BC4 RID: 7108 RVA: 0x000A3FB4 File Offset: 0x000A21B4
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

        // Token: 0x17000523 RID: 1315
        // (get) Token: 0x06001BC5 RID: 7109 RVA: 0x000A3FE8 File Offset: 0x000A21E8
        public int skillGroupId
        {
            get
            {

                return this.skill_group_id;
            }
        }

        // Token: 0x17000524 RID: 1316
        // (get) Token: 0x06001BC6 RID: 7110 RVA: 0x000A4018 File Offset: 0x000A2218
        public int skillPriority
        {
            get
            {

                return this.skill_priority;
            }
        }

        // Token: 0x17000525 RID: 1317
        // (get) Token: 0x06001BC7 RID: 7111 RVA: 0x000A4048 File Offset: 0x000A2248
        // (set) Token: 0x06001BC8 RID: 7112 RVA: 0x000A4084 File Offset: 0x000A2284
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

        // Token: 0x17000526 RID: 1318
        // (get) Token: 0x06001BC9 RID: 7113 RVA: 0x000A40B8 File Offset: 0x000A22B8
        public int trainCoinType
        {
            get
            {
                return this.train_coin_type;
            }
        }

        // Token: 0x17000527 RID: 1319
        // (get) Token: 0x06001BCA RID: 7114 RVA: 0x000A40E8 File Offset: 0x000A22E8
        public int trainCoinNumber
        {
            get
            {
                return this.train_coin_number;
            }
        }

        // Token: 0x17000528 RID: 1320
        // (get) Token: 0x06001BCB RID: 7115 RVA: 0x000A4118 File Offset: 0x000A2318
        public int trainTime
        {
            get
            {
                return this.skill_up_time;
            }
        }

        // Token: 0x17000529 RID: 1321
        // (get) Token: 0x06001BCC RID: 7116 RVA: 0x000A4148 File Offset: 0x000A2348
        public int daynightOnly
        {
            get
            {
                return this.daynight_only;
            }
        }

        // Token: 0x1700052A RID: 1322
        // (get) Token: 0x06001BCD RID: 7117 RVA: 0x000A4178 File Offset: 0x000A2378
        public int interruptType
        {
            get
            {
                return this.interrupt_type;
            }
        }

        // Token: 0x1700052B RID: 1323
        // (get) Token: 0x06001BCE RID: 7118 RVA: 0x000A41A8 File Offset: 0x000A23A8
        public int interruptDamageLimit
        {
            get
            {

                return this.interrupt_damage_limit;
            }
        }

        // Token: 0x1700052C RID: 1324
        // (get) Token: 0x06001BCF RID: 7119 RVA: 0x000A41D8 File Offset: 0x000A23D8
        public int cdType
        {
            get
            {

                return this.cd_type;
            }
        }

        // Token: 0x1700052D RID: 1325
        // (get) Token: 0x06001BD0 RID: 7120 RVA: 0x000A4208 File Offset: 0x000A2408
        public int cdTime
        {
            get
            {
                return this.cd_time;
            }
        }

        // Token: 0x1700052E RID: 1326
        // (get) Token: 0x06001BD1 RID: 7121 RVA: 0x000A4238 File Offset: 0x000A2438
        public int startCdTime
        {
            get
            {
                return this.start_cd_time;
            }
        }

        // Token: 0x1700052F RID: 1327
        // (get) Token: 0x06001BD2 RID: 7122 RVA: 0x000A4268 File Offset: 0x000A2468
        public int targetSelectAi
        {
            get
            {
                return this.target_select_ai;
            }
        }

        // Token: 0x17000530 RID: 1328
        // (get) Token: 0x06001BD3 RID: 7123 RVA: 0x000A4298 File Offset: 0x000A2498
        public int targetLost
        {
            get
            {
                return this.target_lost;
            }
        }

        // Token: 0x17000531 RID: 1329
        // (get) Token: 0x06001BD4 RID: 7124 RVA: 0x000A42C8 File Offset: 0x000A24C8
        public int actionId
        {
            get
            {
                return this.action_id;
            }
        }

        // Token: 0x17000532 RID: 1330
        // (get) Token: 0x06001BD5 RID: 7125 RVA: 0x000A42F8 File Offset: 0x000A24F8
        public int fairyConsumption
        {
            get
            {

                return this.consumption;
            }
        }

        // Token: 0x17000533 RID: 1331
        // (get) Token: 0x06001BD6 RID: 7126 RVA: 0x000A4328 File Offset: 0x000A2528
        public int buffDelay
        {
            get
            {
                return this.buff_delay;
            }
        }

        // Token: 0x17000534 RID: 1332
        // (get) Token: 0x06001BD7 RID: 7127 RVA: 0x000A4358 File Offset: 0x000A2558
        public bool isFormAction
        {
            get
            {
                return (int)this.is_form_action == 1;
            }
        }

        // Token: 0x17000535 RID: 1333
        // (get) Token: 0x06001BD8 RID: 7128 RVA: 0x000A438C File Offset: 0x000A258C
        public bool isSwitch
        {
            get
            {
                return (int)this.is_switch == 1;
            }
        }

        // Token: 0x17000536 RID: 1334
        // (get) Token: 0x06001BD9 RID: 7129 RVA: 0x000A43C0 File Offset: 0x000A25C0
        public bool isReTarget
        {
            get
            {
                return (int)this.is_re_target == 1;
            }
        }

        // Token: 0x17000537 RID: 1335
        // (get) Token: 0x06001BDA RID: 7130 RVA: 0x000A43F4 File Offset: 0x000A25F4
        public bool isMindupdate
        {
            get
            {
                return (int)this.is_mindupdate == 1;
            }
        }

        // Token: 0x17000538 RID: 1336
        // (get) Token: 0x06001BDB RID: 7131 RVA: 0x000A4428 File Offset: 0x000A2628
        public bool isRare
        {
            get
            {
                return (int)this.is_rare == 1;
            }
        }

        // Token: 0x17000539 RID: 1337
        // (get) Token: 0x06001BDC RID: 7132 RVA: 0x000A445C File Offset: 0x000A265C
        public string prefixName
        {
            get
            {

                return this.passive_name;
            }
        }

        // Token: 0x1700053A RID: 1338
        // (get) Token: 0x06001BDD RID: 7133 RVA: 0x000A4498 File Offset: 0x000A2698
        public string prefixNameColored
        {
            get
            {
                return (!this.isRare) ? this.passive_name : ("<color=#FFB400FF>" + this.passive_name + "</color>");
            }
        }

        // Token: 0x06001BDE RID: 7134 RVA: 0x000A4504 File Offset: 0x000A2704
        public override void InitData()
        {
            string text = this.buff_id_target;
            string[] array = text.Split(new char[]
            {
            ','
            });
            this.buffTarget = new List<int>();
            this.buffTargetNum = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                string[] array2 = array[i].Split(new char[]
                {
                ':'
                });
                int item = 0;
                int num = 0;
                if (array2.Length > 1 && int.TryParse(array2[0], out item))
                {
                    this.buffTarget.Add(item);
                    this.buffTargetNum.Add((!int.TryParse(array2[1], out num)) ? 0 : num);
                }
            }
            text = this.buff_id_self;
            array = text.Split(new char[]
            {
            ','
            });
            this.buffSelf = new List<int>();
            this.buffSelfNum = new List<int>();
            for (int j = 0; j < array.Length; j++)
            {
                string[] array3 = array[j].Split(new char[]
                {
                ':'
                });
                int item2 = 0;
                int num2 = 0;
                if (array3.Length > 1 && int.TryParse(array3[0], out item2))
                {
                    this.buffSelf.Add(item2);
                    this.buffSelfNum.Add((!int.TryParse(array3[1], out num2)) ? 0 : num2);
                }
            }
            //this._duration = this.skill_duration;
            string text2 = this.data_pool_1;
            if (text2.Length > 0)
            {
                string[] array4 = text2.Split(new char[]
                {
                ','
                });
                this.dataPool1 = new float[array4.Length];
                float num3 = 0f;
                for (int k = 0; k < array4.Length; k++)
                {
                    if (float.TryParse(array4[k], out num3))
                    {
                        this.dataPool1[k] = num3;
                    }
                    else
                    {
                        this.dataPool1[k] = 0f;
                        new Log().systemInit("技能数值池1中错误的数值:" + k).coreInfo();
                    }
                }
            }
            text2 = this.data_pool_2;
            if (text2.Length > 0)
            {
                string[] array5 = text2.Split(new char[]
                {
                ','
                });
                this.dataPool2 = new float[array5.Length];
                float num4 = 0f;
                for (int l = 0; l < array5.Length; l++)
                {
                    if (float.TryParse(array5[l], out num4))
                    {
                        this.dataPool2[l] = num4;
                    }
                    else
                    {
                        this.dataPool2[l] = 0f;
                        new Log().systemInit("技能数值池2中错误的数值:" + 1).coreInfo();

                    }
                }
            }
            text2 = this.night_data_pool_1;
            if (text2.Length > 0)
            {
                string[] array6 = text2.Split(new char[]
                {
                ','
                });
                this.dataPoolNight1 = new float[array6.Length];
                float num5 = 0f;
                for (int m = 0; m < array6.Length; m++)
                {
                    if (float.TryParse(array6[m], out num5))
                    {
                        this.dataPoolNight1[m] = num5;
                    }
                    else
                    {
                        this.dataPoolNight1[m] = 0f;
                        new Log().systemInit("技能夜战数值池1中错误的数值:" + m).coreInfo();
                    }
                }
            }
            text2 = this.night_data_pool_2;
            if (text2.Length > 0)
            {
                string[] array7 = text2.Split(new char[]
                {
                ','
                });
                this.dataPoolNight2 = new float[array7.Length];
                float num6 = 0f;
                for (int n = 0; n < array7.Length; n++)
                {
                    if (float.TryParse(array7[n], out num6))
                    {
                        this.dataPoolNight2[n] = num6;
                    }
                    else
                    {
                        this.dataPoolNight2[n] = 0f;
                        new Log().systemInit("技能夜战数值池2中错误的数值:" + n).coreInfo();
                    }
                }
            }
            string[] array8 = this.trigger_id.Split(new char[]
            {
            ','
            });
            this.triggerIds = new int[array8.Length];
            for (int num7 = 0; num7 < array8.Length; num7++)
            {
                if (!int.TryParse(array8[num7], out this.triggerIds[num7]))
                {
                    new Log().systemInit(string.Format("battle_skill_config trigger_id错误 id: {0}, trigger_id: {1}", this.id, this.trigger_id)).coreInfo();
                    this.triggerIds[num7] = 0;
                }
            }
            string[] array9 = this.sppool_trigger_id.Split(new char[]
            {
            ','
            });
            this.spTriggerIds = new int[array9.Length];
            for (int num8 = 0; num8 < array9.Length; num8++)
            {
                int num9 = 0;
                if (int.TryParse(array9[num8], out num9))
                {
                    this.spTriggerIds[num8] = num9;
                }
            }
            text2 = this.sp_data_pool_1;
            if (text2.Length > 0)
            {
                string[] array10 = text2.Split(new char[]
                {
                ','
                });
                this.spDataPool1 = new float[array10.Length];
                float num10 = 0f;
                for (int num11 = 0; num11 < array10.Length; num11++)
                {
                    if (float.TryParse(array10[num11], out num10))
                    {
                        this.spDataPool1[num11] = num10;
                    }
                    else
                    {
                        this.spDataPool1[num11] = 0f;
                        new Log().systemInit("技能条件数值池1中错误的数值:" + num11).coreInfo();
                    }
                }
            }
            text2 = this.sp_data_pool_2;
            if (text2.Length > 0)
            {
                string[] array11 = text2.Split(new char[]
                {
                ','
                });
                this.spDataPool2 = new float[array11.Length];
                float num12 = 0f;
                for (int num13 = 0; num13 < array11.Length; num13++)
                {
                    if (float.TryParse(array11[num13], out num12))
                    {
                        this.spDataPool2[num13] = num12;
                    }
                    else
                    {
                        this.spDataPool2[num13] = 0f;
                        new Log().systemInit("技能条件数值池2中错误的数值:" + num13).coreInfo();
                    }
                }
            }
            string skin_action = this.skin_action;
            if (skin_action.Length > 0)
            {
                string[] array12 = skin_action.Split(new char[]
                {
                ','
                });
                if (array12.Length > 0)
                {
                    this.dicSkinAction = new Dictionary<int, int>();
                    for (int num14 = 0; num14 < array12.Length; num14++)
                    {
                        string[] array13 = array12[num14].Split(new char[]
                        {
                        ':'
                        });
                        int key = 0;
                        int value = 0;
                        if (array13.Length > 1 && int.TryParse(array13[0], out key) && int.TryParse(array13[1], out value))
                        {
                            this.dicSkinAction.Add(key, value);
                        }
                    }
                }
            }
        }

        // Token: 0x1700053B RID: 1339
        // (get) Token: 0x06001BDF RID: 7135 RVA: 0x000A4BD0 File Offset: 0x000A2DD0
        // (set) Token: 0x06001BE0 RID: 7136 RVA: 0x000A4C0C File Offset: 0x000A2E0C
        public string lvupDescription
        {
            get
            {

                return this.lvup_description;
            }
            set
            {
                this.lvup_description = value;
            }
        }

        // Token: 0x1700053C RID: 1340
        // (get) Token: 0x06001BE1 RID: 7137 RVA: 0x000A4C40 File Offset: 0x000A2E40
        public string skillCd
        {
            get
            {
                return cdTime.ToString();
            }
        }

        // Token: 0x06001BE2 RID: 7138 RVA: 0x000A4C8C File Offset: 0x000A2E8C
        public long GetID()
        {
            return (long)this.id;
        }

        // Token: 0x06001BE3 RID: 7139 RVA: 0x000A4CC0 File Offset: 0x000A2EC0
        public bool IsActiveSkill()
        {
            return this.type == 1;
        }

        // Token: 0x06001BE4 RID: 7140 RVA: 0x000A4CF4 File Offset: 0x000A2EF4
        public bool IsCommonSkill()
        {
            return this.type == 3;
        }

        // Token: 0x06001BE5 RID: 7141 RVA: 0x000A4D28 File Offset: 0x000A2F28


        // Token: 0x04002570 RID: 9584
        private int _duration;

        // Token: 0x04002571 RID: 9585
        public float[] dataPool1;

        // Token: 0x04002572 RID: 9586
        public float[] dataPool2;

        // Token: 0x04002573 RID: 9587
        public float[] dataPoolNight1;

        // Token: 0x04002574 RID: 9588
        public float[] dataPoolNight2;

        // Token: 0x04002575 RID: 9589
        public float[] spDataPool1;

        // Token: 0x04002576 RID: 9590
        public float[] spDataPool2;

        // Token: 0x04002577 RID: 9591
        public int[] triggerIds;

        // Token: 0x04002578 RID: 9592
        public int[] spTriggerIds;

        // Token: 0x04002579 RID: 9593
        public List<int> buffTarget;

        // Token: 0x0400257A RID: 9594
        public List<int> buffTargetNum;

        // Token: 0x0400257B RID: 9595
        public List<int> buffSelf;

        // Token: 0x0400257C RID: 9596
        public List<int> buffSelfNum;

        // Token: 0x0400257D RID: 9597
        public Dictionary<int, int> dicSkinAction;

















    }
}
