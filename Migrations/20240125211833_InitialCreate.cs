using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4c3292ce-d1f6-42a7-bf84-1398b18e0a8e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c13eecbe-06ae-4fe2-9481-16ee0c6b1980");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "61ca8f6c-3b1a-40fe-8ad0-83489e3400bf");

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_Job_Applications_Applicant_Profile_ID",
                schema: "Identity",
                table: "Applicant_Job_Applications",
                column: "Applicant_Profile_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicant_Job_Applications",
                schema: "Identity");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "66c07ea9-9bdf-4b70-9734-1bd40ea76fb1");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5d9da6f7-0792-4267-8205-965008c2165f");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6918dbe4-e35a-4e92-ba2a-0b3a76fd5ef1");
        }
    }
}
