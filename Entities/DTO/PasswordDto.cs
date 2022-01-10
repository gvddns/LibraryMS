using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class PasswordDto
    {
        public string username { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }
}
