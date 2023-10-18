using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Core.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        IPermissionService _permissionService;
        int _permissionId = 0;
        public PermissionCheckerAttribute(int permissionId)
        {
            
            _permissionId = permissionId;
        }
       
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;

                if (!_permissionService.CheckPermission(_permissionId, userName))
                {
                    context.Result = new RedirectResult("/Login");
                }

            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }


    }
}
