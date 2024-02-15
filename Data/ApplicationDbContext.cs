using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TS.Models;
namespace TS.Data
{
    public class ApplicationDbContext : IdentityDbContext<RegisteredUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            builder.Entity<RegisteredUser>(entity =>
            {
                entity.ToTable(name: "RegisteredUser");
            });

            builder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<int>>(b =>
            {
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<int>>(b =>
            {
                b.ToTable("UserTokens");
            });

            builder.Entity<IdentityRole<int>>(b =>
            {
                b.ToTable("Roles");
            });

            builder.Entity<IdentityRoleClaim<int>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserRole<int>>(b =>
            {
                b.ToTable("UserRoles");
            });

            builder.Entity<ApplicantProfile>()
                .Property(ap => ap.RegistrationDate)
                .HasDefaultValueSql("getdate()");

            builder.Entity<AdminProfile>()
                .Property(ap => ap.RegistrationDate)
                .HasDefaultValueSql("getdate()");

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "admin" },
                new IdentityRole<int> { Id = 2, Name = "User", NormalizedName = "user" },
                new IdentityRole<int> { Id = 3, Name = "SuperAdmin", NormalizedName = "superadmin" }
                //new IdentityRole<int> { Id = 4, Name = "SuperAdmin", NormalizedName = "superadmin" }
                );

            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Canada" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "India" }
                );

        }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<ApplicantProfile> ApplicantProfiles { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<ApplicantTestimonial> ApplicantTestimonials { get; set; }

        public static implicit operator ControllerContext(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}