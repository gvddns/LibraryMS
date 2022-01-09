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

        public async Task<string> GetEmail(string username)
        {
            _user = await _userManager.FindByNameAsync(username);
            var email = await _userManager.GetEmailAsync(_user);
            return email;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return (List<User>)users;
        }
    }
}
