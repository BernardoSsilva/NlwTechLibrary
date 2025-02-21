using TechLibrary.Domain.repositories;
using TechLibrary.Domain.entities;

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

        public UserEntity findByEmail(string email)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            return user;
        }
    }
}
