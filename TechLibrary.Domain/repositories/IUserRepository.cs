using TechLibrary.Domain.entities;

namespace TechLibrary.Domain.repositories
{
    public interface IUserRepository
    {
        void createUser(UserEntity userData);
        UserEntity findByEmail(string email);
    }
}
