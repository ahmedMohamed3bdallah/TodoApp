using Application.Todo.Queries.GetAll.Dto;
using MediatR;
using System.Collections.Generic;

namespace Application.Todo.Queries.GetAll
{
    public class GetAllQuery : IRequest<List<TodoGetAllQueryDto>>
    {
        public long UserID { get; set; }

    }
}
