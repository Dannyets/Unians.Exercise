using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using AutoMapper;
using BaseRepositories.DynamoDb;
using Exercise.Api.DbModels;
using Exercise.Api.Interfaces;
using Exercise.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Api.Services
{
    public class ExerciseRepository : BaseAwsDynamoDbRepository<ExerciseDbModel>, IExerciseRepository
    {
        public ExerciseRepository(AWSCredentials credentials, 
                                  RegionEndpoint region) : base("Exercise", credentials, region)
        {

        }
    }
}
