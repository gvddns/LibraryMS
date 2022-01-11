using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class PasswordDto
    {
        [Required(ErrorMessage = "Username is a required field.")]
        public string username { get; set; }
        [Required(ErrorMessage = "password is a required field.")]
        [MinLength(8, ErrorMessage = "minimum length should be 8 char.")]
        public string oldpassword { get; set; }
        [Required(ErrorMessage = "New Password is a required field.")]
        [MinLength(8, ErrorMessage = "minimum length should be 8 char.")]
        public string newpassword { get; set; }
    }
}
