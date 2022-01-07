using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Interface
{
    public interface ICreateMail
    {
        void NewMail(RentRequest rentRequest);
    }
}
