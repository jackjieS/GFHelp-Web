﻿using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.MulitePlayerData
{
    public class Mail
    {
        public Mail(UserData userData)
        {
            this.userData = userData;
        }
        UserData userData;

        public void MailHandle()
        {
            getMailList();
            getMailResouce();
        }

        private void getMailList()
        {
            listMail.Clear();
            Read(GetMailList());
            userData.webData.StatusBarText = "空闲";

        }
        private void getMailResouce()
        {
            for (int i = 0; i < listMail.Count; i++)
            {
                userData.webData.StatusBarText = "获取邮件 ID: " + listMail[i].id;
                new Log().userInit(userData.GameAccount.GameAccountID, String.Format("获取邮件 ID: {0} 标题 {1} 内容 {2}",
                    listMail[i].id,
                    CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(listMail[i].title),
                    CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(listMail[i].content)
                    )).userInfo();
                try
                {
                    GetMailResouce(listMail[i].id);
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "获取邮件错误", e.ToString()).userInfo();
                }


            }


            userData.webData.StatusBarText = "空闲";


        }

        private string GetMailList()
        {
            userData.webData.StatusBarText = "检查邮箱";

            Thread.Sleep(2000);
            int count = 0;

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("data_version");
            jsonWriter.Write(userData.GameAccount.data_version);
            jsonWriter.WritePropertyName("ab_version");
            jsonWriter.Write(userData.GameAccount.ab_version);
            jsonWriter.WritePropertyName("start_id");
            jsonWriter.Write(0);
            jsonWriter.WritePropertyName("ignore_time");
            jsonWriter.Write(1);
            jsonWriter.WriteObjectEnd();

            int k = 0;
            while (true)
            {
                string result = userData.Net.Home.getMailList(userData.GameAccount, stringBuilder.ToString());

                switch (userData.Response.Check( ref result, "home", true))
                {
                    case 1:
                        {
                            return result;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            new Log().userInit(userData.GameAccount.GameAccountID, String.Format("{0} GET MAIL LIST FAILED {1} ", userData.user_Info.name, result), result).userInfo();
                            return "";
                        }
                    default:
                        break;
                }
            }
        }

        private bool GetMailResouce(int mail_with_user_id)
        {
            Thread.Sleep(2000);
            int count = 0;

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("mail_with_user_id");
            jsonWriter.Write(mail_with_user_id);
            jsonWriter.WriteObjectEnd();

            int k = 0;
            while (true)
            {
                string result = userData.Net.Home.GetMailResource(userData.GameAccount, stringBuilder.ToString());

                switch (userData.Response.Check( ref result, "MailResource", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            return false;
                        }
                    case -1:
                        {
                            return false;
                        }
                    default:
                        break;
                }
            }



        }

        private void SquadeTaskDailyHandle(Data data)
        {
            for (int i = 0; i < userData.task_Daily.listSquadData.Count; i++)
            {
                string squadID = userData.task_Daily.listSquadData[i].squad_id.ToString();
                if(data.title.Contains("squad_data_daily")&& data.title.Contains(squadID))
                {
                    userData.task_Daily.listSquadData[i].isFinish = true;
                }
            }

        }




        public void Read(string result)
        {


            JsonData jsonData = JsonMapper.ToObject(result);
            if (jsonData.Contains("index_getmaillist"))
            {
                JsonData jsonData16 = jsonData["index_getmaillist"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2 = new Data(jsonData16[num8]);
                    if(data2.CouldGet)
                    listMail.Add(data2);
                }
            }


        }


        public List<Data> listMail = new List<Data>();

        public class Data
        {
            public Data(JsonData jsonData=null)
            {
                if (jsonData != null)
                {
                    this.id = jsonData["id"].Int;
                    this.user_id = jsonData["user_id"].Int;
                    this.type = jsonData["type"].Int;
                    this.sub_id = jsonData["sub_id"].String;
                    this.title = jsonData["title"].String;
                    this.content = jsonData["content"].String;
                    this.start_time = jsonData["start_time"].Int;
                    if (Decrypt.getDateTime_China_Int(DateTime.Now)>this.start_time)
                        this.CouldGet = true;
                    else
                    {
                        this.CouldGet = false;
                    }
                }
            }

            public bool CouldGet;
            public int id;
            public int user_id;
            public int type;
            public string sub_id;
            public int user_exp;
            public int mp;
            public int ammo;
            public int mre;
            public int part;
            public int core;
            public int gem;
            public int gun_id;
            public string item_ids;
            public string equip_ids;
            public string furniture;
            public string gift;
            public string coins;
            public string skin;
            public string title;
            public string content;
            public string code;
            public int start_time;
            public int end_time;
            public int if_read;
        }





    }
}
