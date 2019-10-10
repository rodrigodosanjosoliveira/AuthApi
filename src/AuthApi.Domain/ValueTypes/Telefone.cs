using AuthApi.Domain.Entities;
using System.Collections.Generic;

namespace AuthApi.Domain.ValueTypes
{
    public class Telefone : ValueObject
    {
        public string Ddd { get; }
        public string Numero { get; }
        public int ProfileId { get; }
        public Profile Profile { get; }

        public Telefone(string ddd, string numero)
        {
            Ddd = ddd;
            Numero = numero;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Ddd;
            yield return Numero;
        }
    }
}
