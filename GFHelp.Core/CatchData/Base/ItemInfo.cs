using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class ItemInfo : StcItem, tBaseData
    {

        //public int UserAmount
        //{
        //    get
        //    {
        //        return GameData.GetItem(this.itemId);
        //    }
        //}


        //public string name
        //{
        //    get
        //    {
        //        return PLTable.Instance.GetTableLang(this.nameId);
        //    }
        //    set
        //    {
        //        this.nameId = value;
        //    }
        //}

        //public new string introduction
        //{
        //    get
        //    {
        //        return PLTable.Instance.GetTableLang(this.intrdouctionId);
        //    }
        //    set
        //    {
        //        this.intrdouctionId = value;
        //    }
        //}
        
        public long GetID()
        {
            return (long)this.itemId;
        }

        public override void InitData()
        {
            this.itemId = this.id;
            this.nameId = this.item_name;
            //this.intrdouctionId = this.introduction;
            this.arg = Convert.ToInt32(this.arg);
        }

        public int itemId;

        // Token: 0x04001935 RID: 6453
        private string nameId;

        // Token: 0x04001936 RID: 6454
        private string intrdouctionId;

        // Token: 0x04001937 RID: 6455
        public new int arg;
    }

}
