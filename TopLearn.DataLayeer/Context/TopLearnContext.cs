﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayeer.Entities.Course;
using TopLearn.DataLayeer.Entities.Permission;
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


        #region Permission

        public DbSet<Permission> Permission{ get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }

        #endregion

        #region Course

        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseStatus> CourseStatuses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEpisode> CourseEpisodes { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);

            modelBuilder.Entity<CourseGroup>()
                .HasQueryFilter(g => !g.IsDelete);
            modelBuilder.Entity<Course>()
               .HasQueryFilter(g => !g.IsDelete);

            modelBuilder.Entity<Course>()
                .HasOne<CourseGroup>(c => c.CourseGroup)
                .WithMany(cg => cg.Courses)
                .HasForeignKey(fk => fk.GroupId);

            modelBuilder.Entity<Course>()
                .HasOne<CourseGroup>(c => c.Group)
                .WithMany(cg => cg.SubGroup)
                .HasForeignKey(fk => fk.SubGroup);

            base.OnModelCreating(modelBuilder);
        }
    }
}