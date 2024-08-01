using System;
using BookStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace BookStore.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken);
        Task<Order> GetById(int id, CancellationToken cancellationToken);
        Task<Order> Add(Order order, CancellationToken cancellationToken); 
        Task<Order> Remove(Order order, CancellationToken cancellationToken);
    }
}
