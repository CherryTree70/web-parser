using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using WebParser.Models;


namespace WebParser.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CorrectUrl u)
        {

            if (ModelState.IsValid)
            {
                var request = (HttpWebRequest)WebRequest.Create("https://mercury.postlight.com/parser?url=" + u.Url);
                request.ContentType = "application / json";
                request.Headers.Add("x-api-key", "OaWQ6uUJWAve76eQ69vEvaeFs2OCUFjA5q8cgqYC");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var response1 = JsonConvert.DeserializeObject<Response>(responseString);
                //var s = JsonConvert.DeserializeObject<Response>(responseString).Content;
                //HtmlDocument doc = new HtmlDocument();
                //doc.Load(s);
                //Console.WriteLine(doc);
                return View("ResponseResult", response1);

            }
            return View();

        }

        public static IHtmlString ToJson(HtmlHelper helper, object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new JavaScriptDateTimeConverter());
            return helper.Raw(JsonConvert.SerializeObject(obj, settings));
        }



    }
}