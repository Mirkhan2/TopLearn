using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Wab.Pages.Admin.Roles
{
    
    [PermissionChecker(1002)]
    public class IndexModel : PageModel
    {
      IPermissionService _permissionService;
        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> RoleList { get; set; }
        public void OnGet()
        {
            RoleList = _permissionService.GetRoles();
        }
       
    }
}
