using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    public partial class RemoveTaskIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Task_TaskPriorityId",
            table: "Task");

            migrationBuilder.DropColumn(
            name: "TaskPriorityId",
            table: "Task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "TaskPriorityId",
               table: "Task",
               type: "int",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.CreateIndex(
               name: "IX_Task_TaskPriorityId",
               table: "Task",
               column: "TaskPriorityId");
        }
    }
}
