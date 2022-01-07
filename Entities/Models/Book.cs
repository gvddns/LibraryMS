using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Book name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")] 
        public string BookName { get; set; }
        [Required(ErrorMessage = "Author name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Author is 60 characters")]
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public string ImageAddress { get; set; }
        public int NoOfBooks { get; set; }
        public int rent { get; set; }
    }
}
