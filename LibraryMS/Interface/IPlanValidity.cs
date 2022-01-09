using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Interface
{
    public interface IPlanValidity
    {
        public int AddValidity(string username, int planid);
        public void CreateValidity(string username);
    }
}
