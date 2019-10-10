using AuthApi.Domain.Entities;
using AuthApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthApi.Domain.Dto
{
    public class ProfileDto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public List<Telefone> Telefones { get; private set; }

        public ProfileDto(Profile profile)
        {
            Id = profile.Id;
            Nome = profile.Nome;
            Email = profile.Email;
            Senha = profile.Senha;
            Telefones = profile.Telefones.ToList();
        }

        public static List<ProfileDto> Convert(List<Profile> profiles) => profiles.Select(profile => new ProfileDto(profile)).ToList();
    }

}
