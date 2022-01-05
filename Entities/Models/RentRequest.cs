using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    class RentRequest
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int bookid { get; set; }
        public DateTime requestdate { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string approval { get; set; }
        public DateTime approvaldate { get; set; }
    }
}
