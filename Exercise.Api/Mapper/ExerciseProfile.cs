using AutoMapper;
using Exercise.Api.DbModels;
using Exercise.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Mapper
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExerciseApiModel, ExerciseDbModel>().ReverseMap();
        }
    }
}
