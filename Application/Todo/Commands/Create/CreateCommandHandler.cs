using Application.Interfaces;
using Application.Todo.Commands.Create.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todo.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<TodoCreateCommandDto, TodoCreateCommandDto>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public CreateCommandHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }
        public async Task<TodoCreateCommandDto> Handle(TodoCreateCommandDto request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Todos>(request);
            try
            {
                _todoContext.Todos.Add(entity);

                await _todoContext.SaveChangesAsync(cancellationToken);

                _mapper.Map(entity, request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return request;
        }
    }
}
