using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TS.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                schema: "Identity",
                table: "RegisteredUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e02ff0d3-6718-4c9e-ac8d-9c62afcd9dda");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "61da618b-fc1f-44db-bb5c-829e3858173e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "3067a00b-ef47-4799-a99f-20655eb183c4");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Profiles_Registered_User_ID",
                schema: "Identity",
                table: "Company_Profiles",
                column: "Registered_User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSector_User_ID",
                schema: "Identity",
                table: "UserSector",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company_Profiles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSector",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                schema: "Identity",
                table: "RegisteredUser");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e5d6ea3f-bb11-409f-83a9-31aebd1068d0");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a2d9be7d-d030-41fa-b52d-4177c03cf0f0");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "75d9dbf4-4571-4c25-b2df-53160eb05d0f");
        }
    }
}
