using AspNetCore.Infrastructure.Repositories.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Exercise.Data.Models;

namespace Unians.Exercise.Data.Context
{
    public class ExerciseDbContext : BaseMySqlDbContext
    {
        public ExerciseDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: REMOVE ONCE NEW DATABASE IS ADDED
            optionsBuilder.UseInMemoryDatabase("unians_exercise");
        }

        public DbSet<DbExercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbExercise>().HasKey(p => p.Id);

            modelBuilder.Entity<DbExercise>().HasIndex(p => new { p.CourseId, p.SemesterId });

            //TODO: REMOVE ONCE NEW DATABASE IS ADDED
            AddInitialData(modelBuilder);
        }

        private void AddInitialData(ModelBuilder modelBuilder)
        {
            var exercise = new DbExercise
            {
                Id = 1,
                CourseId = 1,
                SemesterId = 1,
                Name = "תרגיל בית 1",
                CreatedAt = DateTime.UtcNow,
                LastUdpatedAt = DateTime.UtcNow
            };

            var exercises = new List<DbExercise> { exercise };

            modelBuilder.Entity<DbExercise>().HasData(exercises);
        }
    }
}
