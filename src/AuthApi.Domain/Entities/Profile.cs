using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace AuthApi.Domain.Entities
{
    public class Profile : Entity
    {
        public Profile(Guid id, string nome, string email, string senha, ICollection<Telefone> telefones)
            : base(id)
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
        public DateTime UltimoLogin { get; set; }
        public ICollection<Telefone> Telefones { get; }
    }


}
