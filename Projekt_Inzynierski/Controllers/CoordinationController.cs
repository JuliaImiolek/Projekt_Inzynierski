using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Controllers
{
    public class CoordinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LevelEasy()
        {
            return View();
        }
        public IActionResult LevelMedium()
        {
            return View();
        }
        public IActionResult LevelHard()
        {
            return View();
        }
        public IActionResult MediumShapes()
        {
            return View();
        }
        public IActionResult TinyShapes()
        {
            return View();
        }

    }
}
