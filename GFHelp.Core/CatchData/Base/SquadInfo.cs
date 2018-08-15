using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadInfo : StcSquad, tBaseData
    {
        public SquadInfo()
        {

        }
        public long GetID()
        {
            return (long)this.id;
        }
        //public string name;
        //{
        //    get
        //    {
        //        return this.name;
        //    }
        //    set
        //    {
        //        this.name = value;
        //    }
        //}
        //public string enName
        //{
        //    get
        //    {
        //        return this.en_name;
        //    }
        //}
        //public string typeName;
        //{
        //    get
        //    {
        //        return this.typeInfo.name;
        //    }
        //}
        //public string typeEnName;
        //{
        //    get
        //    {

        //        return this.typeInfo.en_name;
        //    }
        //}

        //public string categoryName;
        //{
        //    get
        //    {
        //        return this.typeInfo.class_name;
        //    }
        //}
        //public string categoryEnName;
        //{
        //    get
        //    {
        //        return this.typeInfo.class_en_name;
        //    }
        //}
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
        public int popcost
        {
            get
            {
                return this.population;
            }
        }
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
                    new Log().systemInit("获取类型有误" + this.type).coreInfo();
                }
                return this._infoType;
            }
        }
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
        public static string GetCategoryCnName(SquadInfoCategory type2)
        {
            SquadInfoCategory type = type2;
            SquadInfo squadInfo = GameData.listSquadInfo.Find((SquadInfo sq) => sq.infoType == type);
            if (squadInfo == null)
            {
                return string.Empty;
            }
            return squadInfo.typeInfo.class_name;
        }
        public static string GetCategoryEnName(SquadInfoCategory type2)
        {
            SquadInfoCategory type = type2;
            SquadInfo squadInfo = GameData.listSquadInfo.Find((SquadInfo sq) => sq.infoType == type);
            if (squadInfo == null)
            {
                return string.Empty;
            }
            return squadInfo.typeInfo.class_en_name;
        }

        // Token: 0x0400443A RID: 17466
        public string destroyBuildSkill;

        // Token: 0x0400443B RID: 17467
        public string rebuildBuildSkill;

        // Token: 0x0400443C RID: 17468
        public int battleSkillRangeMin;

        // Token: 0x0400443D RID: 17469
        public int battleSkillRangeMax;

        // Token: 0x0400443E RID: 17470
        public int[] aiIds;

        // Token: 0x0400443F RID: 17471
        public TeamBelong belongDefult = TeamBelong.friendly;

        // Token: 0x04004440 RID: 17472
        private SquadInfoCategory _infoType;

        // Token: 0x04004441 RID: 17473
        private SquadTypeInfo _type;



















    }
    public enum SquadInfoCategory
    {
        // Token: 0x04004436 RID: 17462
        none,
        // Token: 0x04004437 RID: 17463
        fireTeam,
        // Token: 0x04004438 RID: 17464
        carrier,
        // Token: 0x04004439 RID: 17465
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
