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
    [Route("Perception")]
    [ApiController]
    public class PerceptionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        
        public PerceptionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ReactionTimeTest()
        {
            return View(await _context.PerceptionTest.ToListAsync());
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

            PerceptionModel perceptionTest = new PerceptionModel()
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Perception",
                GameName = model.testName,
                ReactionTime = timespan,
                ApplicationUserId = currentUser.Id
            };

            await _context.PerceptionTest.AddAsync(perceptionTest);
            await _context.SaveChangesAsync();

            return Ok(JsonConvert.SerializeObject(new
            {
                Success = true
            }));
        }
    }
}
