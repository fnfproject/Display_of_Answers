using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestionBankApiLibrary.Models;
namespace QuestionBankApiLibrary.Data
{
    public class QuestionBankDbContext : DbContext
    {
        public QuestionBankDbContext(DbContextOptions<QuestionBankDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table names if different from default
            modelBuilder.Entity<Question>().ToTable("Question");  // Map to the correct table name
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<Result>().ToTable("Result");

            base.OnModelCreating(modelBuilder);
        }
    }
}