using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Context;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Core.Services.Interfaces
{
    public  class PermissionService : IPermissionService
    {
        private TopLearnContext _context;

        public PermissionService(TopLearnContext context)
        {
            _context = context;
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
