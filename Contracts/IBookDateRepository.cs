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
        public IEnumerable<BookDate> GetAllBookDates(bool trackChanges);
        IEnumerable<BookDate> GetBookDates(int BookId, bool trackChanges);
        public int FindNpofBooksForDate(int Bookid, DateTime date, bool trackChanges);
    }
}
