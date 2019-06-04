using Exercise.Api.DbModels;
using Exercise.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRepositories.Interfaces;

namespace Exercise.Api.Interfaces
{
    public interface IExerciseRepository : IBaseRepository<ExerciseDbModel, string>
    {
    }
}
