using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory> GetById(int id, CancellationToken cancellationToken);
        Task<Inventory> Add(Inventory inventory, CancellationToken cancellationToken);
        Task<Inventory> Update(Inventory inventory, CancellationToken cancellationToken);
        Task<bool> Remove(Inventory inventory, CancellationToken cancellationToken);
        Task<IEnumerable<Inventory>> SearchInventoryForBook(string searchedValue, CancellationToken cancellationToken);
    }
}