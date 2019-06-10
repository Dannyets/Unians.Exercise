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
using Exercise.Api.Models.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class ExerciseController : Controller
    {
        private IExerciseRepository _exerciseRepository;
        private IMapper _mapper;
        private INotificationService _notificationService;

        public ExerciseController(IExerciseRepository exerciseRepository,
                                  IMapper mapper,
                                  INotificationService notificationService)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpPost]
        [ProducesResponseType(500, Type=typeof(string))]
        [ProducesResponseType(201, Type=typeof(ExerciseApiModel))]
        public async Task<ActionResult<ExerciseApiModel>> Create([FromBody]ExerciseApiModel model)
        {
            try
            {
                var dbModel = _mapper.Map<ExerciseDbModel>(model);

                dbModel = await _exerciseRepository.Add(dbModel);

                model = _mapper.Map<ExerciseApiModel>(dbModel);

                var message = new ConfirmExerciseMessage
                {
                    Id = model.Id,
                    Title = model.Title
                };

                await _notificationService.PublishMessage(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return StatusCode(201, model);
        }
    }
}
