using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AuthApi.Domain.Dto
{
    [DataContract]
    public class TelefoneDto
    {
        public TelefoneDto()
        {

        }

        [DataMember]
        public string Ddd { get; set; }

        [DataMember]
        public string Numero { get; set; }

        public Guid UsuarioId { get; set; }

        public TelefoneDto(Telefone telefone)
        {
            Ddd = telefone.Ddd;
            Numero = telefone.Numero;
            UsuarioId = telefone.UsuarioId;
        }

        public static List<TelefoneDto> Convert(List<Telefone> telefones) => telefones.Select(telefone => new TelefoneDto(telefone)).ToList();
    }

}
