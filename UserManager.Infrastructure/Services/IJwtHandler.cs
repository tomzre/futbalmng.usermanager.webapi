using System;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}