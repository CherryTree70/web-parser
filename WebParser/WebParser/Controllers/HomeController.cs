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
        private Response _finalResponse;


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CorrectUrl userUrl)
        {

            if (ModelState.IsValid)
            {
                ApiKey key = new ApiKey();
                var request = (HttpWebRequest)WebRequest.Create("https://mercury.postlight.com/parser?url=" + userUrl.Url);
                request.ContentType = "application / json";
                request.Headers.Add("x-api-key", key.GetKey());
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                _finalResponse = JsonConvert.DeserializeObject<Response>(responseString, settings);
                var lastUsedUlrsList = myUrlQueue.OperateOnQueue(userUrl.Url);
                ViewBag.ListOfLastUrls = lastUsedUlrsList;

                return View("ResponseResult", _finalResponse);

            }
            return View();
        }
    }
}