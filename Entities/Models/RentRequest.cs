using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RentRequest
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public int bookid { get; set; }
        public string requestdate { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int totalrent { get; set; }
        public string approval { get; set; }
        public string approvaldate { get; set; }
    }
}
