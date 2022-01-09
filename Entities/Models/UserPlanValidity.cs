using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserPlanValidity
    {
        public int id { get; set; }
        public DateTime planEnddate { get; set; }
        public string UserName { get; set; }
    }
}
