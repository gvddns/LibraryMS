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
        public IEnumerable<Book> GetAllBooks(bool trackChanges);
        IEnumerable<Book> GetBooks(int categoryId, bool trackChanges);
        public Book GetBook(int BookId, bool trackChanges);
        void CreateBook(Book book);
    }
}
