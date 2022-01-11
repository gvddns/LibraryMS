using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class BookCreateDto
    {
        [Required(ErrorMessage = "Book name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Author name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Author is 60 characters")]
        public string Author { get; set; }
        public string ImageAddress { get; set; }
        [Required(ErrorMessage = "Number of books is a required field.")]
        public int NoOfBooks { get; set; }
        [Required(ErrorMessage = "Rent is a required field.")]
        public int rent { get; set; }
        [Required(ErrorMessage = "CategoryId is a required field.")]
        public int CategoryId { get; set; }
        
    }
}
