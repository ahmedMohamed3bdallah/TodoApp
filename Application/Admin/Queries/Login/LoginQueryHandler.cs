using Application.Admin.Queries.Login.Dto;
using Application.Common;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Admin.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryDto>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public LoginQueryHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }
        public async Task<LoginQueryDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _todoContext.Users
                .FirstOrDefaultAsync(s => s.UserName == request.UserName,cancellationToken);

            if (user == null) return null;

            if (Utilities.VerifyPasswordHash(request.password, user.PasswordHash, user.PasswordSalt))
            {
                return _mapper.Map<LoginQueryDto>(user);
            }
            else
            {
                return null;
            }
        }
    }
}
