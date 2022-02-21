using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Futarszolgalat.Data.Migrations
{
    public partial class ElsoMigracio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gyogyszer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hatoanyag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venykoteles = table.Column<bool>(type: "bit", nullable: false),
                    Raktaron = table.Column<bool>(type: "bit", nullable: false),
                    Gyarto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyogyszer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gyogyszer");
        }
    }
}
