using AuthApi.Data.Context;
using AuthApi.Domain.Contracts.Repositories;
using AuthApi.Domain.Entities;

namespace AuthApi.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AuthApiContext context)
            : base(context) { }

        
    }
}
