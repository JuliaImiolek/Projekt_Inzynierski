using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Controllers
{
    public class MemoryController : Controller
    {
        public IActionResult Memory()
        {
            return View();
        }
    }
}
