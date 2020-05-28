using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo.Commands.Delete.Dto
{
    public class TodoDeleteCommandDto : IRequest
    {
        public long ID { get; set; }
    }
}
