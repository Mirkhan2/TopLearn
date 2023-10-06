using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs;
using TopLearn.DataLayeer.Entities;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string Email);
        int AddUser(User user);
        User LoginUser(LoginViewModel user);
        User GetUserByEmail(string email);
        User GetUserByActiceCode(string acticeCode);    

        User GetUserByUserName(string username);
     
        void UpdateUser(User user);
        bool ActiveAccount(string activeCode);
        #region User Panel
        InformationUserViewModel GetUSerInformation(string username);
        SideBarUserPanelViewModel GetSideBarUserPanelData(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);

        #endregion

    }
}
