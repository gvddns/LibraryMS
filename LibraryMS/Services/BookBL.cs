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
        //Declaration of Interfaces
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookBL(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //Code for Book Updation
        public async Task<string> UpdateBookbyId(int id, BookCreateDto book)
        {
            Book bookToUpdate = await _repository.Book.GetBookAsync(id);
            if (bookToUpdate == null)
            {
                return "The book record couldn't be found.";
            }
            var bookEntity = _mapper.Map<Book>(book);
            bookEntity.BookId = id;
            _repository.Book.UpdateBookAsync(bookEntity);
            await _repository.SaveAsync();
            return "Updated Successfully";
        }
    }
}
