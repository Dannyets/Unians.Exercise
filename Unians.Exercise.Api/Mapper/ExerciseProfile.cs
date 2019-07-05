using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unians.Exercise.Api.Data.Models;
using Unians.Exercise.Data.Models;

namespace Unians.Exercise.Api.Mapper
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ApiExercise, DbExercise>().ReverseMap();
        }
    }
}
