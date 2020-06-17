using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddUserIdSubjectIdColumnUserSubjecMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectsMapping_Subjects_SubjectId",
                table: "UserSubjectsMapping");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "UserSubjectsMapping",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectsMapping_Subjects_SubjectId",
                table: "UserSubjectsMapping",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectsMapping_Subjects_SubjectId",
                table: "UserSubjectsMapping");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "UserSubjectsMapping",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectsMapping_Subjects_SubjectId",
                table: "UserSubjectsMapping",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
