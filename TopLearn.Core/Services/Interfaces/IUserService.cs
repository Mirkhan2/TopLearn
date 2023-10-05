using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs;
using TopLearn.DataLayeer.Entities;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string Email);
        int AddUser(User user);
        User Login(User user);
        bool ActiveAccount(string activeCode);
        object LoginUser(LoginViewModel login);
    }
}
