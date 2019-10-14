using System;
using System.Collections.Generic;

namespace AuthApi.Domain.ValueTypes
{
    public class Telefone : ValueObject
    {
        public Telefone()
        {

        }

        public string Ddd { get; }
        public string Numero { get; }
        public Guid UsuarioId { get; }

        public Telefone(string ddd, string numero, Guid usuarioId)
        {
            Ddd = ddd;
            Numero = numero;
            UsuarioId = usuarioId;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Ddd;
            yield return Numero;
            yield return UsuarioId;
        }

        
    }
}
