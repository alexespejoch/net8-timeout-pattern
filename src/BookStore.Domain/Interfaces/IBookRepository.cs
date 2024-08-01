using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        new Task<List<Book>> GetAll(CancellationToken cancellationToken);
        new Task<Book> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue, CancellationToken cancellationToken);
    }
}