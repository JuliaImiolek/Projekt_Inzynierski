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
    [Route("Reasoning")]
    [ApiController]
    public class ReasoningController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public ReasoningController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Wordle()
        {
            return View(_context.ReasoningTest.ToListAsync());
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
            ReasoningModel reasoningTest = new ReasoningModel()
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Reasoning",
                GameName = model.testName,
                ApplicationUserId = currentUser?.Id ?? string.Empty,
                isWinner = model.isWinner 
            };

            await _context.ReasoningTest.AddAsync(reasoningTest);
            await _context.SaveChangesAsync();

            return Ok(JsonConvert.SerializeObject(new
            {
                Success = true
            }));
        }
    }
}
