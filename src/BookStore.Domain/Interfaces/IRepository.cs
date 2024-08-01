using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken);
        Task Update(TEntity entity, CancellationToken cancellationToken);
        Task UpdateRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task Remove(TEntity entity, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}