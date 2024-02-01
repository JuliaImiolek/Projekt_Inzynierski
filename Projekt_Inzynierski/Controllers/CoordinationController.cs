using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Controller]
    [Route("Coordination")]
    [ApiController]
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
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoordinationTest.ToListAsync());
        }
        [HttpGet("LevelEasy")]
        public async Task<IActionResult> LevelEasy()
        {
            return View(await _context.CoordinationTest.ToListAsync());
        }
        [HttpGet("LevelMedium")]
        public async Task<IActionResult> LevelMedium()
        {
            return View(await _context.CoordinationTest.ToListAsync());
        }
        [HttpGet("LevelHard")]
        public async Task<IActionResult> LevelHard()
        {
            return View(await _context.CoordinationTest.ToListAsync());
        }
        [HttpGet("MediumShapes")]
        public async Task<IActionResult> MediumShapes()
        {
            return View(await _context.CoordinationTest.ToListAsync());
        }
        [HttpGet("TinyShapes")]
        public async Task<IActionResult> TinyShapes()
        {
            return View(await _context.CoordinationTest.ToListAsync());
        }

        [HttpPost]
        [Route("AddRecordToReactionTest")]
        public async Task<IActionResult> AddRecordToModels([FromBody] AddRecordToModels model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (model == null)
            {
                return BadRequest("Model niepoprawny");
            }

            int seconds = model.span / 1000;
            int miliseconds = model.span - (seconds * 1000);
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
                ReactionTime = timespan,
                ApplicationUserId = currentUser?.Id ?? string.Empty 
            };

            await _context.CoordinationTest.AddAsync(coordinationTest);
            await _context.SaveChangesAsync();
            return Ok(JsonConvert.SerializeObject(new
            {
                Success = true
            }));
        }
    }
}
