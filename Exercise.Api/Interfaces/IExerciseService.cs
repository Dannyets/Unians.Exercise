using Exercise.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Interfaces
{
    public interface IExerciseService
    {
        Task<string> Add(ExerciseModel model);

        Task Confirm(ConfirmTransactionModel model);
    }
}
