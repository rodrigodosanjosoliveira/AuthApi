using AuthApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AuthApi.Domain.Dto
{
    [DataContract]
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Senha { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public List<TelefoneDto> Telefones { get; set; }

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Senha = usuario.Senha;
            Token = usuario.Token;
            Telefones = TelefoneDto.Convert(usuario.Telefones.ToList());
        }

        public static List<UsuarioDto> Convert(List<Usuario> usuarios) => usuarios.Select(usuario => new UsuarioDto(usuario)).ToList();
    }

}
