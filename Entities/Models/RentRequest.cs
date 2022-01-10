using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RentRequest
    {
        [Key]
        public int rid { get; set; }
        public string username { get; set; }
        public DateTime requestdate { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public int totalrent { get; set; }
        public string approval { get; set; }
        public DateTime approvaldate { get; set; }

        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Category book { get; set; }
    }
}
