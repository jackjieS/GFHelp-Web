using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class MailList
    {
        public void Read(dynamic jsonobj)
        {
            dicMail.Clear();

            foreach (var item in jsonobj)
            {
                MailList ml = new MailList();
                try
                {
                    ml.id = Convert.ToInt32(item.id);
                    ml.user_id = Convert.ToInt32(item.user_id);
                    ml.type = Convert.ToInt32(item.type);
                    ml.sub_id = Convert.ToInt32(item.sub_id);
                    ml.user_exp = Convert.ToInt32(item.user_exp);
                    ml.mp = Convert.ToInt32(item.mp);
                    ml.ammo = Convert.ToInt32(item.ammo);
                    ml.mre = Convert.ToInt32(item.mre);
                    ml.part = Convert.ToInt32(item.part);
                    ml.core = Convert.ToInt32(item.core);
                    ml.gem = Convert.ToInt32(item.gem);
                    ml.gun_id = Convert.ToInt32(item.gun_id);
                    ml.item_ids = item.item_ids.ToString();
                    ml.equip_ids = item.equip_ids.ToString();
                    ml.furniture = item.furniture.ToString();
                    ml.gift = item.gift.ToString();
                    ml.coins = item.coins.ToString();
                    ml.skin = item.skin.ToString();
                    ml.title = item.title.ToString();
                    ml.content = item.content.ToString();
                    ml.code = item.code.ToString();
                    ml.start_time = Convert.ToInt32(item.start_time);
                    ml.end_time = Convert.ToInt32(item.end_time);
                    ml.if_read = Convert.ToInt32(item.if_read);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取maillist", e.ToString()).coreError();

                }
                dicMail.Add(dicMail.Count, ml);
            }
        }

        public Dictionary<int, MailList> dicMail = new Dictionary<int, MailList>();

        public int id;
        public int user_id;
        public int type;
        public int sub_id;
        public int user_exp;
        public int mp;
        public int ammo;
        public int mre;
        public int part;
        public int core;
        public int gem;
        public int gun_id;
        public string item_ids;
        public string equip_ids;
        public string furniture;
        public string gift;
        public string coins;
        public string skin;
        public string title;
        public string content;
        public string code;
        public int start_time;
        public int end_time;
        public int if_read;



    }
}
