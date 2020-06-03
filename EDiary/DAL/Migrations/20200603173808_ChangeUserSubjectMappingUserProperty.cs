using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeUserSubjectMappingUserProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectMappings_AspNetUsers_ApplicationUserId",
                table: "UserSubjectMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserSubjectMappings_ApplicationUserId",
                table: "UserSubjectMappings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserSubjectMappings");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserSubjectMappings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSubjectMappings_UserId",
                table: "UserSubjectMappings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectMappings_AspNetUsers_UserId",
                table: "UserSubjectMappings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectMappings_AspNetUsers_UserId",
                table: "UserSubjectMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserSubjectMappings_UserId",
                table: "UserSubjectMappings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSubjectMappings");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserSubjectMappings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSubjectMappings_ApplicationUserId",
                table: "UserSubjectMappings",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectMappings_AspNetUsers_ApplicationUserId",
                table: "UserSubjectMappings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
