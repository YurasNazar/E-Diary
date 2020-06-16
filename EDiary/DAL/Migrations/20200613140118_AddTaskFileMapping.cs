using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddTaskFileMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskFileMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(nullable: true),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFileMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFileMappings_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskFileMappings_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileMappings_FileId",
                table: "TaskFileMappings",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileMappings_TaskId",
                table: "TaskFileMappings",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFileMappings");
        }
    }
}
