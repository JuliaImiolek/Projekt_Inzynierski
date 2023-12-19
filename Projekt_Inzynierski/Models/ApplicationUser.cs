using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<AttentionModel> AttentionTest { get; set; }
    }
}
