using Application.Admin.Queries.Login.Dto;
using MediatR;

namespace Application.Admin.Queries
{
    public class LoginQuery : IRequest<LoginQueryDto>
    {
        public string UserName { get; set; }
        public string password { get; set; }

    }
}
