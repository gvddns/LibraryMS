using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(b => b.UserId).ToList();
        }

        public User GetUser(int UserId, bool trackChanges)
        {
            return FindByCondition(c => c.UserId.Equals(UserId), trackChanges).SingleOrDefault();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
