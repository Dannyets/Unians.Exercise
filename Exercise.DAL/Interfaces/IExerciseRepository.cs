using Exercise.Api.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRepositories.DynamoDb.Interfaces;

namespace Exercise.Api.DAL.Interfaces
{
    public interface IExerciseRepository : IDynamoDbRepository<ExerciseDbModel>
    {

    }
}
