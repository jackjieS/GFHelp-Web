using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class ItemInfo : StcItem, tBaseData
    {
        // Token: 0x060017FB RID: 6139 RVA: 0x000AF9E0 File Offset: 0x000ADBE0
        public ItemInfo()
        {
        }

        // Token: 0x170005DB RID: 1499
        // (get) Token: 0x060017FC RID: 6140 RVA: 0x000AFA10 File Offset: 0x000ADC10
        //public int UserAmount
        //{
        //    get
        //    {

        //        return GameData.GetItem(this.itemId);
        //    }
        //}

        // Token: 0x170005DC RID: 1500
        // (get) Token: 0x060017FD RID: 6141 RVA: 0x000AFA48 File Offset: 0x000ADC48
        // (set) Token: 0x060017FE RID: 6142 RVA: 0x000AFA84 File Offset: 0x000ADC84
        public string name
        {
            get
            {
                return this.nameId;
                //return PLTable.Instance.GetTableLang(this.nameId);
            }
            set
            {

                this.nameId = value;
            }
        }

        // Token: 0x170005DD RID: 1501
        // (get) Token: 0x060017FF RID: 6143 RVA: 0x000AFAB8 File Offset: 0x000ADCB8
        // (set) Token: 0x06001800 RID: 6144 RVA: 0x000AFAF4 File Offset: 0x000ADCF4
        public new string introduction
        {
            get
            {

                return this.intrdouctionId;

                //return PLTable.Instance.GetTableLang(this.intrdouctionId);
            }
            set
            {

                this.intrdouctionId = value;
            }
        }

        // Token: 0x06001801 RID: 6145 RVA: 0x000AFB28 File Offset: 0x000ADD28
        public long GetID()
        {

            return (long)this.itemId;
        }

        // Token: 0x06001802 RID: 6146 RVA: 0x000AFB5C File Offset: 0x000ADD5C
        public override void InitData()
        {

            this.itemId = this.id;
            this.nameId = this.item_name;
            this.intrdouctionId = this.introduction;
            this.arg = Convert.ToInt32(this.arg);
            try
            {
                if (this.daily_limit != string.Empty)
                {
                    string[] array = this.daily_limit.Split(new char[]
                    {
                    ';'
                    });
                    this.active_daily_num = int.Parse(array[0]);
                    if (array.Length > 1)
                    {
                        this.normalactive_daily_num = int.Parse(array[1]);
                    }
                }
                if (this.initial_num != string.Empty)
                {
                    string[] array2 = this.initial_num.Split(new char[]
                    {
                    ';'
                    });
                    this.active_initial_num = int.Parse(array2[0]);
                    if (array2.Length > 1)
                    {
                        this.normalactive_initial_num = int.Parse(array2[1]);
                    }
                }
            }
            catch
            {
            }
        }

        // Token: 0x040026F1 RID: 9969
        public int itemId;

        // Token: 0x040026F2 RID: 9970
        private string nameId;

        // Token: 0x040026F3 RID: 9971
        private string intrdouctionId;

        // Token: 0x040026F4 RID: 9972
        public new int arg;

        // Token: 0x040026F5 RID: 9973
        public int active_daily_num;

        // Token: 0x040026F6 RID: 9974
        public int normalactive_daily_num;

        // Token: 0x040026F7 RID: 9975
        public int active_initial_num;

        // Token: 0x040026F8 RID: 9976
        public int normalactive_initial_num;


    }

}
