using BaseRepositories.EntityFrameworkCore.MySql;
using Exercise.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.DAL
{
    public class ExerciseDbContext : BaseMySqlDbContext
    {
        public DbSet<ExerciseDbModel> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseDbModel>().HasKey(p => p.Id);
        }
    }
}
