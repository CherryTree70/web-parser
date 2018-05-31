using System.IO;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebParser.Models;


namespace WebParser.Controllers
{

    public class HomeController : Controller
    {

        static UrlQueue myUrlQueue = new UrlQueue();


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
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var response1 = JsonConvert.DeserializeObject<Response>(responseString, settings);
                var lastUsedUlrsList = myUrlQueue.OperateOnQueue(u.Url);
                ViewBag.ListOfLastUrls = lastUsedUlrsList;


                return View("ResponseResult", response1);

            }
            return View();

        }



    }
}