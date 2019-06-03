using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Api.Interfaces;
using Exercise.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class ExerciseController : Controller
    {
        private IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        [ProducesResponseType(500, Type=typeof(string))]
        [ProducesResponseType(201, Type=typeof(CreateExerciseResponse))]
        public async Task<IActionResult> Create([FromBody]ExerciseModel model)
        {
            string recordId;

            try
            {
                recordId = await _exerciseService.Add(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            var response = new CreateExerciseResponse
            {
                Id = recordId
            };

            return StatusCode(201, response);
        }

        [HttpPut]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Confirm([FromBody]ConfirmTransactionModel model)
        {
            try
            {
                await _exerciseService.Confirm(model);
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }
    }
}
