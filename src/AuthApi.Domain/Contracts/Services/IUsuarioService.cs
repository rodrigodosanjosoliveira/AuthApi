using AuthApi.Domain.Dto;
using AuthApi.Domain.Entities;
using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Domain.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> Create(UsuarioInputDto usuario);

        Task Delete(Guid id);

        IEnumerable<Usuario> GetAll();

        Task<Usuario> GetById(Guid id);

        Task<Usuario> Update(Guid id, UsuarioDto usuario);

        Erro EmailJaExiste(UsuarioInputDto usuario);
 
    }
}
