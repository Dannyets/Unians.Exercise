using System;
using System.Collections.Generic;
using System.Text;

namespace Unians.Exercise.Api.Data.Models
{
    public class ApiExercise
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int SemesterId { get; set; }

        public string Name { get; set; }
    }
}
