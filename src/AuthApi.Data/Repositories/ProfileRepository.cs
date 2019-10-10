using AuthApi.Data.Context;
using AuthApi.Domain.Contracts.Repositories;
using AuthApi.Domain.Entities;

namespace AuthApi.Data.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(AuthApiContext context)
            : base(context) { }
    }
}
