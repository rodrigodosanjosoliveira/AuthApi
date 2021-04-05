using AuthApi.Domain.Entities;
using Bogus;
using System;

namespace AuthApi.Tests.Entities
{
    public class UsuarioFake
    {
        public static Faker<Usuario> FakeData { get; } =
            new Faker<Usuario>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Senha, f => f.Internet.Password())
                .RuleFor(u => u.UltimoLogin, f => f.Date.Past())
                .RuleFor(u => u.Nome, f => f.Name.FullName());
                

    }
}
