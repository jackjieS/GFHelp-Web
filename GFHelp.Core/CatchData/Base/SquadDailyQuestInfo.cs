using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadDailyQuestInfo : StcSquad_data_daily, tBaseData
    {
        public SquadDailyQuestInfo()
        {

        }

        // Token: 0x06002438 RID: 9272 RVA: 0x000EE254 File Offset: 0x000EC454
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x1700077C RID: 1916
        // (get) Token: 0x06002439 RID: 9273 RVA: 0x000EE288 File Offset: 0x000EC488
        //public new string title
        //{
        //    get
        //    {

        //        return this.title;
        //    }
        //}

        //// Token: 0x1700077D RID: 1917
        //// (get) Token: 0x0600243A RID: 9274 RVA: 0x000EE2C4 File Offset: 0x000EC4C4
        //public new string content
        //{
        //    get
        //    {
        //        return this.content;
        //    }
        //}

        // Token: 0x0600243B RID: 9275 RVA: 0x000EE300 File Offset: 0x000EC500
        public override void InitData()
        {

            string[] array = this.prize.Split(new char[]
            {
            ','
            });
            if (array.Length < 2 || !int.TryParse(array[0], out this.dataNum[0]) || !int.TryParse(array[1], out this.dataNum[1]))
            {
                new Log().systemInit(string.Format("error prize in squad_data_daily id: {0}, prize: {1}", this.id, this.prize)).coreInfo();
            }
        }

        // Token: 0x0400447A RID: 17530
        public int[] dataNum = new int[2];
    }
}
