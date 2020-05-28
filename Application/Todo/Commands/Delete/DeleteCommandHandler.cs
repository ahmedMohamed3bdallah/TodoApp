using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Todo.Commands.Delete.Dto;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todo.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<TodoDeleteCommandDto,Unit>
    {
        private readonly ITodoContext _todoContext;

        public DeleteCommandHandler(ITodoContext todoContext)
        {
            this._todoContext = todoContext;
        }

        public async Task<Unit> Handle(TodoDeleteCommandDto request, CancellationToken cancellationToken)
        {
            var builder = await _todoContext.Todos
                .FindAsync(request.ID);

            if (builder == null)
            {
                throw new NotFoundException(nameof(Todos), request.ID);
            }

            try
            {
                _todoContext.Todos.Remove(builder);

                await _todoContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw new DeleteFailureException(nameof(Todos), request.ID, "Error While Deleting");
            }

            return Unit.Value;
        }
    }
}
