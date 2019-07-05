using AspNetCore.Infrastructure.Repositories.EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unians.Exercise.Data.Models
{
    public class DbExercise : DbIdEntity
    {
        public int CourseId { get; set; }

        public int SemesterId { get; set; }

        public string Name { get; set; }
    }
}
