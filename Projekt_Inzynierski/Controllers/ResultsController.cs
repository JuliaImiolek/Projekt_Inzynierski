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

        public IActionResult Easy()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Easy").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult Medium()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Medium").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult Hard()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Hard").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult TinyShapes()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var founded = _context.CoordinationTest.Where(x => x.ApplicationUserId == id).ToList();
            var easy = founded.Where(x => x.GameName == "Tine shapes").OrderBy(x => x.ReactionTime).ToList();
            return View(easy);
        }
        public IActionResult MediumShapes()
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
            List<AttentionModel> attentionTest = founded.Where(x => x.GameName == "Attention").ToList();
            return View(attentionTest);
        }
    }
}
