﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAuthRepository
    {
        Task<int> RegisterAsync(string username, string password);
        Task<string> LoginAsync(string username, string password);
    }
}
