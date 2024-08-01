using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;

namespace BookStore.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Book>> GetAll(CancellationToken cancellationToken)
        {
            //await Task.Delay(TimeSpan.FromMilliseconds(5000), cancellationToken);
            return await _bookRepository.GetAll(cancellationToken);
        }

        public async Task<Book> GetById(int id, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetById(id, cancellationToken);
        }

        public async Task<Book> Add(Book book, CancellationToken cancellationToken)
        {
            if (_bookRepository.Search(b => b.Name == book.Name, cancellationToken).Result.Any())
                return null;

            var category = await _categoryRepository.GetById(book.CategoryId, cancellationToken);
            if (category is null)
                return null;

            if (!book.HasCorrectPublishDate())
                return null;

            if (!book.HasPositivePrice())
                return null;

            await _bookRepository.Add(book, cancellationToken);
            return book;
        }

        public async Task<Book> Update(Book book, CancellationToken cancellationToken)
        {
            if (_bookRepository.Search(b => b.Name == book.Name && b.Id != book.Id, cancellationToken).Result.Any())
                return null;

            if (!book.HasCorrectPublishDate())
                return null;

            if (!book.HasPositivePrice())
                return null;

            await _bookRepository.Update(book, cancellationToken);
            return book;
        }

        public async Task<bool> Remove(Book book, CancellationToken cancellationToken)
        {
            await _bookRepository.Remove(book, cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBooksByCategory(categoryId, cancellationToken);
        }

        public async Task<IEnumerable<Book>> Search(string bookName, CancellationToken cancellationToken)
        {
            return await _bookRepository.Search(c => c.Name.Contains(bookName), cancellationToken);
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue, CancellationToken cancellationToken)
        {
            return await _bookRepository.SearchBookWithCategory(searchedValue, cancellationToken);
        }
    }
}