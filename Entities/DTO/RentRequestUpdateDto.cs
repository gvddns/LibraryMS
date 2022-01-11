using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class RentRequestUpdateDto
    {
        [Required(ErrorMessage = "request id is a required field.")]
        public int rid { get; set; }
        [Required(ErrorMessage = "Approval is a required field.")]
        public string approval { get; set; }
        //public DateTime approvaldate { get; set; }
    }
}
