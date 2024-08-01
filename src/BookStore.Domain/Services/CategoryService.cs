using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;

namespace BookStore.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;

        public CategoryService(ICategoryRepository categoryRepository,  IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll(cancellationToken);
        }

        public async Task<Category> GetById(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetById(id, cancellationToken);
        }

        public async Task<Category> Add(Category category, CancellationToken cancellationToken)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name, cancellationToken).Result.Any())
                return null;

            await _categoryRepository.Add(category, cancellationToken);
            return category;
        }

        public async Task<Category> Update(Category category, CancellationToken cancellationToken)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name && c.Id != category.Id, cancellationToken).Result.Any())
                return null;

            if (!_categoryRepository.Search(c => c.Id == category.Id, cancellationToken).Result.Any())
                return null;

            await _categoryRepository.Update(category, cancellationToken);
            return category;
        }

        public async Task<bool> Remove(Category category, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksByCategory(category.Id, cancellationToken);
            if (books.Any()) return false;

            await _categoryRepository.Remove(category, cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Category>> Search(string categoryName, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Search(c => c.Name.Contains(categoryName), cancellationToken);
        }
    }
}