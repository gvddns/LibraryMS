using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IBookDateRepository
    {
        public void CreateBookDate(BookDate bookdate);
        public Task<IEnumerable<BookDate>> GetAllBookDatesAsync();
        Task<IEnumerable<BookDate>> GetBookDatesAsync(int BookId);
        public int FindNpofBooksForDate(int Bookid, DateTime date);
    }
}
