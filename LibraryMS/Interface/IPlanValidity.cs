using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Interface
{
    public interface IPlanValidity
    {
        public Task<int> AddValidityAsync(string username, int planid);
        public void CreateValidity(string username);
    }
}
