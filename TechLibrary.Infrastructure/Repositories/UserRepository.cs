using TechLibrary.Domain.repositories;
using TechLibrary.Infrastructure.entities;

namespace TechLibrary.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TechLibraryDbContext dbContext;
        public void createUser(UserEntity userData)
        {
            dbContext.Users.Add(userData);
            dbContext.SaveChanges();
        }

      
    }
}
