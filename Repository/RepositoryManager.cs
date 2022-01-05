using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IBookRepository _bookRepository;
        private ICategoryRepository _categoryRepository;
        public RepositoryManager(RepositoryContext repositoryContext) 
        { 
            _repositoryContext = repositoryContext; 
        }
        public IBookRepository Book 
        {
            get 
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_repositoryContext);
                return _bookRepository; 
            }
        }

        public ICategoryRepository Category
        { 
            get 
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_repositoryContext);
                return _categoryRepository; 
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
