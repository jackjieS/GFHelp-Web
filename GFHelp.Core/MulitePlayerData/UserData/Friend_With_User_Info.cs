using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Friend_With_User_Info
    {
        public Dictionary<int, Data> dicFriend = new Dictionary<int, Data>();


        public bool Read(dynamic jsonobj)
        {
            dicFriend.Clear();

            foreach (var item in jsonobj.friend_with_user_info)
            {
                Data data = new Data();
                try
                {
                    data.type = Convert.ToInt32(item.type);
                    data.f_userid = Convert.ToInt32(item.f_userid);
                    data.name = item.name.ToString();
                    data.lv = Convert.ToInt32(item.lv);
                    data.headpic_id = Convert.ToInt32(item.headpic_id);
                    data.homepage_time = Convert.ToInt32(item.homepage_time);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_friend_with_user_info遇到错误", e.ToString()).coreError();

                    continue;
                }

                dicFriend.Add(dicFriend.Count, data);
            }

            return true;
        }

        public class Data
        {
            public int type;
            public int f_userid;
            public string name;
            public int lv;
            public int headpic_id;
            public int homepage_time;
        }



    }

}
