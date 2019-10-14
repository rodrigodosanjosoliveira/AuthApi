using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace AuthApi.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario() { }

        public Usuario(string nome, string email, string senha, List<Telefone> telefones)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefones = telefones;
            UltimoLogin = base.DateCreated;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; }
        public string Token { get; set; }
        public DateTime UltimoLogin { get; set; }
        public List<Telefone> Telefones { get; }
    }

}
