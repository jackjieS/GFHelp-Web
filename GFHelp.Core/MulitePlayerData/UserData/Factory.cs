﻿using Codeplex.Data;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GFHelp.Core.MulitePlayerData
{
    public class Factory
    {
        public Factory(UserData userData)
        {
            this.userData = userData;
        }
        UserData userData;


        public bool Eat_EquipHandle(Action.BattleBase.MissionInfo.Data data=null,int FoodNum=0)
        {
            //SELECT+1
            //选取需要升级的枪 done
            //选取狗粮 优先2级 done
            //发送请求         done
            //删除装备         done
            //经验++           done
            Thread.Sleep(2000);
            userData.webData.StatusBarText = "准备装备升级";
            userData.equip_With_User_Info.Read_Equipment_Upgrade();
            if (data != null && data.equipid != 0)
            {
                userData.equip_With_User_Info.Read_Equipment_Upgrade(data.equipid);
            }


            string result = "";
            for (int i = 0; i < userData.equip_With_User_Info.dicUpgrade.Count;)
            {
                long id = userData.equip_With_User_Info.dicUpgrade[i].id;
                int updateResult = Eat_Equip(id, ref result, FoodNum);
                if (updateResult == 1)
                {
                    JsonData jsonData = JsonMapper.ToObject(result);
                    int @int = jsonData["equip_add_exp"].Int;
                    userData.equip_With_User_Info.listEquip.GetDataById(id).equip_level +=  userData.equip_With_User_Info.listEquip.GetDataById(id).GetLevelToBeAdded(@int);
                    userData.equip_With_User_Info.listEquip.GetDataById(id).equip_exp += @int;
                    //删除装备
                    userData.equip_With_User_Info.Del_Equip_IN_Dict(userData.equip_With_User_Info.Get_Equipment_Food());
                    new Log().userInit(userData.GameAccount.GameAccountID, string.Format("装备强化 id {0}", userData.equip_With_User_Info.dicUpgrade[0].id.ToString())).userInfo();
                    return true;
                }
                if (updateResult == -1)
                {
                    i++;
                    continue;
                }
            }
            return true;
        }




        private int Eat_Equip(long id, ref string result,int equipFoodNum=0)
        {
            List<long> equipFood = new List<long>();
            equipFood = userData.equip_With_User_Info.Get_Equipment_Food();
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("equip_with_user_id");
            jsonWriter.Write(id);
            jsonWriter.WritePropertyName("food");
            jsonWriter.WriteArrayStart();
            if (equipFoodNum == 0)
            {
                foreach (var item in equipFood)
                {
                    jsonWriter.Write(item.ToString());
                }
            }
            else
            {
                for (int i = 0; i < equipFood.Count && i<equipFoodNum; i++)
                {
                    jsonWriter.Write(equipFood[i].ToString());
                }
            }

            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();
            int count = 0;
            while (true)
            {
                result = userData.Net.Factory.Eat_Equip(userData.GameAccount, sb.ToString());
                switch (userData.Response.Check( ref result, "Eat_Equip_Pro", true))
                {
                    case 1:
                        {
                            return 1;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "装备强化 ERROR", result).userInfo();
                                return -1;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public void Equip_retire()
        {
            int count = 0;
            while (true)
            {

                Thread.Sleep(2000);
                userData.webData.StatusBarText = "准备装备拆解";

                if (userData.equip_With_User_Info.listEquip.Count + 5 < userData.user_Info.maxequip)
                {
                    return;
                }
                List<long> equipFood = new List<long>();
                equipFood = userData.equip_With_User_Info.Get_Equipment_Food();

                if (equipFood.Count==0)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, " 没有2星3星装备 请整理装备").userInfo();
                }
                StringBuilder sb = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(sb);
                jsonWriter.WriteObjectStart();
                jsonWriter.WritePropertyName("equips");
                jsonWriter.WriteArrayStart();

                int i = 1;
                foreach (var equip in equipFood)
                {
                    if (i > 24) break;
                    jsonWriter.Write(equip.ToString());
                    i++;

                }

                jsonWriter.WriteArrayEnd();

                jsonWriter.WriteObjectEnd();

                string result = userData.Net.Factory.Equip_retire(userData.GameAccount, sb.ToString());

                switch (userData.Response.Check( ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            userData.equip_With_User_Info.Del_Equip_IN_Dict(equipFood);
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                userData.webData.StatusBarText = "Get_Set_UserInfo";
                                new Log().userInit(userData.GameAccount.GameAccountID, "装备强化 ERROR", result).userInfo();
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }










            }


        }

        /// <summary>
        /// 进行扩编
        /// </summary>
        public void CombineGun()
        {
            //if (!ProgrameData.AutoDummyLink) return;
            userData.webData.StatusBarText = "准备扩编";

            int count = 0;

            userData.gun_With_User_Info.Get_dicGun_Combine(userData.MissionInfo.getFirsDataTeamID());
            if (userData.gun_With_User_Info.dicGun_Combine.Count == 0) return;

            if (userData.user_Info.core <= userData.gun_With_User_Info.dicGun_Combine[0].Core_COMbineNeed) return;
            Thread.Sleep(2000);
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("gun_with_user_id");
            jsonWriter.Write(userData.gun_With_User_Info.dicGun_Combine[0].id);
            jsonWriter.WritePropertyName("combine");
            jsonWriter.WriteArrayStart();
            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();



            while (count++ <= userData.config.ErrorCount)
            {
                string result = userData.Net.Factory.combineGun(userData.GameAccount, sb.ToString());
                if (userData.Response.Check(ref result, "GUN_OUTandIN_Team_PRO", false) == 1)
                {
                    userData.user_Info.core -= userData.gun_With_User_Info.dicGun_Combine[0].Core_COMbineNeed;
                    userData.gun_With_User_Info.dicGun_Combine[0].number++;
                    new Log().userInit(userData.GameAccount.GameAccountID, string.Format("人形 : {0} 扩编", userData.gun_With_User_Info.dicGun_Combine[0].id)).userInfo();
                    return;
                }
                else
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "扩编出错", result).userInfo();
                }
            }
        }


        public int Gun_PowerUP(int id, ref string result,int retireGunNum=0)
        {

            Thread.Sleep(2000);
            if (userData.gun_With_User_Info.Get_Gun_Retire() == false)
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "没有2级枪 ERROR", result).userInfo();
                return 0;
            }
            //Gun_Retire
            int count = 0;

            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("gun_with_user_id");
            jsonWriter.Write(id);
            jsonWriter.WritePropertyName("item9_num");
            jsonWriter.Write(0);
            jsonWriter.WritePropertyName("food");
            jsonWriter.WriteArrayStart();
            if (retireGunNum == 0)
            {
                foreach (var item in userData.gun_With_User_Info.Rank2)
                {
                    jsonWriter.Write(item);
                }
            }
            else
            {
                for (int i = 0; i < userData.gun_With_User_Info.Rank2.Count && i < retireGunNum; i++)
                {
                    jsonWriter.Write(userData.gun_With_User_Info.Rank2[i]);
                }
            }

            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();

            while (true)
            {
                result =userData.Net.Factory.EatGun(userData.GameAccount,sb.ToString());


                switch (userData.Response.Check(ref result, "EatGun", true))
                {
                    case 1:
                        {
                            return 1;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "人形强化 ERROR", result).userInfo();
                                return -1;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }

        public bool EatGunHandle(int retireGunnum = 0)
        {
            Thread.Sleep(2000);
            userData.webData.StatusBarText = "准备人形强化";

            string result = "";
            userData.others.Get_dicGun_PowerUP();

            if (userData.gun_With_User_Info.dicGun_PowerUP.Count == 0) return false;

            for (int i = 0; i < userData.gun_With_User_Info.dicGun_PowerUP.Count();)
            {
                int intResult = Gun_PowerUP(userData.gun_With_User_Info.dicGun_PowerUP[i].id, ref result, retireGunnum);
                if (intResult==1)
                {
                    userData.gun_With_User_Info.Del_Gun_IN_Dict(2);
                }
                if(intResult == -1)
                {
                    i++;
                    continue;
                }

                JsonData jsonData = new JsonData();
                try
                {
                    jsonData = JsonMapper.ToObject(result);
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "人形强化 ERROR", e.ToString()).userInfo();
                }

                int additionPow = Convert.ToInt32((int)jsonData["pow"]);
                int additionHit = Convert.ToInt32((int)jsonData["hit"]);
                int additionDodge = Convert.ToInt32((int)jsonData["dodge"]);
                int additionRate = Convert.ToInt32((int)jsonData["rate"]);

                userData.gun_With_User_Info.dicGun_PowerUP[i].additionPow = additionPow;
                userData.gun_With_User_Info.dicGun_PowerUP[i].additionHit = additionHit;
                userData.gun_With_User_Info.dicGun_PowerUP[i].additionDodge = additionDodge;
                userData.gun_With_User_Info.dicGun_PowerUP[i].additionRate = additionRate;
                userData.gun_With_User_Info.dicGun_PowerUP[i].UpdateData();
                return true;
            }
            if (userData.MissionInfo.listTask.Count != 0)
            {
                userData.MissionInfo.listTask[0].AutoStrengthen = false;
            }

            return false;
        }



        public void UnlockGun()
        {
            userData.gun_With_User_Info.GetUnlockList();
            userData.home.changeLock(new List<int>(), userData.gun_With_User_Info.Unlocklist);
            userData.gun_With_User_Info.Unlock();
        }



        /// <summary>
        /// 枪支拆解 参数type是拆解的星
        /// </summary>
        /// <param name="type"> 传入2是只拆2星，传入3是只拆3星</param>
        /// <returns></returns>
        public bool Gun_retire(int type)
        {
            int count = 0;
            while (true)
            {
                userData.gun_With_User_Info.Get_Gun_Retire();


                StringBuilder sb = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(sb);
                jsonWriter.WriteArrayStart();
                switch (type)
                {
                    case 2:
                        {
                            if (userData.gun_With_User_Info.Rank2.Count == 0) return false;
                            userData.webData.StatusBarText = "拆解2星人形";

                            foreach (var item in userData.gun_With_User_Info.Rank2)
                            {
                                jsonWriter.Write(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (userData.gun_With_User_Info.Rank3.Count == 0) return false;
                            userData.webData.StatusBarText = "拆解3星人形";

                            foreach (var item in userData.gun_With_User_Info.Rank3)
                            {
                                jsonWriter.Write(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (userData.gun_With_User_Info.Rank4.Count == 0) return false;
                            userData.webData.StatusBarText = "拆解4星人形";

                            foreach (var item in userData.gun_With_User_Info.Rank4)
                            {
                                jsonWriter.Write(item);
                            }
                            break;
                        }
                    default:
                        break;
                }

                jsonWriter.WriteArrayEnd();
                Thread.Sleep(2000);


                string result = userData.Net.Factory.Retire_Gun(userData.GameAccount,sb.ToString());

                switch (userData.Response.Check( ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            userData.gun_With_User_Info.Del_Gun_IN_Dict(type);
                            return true;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "Gun_retire ERROR", result).userInfo();
                                return false;
                            }
                            userData.webData.StatusBarText = "Get_Set_UserInfo";
                            userData.home.GetUserInfo();
                            break;
                        }
                    default:
                        break;
                }
            }
        }






    }
}
