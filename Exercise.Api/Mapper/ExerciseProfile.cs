using AutoMapper;
using Exercise.Api.DAL.DbModels;
using Exercise.Api.Models;

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
