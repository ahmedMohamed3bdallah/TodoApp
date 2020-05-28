using MediatR;

namespace Application.Admin.Commands.Register.Dto
{
    public class UserRegisterCommandDto: IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
