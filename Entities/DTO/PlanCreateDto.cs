using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class PlanCreateDto
    {
        [Required(ErrorMessage = "lan name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string planName { get; set; }
        [Required(ErrorMessage = "Duration is a required field.")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Book name is a required field.")]
        public int price { get; set; }
    }
}
