using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> ColorGuess()
        {
            return View(await _context.AttentionTest.ToListAsync());
        }

        private bool IsAttentionTestExists(string id)
        {
            return _context.AttentionTest.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("AddResults")]
        [Authorize]
        public async Task<IActionResult> AddRecordToModels(string testName, int numOfClick)
        {
            AddRecordToModels model = new AddRecordToModels() {testName = testName, numOfClick = numOfClick };
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
                ApplicationUserId = currentUser.Id
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
