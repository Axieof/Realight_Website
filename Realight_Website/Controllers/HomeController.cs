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

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                foreach (var item in data)
                {
                    //string roomID = item[]
                    Room addRoom = JsonConvert.DeserializeObject<Room>(((JProperty)item).Value.ToString());
                    if (addRoom.interestTag.Contains(searchString) || addRoom.name.Contains(searchString))
					{
                        list.Add(addRoom);
					}
                }
            }
			else
			{
                foreach (var item in data)
                {
                    Room addRoom = JsonConvert.DeserializeObject<Room>(((JProperty)item).Value.ToString());
                    addRoom.RoomID = item.Name;
                    list.Add(addRoom);
                }
            }
            

            return View(list);
		}

        [HttpGet]
        public async Task<IActionResult> RoomDetail(string? id)
        {
            //Use searchString as the input and use it to identify any similar interest tag
            HttpContext.Session.SetString("HomePage", "Default");

            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Rooms");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Room>();

            //Checking for the ID
            if (!String.IsNullOrEmpty(id))
            {
                foreach (var item in data)
                {
                    Room addRoom = JsonConvert.DeserializeObject<Room>(((JProperty)item).Value.ToString());
                    addRoom.RoomID = item.Name;
                    if (addRoom.RoomID.Contains(id))
                    {;
                        list.Add(addRoom);
                        return View(list);
                    }
                }
            }
            else
            {
                return View(list);
            }


            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> MapList()
        {
            //Use searchString as the input and use it to identify any similar interest tag
            HttpContext.Session.SetString("HomePage", "Default");

            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Downloadable-Map");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Maps>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Maps>(((JProperty)item).Value.ToString()));
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
