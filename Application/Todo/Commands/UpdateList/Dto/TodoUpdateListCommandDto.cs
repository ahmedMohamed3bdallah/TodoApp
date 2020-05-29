using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo.Commands.UpdateList.Dto
{
    public class TodoUpdateListCommandDto
    {
        public long ID { get; set; }
        public long SortOrder { get; set; }
    }
}
