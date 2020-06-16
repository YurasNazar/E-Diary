using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteTaskFileMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFileMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskFileMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFileMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFileMapping_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskFileMapping_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileMapping_FileId",
                table: "TaskFileMapping",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileMapping_TaskId",
                table: "TaskFileMapping",
                column: "TaskId");
        }
    }
}
