using System;

namespace UserManager.Infrastructure.Commands
{
    public class AuthenticatedCommand : IAuthenticatedCommand
    {
        public Guid UserId { get; set ; }
    }
}