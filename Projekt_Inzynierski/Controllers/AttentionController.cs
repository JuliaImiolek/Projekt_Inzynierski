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
    [Route("Attention")]
    [ApiController]
    public class AttentionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public AttentionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> ColorGuess()
        {
            return View(await _context.AttentionTest.ToListAsync());
        }

        private bool IsAttentionTestExists(string id)
        {
            return _context.AttentionTest.Any(e => e.Id == id);
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
            AttentionModel attentionTest = new AttentionModel()
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Attention",
                GameName = model.testName,
                CorrectAns = model.numOfClick,
                ApplicationUserId = currentUser?.Id ?? string.Empty
            };

            await _context.AttentionTest.AddAsync(attentionTest);
            await _context.SaveChangesAsync();

            return Ok(JsonConvert.SerializeObject(new
            {
                Success = true
            }));
        }
    }
}
