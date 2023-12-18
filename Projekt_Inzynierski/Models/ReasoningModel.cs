using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Models
{
    public class ReasoningModel
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string GameName { get; set; }
        public bool isWinner { get; set; }
    }
}
