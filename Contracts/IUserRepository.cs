using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers(bool trackChanges);
        public User GetUser(int UserId, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
