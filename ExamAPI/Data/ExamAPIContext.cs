using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamAPI.Models;

namespace ExamAPI.Data
{
    public class ExamAPIContext : DbContext
    {
        public ExamAPIContext (DbContextOptions<ExamAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ExamAPI.Models.Encuestas> Encuestas { get; set; }

        public DbSet<ExamAPI.Models.Campos> Campos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encuestas>()
                .OwnsMany(e => e.Campos);
        }
    }
}
