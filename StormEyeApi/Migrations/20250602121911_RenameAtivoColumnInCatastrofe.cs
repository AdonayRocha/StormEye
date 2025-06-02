using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StormEyeApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameAtivoColumnInCatastrofe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AtivoM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "Ativo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "AtivoM");
        }
    }
}
