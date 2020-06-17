using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddUserIdTaskIdColumnUserTasksMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasksMapping_Tasks_TaskId",
                table: "UserTasksMapping");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "UserTasksMapping",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasksMapping_Tasks_TaskId",
                table: "UserTasksMapping",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasksMapping_Tasks_TaskId",
                table: "UserTasksMapping");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "UserTasksMapping",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasksMapping_Tasks_TaskId",
                table: "UserTasksMapping",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
