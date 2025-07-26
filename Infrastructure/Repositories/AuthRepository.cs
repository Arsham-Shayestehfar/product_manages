using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IJwtRepository _jwt;

        public AuthRepository(AppDbContext context, IJwtRepository jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<int> RegisterAsync(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
                throw new Exception("Username is already taken.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password.");

            return _jwt.GenerateToken(user);
        }
    }
}
