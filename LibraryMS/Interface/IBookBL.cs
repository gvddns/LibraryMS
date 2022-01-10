using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Interface
{
    public interface IBookBL
    {
        public Task<string> UpdateBookbyId(int id, BookCreateDto book);
    }
}
