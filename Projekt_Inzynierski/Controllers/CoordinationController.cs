using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Projekt_Inzynierski.Data;
using Projekt_Inzynierski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Controllers
{
    public class CoordinationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public CoordinationController(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
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

        [HttpPost]
        [Route("AddResults")]
        public IActionResult AddRecordToModels(string testName, int numOfClick, int span)
        {
            AddRecordToModels model = new AddRecordToModels() { testName = testName, numOfClick = numOfClick, span = span };
            if (model == null)
            {
                return BadRequest("Model niepoprawny");
            }

            int seconds = span / 1000;
            int miliseconds = span - (seconds * 1000);
            int minutes = seconds / 60;
            seconds = seconds - (minutes * 60);
            int hours = minutes / 60;
            minutes = minutes - (hours * 60);
            int days = hours / 24;

            TimeSpan timespan = new TimeSpan(days, hours, minutes, seconds, miliseconds);

            CoordinationModel coordinationTest = new CoordinationModel()
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Coordination",
                GameName = model.testName,
                NumOfClick = model.numOfClick,
                ReactionTime = timespan
       
            };
            return Ok(JsonConvert.SerializeObject(new
            {
                Success = true
            }));
        }
    }
}
