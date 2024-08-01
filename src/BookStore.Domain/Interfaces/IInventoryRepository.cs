using BookStore.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> SearchInventoryForBook(string bookName, CancellationToken cancellationToken);
    }
}