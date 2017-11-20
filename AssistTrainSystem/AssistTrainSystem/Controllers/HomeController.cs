using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistTrainSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssistTrainSystem.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult test1()
        {
            return View();
        }
        public IActionResult test2()
        {
            return View();
        }
        public IActionResult test3()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
