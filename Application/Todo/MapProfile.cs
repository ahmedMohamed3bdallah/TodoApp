using Application.Todo.Commands.Create.Dto;
using Application.Todo.Commands.Update.Dto;
using Application.Todo.Queries.Get;
using Application.Todo.Queries.GetAll.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Todo
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Get
            CreateMap<Todos, TodoGetQueryDto>().ReverseMap();

            //GetALl
            CreateMap<Todos, TodoGetAllQueryDto>().ReverseMap();

            //Create
            CreateMap<Todos, TodoCreateCommandDto>().ReverseMap();

            //Update
            CreateMap<Todos, TodoUpdateCommandDto>().ReverseMap();

        }
    }
}
