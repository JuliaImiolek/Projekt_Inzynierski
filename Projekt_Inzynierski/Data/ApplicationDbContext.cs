﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Inzynierski.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<AttentionModel> AttentionTest { get; set; }
        public DbSet<CoordinationModel> CoordinationTest { get; set; }
        public DbSet<MemoryModel> MemoryTest { get; set; }
        public DbSet<PerceptionModel> PerceptionTest { get; set; }
        public DbSet<ReasoningModel> ReasoningTest { get; set; }
    }
}
