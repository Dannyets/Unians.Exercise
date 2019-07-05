using AspNetCore.Infrastructure.Controllers;
using AspNetCore.Infrastructure.Repositories.EntityFrameworkCore.Models.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unians.Exercise.Api.Data.Models;
using Unians.Exercise.Data.Interfaces;
using Unians.Exercise.Data.Models;

namespace Unians.Exercise.Api.Controllers
{
    public class ExerciseController : BaseEfCrudController<ApiExercise, DbExercise>
    {
        private readonly IExerciseRepository _repository;

        public ExerciseController(IExerciseRepository repository,
                                  IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiExercise>>> GetExercisesForCourseAndSemester(int courseId, int semesterId)
        {
            var exercises = await _repository.GetExercisesForCourseAndSemester(courseId, semesterId);

            return Ok(exercises);
        }
    }
}
