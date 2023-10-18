using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Entities.Permission;

namespace TopLearn.DataLayeer.Entities.User
{
    public class Role
    {
        public Role()
        {

        }

        [Key]
        public int RoleId { get; set; }

        [Display(Name = "onvan naqsh")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleTitle { get; set; }

       

        public bool IsDelete { get; set; }

		#region Relations

		public virtual List<UserRole> UserRoles { get; set; }
		public List<RolePermission> RolePermissions { get; set; }


		#endregion
	}
}
