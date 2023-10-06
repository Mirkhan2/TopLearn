using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayeer.Entities;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.DataLayeer.Context
{
	public class TopLearnContext : DbContext
	{

		public TopLearnContext(DbContextOptions<TopLearnContext> options) : base(options)
		{
		}




		#region User


		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		#endregion
	}
}