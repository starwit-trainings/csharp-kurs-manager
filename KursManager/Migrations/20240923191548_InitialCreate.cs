using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Trainer = table.Column<string>(type: "TEXT", nullable: true),
                    Dates = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teilnehmer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    KursId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teilnehmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teilnehmer_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teilnehmer_KursId",
                table: "Teilnehmer",
                column: "KursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teilnehmer");

            migrationBuilder.DropTable(
                name: "Kurs");
        }
    }
}
