using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayeer.Entities.User;
using TopLearn.DataLayeer.Entities.Wallet;

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

        #region Wallet

        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);

            base.OnModelCreating(modelBuilder);
        }
    }
}