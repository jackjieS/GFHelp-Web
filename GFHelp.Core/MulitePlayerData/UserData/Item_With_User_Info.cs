using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Item_With_User_Info
    {
        public Dictionary<int, Item_With_User_Info> dicItem = new Dictionary<int, Item_With_User_Info>();
        public int item_id;
        public int number;

        public void Read(dynamic jsonobj)
        {
            dicItem.Clear();

            foreach (var item in jsonobj.item_with_user_info)
            {
                Item_With_User_Info iwui = new Item_With_User_Info();
                try
                {
                    iwui.item_id = Convert.ToInt32(item.item_id);
                    iwui.number = Convert.ToInt32(item.number);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_item_with_user_info", e.ToString()).coreError();

                    continue;
                }
                dicItem.Add(dicItem.Count, iwui);
            }
        }


    }



}
