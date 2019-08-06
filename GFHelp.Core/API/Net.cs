using GFHelp.Core.Management;
using GFHelp.NetBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    public class Net
    {
        BaseRequset BaseRequset;
        public Net(UserData UserData)
        {
            this.UserData = UserData;
            BaseRequset = UserData.baseRequset;
            this.Battle = new Battle(UserData.authCode,BaseRequset);
            this.Dorm = new Dorm(UserData.authCode, BaseRequset);
            this.Factory = new Factory(UserData.authCode, BaseRequset);
            this.Home = new Home(UserData.authCode, BaseRequset);
            this.Kalina = new Kalina(UserData.authCode, BaseRequset);
            this.Operation = new  Operation(UserData.authCode, BaseRequset);
        }
        private UserData UserData;
        public Battle Battle;
        public Dorm Dorm;
        public Factory Factory;
        public Home Home;
        public Kalina Kalina;
        public Operation Operation;
    }
}
