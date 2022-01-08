using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class PlanDto
    {
        public int Planid { get; set; }
        public string planName { get; set; }
        public int Duration { get; set; }
        public int price { get; set; }
    }
}
