using Amazon.DynamoDBv2.DataModel;
using BaseRepositories.Models;
using BaseRepositories.Models.Enums;
using BaseRepositories.Models.Interfaces;
using System;

namespace Exercise.Api.DbModels
{
    [DynamoDBTable("Exercise")]
    public class ExerciseDbModel : IBaseDbModel<string>
    {
        [DynamoDBProperty]
        public string Id { get; set; }

        [DynamoDBProperty]
        public DbTransactionStatus TransactionStatus { get; set; }

        [DynamoDBProperty]
        public DateTime CreatedAt { get; set; }

        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; }
    }
}
