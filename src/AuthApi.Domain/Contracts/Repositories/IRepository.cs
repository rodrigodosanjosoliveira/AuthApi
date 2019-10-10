using AuthApi.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Domain.Contracts.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task Update(Guid id, T entity);

        Task Delete(Guid id);
    }
}
