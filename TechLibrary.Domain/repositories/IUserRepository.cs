using TechLibrary.Infrastructure.entities;

namespace TechLibrary.Domain.repositories
{
    public interface IUserRepository
    {
        void createUser(UserEntity userData);
    }
}
