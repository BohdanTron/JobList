using Microsoft.EntityFrameworkCore.Migrations;

namespace JobList.Persistence.Migrations
{
    public partial class RemovedUnneededForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruiters_Roles_RoleId",
                table: "Recruiters");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeLanguages_Languages_LanguageId",
                table: "ResumeLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_WorkAreas_WorkAreaId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_CityId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_WorkAreaId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_ResumeLanguages_LanguageId",
                table: "ResumeLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Recruiters_RoleId",
                table: "Recruiters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CityId",
                table: "Vacancies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_WorkAreaId",
                table: "Vacancies",
                column: "WorkAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeLanguages_LanguageId",
                table: "ResumeLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_RoleId",
                table: "Recruiters",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiters_Roles_RoleId",
                table: "Recruiters",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeLanguages_Languages_LanguageId",
                table: "ResumeLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_WorkAreas_WorkAreaId",
                table: "Vacancies",
                column: "WorkAreaId",
                principalTable: "WorkAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
