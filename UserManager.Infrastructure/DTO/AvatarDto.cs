using System;

namespace UserManager.Infrastructure.DTO
{
    public class AvatarDto
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Link { get; protected set; }
    }
}