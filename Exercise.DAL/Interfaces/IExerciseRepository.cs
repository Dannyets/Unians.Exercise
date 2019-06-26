using Exercise.DAL.Models;
using BaseRepositories.EntityFrameworkCore.Interfaces;

namespace Exercise.DAL.Interfaces
{
    public interface IExerciseRepository : IEfRepository<ExerciseDbModel>
    {

    }
}
