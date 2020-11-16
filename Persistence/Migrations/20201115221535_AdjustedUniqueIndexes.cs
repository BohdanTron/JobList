using Microsoft.EntityFrameworkCore.Migrations;

namespace JobList.Persistence.Migrations
{
    public partial class AdjustedUniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                newName: "UQ_Schools_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                newName: "UQ_Roles_Name");

            migrationBuilder.CreateIndex(
                name: "UQ_WorkAreas_Name",
                table: "WorkAreas",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_WorkAreas_Name",
                table: "WorkAreas");

            migrationBuilder.RenameIndex(
                name: "UQ_Schools_Name",
                table: "Schools",
                newName: "IX_Schools_Name");

            migrationBuilder.RenameIndex(
                name: "UQ_Roles_Name",
                table: "Roles",
                newName: "IX_Roles_Name");
        }
    }
}
