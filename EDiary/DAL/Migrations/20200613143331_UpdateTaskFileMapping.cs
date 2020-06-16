using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateTaskFileMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskFileMappings_Files_FileId",
                table: "TaskFileMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskFileMappings_Tasks_TaskId",
                table: "TaskFileMappings");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "TaskFileMappings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "TaskFileMappings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskFileMappings_Files_FileId",
                table: "TaskFileMappings",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskFileMappings_Tasks_TaskId",
                table: "TaskFileMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskFileMappings_Files_FileId",
                table: "TaskFileMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskFileMappings_Tasks_TaskId",
                table: "TaskFileMappings");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "TaskFileMappings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "TaskFileMappings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TaskFileMappings_Files_FileId",
                table: "TaskFileMappings",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskFileMappings_Tasks_TaskId",
                table: "TaskFileMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
