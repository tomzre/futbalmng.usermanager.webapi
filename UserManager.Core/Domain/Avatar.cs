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

        public Avatar(string link, string name)
        {
            Name = name;
            Link = link;
        }
    }

    
}