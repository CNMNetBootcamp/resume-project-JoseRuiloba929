using Microsoft.EntityFrameworkCore;
using ResumeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Data
{
    public class JobContext:DbContext
    {
        public JobContext(DbContextOptions<JobContext> options): base(options)
        {
        }
        public DbSet<Submitter> Submitters { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<ProfSummary> ProfSummaries { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submitter>().ToTable("Submitter");
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<JobDescription>().ToTable("JobDescription");
            modelBuilder.Entity<ProfSummary>().ToTable("ProfSummary");
            modelBuilder.Entity<Reference>().ToTable("Reference");
            modelBuilder.Entity<SkillSet>().ToTable("SkillSet");
            modelBuilder.Entity<WorkExperience>().ToTable("WorkExperience");
        }
    }
}
