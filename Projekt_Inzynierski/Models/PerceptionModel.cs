using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Models
{
    public class PerceptionModel
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string GameName { get; set; }
        public TimeSpan ReactionTime { get; set; }
    }
}
