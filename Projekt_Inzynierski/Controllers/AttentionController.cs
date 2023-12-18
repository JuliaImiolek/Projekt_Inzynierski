using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projekt_Inzynierski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Controllers
{
    public class AttentionController : Controller
    {
        public IActionResult ColorGuess()
        {
            return View();
        }
        [HttpPost]
        [Route("AddResults")]
        public IActionResult AddRecordToModels(string testName, int numOfClick)
        {
            AddRecordToModels model = new AddRecordToModels() {testName = testName, numOfClick = numOfClick };
            if (model == null)
            {
                return BadRequest("Model niepoprawny");
            }
            AttentionModel attentionGame = new AttentionModel()
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Attention",
                GameName = model.testName,
                CorrectAns = model.numOfClick
            };
            return Ok(JsonConvert.SerializeObject(new
            {
                Success = true
            }));
        }
    }
}
