using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(BookStoreDbContext context) : base(context)
        {
        }

        public override async Task Add(Category entity, CancellationToken cancellationToken)
        {
            await base.Add(entity, cancellationToken);            
        }

        public override async Task Update(Category entity, CancellationToken cancellationToken)
        {
            await base.Update(entity, cancellationToken);
        }

        public override async Task Remove(Category entity, CancellationToken cancellationToken)
        {
            await base.Remove(entity, cancellationToken);
        }
    }
}