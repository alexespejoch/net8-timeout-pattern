using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll(CancellationToken cancellationToken);
        Task<Book> GetById(int id, CancellationToken cancellationToken);
        Task<Book> Add(Book book, CancellationToken cancellationToken);
        Task<Book> Update(Book book, CancellationToken cancellationToken);
        Task<bool> Remove(Book book, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> Search(string bookName, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue, CancellationToken cancellationToken);
    }
}