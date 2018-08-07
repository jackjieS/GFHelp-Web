using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Item_With_User_Info
    {

        public Item_With_User_Info(UserData userData)
        {
            this.userData = userData;
        }


        public void Read(dynamic jsonobj)
        {
            dicItem.Clear();
            foreach (var item in jsonobj.item_with_user_info)
            {
                Data iwui = new Data();
                try
                {
                    iwui.item_id = Convert.ToInt32(item.item_id);
                    iwui.number = Convert.ToInt32(item.number);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_item_with_user_info", e.ToString()).coreError();
                }
                finally
                {
                    dicItem.Add(iwui.item_id, iwui);
                }

            }
        }


        private UserData userData;
        public class Data
        {
            public int item_id;
            public int number;
        }
        public Dictionary<int, Data> dicItem = new Dictionary<int, Data>();
        public int Battery
        {
            get
            {
                if(dicItem.ContainsKey(506))
                {
                    return dicItem[506].number;
                }
                return 0;
            }
            set
            {
                if(dicItem.ContainsKey(506))
                {
                    dicItem[506].number = value;
                }
                else
                {
                    Data iwui = new Data();
                    iwui.number = value;
                    iwui.item_id = 506;
                    dicItem.Add(506, iwui);
                }

            }

        }
        public int globalFreeExp
        {
            get
            {
                if (dicItem.ContainsKey(507))
                {
                    return dicItem[507].number;
                }
                return 0;
            }
            set
            {
                if (dicItem.ContainsKey(507))
                {
                    dicItem[507].number = value;
                }
                else
                {
                    Data iwui = new Data();
                    iwui.number = value;
                    iwui.item_id = 507;
                    dicItem.Add(507, iwui);
                }

            }
        }





    }



}
