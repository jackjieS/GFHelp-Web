using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class Game_Config_Info
    {
        public string parameter_name;
        public string parameter_type;
        public Dictionary<int, string[]> parameter_value = new Dictionary<int, string[]>();
        public string parameter_value_String;
        public string client_require;
    }
}
