using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookDateRepository : RepositoryBase<BookDate>, IBookDateRepository
    {
        public BookDateRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateBookDate(BookDate bookdate)
        {
            Create(bookdate);
        }

        public int FindNpofBooksForDate(int Bookid, DateTime date,bool trackChanges)
        {
            return (FindByCondition(b => b.bookid.Equals(Bookid) && b.date.Equals(date),trackChanges).Count());
        }

        public IEnumerable<BookDate> GetAllBookDates(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(b => b.id).ToList();
        }

        public IEnumerable<BookDate> GetBookDates(int BookId, bool trackChanges)
        {
            return FindByCondition(b => b.bookid.Equals(BookId), trackChanges).ToList();
        }
    }
}
