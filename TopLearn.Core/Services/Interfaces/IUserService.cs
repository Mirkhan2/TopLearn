using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs;
using TopLearn.Core.DTOs.Users;
using TopLearn.DataLayeer.Entities;
using TopLearn.DataLayeer.Entities.User;
using TopLearn.DataLayeer.Entities.Wallet;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string Email);
        int AddUser(User user);
        User LoginUser(LoginViewModel user);
        User GetUserByEmail(string email);
        User GetUserByActiveCode(string acticeCode);    

        User GetUserByUserName(string username);
     
        void UpdateUser(User user);
        bool ActiveAccount(string activeCode);
        int GetUserIdByUserName(string userName);
        #region User Panel
        InformationUserViewModel GetUSerInformation(string username);
        SideBarUserPanelViewModel GetSideBarUserPanelData(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username,EditProfileViewModel profile);
        bool CompareOldPassword(string oldPassword , string username);
        void ChangeUserPassword(string userName , string newPassword);
        #endregion

        #region Wallet 

        int BalanceUserWallet(string userName);
        List<WalletViewModel> GetWalletUser(string userName);
        int ChargeWallet(string userName , int amount ,string description , bool isPay=false);
        int AddWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);

		#endregion

		#region Admin Panel

		UserForAdminViewModel GetUsers(int pageId =1, string filterEmail = "" , string filterUserName = "");
        int AddUserFromAdmin(CreateUserViewModel user);

		#endregion
	}
}
