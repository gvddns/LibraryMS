using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LibraryMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Services
{
    public class AddBookDate : IAddBookDate
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AddBookDate(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async void AddBooks(DateTime startdate, DateTime enddate,int Bookid)
        {
            BookDateDto bookDate = new BookDateDto()
            {
                BookId = Bookid
            };

            while (DateTime.Compare(startdate.Date, enddate.Date)<=0)
            {
                bookDate.date = startdate.Date;
                var bookDateEntity = _mapper.Map<BookDate>(bookDate);
                
                _repository.BookDate.CreateBookDate(bookDateEntity);
                _repository.Save();
                startdate = startdate.AddDays(1);
            }
            
        }
    }
}
