﻿using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiteratureProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }
        public DbSet<AnalysisPart> AnalysisParts { get; set; }
            public DbSet<Author> Authors {get;set;}
        public DbSet<LiteratureWork> LiteratureWorks { get; set; }
        public DbSet<StudentAnalysis> StudentAnalyses { get; set; }
        public DbSet<StudentWorkComponent> StudentWorkComponents { get; set; }
        public DbSet<TeacherLiteratureWork> UserLiteratureWorks { get; set; }
    }
}
