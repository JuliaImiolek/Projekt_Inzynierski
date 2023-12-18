using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Models
{
    public class AttentionModel
    {
        [Key]
        public string Id { get; set; }
        public string Category { get; set; }
        public string GameName { get; set; }
        public int CorrectAns { get; set; }

        // User
    }
}
