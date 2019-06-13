using BaseRepositories.DynamoDb.Repositories;
using De.Amazon.Configuration.Models;
using Exercise.Api.DAL.DbModels;
using Exercise.Api.DAL.Interfaces;

namespace Exercise.Api.DAL.Repositories
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
