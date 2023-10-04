using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayeer.Entities
{
	public class Role
	{
		public Role()
		{

		}


		[Key]
		public int RoleId { get; set; }

		[Display(Name = "")]
		[Required(ErrorMessage = "Please Add {}")]
		[MaxLength(200, ErrorMessage = "{}Its Cant be more than {}.")]
		public string RoleTitle { get; set; }

		#region Relations

		public virtual List<UserRole> UserRoles { get; set; }
		#endregion
	}
}
