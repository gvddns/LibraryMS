using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Interface
{
    public interface IGetUserData
    {
        Task<string> GetRoles(string userName);
        Task<string> GetEmail(string username);
        Task<List<User>> GetAllUsers();
    }
}
