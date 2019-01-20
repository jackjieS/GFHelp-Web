using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadInfo : StcSquad, tBaseData
    {
        // Token: 0x06001D39 RID: 7481 RVA: 0x000E24D4 File Offset: 0x000E06D4
        public SquadInfo()
        {

        }

        // Token: 0x06001D3A RID: 7482 RVA: 0x000E250C File Offset: 0x000E070C
        public long GetID()
        {
            return (long)this.id;
        }

        // Token: 0x17000798 RID: 1944
        // (get) Token: 0x06001D3B RID: 7483 RVA: 0x000E2540 File Offset: 0x000E0740
        // (set) Token: 0x06001D3C RID: 7484 RVA: 0x000E257C File Offset: 0x000E077C
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

        // Token: 0x17000799 RID: 1945
        // (get) Token: 0x06001D3D RID: 7485 RVA: 0x000E25B0 File Offset: 0x000E07B0
        public string launchTime
        {
            get
            {

                return this.launch_time;
            }
        }

        // Token: 0x1700079A RID: 1946
        // (get) Token: 0x06001D3E RID: 7486 RVA: 0x000E25E8 File Offset: 0x000E07E8
        public string enName
        {
            get
            {
                return this.en_name;
            }
        }

        // Token: 0x1700079B RID: 1947
        // (get) Token: 0x06001D3F RID: 7487 RVA: 0x000E2624 File Offset: 0x000E0824
        public string typeName
        {
            get
            {

                return this.typeInfo.name;
            }
        }

        // Token: 0x1700079C RID: 1948
        // (get) Token: 0x06001D40 RID: 7488 RVA: 0x000E2664 File Offset: 0x000E0864
        public string typeEnName
        {
            get
            {

                return this.typeInfo.en_name;
            }
        }

        // Token: 0x1700079D RID: 1949
        // (get) Token: 0x06001D41 RID: 7489 RVA: 0x000E26A4 File Offset: 0x000E08A4
        public string categoryName
        {
            get
            {
                return this.typeInfo.class_name;
            }
        }

        // Token: 0x1700079E RID: 1950
        // (get) Token: 0x06001D42 RID: 7490 RVA: 0x000E26E4 File Offset: 0x000E08E4
        public string categoryEnName
        {
            get
            {
                return this.typeInfo.class_en_name;
            }
        }

        // Token: 0x1700079F RID: 1951
        // (get) Token: 0x06001D43 RID: 7491 RVA: 0x000E2724 File Offset: 0x000E0924
        public int nightView
        {
            get
            {
                return this.night_vision;
            }
        }

        // Token: 0x06001D44 RID: 7492 RVA: 0x000E2754 File Offset: 0x000E0954
        public override void InitData()
        {
            try
            {
                string[] array = this.battle_assist_range.Split(new char[]
                {
                ','
                });
                this.battleSkillRangeMin = int.Parse(array[0]);
                this.battleSkillRangeMax = int.Parse(array[1]);
            }
            catch
            {
            }
            string[] array2 = this.dorm_ai.Split(new char[]
            {
            ','
            });
            this.aiIds = new int[array2.Length];
            for (int i = 0; i < this.aiIds.Length; i++)
            {
                int.TryParse(array2[i], out this.aiIds[i]);
            }
        }

        // Token: 0x170007A0 RID: 1952
        // (get) Token: 0x06001D45 RID: 7493 RVA: 0x000E2820 File Offset: 0x000E0A20
        public int popcost
        {
            get
            {
                return this.population;
            }
        }

        // Token: 0x170007A1 RID: 1953
        // (get) Token: 0x06001D46 RID: 7494 RVA: 0x000E2850 File Offset: 0x000E0A50
        public SquadInfoCategory infoType
        {
            get
            {

                if (this._infoType == SquadInfoCategory.none)
                {
                    this._infoType = (SquadInfoCategory)Data.SquadCategory(this.type);
                }
                if (this._infoType == SquadInfoCategory.none)
                {
                    Console.WriteLine("获取类型有误" + this.type);
                }
                return this._infoType;
            }
        }

        // Token: 0x170007A2 RID: 1954
        // (get) Token: 0x06001D47 RID: 7495 RVA: 0x000E28C4 File Offset: 0x000E0AC4
        public SquadTypeInfo typeInfo
        {
            get
            {
                if (this._type == null)
                {
                    this._type = GameData.listSquadTypeInfo.GetDataById((long)this.type);
                }
                return this._type;
            }
        }

        // Token: 0x06001D48 RID: 7496 RVA: 0x000E2918 File Offset: 0x000E0B18
        public static string GetCategoryCnName(SquadInfoCategory type)
        {

            SquadInfo squadInfo = GameData.listSquadInfo.Find((SquadInfo sq) => sq.infoType == type);
            if (squadInfo == null)
            {
                Console.WriteLine("没有一个SquadInfo的InfoType是" + type);
                return string.Empty;
            }
            return squadInfo.typeInfo.class_name;
        }

        // Token: 0x06001D49 RID: 7497 RVA: 0x000E29A4 File Offset: 0x000E0BA4
        public static string GetCategoryEnName(SquadInfoCategory type)
        {
            SquadInfo squadInfo = GameData.listSquadInfo.Find((SquadInfo sq) => sq.infoType == type);
            if (squadInfo == null)
            {
                Console.WriteLine("没有一个SquadInfo的InfoType是" + type);
                return string.Empty;
            }
            return squadInfo.typeInfo.class_en_name;
        }

        // Token: 0x170007A3 RID: 1955
        // (get) Token: 0x06001D4A RID: 7498 RVA: 0x000E2A30 File Offset: 0x000E0C30
        public int costQuickFixNum
        {
            get
            {
                return (int)Data.GetDataFromStringArray<float>("squad_repair_cost", this.infoType - SquadInfoCategory.fireTeam, ',');
            }
        }




        // Token: 0x06001D4D RID: 7501 RVA: 0x000E2B8C File Offset: 0x000E0D8C
        public int GetAttributeValue(SquadAttriType attr)
        {

            switch (attr)
            {
                case SquadAttriType.assist_damage:
                    return this.assist_damage;
                case SquadAttriType.assist_def_break:
                    return this.assist_def_break;
                case SquadAttriType.assist_hit:
                    return this.assist_hit;
                case SquadAttriType.assist_reload:
                    return this.assist_reload;
                case SquadAttriType.atk_speed:
                    return this.atk_speed;
                case SquadAttriType.damage:
                    return this.damage;
                case SquadAttriType.hit:
                    return this.hit;
                case SquadAttriType.hp:
                    return this.hp;
            }
            return 0;
        }

        // Token: 0x04004174 RID: 16756
        public string destroyBuildSkill;

        // Token: 0x04004175 RID: 16757
        public string rebuildBuildSkill;

        // Token: 0x04004176 RID: 16758
        public int battleSkillRangeMin;

        // Token: 0x04004177 RID: 16759
        public int battleSkillRangeMax;

        // Token: 0x04004178 RID: 16760
        public int[] aiIds;

        // Token: 0x04004179 RID: 16761
        public TeamBelong belongDefult = TeamBelong.friendly;

        // Token: 0x0400417A RID: 16762
        private SquadInfoCategory _infoType;

        // Token: 0x0400417B RID: 16763
        private SquadTypeInfo _type;

        
    }



    public enum SquadInfoCategory
    {
        // Token: 0x04004170 RID: 16752
        none,
        // Token: 0x04004171 RID: 16753
        fireTeam,
        // Token: 0x04004172 RID: 16754
        carrier,
        // Token: 0x04004173 RID: 16755
        SF
    }
    public enum TeamBelong
    {
        // Token: 0x04002522 RID: 9506
        other,
        // Token: 0x04002523 RID: 9507
        friendly,
        // Token: 0x04002524 RID: 9508
        enemy
    }
}
