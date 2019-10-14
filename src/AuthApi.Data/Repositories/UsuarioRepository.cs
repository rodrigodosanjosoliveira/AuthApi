using AuthApi.Data.Context;
using AuthApi.Domain.Contracts.Repositories;
using AuthApi.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace AuthApi.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AuthApiContext context)
            : base(context) { }

        private readonly string ConnectionString = "Server=.\\SQLEXPRESS;Database=AuthApiDb;Integrated Security=true";

        public Usuario CreateUsingAdo(Usuario usuario)
        {
            var query = "INSERT INTO [dbo].[Usuario]"
                       + "([Id]"
                       + ",[DateCreated]"
                       + ",[DateUpdated]"
                       + ",[Nome]"
                       + ",[Email]"
                       + ",[Senha]"
                       + ",[Token]"
                       + ",[UltimoLogin])"
                       + " VALUES"
                       + $"('{usuario.Id}'"
                       + $",'{usuario.DateCreated}'"
                       + $", NULL"
                       + $",'{usuario.Nome}'"
                       + $",'{usuario.Email}'"
                       + $",'{usuario.Senha}'"
                       + $",'{usuario.Token}'"
                       + $",'{usuario.UltimoLogin}'); ";

            if(usuario.Telefones.Any())
                foreach (var telefone in usuario.Telefones)
                {
                    query +=
                            $"INSERT INTO [dbo].[Telefone] " +
                            $"([Ddd],[Numero],[UsuarioId]) " +
                            $"VALUES " +
                            $"('{telefone.Ddd}','{telefone.Numero}', '{usuario.Id}')";
                }

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            var retorno = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return retorno > 0 ? usuario : null;
        }
    }
}
