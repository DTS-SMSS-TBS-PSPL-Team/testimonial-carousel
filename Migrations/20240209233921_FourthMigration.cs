using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TS.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cb685a1d-9ada-4a39-8bdb-2ef5066176a1");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f24f3f62-16f6-47b5-aa71-c9d564b4bab5");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "90b2a2e3-05f4-41db-9fca-cd1e88ff57b9");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Profiles_ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles",
                column: "ApplicantTestimonialId");

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
                name: "CarouselSliderImages",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Admin_Profiles_ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles");

            migrationBuilder.DropColumn(
                name: "ApplicantTestimonialId",
                schema: "Identity",
                table: "Admin_Profiles");

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
        }
    }
}
