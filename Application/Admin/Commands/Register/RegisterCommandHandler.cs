using Application.Admin.Commands.Register.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Admin.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<UserRegisterCommandDto, Unit>
    {
        private readonly ITodoContext _todoContext;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(ITodoContext todoContext, IMapper mapper)
        {
            this._todoContext = todoContext;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UserRegisterCommandDto request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Users>(request);
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _todoContext.Users.AddAsync(user);
            await _todoContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }

    }
}
