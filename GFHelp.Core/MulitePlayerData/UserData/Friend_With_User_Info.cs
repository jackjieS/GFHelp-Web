using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Friend_With_User_Info
    {
        public Dictionary<int, Friend_With_User_Info> dicFriend = new Dictionary<int, Friend_With_User_Info>();
        public int type;
        public int f_userid;
        public string name;
        public int lv;
        public int headpic_id;
        public int homepage_time;

        public bool Read(dynamic jsonobj)
        {
            dicFriend.Clear();

            foreach (var item in jsonobj.friend_with_user_info)
            {
                Friend_With_User_Info fwui = new Friend_With_User_Info();
                try
                {
                    fwui.type = Convert.ToInt32(item.type);
                    fwui.f_userid = Convert.ToInt32(item.f_userid);
                    fwui.name = item.name.ToString();
                    fwui.lv = Convert.ToInt32(item.lv);
                    fwui.headpic_id = Convert.ToInt32(item.headpic_id);
                    fwui.homepage_time = Convert.ToInt32(item.homepage_time);
                }
                catch (Exception e)
                {
                    SysteOthers.Log log = new SysteOthers.Log(1, "读取UserData_friend_with_user_info遇到错误", e.ToString());
                    SysteOthers.Viewer.Logs.Add(log);
                    continue;
                }

                dicFriend.Add(dicFriend.Count, fwui);
            }

            return true;
        }



    }

}
