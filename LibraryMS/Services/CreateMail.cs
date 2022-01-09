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
        private readonly IGetUserData _getUserData;
        


        public CreateMail(IRepositoryManager repository, ILoggerManager logger,IMailService mailService, IGetUserData getUserData)
        {
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
            _getUserData = getUserData;
        }

        public async void NewMail(RentRequest rentRequest)
        {
            string mailid = await _getUserData.GetEmail(rentRequest.username);
            //User user = _repository.User.GetUser(rentRequest.userid,false);
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = mailid;
            Book book = _repository.Book.GetBook(rentRequest.BookId, false);
            mailRequest.Subject = "Confirmation of rent request of book " + book.BookName.ToString();
            mailRequest.Body = "We are happy to inform you that your renting request for the book " +
                "is approved so you can rent the book " + book.BookName.ToString() + " at the date " +
                rentRequest.startdate.ToString();
            await _mailService.SendEmailAsync(mailRequest);
        }

        public void NewRegistrationMail(string username,string mailid)
        {

            //User user = _repository.User.GetUser(rentRequest.userid,false);
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = mailid;
            mailRequest.Subject = "Confirmation of registration  ";
            mailRequest.Body = "Dear " + username + ". We are happy to welcom you as a new member \n" +
                "Also if you have any problems you can mail us on this mail id. And can contact us" +
                " on telephone number 9988776655";
            _mailService.SendEmailAsync(mailRequest);
        }
    }
}
