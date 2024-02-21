﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TS.Data;

#nullable disable

namespace TS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Identity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "3bdc17cc-16b5-43ce-ae4b-267b7b243660",
                            Name = "Admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "924381c6-3ff3-4dfa-9cd8-7502c837cd6e",
                            Name = "User",
                            NormalizedName = "user"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "6421dd31-94a1-41e7-963c-58b00400c91e",
                            Name = "SuperAdmin",
                            NormalizedName = "superadmin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("TS.Models.AdminProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApplicantTestimonialId")
                        .HasColumnType("int");

                    b.Property<int>("CarouselSliderId")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Contact_Name");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("Contact_Phone");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Approved");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Inactive");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LinkedInURL");

                    b.Property<int>("RegisteredUserId")
                        .HasColumnType("int")
                        .HasColumnName("Registered_User_ID");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("RegistrationDate")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantTestimonialId");

                    b.HasIndex("CarouselSliderId");

                    b.HasIndex("RegisteredUserId")
                        .IsUnique();

                    b.ToTable("Admin_Profiles", "Identity");
                });

            modelBuilder.Entity("TS.Models.ApplicantJobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ApplicantProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Applicant_Profile_ID");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Application_Date");

                    b.Property<int>("ApplicationStatus")
                        .HasColumnType("int")
                        .HasColumnName("Application_Status");

                    b.Property<int?>("CompanyJobId")
                        .HasColumnType("int")
                        .HasColumnName("Company_Job_Id");

                    b.Property<string>("CoverLetterLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CoverLetter_Location");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("bit")
                        .HasColumnName("Delete_Flag");

                    b.Property<string>("ExpectedSalary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Expected_Salary");

                    b.Property<string>("ResumeLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Resume_Location");

                    b.Property<string>("SkillMatrixLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Skill_Matrix_Location");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantProfileId");

                    b.ToTable("Applicant_Job_Applications", "Identity");
                });

            modelBuilder.Entity("TS.Models.ApplicantProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("Country_ID");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("Gender");

                    b.Property<string>("GitHub")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("GitHub_URL");

                    b.Property<string>("JobProfession")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Job_Profession");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LinkedIn_URL");

                    b.Property<byte[]>("ProfileImg")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Profile_Img");

                    b.Property<bool>("ProfileIsPublic")
                        .HasColumnType("bit")
                        .HasColumnName("Profile_Is_Public");

                    b.Property<string>("ProfileUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Profile_URL");

                    b.Property<int>("RegisteredUserId")
                        .HasColumnType("int")
                        .HasColumnName("Registered_User_ID");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("RegistrationDate")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegisteredUserId")
                        .IsUnique();

                    b.ToTable("Applicant_Profiles", "Identity");
                });

            modelBuilder.Entity("TS.Models.ApplicantTestimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ApplicantProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Applicant_Profile_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("bit")
                        .HasColumnName("IsApprove");

                    b.Property<string>("Testimonial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Testimonial");

                    b.HasKey("Id");

                    b.HasIndex("AdminProfileId");

                    b.HasIndex("ApplicantProfileId");

                    b.ToTable("Applicant_Testimonial", "Identity");
                });

            modelBuilder.Entity("TS.Models.CarouselSliderImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CSImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Carousel_Button_Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Carousel_Button_URL")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Content_Caption")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Heading_Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("CarouselSliderImages", "Identity");
                });

            modelBuilder.Entity("TS.Models.CompanyProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("CompanyLogo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Company_Logo");

                    b.Property<string>("CompanyWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Company_Website");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Contact_Name");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("Contact_Phone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Description");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email1");

                    b.Property<string>("Email2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Approved");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Inactive");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LinkedInURL");

                    b.Property<int>("RegisteredUserId")
                        .HasColumnType("int")
                        .HasColumnName("Registered_User_ID");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RegistrationDate");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredUserId")
                        .IsUnique();

                    b.ToTable("Company_Profiles", "Identity");
                });

            modelBuilder.Entity("TS.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries", "Identity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Canada"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "India"
                        });
                });

            modelBuilder.Entity("TS.Models.RegisteredUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<byte>("UserFlag")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("UserTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("RegisteredUser", "Identity");
                });

            modelBuilder.Entity("TS.Models.UserSector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RegisteredUserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.Property<int>("SectorId")
                        .HasColumnType("int")
                        .HasColumnName("Sector_ID");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredUserId");

                    b.ToTable("UserSector", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TS.Models.RegisteredUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TS.Models.RegisteredUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TS.Models.RegisteredUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TS.Models.RegisteredUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TS.Models.AdminProfile", b =>
                {
                    b.HasOne("TS.Models.ApplicantTestimonial", "ApplicantTestimonial")
                        .WithMany()
                        .HasForeignKey("ApplicantTestimonialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TS.Models.CarouselSliderImages", "CarouselSlider")
                        .WithMany()
                        .HasForeignKey("CarouselSliderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TS.Models.RegisteredUser", "RegisteredUser")
                        .WithOne("AdminProfile")
                        .HasForeignKey("TS.Models.AdminProfile", "RegisteredUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicantTestimonial");

                    b.Navigation("CarouselSlider");

                    b.Navigation("RegisteredUser");
                });

            modelBuilder.Entity("TS.Models.ApplicantJobApplication", b =>
                {
                    b.HasOne("TS.Models.ApplicantProfile", "ApplicantProfile")
                        .WithMany()
                        .HasForeignKey("ApplicantProfileId");

                    b.Navigation("ApplicantProfile");
                });

            modelBuilder.Entity("TS.Models.ApplicantProfile", b =>
                {
                    b.HasOne("TS.Models.Country", "Country")
                        .WithMany("ApplicantProfiles")
                        .HasForeignKey("CountryId");

                    b.HasOne("TS.Models.RegisteredUser", "RegisteredUser")
                        .WithOne("ApplicantProfile")
                        .HasForeignKey("TS.Models.ApplicantProfile", "RegisteredUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("RegisteredUser");
                });

            modelBuilder.Entity("TS.Models.ApplicantTestimonial", b =>
                {
                    b.HasOne("TS.Models.AdminProfile", null)
                        .WithMany("testimonials")
                        .HasForeignKey("AdminProfileId");

                    b.HasOne("TS.Models.ApplicantProfile", null)
                        .WithMany("ApplicantTestimonials")
                        .HasForeignKey("ApplicantProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TS.Models.CompanyProfile", b =>
                {
                    b.HasOne("TS.Models.RegisteredUser", "RegisteredUser")
                        .WithOne("CompanyProfile")
                        .HasForeignKey("TS.Models.CompanyProfile", "RegisteredUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisteredUser");
                });

            modelBuilder.Entity("TS.Models.UserSector", b =>
                {
                    b.HasOne("TS.Models.RegisteredUser", "registeredUser")
                        .WithMany("UserSectors")
                        .HasForeignKey("RegisteredUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("registeredUser");
                });

            modelBuilder.Entity("TS.Models.AdminProfile", b =>
                {
                    b.Navigation("testimonials");
                });

            modelBuilder.Entity("TS.Models.ApplicantProfile", b =>
                {
                    b.Navigation("ApplicantTestimonials");
                });

            modelBuilder.Entity("TS.Models.Country", b =>
                {
                    b.Navigation("ApplicantProfiles");
                });

            modelBuilder.Entity("TS.Models.RegisteredUser", b =>
                {
                    b.Navigation("AdminProfile")
                        .IsRequired();

                    b.Navigation("ApplicantProfile")
                        .IsRequired();

                    b.Navigation("CompanyProfile")
                        .IsRequired();

                    b.Navigation("UserSectors");
                });
#pragma warning restore 612, 618
        }
    }
}
