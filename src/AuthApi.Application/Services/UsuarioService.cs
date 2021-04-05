using AuthApi.Domain.Contracts.Repositories;
using AuthApi.Domain.Contracts.Services;
using AuthApi.Domain.Dto;
using AuthApi.Domain.Entities;
using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Create(UsuarioInputDto usuarioInput)
        {
            var telefones = usuarioInput.Telefones.Select(t => new Telefone(t.Ddd, t.Numero, t.UsuarioId));
            var usuario = new Usuario(usuarioInput.Nome, usuarioInput.Email, usuarioInput.Senha, telefones.ToList())
            {
                Token = usuarioInput.Token
            };
            Usuario novoUsuario = await _usuarioRepository.Create(usuario);
            return novoUsuario;
        }

        public Usuario CreateWithAdo(UsuarioInputDto usuarioInput)
        {
            var telefones = usuarioInput.Telefones.Select(t => new Telefone(t.Ddd, t.Numero, t.UsuarioId));
            var usuario = new Usuario(usuarioInput.Nome, usuarioInput.Email, usuarioInput.Senha, telefones.ToList())
            {
                Token = usuarioInput.Token
            };

            var retorno = _usuarioRepository.CreateUsingAdo(usuario);
            return retorno;
        }

        public async Task Delete(Guid id)
        {
            await _usuarioRepository.Delete(id);
        }

        public Erro EmailJaExiste(UsuarioInputDto usuario)
        {
            Erro erro = null;

            if (GetAll().Any(p => p.Email == usuario.Email))
                erro = new Erro { StatusCode = "400", Mensagem = "Parâmetros inválidos." };

            return erro;
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();

            return usuarios;
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await _usuarioRepository.GetById(id);
        }

        public async Task<Usuario> Update(Guid id, UsuarioDto usuario)
        {
            var usuarioAtualizado = new Usuario(usuario.Nome, usuario.Email, usuario.Senha, usuario.Telefones.Select(t => new Telefone(t.Ddd, t.Numero, usuario.Id)).ToList());
            return await _usuarioRepository.Update(id, usuarioAtualizado);
        }
    }
}
