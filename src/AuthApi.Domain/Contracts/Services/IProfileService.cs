using AuthApi.Domain.Dto;
using AuthApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Domain.Contracts.Services
{
    public interface IProfileService
    {
        Task<Profile> Create(ProfileInputDto profile);

        Task Delete(Guid id);

        IEnumerable<Profile> GetAll();

        Task<Profile> GetById(Guid id);
 
    }
}
