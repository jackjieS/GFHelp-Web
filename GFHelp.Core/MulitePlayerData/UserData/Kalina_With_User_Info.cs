using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Kalina_With_User_Info
    {
        public int user_id;
        public int click_num;
        public int click_time;
        public int level;
        public int favor;
        public int last_favor;
        public int skin;
        public int send_mail_time;

        public bool Read(dynamic jsonobj)
        {
            try
            {
                user_id = Convert.ToInt32(jsonobj.kalina_with_user_info.user_id);
                click_num = Convert.ToInt32(jsonobj.kalina_with_user_info.click_num);
                click_time = Convert.ToInt32(jsonobj.kalina_with_user_info.click_time);
                level = Convert.ToInt32(jsonobj.kalina_with_user_info.level);
                favor = Convert.ToInt32(jsonobj.kalina_with_user_info.favor);
                last_favor = Convert.ToInt32(jsonobj.kalina_with_user_info.last_favor);
                skin = Convert.ToInt32(jsonobj.kalina_with_user_info.skin);
                send_mail_time = Convert.ToInt32(jsonobj.kalina_with_user_info.send_mail_time);
            }
            catch (Exception e)
            {
                new Log().systemInit("读取UserData_kalina_with_user_info", e.ToString()).coreError();
                return false;
            }


            return true;
        }

    }
}
