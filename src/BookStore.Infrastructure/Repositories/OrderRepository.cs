using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BookStore.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BookStoreDbContext context) 
            : base(context)
        {
        }

        public override async Task<Order> GetById(int id, CancellationToken cancellationToken)
        {
            return await Db.Orders
                .Include(b => b.Books)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<List<Order>> GetAll(CancellationToken cancellationToken)
        {
            return await Db.Orders
                .Include(b => b.Books)
                .ToListAsync(cancellationToken);
        }

        public override async Task Add(Order entity, CancellationToken cancellationToken)
        {
            DbSet.Add(entity);
            await base.SaveChanges(cancellationToken);
        }

        public override async Task Update(Order entity, CancellationToken cancellationToken)
        {
            await base.Update(entity, cancellationToken);
        }

        public async Task<List<Order>> GetOrdersByBookId(int bookId, CancellationToken cancellationToken)
        {
            return await Db.Orders.AsNoTracking()
                .Include(b => b.Books)
                .Where(x => x.Books.Any(y => y.Id == bookId))
                .ToListAsync(cancellationToken);

        }
    }
}