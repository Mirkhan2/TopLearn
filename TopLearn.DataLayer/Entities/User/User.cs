using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayer.Entities.User
{
	public class User
	{

        public User()
        {
            
        }
        [Key]
        public int UserId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage ="Please Add{0}")]
        [MaxLength(100 , ErrorMessage ="Its Cant be Longer{1} than{0} character.")]
        public string UserName { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Please Add{0}")]
		[MaxLength(100, ErrorMessage = "Its Cant be Longer{1} than{0} character.}")]
        [EmailAddress(ErrorMessage ="Email doesnt Exit")]
		public string Email { get; set; }


		[Display(Name = "Password")]
		[Required(ErrorMessage = "Please Add{0}")]
		[MaxLength(100, ErrorMessage = "Its Cant be Longer{1} than{0} character.")]
		public string  Password { get; set; }

		[Display(Name = "ActiveCode")]
		[MaxLength(100, ErrorMessage = "Its Cant be Longer{1} than{0} character.")]
		protected string ActiveCode {  get; set; }

		[Display(Name = "Activr")]
		public bool IsActive { get; set; }

		[Display(Name = "Avatar")]
		[MaxLength(50, ErrorMessage = "Its Cant be Longer{1} than{0} character.")]
		public string  UserAvatar { get; set; }

		[Display(Name = "Date")]
		public DateTime RegisterDate { get; set; }

		#region Relations 

		public virtual  List<UserRole> UserRoles { get; set; }

		#endregion

	}
}
