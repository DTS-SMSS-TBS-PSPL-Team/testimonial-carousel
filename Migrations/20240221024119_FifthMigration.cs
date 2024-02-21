using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TS.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "CarouselSliderImages",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading_Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content_Caption = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Carousel_Button_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Carousel_Button_URL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CSImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselSliderImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUser",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFlag = table.Column<byte>(type: "tinyint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicant_Profiles",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered_User_ID = table.Column<int>(type: "int", nullable: false),
                    Country_ID = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LinkedIn_URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GitHub_URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Profile_URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Profile_Is_Public = table.Column<bool>(type: "bit", nullable: false),
                    Job_Profession = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Profile_Img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant_Profiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applicant_Profiles_Countries_Country_ID",
                        column: x => x.Country_ID,
                        principalSchema: "Identity",
                        principalTable: "Countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Applicant_Profiles_RegisteredUser_Registered_User_ID",
                        column: x => x.Registered_User_ID,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company_Profiles",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered_User_ID = table.Column<int>(type: "int", nullable: false),
                    Company_Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Contact_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Company_Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LinkedInURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Is_Approved = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Profiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Company_Profiles_RegisteredUser_Registered_User_ID",
                        column: x => x.Registered_User_ID,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_RegisteredUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_RegisteredUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSector",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Sector_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSector", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserSector_RegisteredUser_User_ID",
                        column: x => x.User_ID,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_RegisteredUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_RegisteredUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applicant_Job_Applications",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicant_Profile_ID = table.Column<int>(type: "int", nullable: true),
                    Company_Job_Id = table.Column<int>(type: "int", nullable: true),
                    Application_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resume_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_Matrix_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expected_Salary = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Delete_Flag = table.Column<bool>(type: "bit", nullable: false),
                    Application_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant_Job_Applications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applicant_Job_Applications_Applicant_Profiles_Applicant_Profile_ID",
                        column: x => x.Applicant_Profile_ID,
                        principalSchema: "Identity",
                        principalTable: "Applicant_Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Admin_Profiles",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered_User_ID = table.Column<int>(type: "int", nullable: false),
                    Contact_Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Contact_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LinkedInURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Is_Approved = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ApplicantTestimonialId = table.Column<int>(type: "int", nullable: false),
                    CarouselSliderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin_Profiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_Profiles_CarouselSliderImages_CarouselSliderId",
                        column: x => x.CarouselSliderId,
                        principalSchema: "Identity",
                        principalTable: "CarouselSliderImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_Profiles_RegisteredUser_Registered_User_ID",
                        column: x => x.Registered_User_ID,
                        principalSchema: "Identity",
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applicant_Testimonial",
                schema: "Identity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicant_Profile_ID = table.Column<int>(type: "int", nullable: false),
                    Testimonial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApprove = table.Column<bool>(type: "bit", nullable: false),
                    //AdminProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant_Testimonial", x => x.ID);
                    //table.ForeignKey(
                    //    name: "FK_Applicant_Testimonial_Admin_Profiles_AdminProfileId",
                    //    column: x => x.AdminProfileId,
                    //    principalSchema: "Identity",
                    //    principalTable: "Admin_Profiles",
                    //    principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Applicant_Testimonial_Applicant_Profiles_Applicant_Profile_ID",
                        column: x => x.Applicant_Profile_ID,
                        principalSchema: "Identity",
                        principalTable: "Applicant_Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Canada" },
                    { 2, "USA" },
                    { 3, "India" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "3bdc17cc-16b5-43ce-ae4b-267b7b243660", "Admin", "admin" },
                    { 2, "924381c6-3ff3-4dfa-9cd8-7502c837cd6e", "User", "user" },
                    { 3, "6421dd31-94a1-41e7-963c-58b00400c91e", "SuperAdmin", "superadmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Profiles_ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles",
                column: "ApplicantTestimonialId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Profiles_CarouselSliderId",
                schema: "Identity",
                table: "Admin_Profiles",
                column: "CarouselSliderId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Profiles_Registered_User_ID",
                schema: "Identity",
                table: "Admin_Profiles",
                column: "Registered_User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_Job_Applications_Applicant_Profile_ID",
                schema: "Identity",
                table: "Applicant_Job_Applications",
                column: "Applicant_Profile_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_Profiles_Country_ID",
                schema: "Identity",
                table: "Applicant_Profiles",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_Profiles_Registered_User_ID",
                schema: "Identity",
                table: "Applicant_Profiles",
                column: "Registered_User_ID",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Applicant_Testimonial_AdminProfileId",
            //    schema: "Identity",
            //    table: "Applicant_Testimonial",
            //    column: "AdminProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_Testimonial_Applicant_Profile_ID",
                schema: "Identity",
                table: "Applicant_Testimonial",
                column: "Applicant_Profile_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Profiles_Registered_User_ID",
                schema: "Identity",
                table: "Company_Profiles",
                column: "Registered_User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "RegisteredUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "RegisteredUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSector_User_ID",
                schema: "Identity",
                table: "UserSector",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Profiles_Applicant_Testimonial_ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles",
                column: "ApplicantTestimonialId",
                principalSchema: "Identity",
                principalTable: "Applicant_Testimonial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Profiles_Applicant_Testimonial_ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles");

            migrationBuilder.DropTable(
                name: "Applicant_Job_Applications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Company_Profiles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSector",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Applicant_Testimonial",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Admin_Profiles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Applicant_Profiles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CarouselSliderImages",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RegisteredUser",
                schema: "Identity");
        }
    }
}
