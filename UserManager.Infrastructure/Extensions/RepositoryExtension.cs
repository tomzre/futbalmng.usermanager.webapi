using System;
using System.Threading.Tasks;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;

namespace UserManager.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);

            if(user == null)
            {
                throw new Exception($"User with id: '{userId}' was not found.");
            }

            return user;
        }

        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetAsync(email);

            if(user == null)
            {
                throw new Exception($"User with email: '{email}' does not exists.");
            }

            return user;
        }
    }
}