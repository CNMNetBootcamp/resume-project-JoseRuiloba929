using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Models;

namespace ResumeApp.Data
{
    public class ResumeProjContext: DbContext
    {
        public ResumeProjContext(DbContextOptions<ResumeProjContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
