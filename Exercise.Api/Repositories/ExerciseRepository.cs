using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using AutoMapper;
using BaseRepositories.DynamoDb;
using BaseRepositories.DynamoDb.Interfaces;
using BaseRepositories.DynamoDb.Repositories;
using De.Amazon.Configuration.Models;
using Exercise.Api.DbModels;
using Exercise.Api.Interfaces;
using Exercise.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
