using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AuthApi.Domain.Dto
{
    [DataContract]
    public class UsuarioInputDto
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Email { get; set; }
        public string Token { get; set;  }
        [DataMember]
        public string Senha { get; set; }
        [DataMember]
        public List<TelefoneDto> Telefones { get; set; }
    }

}
