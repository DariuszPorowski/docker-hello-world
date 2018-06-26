using System;
using Microsoft.AspNetCore.Mvc;

namespace docker_hello_world.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["NAME"] = Environment.GetEnvironmentVariable("NAME");
            ViewData["HOSTNAME"] = Environment.GetEnvironmentVariable("HOSTNAME");

            return View();
        }
    }
}
