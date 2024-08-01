using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly BookStoreDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        protected Repository(BookStoreDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            await SaveChanges(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            DbSet.Update(entity);
            await SaveChanges(cancellationToken);
        }

        public virtual async Task UpdateRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            DbSet.UpdateRange(entities);
            await SaveChanges(cancellationToken);
        }

        public virtual async Task Remove(TEntity entity, CancellationToken cancellationToken)
        {
            DbSet.Remove(entity);
            await SaveChanges(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            return await Db.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}