using DemoDDD.Domain.Users;

namespace DemoDDD.Infrastucture.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
