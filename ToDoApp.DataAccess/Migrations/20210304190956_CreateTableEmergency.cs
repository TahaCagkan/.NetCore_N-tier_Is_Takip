using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.DataAccess.Migrations
{
    public partial class CreateTableEmergency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmergencyId",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Emergencys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmergencyId",
                table: "Jobs",
                column: "EmergencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Emergencys_EmergencyId",
                table: "Jobs",
                column: "EmergencyId",
                principalTable: "Emergencys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Emergencys_EmergencyId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Emergencys");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EmergencyId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EmergencyId",
                table: "Jobs");
        }
    }
}
