using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Core.Services.Interfaces
{
    public  interface IPermissionService
    {
        #region Roles

        List<Role> GetRoles();
        #endregion
    }
}
