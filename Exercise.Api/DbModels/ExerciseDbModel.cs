using Amazon.DynamoDBv2.DataModel;
using Exercise.Api.Models;
using System;

namespace Exercise.Api.DbModels
{
    [DynamoDBTable("Exercise")]
    public class ExerciseDbModel
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; }

        [DynamoDBProperty]
        public TransactionStatus Status { get; set; }

        [DynamoDBProperty]
        public DateTime CreatedAt { get; set; }
    }
}
