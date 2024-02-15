using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestimonialSlider.Models;

namespace TestimonialSlider.Data
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

            builder.Entity<RegisteredUser>(b =>
            {
                b.ToTable("RegisteredUsers");
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
                b.ToTable("AspNetUserRoles");
            });

            builder.Entity<UserProfile>()
                .Property(ap => ap.RegistrationDate)
                .HasDefaultValueSql("getdate()");

            builder.Entity<AdminProfile>()
                .Property(ap => ap.RegistrationDate)
                .HasDefaultValueSql("getdate()");


            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "SuperAdmin", NormalizedName = "superadmin" },
                new IdentityRole<int> { Id = 2, Name = "User", NormalizedName = "user" },
                new IdentityRole<int> { Id = 3, Name = "Admin", NormalizedName = "admin" }
                );

            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Canada" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "India" }
                );
        }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }
        public DbSet<UserTestimonial> UserTestimonials { get; set; }

        public static implicit operator ControllerContext(ApplicationDbContext context)
        {
            throw new NotFiniteNumberException();
        }
    }
}