using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Wab.Pages.Admin.Roles
{
    public class CreateRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
      //add pr
            Role.IsDelete = false;
            
            int roleId = _permissionService.AddRole(Role);
            return RedirectToPage("Index");
        }
    }
}
