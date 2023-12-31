using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Wab.Pages.Admin.Roles
{
    [PermissionChecker(7)]

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
            ViewData["Permissions"] = _permissionService.GetAllPermissions();
        }
        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if(!ModelState.IsValid)
                return Page();
      //add pr
            Role.IsDelete = false;
            int roleId = _permissionService.AddRole(Role);
             _permissionService.AddPermissionsToRole(roleId, SelectedPermission);

            return RedirectToPage("Index");
        }
    }
}
