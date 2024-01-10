using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace db.Migrations
{
    /// <inheritdoc />
    public partial class AddTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeLifting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLifting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiftingWeight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetitor = table.Column<int>(type: "int", nullable: false),
                    IdTypeLifting = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingWeight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiftingWeight_Competitor_IdCompetitor",
                        column: x => x.IdCompetitor,
                        principalTable: "Competitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiftingWeight_TypeLifting_IdTypeLifting",
                        column: x => x.IdTypeLifting,
                        principalTable: "TypeLifting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiftingWeight_IdCompetitor",
                table: "LiftingWeight",
                column: "IdCompetitor");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingWeight_IdTypeLifting",
                table: "LiftingWeight",
                column: "IdTypeLifting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiftingWeight");

            migrationBuilder.DropTable(
                name: "TypeLifting");
        }
    }
}
