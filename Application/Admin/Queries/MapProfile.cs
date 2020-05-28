using Application.Admin.Commands.Register.Dto;
using Application.Admin.Queries.Login.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Admin.Login
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Login
            CreateMap<Users, LoginQueryDto>().ReverseMap();
            CreateMap<Users, UserRegisterCommandDto>().ReverseMap();
        }
    }
}
