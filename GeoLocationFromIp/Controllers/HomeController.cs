using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaxMind.GeoIP2;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace GeoLocationFromIp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            using (var reader = new DatabaseReader(_hostingEnvironment.ContentRootPath + "\\GeoLite2-City.mmdb"))
            {
                // Determine the IP Address of the request
                var ipAddress = HttpContext.Connection.RemoteIpAddress;

                // Get the city from the IP Address
                var city = reader.City(ipAddress);

                return View(city);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
