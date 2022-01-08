using Contracts;
using Entities.Models;
using LibraryMS.Interface;
using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Services
{
    public class CreateMail
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMailService _mailService;
        
        


        public CreateMail(IRepositoryManager repository, ILoggerManager logger,IMailService mailService)
        {
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
        }

        public void NewMail(RentRequest rentRequest)
        {

            //User user = _repository.User.GetUser(rentRequest.userid,false);
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = "govindaboob@gmail.com";
            Book book = _repository.Book.GetBook(rentRequest.BookId, false);
            mailRequest.Subject = "Confirmation of rent request of book " + book.BookName.ToString();
            mailRequest.Body = "We are happy to inform you that your renting request for the book " +
                "is approved so you can rent the book " + book.BookName.ToString() + "at the date " +
                rentRequest.startdate.ToString();
            _mailService.SendEmailAsync(mailRequest);
        }
    }
}
