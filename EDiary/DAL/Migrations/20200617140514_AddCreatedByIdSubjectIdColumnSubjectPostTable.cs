using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddCreatedByIdSubjectIdColumnSubjectPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectPosts_Subjects_SubjectId",
                table: "SubjectPosts");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectPosts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectPosts_Subjects_SubjectId",
                table: "SubjectPosts",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectPosts_Subjects_SubjectId",
                table: "SubjectPosts");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectPosts_Subjects_SubjectId",
                table: "SubjectPosts",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
