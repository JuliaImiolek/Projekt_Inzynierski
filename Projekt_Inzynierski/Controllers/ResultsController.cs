using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projekt_Inzynierski.Data;
using Projekt_Inzynierski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Controllers
{
    [Authorize]
    public class ResultsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        public ResultsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CLevelEasy()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Easy").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult CLevelMedium()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Medium").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult CLevelHard()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Hard").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult CTinyShapes()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Tine shapes").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult CMediumShapes()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Medium shapes").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }

        public IActionResult Attention()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.AttentionTest.Where(x => x.ApplicationUserId == id).ToList();
            List<AttentionModel> attentionTest = founded.Where(x => x.Category == "Attention").ToList();
            return View(attentionTest);
        }
        public IActionResult Memory()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.MemoryTest.Where(x => x.ApplicationUserId == id).ToList();
            List<MemoryModel> memoryTest = founded.Where(x => x.Category == "Memory").ToList();
            return View(memoryTest);
        }
        public IActionResult Perception()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.PerceptionTest.Where(x => x.ApplicationUserId == id).ToList();
            List<PerceptionModel> perceptionTest = founded.Where(x => x.Category == "Perception").ToList();
            return View(perceptionTest);
        }

        public IActionResult Reasoning()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.ReasoningTest.Where(x => x.ApplicationUserId == id).ToList();
            List<ReasoningModel> reasoningTest = founded.Where(x => x.Category == "Reasoning").ToList();
            return View(reasoningTest);
        }
    }
}
