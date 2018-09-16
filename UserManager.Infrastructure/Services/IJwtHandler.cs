using System;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}