using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Context;
using TopLearn.DataLayeer.Entities.Permission;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.Core.Services.Interfaces
{
	public class PermissionService : IPermissionService
	{
		//html fertig abeb 24 nov
		private TopLearnContext _context;

		public PermissionService(TopLearnContext context)
		{
			_context = context;
		}
		public List<Role> GetRoles()
		{
			return _context.Roles.ToList();
		}

		public void AddRolesToUser(List<int> roleIds, int userId)
		{
			foreach (var roleId in roleIds)
			{
				_context.UserRoles.Add(new UserRole()


				{
					RoleId = roleId,
					UserId = userId
				});
			}
			//_context.SaveChanges();
			_context.SaveChanges();
		}

		public void EditRolesUser(int userId, List<int> roleIds)
		{
			//|Delete all Roles User
			_context.UserRoles.Where(r => r.UserId
			== userId).ToList()
			.ForEach(r => _context.UserRoles.Remove(r));

			//Add NEw ROles
			AddRolesToUser(roleIds, userId);
		}

		public int AddRole(Role role)
		{
			_context.Roles.Add(role);
			_context.SaveChanges();
			return role.RoleId;
		}

		public Role GetRoleById(int roleId)
		{
			return _context.Roles.Find(roleId);
		}

		public void UpdateRole(Role role)
		{
			_context.Roles.Update(role);
			_context.SaveChanges();
		}

		public void DeleteRole(Role role)
		{
			role.IsDelete = true;
			UpdateRole(role);
		}

		public List<Permission> GetAllPermissions()
		{
			return _context.Permission.ToList();
		}

		public void AddPermissionsToRole(int roleId, List<int> permission)
		{
			foreach (var p in permission)
			{
				_context.RolePermission.Add(new RolePermission()
				{
					PermissionId = p,
					RoleId = roleId

				});
			}
		}

        public List<int> PermissionsRole(int roleId)
        {
			return _context.RolePermission
				.Where(r => r.RoleId == roleId)
				.Select(r => r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
           _context.RolePermission.Where(p => p.RoleId == roleId )
				.ToList().ForEach(p => _context.RolePermission.Remove(p));

			AddPermissionsToRole (roleId, permissions);
        }

        public bool CheckPermission(int permissionId, string userName)
        {
			int userId= _context.Users.Single(u => u.UserName == userName).UserId;

          List<int> UserRoles = _context.UserRoles
				.Where(r => r.UserId == userId).Select(r =>r.RoleId).ToList();

			if (!UserRoles.Any())
			{
				return false;
			}
			List<int> RolesPermission = _context.RolePermission
				.Where(p => p.PermissionId == permissionId)
				.Select (p => p.RoleId).ToList();

			return RolesPermission.Any(p => UserRoles.Contains(p));
        }
    }
}
