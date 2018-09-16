using System;

namespace UserManager.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : AuthenticatedCommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}