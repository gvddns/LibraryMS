using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string ImageAddress { get; set; }
        public int NoOfBooks { get; set; }
        public int rent { get; set; }
        public int CategoryId { get; set; }
    }
}
