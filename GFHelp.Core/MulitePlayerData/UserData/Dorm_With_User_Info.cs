using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    /// <summary>
    /// 主要用途: 获取电池 
    /// </summary>
    public class Dorm_With_User_Info
    {
        public void Read(dynamic jsonobj)
        {
            try
            {
                info.dorm_id = jsonobj.info.dorm_id.ToString();
                info.praise_num = jsonobj.info.praise_num.ToString();
                info.user_id = jsonobj.info.user_id.ToString();
                info.visit_num = jsonobj.info.visit_num.ToString();
                current_build_coin = Convert.ToInt32(jsonobj.current_build_coin);
                build_coin_flag = Convert.ToInt32(jsonobj.build_coin_flag);
            }
            catch (Exception e)
            {
                new Log().systemInit("读取DormData遇到错误", e.ToString()).coreError();
            }
        }
        public info info = new info();
        public int current_build_coin;
        public int build_coin_flag;

    }

    public class info
    {
        public string praise_num;
        public string visit_num;
        public string user_id;//记录这个
        public string dorm_id;//记录这个
    }
}
