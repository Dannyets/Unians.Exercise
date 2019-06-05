using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseRepositories.Models;
using Exercise.Api.DbModels;
using Exercise.Api.Interfaces;
using Exercise.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class ExerciseController : Controller
    {
        private IExerciseRepository _exerciseRepository;
        private IMapper _mapper;

        public ExerciseController(IExerciseRepository exerciseRepository,
                                  IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(500, Type=typeof(string))]
        [ProducesResponseType(201, Type=typeof(CreateExerciseResponseModel))]
        public async Task<IActionResult> Create([FromBody]ExerciseModel model)
        {
            string recordId;

            try
            {
                var dbModel = _mapper.Map<ExerciseDbModel>(model);
                dbModel = await _exerciseRepository.Add(dbModel);
                recordId = dbModel.Id;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            var response = new CreateExerciseResponseModel
            {
                Id = recordId
            };

            return StatusCode(201, response);
        }

        [HttpPut]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Confirm([FromBody]ConfirmTransactionModel<string> model)
        {
            try
            {
                await _exerciseRepository.ConfirmTransaction(model);
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
