using AngularAndNetCoreAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace AngularAndNetCoreAuth.Data
{
    ///Create your application database context. This class stands at the center of EF core.
    ///Check here: https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx for adding migrations and updating Database
    ///I ended up using CLI for all my EF transactions. Package manager console was becoming a pain.
    //public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //    {

    //    }

    //    public DbSet<UserData> UserData { get; set; }
    //    public DbSet<AspNetRefreshToken> AspNetRefreshTokens { get; set; }

    //}


    public class UsersDbContext : IdentityDbContext<ApplicationUser>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<AspNetUserProfile> AspNetUserProfile { get; set; } = null!;
        public virtual DbSet<AspNetRefreshToken> AspNetRefreshTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AspNetRefreshToken>(entity =>
            {
                entity.ToTable("AspNetRefreshToken");
            });

            builder.Entity<ApplicationUser>(builder =>
            {
                builder.Property(e => e.UserId).ValueGeneratedOnAdd()
                    .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            });
            base.OnModelCreating(builder);
        }

    }


}
