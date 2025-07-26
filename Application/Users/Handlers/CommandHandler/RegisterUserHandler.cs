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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IAuthRepository _auth;

        public RegisterUserHandler(IAuthRepository authService)
        {
            _auth = authService;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _auth.RegisterAsync(request.Username, request.Password);
        }
    }
}
