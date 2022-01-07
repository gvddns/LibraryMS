using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string Rolename { get; set; }
    }
}
