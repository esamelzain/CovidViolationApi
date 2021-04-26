using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidViolation.Migrations
{
    public partial class navigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Violation_FineId",
                table: "Violation",
                column: "FineId");

            migrationBuilder.CreateIndex(
                name: "IX_Violation_ViolatorId",
                table: "Violation",
                column: "ViolatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violation_Fine_FineId",
                table: "Violation",
                column: "FineId",
                principalTable: "Fine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Violation_Violator_ViolatorId",
                table: "Violation",
                column: "ViolatorId",
                principalTable: "Violator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violation_Fine_FineId",
                table: "Violation");

            migrationBuilder.DropForeignKey(
                name: "FK_Violation_Violator_ViolatorId",
                table: "Violation");

            migrationBuilder.DropIndex(
                name: "IX_Violation_FineId",
                table: "Violation");

            migrationBuilder.DropIndex(
                name: "IX_Violation_ViolatorId",
                table: "Violation");
        }
    }
}
