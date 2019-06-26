using AutoMapper;
using Exercise.Api.Models;
using Exercise.DAL.Models;

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
