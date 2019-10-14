using System.Collections.Generic;

namespace AuthApi.Domain.ValueTypes
{
    public class Erro : ValueObject
    {
        public Erro()
        {

        }

        public string StatusCode { get; set; }
        public string Mensagem { get; set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StatusCode;
            yield return Mensagem;
        }
    }
}
