using System;

namespace UserManager.Core.Domain
{
    public class Avatar
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Link { get; protected set; }
            
        protected Avatar()
        {
        }

        public Avatar(string name, string link)
        {
            Id = Guid.NewGuid();
            Name = name;
            Link = link;
        }

        public static Avatar Create(string name, string link)
            => new Avatar(name, link);
    }

    
}