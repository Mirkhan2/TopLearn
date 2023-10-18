using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.DataLayeer.Entities.Permission
{
	public class RolePermission
	{
		[Key]
		public int RP_Id { get; set; }
		public int RoleId { get; set; }
		public int PermissionId { get; set; }

		public Role Role { get; set; }
		public Permission  Permission{ get; set; }

	}
}
