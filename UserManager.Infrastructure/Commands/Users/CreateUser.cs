using System;

namespace UserManager.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}