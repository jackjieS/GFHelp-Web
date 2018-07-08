using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Outhouse_Establish_Info
    {
        private static Dictionary<int, Outhouse_Establish_Info> dicEstablish = new Dictionary<int, Outhouse_Establish_Info>();

        public int id;
        public int user_id;
        public int room_id;
        public int establish_id;
        public int establish_type;
        public int furniture_id;
        public int upgrade_establish_id;
        public int upgrade_starttime;
        public int build_starttime;
        public int build_num;
        public string build_tmp_data;
        public int build_get_time;
        public int update_furniture_id;
        public int furniture_postion;
        public int establish_lv;
        public int upgrade_coin;
        public int upgrade_time;
        public int upgrade_condition;
        public int parameter_1;
        public int parameter_2;
        public int parameter_3;

        public bool Read(dynamic jsonobj)
        {
            dicEstablish.Clear();

            foreach (var item in jsonobj.outhouse_establish_info)
            {
                Outhouse_Establish_Info oei = new Outhouse_Establish_Info();
                try
                {
                    oei.id = Convert.ToInt32(item.id);
                    oei.user_id = Convert.ToInt32(item.user_id);
                    oei.room_id = Convert.ToInt32(item.room_id);
                    oei.establish_id = Convert.ToInt32(item.establish_id);
                    oei.establish_type = Convert.ToInt32(item.establish_type);
                    oei.furniture_id = Convert.ToInt32(item.furniture_id);
                    oei.upgrade_establish_id = Convert.ToInt32(item.upgrade_establish_id);
                    oei.upgrade_starttime = Convert.ToInt32(item.upgrade_starttime);
                    oei.build_starttime = Convert.ToInt32(item.build_starttime);
                    oei.build_num = Convert.ToInt32(item.build_num);
                    if (item.build_tmp_data != null)
                    {
                        oei.build_tmp_data = item.build_tmp_data.ToString();
                    }

                    oei.build_get_time = Convert.ToInt32(item.build_get_time);
                    oei.update_furniture_id = Convert.ToInt32(item.update_furniture_id);
                    //oei.furniture_postion = Convert.ToInt32(item.furniture_postion);
                    oei.establish_lv = Convert.ToInt32(item.establish_lv);
                    oei.upgrade_coin = Convert.ToInt32(item.upgrade_coin);
                    oei.upgrade_time = Convert.ToInt32(item.upgrade_time);
                    //oei.upgrade_condition = Convert.ToInt32(item.upgrade_condition);
                    int.TryParse(item.parameter_1.ToString(), out oei.parameter_1);
                    int.TryParse(item.parameter_2.ToString(), out oei.parameter_2);
                    int.TryParse(item.parameter_3.ToString(), out oei.parameter_3);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_Establish", e.ToString()).coreError();

                    continue;
                }
                dicEstablish.Add(oei.establish_type, oei);
            }
            return true;
        }

        public int Furniture_database
        {
            get
            {
                return dicEstablish[204].parameter_1;
            }
        }

        public int Furniture_printer
        {
            get
            {
                return dicEstablish[206].parameter_1;
            }
        }
        public int Furniture_server
        {
            get
            {
                return dicEstablish[205].parameter_1;
            }
        }

    }
}
