using AuthApi.Domain.Entities;

namespace AuthApi.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario> 
    {
        Usuario CreateUsingAdo(Usuario usuario);
    }
}
