using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo.Commands.Update.Dto
{
    public class TodoUpdateCommandDto : IRequest
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public long SortOrder { get; set; }
    }
}
