using Application.Interfaces;
using Application.Todo.Queries.GetAll.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todo.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<TodoGetAllQueryDto>>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }
        public async Task<List<TodoGetAllQueryDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var entity = await _todoContext
                                   .Todos
                                   .Where(u => u.UserID == request.UserID)
                                   .ProjectTo<TodoGetAllQueryDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);
            return entity;
        }
    }
}
