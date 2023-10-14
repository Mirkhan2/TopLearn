using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Wab.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int pageId = 1 ,string filterUserName = "",string filterEmail = "")
        {
            UserForAdminViewModel = _userService.GetUsers();
        }
       
    }
}
