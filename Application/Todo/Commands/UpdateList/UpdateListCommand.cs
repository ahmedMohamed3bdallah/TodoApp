using Application.Todo.Commands.UpdateList.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo.Commands.UpdateList
{
    public class UpdateListCommand : IRequest
    {
        public UpdateListCommand()
        {
            todos = new HashSet<TodoUpdateListCommandDto>();
        }
        public long UserId { get; set; }
        public ICollection<TodoUpdateListCommandDto> todos { get; set; }
    }
}
