using System;
using System.Collections.Generic;
using System.Web;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Realight_Website.Models;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace Realight_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "qOzvcqVr0tufiu5Ra0I9ZOJ6rKoamkTePy2mRKfi",
            BasePath= "https://realight-db.firebaseio.com/"
        };
        FirebaseClient client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("HomePage", "BackgroundVideo");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Browse(string? searchString)
        {
            //Use searchString as the input and use it to identify any similar interest tag
            HttpContext.Session.SetString("HomePage", "Default");

            ViewData["CurrentFilter"] = searchString;

            

            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Rooms");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Room>();
     
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Room>(((JProperty)item).Value.ToString()));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                list[0].code = searchString;
            }

            return View(list);
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
