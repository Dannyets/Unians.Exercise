using BaseRepositories.EntityFrameworkCore.Repositories;
using Exercise.DAL.Interfaces;
using Exercise.DAL.Models;

namespace Exercise.DAL.Repositories
{
    public class ExerciseRepository : BaseEntityFrameworkCoreRepository<ExerciseDbModel>, IExerciseRepository
    {
        public ExerciseRepository(ExerciseDbContext context) : base(context)
        {

        }
    }
}
