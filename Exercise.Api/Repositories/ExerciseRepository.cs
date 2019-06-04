using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
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
    public class ExerciseRepository : BaseDynamoDbRepository<ExerciseDbModel>, IExerciseRepository
    {
        public ExerciseRepository() : base("Exercise")
        {

        }
    }
}
