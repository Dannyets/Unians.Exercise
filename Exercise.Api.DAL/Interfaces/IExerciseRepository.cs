using BaseRepositories.DynamoDb.Interfaces;
using Exercise.Api.DAL.DbModels;

namespace Exercise.Api.DAL.Interfaces
{
    public interface IExerciseRepository : IDynamoDbRepository<ExerciseDbModel>
    {

    }
}
