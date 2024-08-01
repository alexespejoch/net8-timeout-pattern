using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(
            BookStoreDbContext context) : base(context)
        {
        }

        public override async Task<List<Book>> GetAll(CancellationToken cancellationToken)
        {
            return await Db.Books.Include(b => b.Category)
                .OrderBy(b => b.Name)
                .ToListAsync(cancellationToken);
        }

        public override async Task<Book> GetById(int id, CancellationToken cancellationToken)
        {
            return await Db.Books.Include(b => b.Category)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId, CancellationToken cancellationToken)
        {
            return await Search(b => b.CategoryId == categoryId, cancellationToken);
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue, CancellationToken cancellationToken)
        {
            return await Db.Books.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) || 
                            b.Author.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync(cancellationToken);
        }

        public override async Task Add(Book entity, CancellationToken cancellationToken)
        {
            await base.Add(entity, cancellationToken);
        }

        public override async Task Update(Book entity, CancellationToken cancellationToken)
        {
            await base.Update(entity,cancellationToken);
        }

        public override async Task Remove(Book entity, CancellationToken cancellationToken)
        {
            await base.Remove(entity, cancellationToken);
        }
    }
}