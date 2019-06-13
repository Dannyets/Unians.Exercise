using BaseRepositories.DynamoDb.Repositories;
using De.Amazon.Configuration.Models;
using Exercise.Api.DbModels;
using Exercise.Api.Interfaces;

namespace Exercise.Api.Services
{
    public class ExerciseRepository : BaseDynamoDbRepository<ExerciseDbModel>, IExerciseRepository
    {
        public ExerciseRepository(AmazonConfiguration amazonConfiguration) : base("Exercise", 
                                                                                  amazonConfiguration.Credentials, 
                                                                                  amazonConfiguration.RegionEndpoint)
        {

        }
    }
}
