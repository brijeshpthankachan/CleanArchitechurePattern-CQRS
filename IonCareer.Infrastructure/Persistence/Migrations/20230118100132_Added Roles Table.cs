using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IonCareer.Infrastructure.Persistence.Migrations
{
    public partial class AddedRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDatas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1L, "Director" },
                    { 2L, "VicePresident" },
                    { 3L, "HrRecruiter" },
                    { 4L, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "WeatherDatas",
                columns: new[] { "Id", "Humidity", "Location", "Temperature" },
                values: new object[,]
                {
                    { 1, 0, "Loc4", "40" },
                    { 2, 0, "Loc3", "40" },
                    { 3, 0, "Loc3", "40" },
                    { 6, 2, "Loc5", "40" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "WeatherDatas");
        }
    }
}
