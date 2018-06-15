using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class User_Record
    {
        public bool Read(dynamic jsonobj)
        {
            try
            {
                user_id = Convert.ToInt32(jsonobj.user_record.user_id);
                mission_campaign = Convert.ToInt32(jsonobj.user_record.mission_campaign);
                special_mission_campaign = jsonobj.user_record.special_mission_campaign.ToString();
                attendance_type1_day = Convert.ToInt32(jsonobj.user_record.attendance_type1_day);
                attendance_type1_time = Convert.ToInt32(jsonobj.user_record.attendance_type1_time);
                attendance_type2_day = Convert.ToInt32(jsonobj.user_record.attendance_type2_day);
                attendance_type2_time = Convert.ToInt32(jsonobj.user_record.attendance_type2_time);
                develop_lowrank_count = Convert.ToInt32(jsonobj.user_record.develop_lowrank_count);
                special_develop_lowrank_count = Convert.ToInt32(jsonobj.user_record.special_develop_lowrank_count);
                get_gift_ids = jsonobj.user_record.get_gift_ids.ToString();
                spend_point = Convert.ToDouble(jsonobj.user_record.spend_point);
                gem_mall_ids = jsonobj.user_record.gem_mall_ids.ToString();
                product_type21_ids = jsonobj.user_record.product_type21_ids.ToString();
                seven_attendance_days = jsonobj.user_record.seven_attendance_days.ToString();
                last_bp_buy_time = Convert.ToInt32(jsonobj.user_record.last_bp_buy_time);
                bp_buy_count = Convert.ToInt32(jsonobj.user_record.bp_buy_count);
                new_developgun_count = Convert.ToInt32(jsonobj.user_record.new_developgun_count);
                buyitem1_developgun_count = Convert.ToDouble(jsonobj.user_record.buyitem1_developgun_count);
                buyitem1_specialdevelopgun_count = Convert.ToDouble(jsonobj.user_record.buyitem1_specialdevelopgun_count);
                buyitem1_num = Convert.ToInt32(jsonobj.user_record.buyitem1_num);
                last_developgun_time = Convert.ToInt32(jsonobj.user_record.last_developgun_time);
                last_specialdevelopgun_time = Convert.ToInt32(jsonobj.user_record.last_specialdevelopgun_time);
                furniture_classes = jsonobj.user_record.furniture_classes.ToString();
                adjutant = jsonobj.user_record.adjutant.ToString();
            }
            catch (Exception e)
            {
                SysteOthers.Log log = new SysteOthers.Log(1, "读取UserData_user_info遇到错误", e.ToString());
                SysteOthers.Viewer.Logs.Add(log);
                return false;
            }
            return true;
        }


        public int user_id;
        public int mission_campaign;
        public string special_mission_campaign;
        public int attendance_type1_day;
        public int attendance_type1_time;
        public int attendance_type2_day;
        public int attendance_type2_time;
        public int develop_lowrank_count;
        public int special_develop_lowrank_count;
        public string get_gift_ids;
        public double spend_point;
        public string gem_mall_ids;
        public string product_type21_ids;
        public string seven_attendance_days;
        public int last_bp_buy_time;
        public int bp_buy_count;
        public int new_developgun_count;
        public double buyitem1_developgun_count;
        public double buyitem1_specialdevelopgun_count;
        public int buyitem1_num;
        public int last_developgun_time;
        public int last_specialdevelopgun_time;
        public string furniture_classes;
        public string adjutant;

    }


}
