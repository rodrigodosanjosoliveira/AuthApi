using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace AuthApi.Domain.Dto
{
    public class ProfileInputDto
    {
        public  Guid Id{ get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public List<Telefone> Telefones { get; private set; }
    }

}
