using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class RentRequestDto
    {
        public int id { get; set; }
        public int userid { get; set; }
        public DateTime requestdate { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public int totalrent { get; set; }
        public string approval { get; set; }
        public DateTime approvaldate { get; set; }
        public int BookId { get; set; }
    }
}
