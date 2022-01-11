using Entities.Models;
using LibraryMS.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Services
{
    public class GetUserData: IGetUserData
    {
        private readonly UserManager<User> _userManager;
        private User _user;
        public GetUserData(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetRoles(string userName)
        {
            _user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(_user);
            return roles.FirstOrDefault();
        }

        //Method to get email from username
        public async Task<string> GetEmail(string username)
        {
            _user = await _userManager.FindByNameAsync(username);
            var email = await _userManager.GetEmailAsync(_user);
            return email;
        }

        //Method to get all Users with role user
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return (List<User>)users;
        }


        public async Task<string> GetUserId(string username)
        {
            _user = await _userManager.FindByNameAsync(username);
            if (_user != null)
            {
                var userid = await _userManager.GetUserIdAsync(_user);
                return userid;
            }
            else
                return null;
        }

        //Validation for dates entries for renting
        public async Task<string> CheckDates(string username, DateTime startdate, DateTime enddate)
        {
            _user = await _userManager.FindByNameAsync(username);
            if (DateTime.Compare(startdate,enddate)>0)
            {
                return "Start Date can not be later than end date";
            }
            if (DateTime.Compare(enddate, _user.PlanDate)>0)
            {
                return "End Date can not be later than Membership end date";
            }
            return null;
        }
    }
}
