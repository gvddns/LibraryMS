using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        ICategoryRepository Category { get; }
        IBookDateRepository BookDate { get; }
        IRentRequestRepository RentRequest { get; }
        //IUserRepository User { get; }
        IPlanRepository Plan { get; }
        void Save();
    }
}
