﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BookDate
    {
        [Key]
        public int id { get; set; }
        public int bookid { get; set; }
        public DateTime date { get; set; }
    }
}
