using MediatR;

namespace Application.Todo.Queries.Get.Dto
{
    public class GetQuery : IRequest<TodoGetQueryDto>
    {
        public long ID { get; set; }

    }
}
