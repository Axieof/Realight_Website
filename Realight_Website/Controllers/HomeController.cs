using System;
using System.Collections.Generic;
using System.Web;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Firebase.Storage;
using Realight_Website.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<ActionResult> Register(IFormCollection formData)
        {
            client = new FirebaseClient(config);
            //Read inputs from textboxes
            string name = formData["name"].ToString();
            string email = formData["email"].ToString().ToLower();
            string password = formData["password"].ToString();

            var player = new Player
            {
                name = name,
                email = email,
                password = password,
                status = "New to Realight!",
                biography = "Hi I'm " + name
            };
            PushResponse response = await client.PushAsync("Players", player);
            Player result = response.ResultAs<Player>();
            string id = response.Result.name;
            var newID = new Player
            {
                id = id
            };
            PushResponse update = await client.PushAsync("Players/" + "id", id);
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Login(string? email, string? password)
        {
            // Read inputs from textboxes             
            // Email address converted to lowercase
            email = email.ToLower();

            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Players");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Player>();

            if (!String.IsNullOrEmpty(email))
            {
                foreach (var item in data)
                {
                    Player user = JsonConvert.DeserializeObject<Player>(((JProperty)item).Value.ToString());
                    if (user.email.ToLower() == email)
                    {
                        if(user.password == password)
                        {
                            HttpContext.Session.SetString("User", user.name);
                            HttpContext.Session.SetString("UserID", user.id);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in data)
                {
                    Player user = JsonConvert.DeserializeObject<Player>(((JProperty)item).Value.ToString());
                    if (user.email.ToLower() == email)
                    {
                        list.Add(user);
                    }
                }
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Edit()
        {
            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Players");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Player>();

            string currUser = HttpContext.Session.GetString("User");
            //Checking for the ID
            if (!String.IsNullOrEmpty(currUser))
            {
                foreach (var item in data)
                {
                    Player addPlayer = JsonConvert.DeserializeObject<Player>(((JProperty)item).Value.ToString());
                    addPlayer.id = item.Name;
                    if (addPlayer.name.Contains(currUser))
                    {
                        list.Add(addPlayer);
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
        [HttpPost]
        public async Task<ActionResult> Edit(IFormCollection formData)
        {
            client = new FirebaseClient(config);
            //Read inputs from textboxes
            string status = formData["status"].ToString();
            string biography = formData["biography"].ToString();

            var player = new Player
            {
                id = HttpContext.Session.GetString("UserID"),
                name = HttpContext.Session.GetString("User"),
                status = status,
                biography = biography
            };
            SetResponse response = await client.SetAsync("Players/" + HttpContext.Session.GetString("UserID"), player);
            Player result = response.ResultAs<Player>();
            return View("Index");
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
                        addRoom.RoomID = item.Name;
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
        public async Task<IActionResult> Profile(string? ownername)
        {
            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Players");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Player>();

            //Checking for the ID
            if (!String.IsNullOrEmpty(ownername))
            {
                foreach (var item in data)
                {
                    Player addPlayer = JsonConvert.DeserializeObject<Player>(((JProperty)item).Value.ToString());
                    addPlayer.id = item.Name;
                    if (addPlayer.name.Contains(ownername))
                    {
                        list.Add(addPlayer);
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

        public IActionResult UploadMap()
        {
            return View();
        }

        //Posting of map onto firebase storage
        [HttpPost]
        public async Task<IActionResult> UploadMap(Maps map)
        {
            
            // full path to file in temp location
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),map.mapFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await map.mapFile.CopyToAsync(stream);

            }
            var previewDownloadURLs = new List<string>();
            if (map.mapPreviews.Count > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (map.mapPreviews[i].Length > 0)
                    {
                        var filePathImage = Path.Combine(Directory.GetCurrentDirectory(), map.mapPreviews[i].FileName);

                        using (var stream = new FileStream(filePathImage, FileMode.Create))
                        {
                            await map.mapPreviews[i].CopyToAsync(stream);

                        }

                        using (var fileStream = new FileStream(filePathImage, FileMode.Open))
                        {
                            var task = new FirebaseStorage("realight-db.appspot.com")
                            .Child("mapsPreviews")
                            .Child(map.mapPreviews[i].FileName)
                            .PutAsync(fileStream);

                            var downloadUrl = await task;
                            previewDownloadURLs.Add(downloadUrl);
                        }
                    }
                }
            }
            else
            {
                foreach (var formFile in map.mapPreviews)
                {
                    if (formFile.Length > 0)
                    {
                        var filePathImage = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                        using (var stream = new FileStream(filePathImage, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);

                        }

                        using (var fileStream = new FileStream(filePathImage, FileMode.Open))
                        {
                            var task = new FirebaseStorage("realight-db.appspot.com")
                            .Child("mapsPreviews")
                            .Child(formFile.FileName)
                            .PutAsync(fileStream);

                            var downloadUrl = await task;
                            previewDownloadURLs.Add(downloadUrl);
                        }
                    }
                }
            }

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var task = new FirebaseStorage("realight-db.appspot.com")
                .Child("maps")
                .Child(map.mapFile.FileName)
                .PutAsync(fileStream);

                var downloadUrl = await task;

                client = new FirebaseClient(config);
                //Read inputs from textboxes
                string mapName = map.mapName;
                string mapMaker = map.mapMaker;
                string mapDescription = map.description;

                var mapCreation = new Maps
                {
                    mapName = map.mapName,
                    mapMaker = map.mapMaker,
                    description = map.description,
                    downloadMapURL = downloadUrl,
                    mapPreviewURLs = previewDownloadURLs
                };
                PushResponse response = await client.PushAsync("Downloadable-Map", mapCreation);
            }

            return View();


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
