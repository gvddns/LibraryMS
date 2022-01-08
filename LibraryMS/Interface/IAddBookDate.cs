using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Interface
{
    public interface IAddBookDate
    {
        public void AddBooks(DateTime startdate,DateTime enddate,int BookId);
    }
}
