using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken);
        Task<Category> GetById(int id, CancellationToken cancellationToken);
        Task<Category> Add(Category category, CancellationToken cancellationToken);
        Task<Category> Update(Category category, CancellationToken cancellationToken);
        Task<bool> Remove(Category category, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> Search(string categoryName, CancellationToken cancellationToken);
    }
}