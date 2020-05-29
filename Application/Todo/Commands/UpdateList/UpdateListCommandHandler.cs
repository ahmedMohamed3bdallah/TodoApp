using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Todo.Commands.Update.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todo.Commands.UpdateList
{
    public class UpdateListCommandHandler : IRequestHandler<UpdateListCommand, Unit>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public UpdateListCommandHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateListCommand request, CancellationToken cancellationToken)
        {
            var todoDTO = request.todos;

            var entity = await _todoContext
                                .Todos
                                .Where(a => a.UserID == request.UserId)
                                .ToListAsync(cancellationToken);

            foreach (var item in todoDTO)
            {
                var temp = entity.FindIndex(s => s.ID == item.ID);
                entity[temp].SortOrder = item.SortOrder;
            }

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
