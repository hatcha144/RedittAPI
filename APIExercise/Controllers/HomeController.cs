using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APIExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //JSON/API EXAMPLE 
        public ActionResult Reddit()
        {

            HttpWebRequest request = WebRequest.CreateHttp("https://www.reddit.com/r/aww/.json");
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            //same as file IO - reading file from internet 
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();

            JObject redditJson = JObject.Parse(data);

            
            List<JToken>singlePost = redditJson["data"]["children"].ToList();

                    
            ViewBag.dat = singlePost[6]["data"]["title"];
            ViewBag.img = singlePost[6]["data"]["thumbnail"];
            ViewBag.link = "http://reddit.com/"+ singlePost[6]["data"]["permalink"];


            return View();
        }
    }
}