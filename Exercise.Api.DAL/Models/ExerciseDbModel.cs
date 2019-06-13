using Amazon.DynamoDBv2.DataModel;
using BaseRepositories.DynamoDb.Models;

namespace Exercise.Api.DAL.DbModels
{
    [DynamoDBTable("Exercise")]
    public class ExerciseDbModel : BaseDynamoDbModel
    {
        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; }
    }
}
