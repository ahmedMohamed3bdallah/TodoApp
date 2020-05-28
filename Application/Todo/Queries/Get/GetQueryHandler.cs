using Application.Interfaces;
using Application.Todo.Queries.Get.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todo.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetQuery, TodoGetQueryDto>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public GetQueryHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }

        public IMapper Mapper => _mapper;

        public async Task<TodoGetQueryDto> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _todoContext.Todos
                .ProjectTo<TodoGetQueryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.ID == request.ID , cancellationToken: cancellationToken);

            return entity;
        }
    }
}
