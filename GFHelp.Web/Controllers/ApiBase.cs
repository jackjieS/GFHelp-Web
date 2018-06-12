using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace GFHelp.Web.Controllers
{ 
    public abstract class ApiBase : Controller
    {

        public  ActionResult Json(int code, JsonResult data, string message)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsondata = new JsonTextWriter(sw);
            jsondata.WriteStartObject();
            jsondata.WritePropertyName("code");
            jsondata.WriteValue(code);
            jsondata.WritePropertyName("data");
            jsondata.WriteValue(data);
            jsondata.WritePropertyName("message");
            jsondata.WriteValue(message);
            jsondata.WriteEndObject();
            return Content(sb.ToString(), "application/json");
        }


        protected ActionResult Json(int code,string message)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsondata = new JsonTextWriter(sw);
            jsondata.WriteStartObject();
            jsondata.WritePropertyName("code");
            jsondata.WriteValue(code);
            jsondata.WritePropertyName("message");
            jsondata.WriteValue(message);
            jsondata.WriteEndObject();
            return Content(sb.ToString(), "application/json");
        }

        protected ActionResult Json(int code, JsonResult data)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsondata = new JsonTextWriter(sw);
            jsondata.WriteStartObject();
            jsondata.WritePropertyName("code");
            jsondata.WriteValue(code);
            jsondata.WritePropertyName("data");
            jsondata.WriteValue(data);
            jsondata.WriteEndObject();
            return Content(sb.ToString(), "application/json");
        }

    }

}
