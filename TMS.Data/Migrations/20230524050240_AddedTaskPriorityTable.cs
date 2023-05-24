using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    public partial class AddedTaskPriorityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifyBy",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskPriorityId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskPriorityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPriorityTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskPriorityId",
                table: "Task",
                column: "TaskPriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskPriorityTypes_TaskPriorityId",
                table: "Task",
                column: "Priority",
                principalTable: "TaskPriorityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskPriorityTypes_TaskPriorityId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "TaskPriorityTypes");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskPriorityId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskPriorityId",
                table: "Task");
        }
    }
}
