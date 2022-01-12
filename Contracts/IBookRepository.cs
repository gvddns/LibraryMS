using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(int categoryId);
        public Task<Book> GetBookAsync(int BookId);
        public Book GetBook(int BookId);
        void CreateBook(Book book);
        Task<string> DeleteBookAsync(int id);
        void UpdateBookAsync(Book book);
    }
}
