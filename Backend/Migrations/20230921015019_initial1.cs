using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace beckend.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Marks_EntradaId",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Marks_SaidaId",
                table: "Registros");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.CreateTable(
                name: "Marcacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Horario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacoes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Marcacoes_EntradaId",
                table: "Registros",
                column: "EntradaId",
                principalTable: "Marcacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Marcacoes_SaidaId",
                table: "Registros",
                column: "SaidaId",
                principalTable: "Marcacoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Marcacoes_EntradaId",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Marcacoes_SaidaId",
                table: "Registros");

            migrationBuilder.DropTable(
                name: "Marcacoes");

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Horario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Marks_EntradaId",
                table: "Registros",
                column: "EntradaId",
                principalTable: "Marks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Marks_SaidaId",
                table: "Registros",
                column: "SaidaId",
                principalTable: "Marks",
                principalColumn: "Id");
        }
    }
}
