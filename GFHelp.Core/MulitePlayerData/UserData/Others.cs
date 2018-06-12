using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Others
    {

        public bool Mission_S;
        public bool ClickGrilsFavor;

        public void Read(dynamic jsonobj)
        {
            ClickGrilsFavor = true;
            Mission_S = false;
            try
            {
                string data = jsonobj.mission_act_info.ToString();
                if (data.Length > 10)
                {
                    Mission_S = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }


        public int GlobalFreeExp(Item_With_User_Info i)
        {

            foreach (var item in i.dicItem)
            {
                if (item.Value.item_id == 507)
                {
                    return item.Value.number;
                }
            }
            return 0;
        }

        public void DeGolbalFreeExp(Item_With_User_Info i, int count)
        {
            for (int k = 0; k < i.dicItem.Count; k++)
            {
                if (i.dicItem[k].item_id == 507)
                {
                    i.dicItem[k].number = i.dicItem[k].number - count;
                }
            }
        }

        public int Battery(Item_With_User_Info i)
        {

            foreach (var item in i.dicItem)
            {
                if (item.Value.item_id == 506)
                {
                    return item.Value.number;
                }
            }
            return 0;
        }
        public void DeBattery(Item_With_User_Info i, int count)
        {
            for (int k = 0; k < i.dicItem.Count; k++)
            {
                if (i.dicItem[k].item_id == 506)
                {
                  i.dicItem[k].number =i.dicItem[k].number - count;
                }
            }
        }

        public bool CheckGunStatus(Operation_Act_Info o,Auto_Mission_Act_Info a, Upgrade_Act_Info u, Gun_With_User_Info gwui)
        {
            //是否在后勤 自律 训练
            foreach (var x in o.dicOperation)
            {
                if (x.Value.team_id == gwui.team_id)
                {
                    return true;
                }

            }
            if (a.team_ids.Contains(gwui.team_id)) return true;
            foreach (var y in u.dic_Upgrade)
            {
                if (y.Value.gun_with_user_id == gwui.id) return true;
            }
            return false;
        }



    }

}
