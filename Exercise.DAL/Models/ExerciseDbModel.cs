using Amazon.DynamoDBv2.DataModel;
using BaseRepositories.EntityFrameworkCore.Models;

namespace Exercise.DAL.Models
{
    public class ExerciseDbModel : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
