using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TS.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
