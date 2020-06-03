using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreateUserScheduleEventMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSubjectMappings_Subjects_SubjectId",
                table: "TaskSubjectMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSubjectMappings_Tasks_TaskId",
                table: "TaskSubjectMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectMappings_Subjects_SubjectId",
                table: "UserSubjectMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectMappings_AspNetUsers_UserId",
                table: "UserSubjectMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskMappings_Tasks_TaskId",
                table: "UserTaskMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskMappings_AspNetUsers_UserId",
                table: "UserTaskMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskMappings",
                table: "UserTaskMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSubjectMappings",
                table: "UserSubjectMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSubjectMappings",
                table: "TaskSubjectMappings");

            migrationBuilder.RenameTable(
                name: "UserTaskMappings",
                newName: "UserTasksMapping");

            migrationBuilder.RenameTable(
                name: "UserSubjectMappings",
                newName: "UserSubjectsMapping");

            migrationBuilder.RenameTable(
                name: "TaskSubjectMappings",
                newName: "TaskSubjectMapping");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskMappings_UserId",
                table: "UserTasksMapping",
                newName: "IX_UserTasksMapping_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskMappings_TaskId",
                table: "UserTasksMapping",
                newName: "IX_UserTasksMapping_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubjectMappings_UserId",
                table: "UserSubjectsMapping",
                newName: "IX_UserSubjectsMapping_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubjectMappings_SubjectId",
                table: "UserSubjectsMapping",
                newName: "IX_UserSubjectsMapping_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSubjectMappings_TaskId",
                table: "TaskSubjectMapping",
                newName: "IX_TaskSubjectMapping_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSubjectMappings_SubjectId",
                table: "TaskSubjectMapping",
                newName: "IX_TaskSubjectMapping_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTasksMapping",
                table: "UserTasksMapping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSubjectsMapping",
                table: "UserSubjectsMapping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSubjectMapping",
                table: "TaskSubjectMapping",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserScheculeEventsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ScheduleEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScheculeEventsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScheculeEventsMapping_ScheduleEvents_ScheduleEventId",
                        column: x => x.ScheduleEventId,
                        principalTable: "ScheduleEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserScheculeEventsMapping_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserScheculeEventsMapping_ScheduleEventId",
                table: "UserScheculeEventsMapping",
                column: "ScheduleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScheculeEventsMapping_UserId",
                table: "UserScheculeEventsMapping",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSubjectMapping_Subjects_SubjectId",
                table: "TaskSubjectMapping",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSubjectMapping_Tasks_TaskId",
                table: "TaskSubjectMapping",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectsMapping_Subjects_SubjectId",
                table: "UserSubjectsMapping",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectsMapping_AspNetUsers_UserId",
                table: "UserSubjectsMapping",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasksMapping_Tasks_TaskId",
                table: "UserTasksMapping",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasksMapping_AspNetUsers_UserId",
                table: "UserTasksMapping",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSubjectMapping_Subjects_SubjectId",
                table: "TaskSubjectMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSubjectMapping_Tasks_TaskId",
                table: "TaskSubjectMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectsMapping_Subjects_SubjectId",
                table: "UserSubjectsMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubjectsMapping_AspNetUsers_UserId",
                table: "UserSubjectsMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasksMapping_Tasks_TaskId",
                table: "UserTasksMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasksMapping_AspNetUsers_UserId",
                table: "UserTasksMapping");

            migrationBuilder.DropTable(
                name: "UserScheculeEventsMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTasksMapping",
                table: "UserTasksMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSubjectsMapping",
                table: "UserSubjectsMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSubjectMapping",
                table: "TaskSubjectMapping");

            migrationBuilder.RenameTable(
                name: "UserTasksMapping",
                newName: "UserTaskMappings");

            migrationBuilder.RenameTable(
                name: "UserSubjectsMapping",
                newName: "UserSubjectMappings");

            migrationBuilder.RenameTable(
                name: "TaskSubjectMapping",
                newName: "TaskSubjectMappings");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasksMapping_UserId",
                table: "UserTaskMappings",
                newName: "IX_UserTaskMappings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasksMapping_TaskId",
                table: "UserTaskMappings",
                newName: "IX_UserTaskMappings_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubjectsMapping_UserId",
                table: "UserSubjectMappings",
                newName: "IX_UserSubjectMappings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubjectsMapping_SubjectId",
                table: "UserSubjectMappings",
                newName: "IX_UserSubjectMappings_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSubjectMapping_TaskId",
                table: "TaskSubjectMappings",
                newName: "IX_TaskSubjectMappings_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSubjectMapping_SubjectId",
                table: "TaskSubjectMappings",
                newName: "IX_TaskSubjectMappings_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskMappings",
                table: "UserTaskMappings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSubjectMappings",
                table: "UserSubjectMappings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSubjectMappings",
                table: "TaskSubjectMappings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSubjectMappings_Subjects_SubjectId",
                table: "TaskSubjectMappings",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSubjectMappings_Tasks_TaskId",
                table: "TaskSubjectMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectMappings_Subjects_SubjectId",
                table: "UserSubjectMappings",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubjectMappings_AspNetUsers_UserId",
                table: "UserSubjectMappings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskMappings_Tasks_TaskId",
                table: "UserTaskMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskMappings_AspNetUsers_UserId",
                table: "UserTaskMappings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
