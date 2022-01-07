﻿using Contracts;
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
        private IRentRequestRepository _rentrequestRepository;
        private IBookDateRepository _bookdateRepository;
        private IUserRepository _userRepository;

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

        public IBookDateRepository BookDate
        {
            get
            {
                if (_bookdateRepository == null)
                    _bookdateRepository = new BookDateRepository(_repositoryContext);
                return _bookdateRepository;
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

        public IRentRequestRepository RentRequest
        {
            get
            {
                if (_rentrequestRepository == null)
                    _rentrequestRepository = new RentRequestRepository(_repositoryContext);
                return _rentrequestRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);
                return _userRepository;
            }
        }


        public void Save() => _repositoryContext.SaveChanges();
    }
}
