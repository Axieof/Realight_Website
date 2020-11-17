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


namespace Realight_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /*IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "qOzvcqVr0tufiu5Ra0I9ZOJ6rKoamkTePy2mRKfi",
            BasePath= "https://realight-db.firebaseio.com/"
        };*/

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
		{

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
