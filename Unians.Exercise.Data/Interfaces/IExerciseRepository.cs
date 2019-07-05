using AspNetCore.Infrastructure.Repositories.EntityFrameworkCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unians.Exercise.Data.Models;

namespace Unians.Exercise.Data.Interfaces
{
    public interface IExerciseRepository : IEfRepository<DbExercise>
    {
        Task<IEnumerable<DbExercise>> GetExercisesForCourseAndSemester(int courseId, int semesterId);
    }
}
