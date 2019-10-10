using AuthApi.Domain.Contracts.Repositories;
using AuthApi.Domain.Contracts.Services;
using AuthApi.Domain.Dto;
using AuthApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Profile> Create(ProfileInputDto profile)
        {
            Profile newProfile = await _profileRepository.Create(new Profile(profile.Id, profile.Nome, profile.Email, profile.Senha, profile.Telefones));
            return newProfile;
        }

        public async Task Delete(Guid id)
        {
            await _profileRepository.Delete(id);
        }

        public IEnumerable<Profile> GetAll()
        {
            var profiles = _profileRepository.GetAll();

            return profiles;
        }

        public async Task<Profile> GetById(Guid id)
        {
            return await _profileRepository.GetById(id);
        }
    }
}
