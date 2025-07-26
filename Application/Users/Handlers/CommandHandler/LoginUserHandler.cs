using Application.Repositories;
using Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handlers.CommandHandler
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthRepository _auth;

        public LoginUserHandler(IAuthRepository auth)
        {
            _auth = auth;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _auth.LoginAsync(request.Username, request.Password);
        }
    }
}
