using AspNetCore.Infrastructure.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unians.Exercise.Data.Interfaces;
using Unians.Exercise.Data.Models;

namespace Unians.Exercise.Data.Repositories
{
    public class ExerciseRepository : BaseEntityFrameworkCoreRepository<DbExercise>, IExerciseRepository
    {
        public ExerciseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<DbExercise>> GetExercisesForCourseAndSemester(int courseId, int semesterId)
        {
            return await _dbSet.Where(e => e.CourseId == courseId && e.SemesterId == semesterId).ToListAsync();
        }
    }
}
