using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Controllers
{
    public class CoordinationController : Controller
    {
        public IActionResult ReactionTimeTest()
        {
            return View();
        }
    }
}
