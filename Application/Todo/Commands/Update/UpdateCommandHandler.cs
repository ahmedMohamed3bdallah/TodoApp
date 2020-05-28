using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Todo.Commands.Update.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todo.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<TodoUpdateCommandDto, Unit>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(TodoUpdateCommandDto request, CancellationToken cancellationToken)
        {
            var entity = await _todoContext
                                .Todos
                                .SingleOrDefaultAsync(a => a.ID == request.ID, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Todos), request.ID);
            }

            _mapper.Map(request, entity);

            try
            {

                await _todoContext.SaveChangesAsync(cancellationToken);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Unit.Value;
        }
    }
}
