using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LibraryMS.Interface;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Services
{
    public class BookBL : IBookBL
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookBL(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<string> UpdateBookbyId(int id, BookCreateDto book)
        {
            Book bookToUpdate = _repository.Book.GetBook(id, false);
            if (bookToUpdate == null)
            {
                return "The book record couldn't be found.";
            }

            var bookEntity = _mapper.Map<Book>(book);
            bookEntity.BookId = id;
            _repository.Book.UpdateBook(bookEntity);
            await _repository.SaveAsync();
            return "Updated Successfully";
        }
    }
}
