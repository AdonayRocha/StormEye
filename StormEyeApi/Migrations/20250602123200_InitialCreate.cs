using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StormEyeApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TGS_CARTILHA_MAPEADA_TGS_CATASTROFE_MAPEADA_IdCatastrofeM",
                table: "TGS_CARTILHA_MAPEADA");

            migrationBuilder.RenameColumn(
                name: "SintomaCatastrofeM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "SINTOMACATASTROFEM");

            migrationBuilder.RenameColumn(
                name: "NomeCatastrofeM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "NOMECATASTROFEM");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "ATIVO");

            migrationBuilder.RenameColumn(
                name: "IdCatastrofeM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "IDCATASTROFEM");

            migrationBuilder.RenameColumn(
                name: "IdCatastrofeM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "IDCATASTROFEM");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "ATIVO");

            migrationBuilder.RenameColumn(
                name: "IdCartilhaM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "IDCARTILHAM");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "NOMECARTILHAM");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "DESCRICAOCARTILHA");

            migrationBuilder.RenameIndex(
                name: "IX_TGS_CARTILHA_MAPEADA_IdCatastrofeM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "IX_TGS_CARTILHA_MAPEADA_IDCATASTROFEM");

            migrationBuilder.AlterColumn<bool>(
                name: "ATIVO",
                table: "TGS_CATASTROFE_MAPEADA",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ATIVO",
                table: "TGS_CARTILHA_MAPEADA",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AddForeignKey(
                name: "FK_TGS_CARTILHA_MAPEADA_TGS_CATASTROFE_MAPEADA_IDCATASTROFEM",
                table: "TGS_CARTILHA_MAPEADA",
                column: "IDCATASTROFEM",
                principalTable: "TGS_CATASTROFE_MAPEADA",
                principalColumn: "IDCATASTROFEM",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TGS_CARTILHA_MAPEADA_TGS_CATASTROFE_MAPEADA_IDCATASTROFEM",
                table: "TGS_CARTILHA_MAPEADA");

            migrationBuilder.RenameColumn(
                name: "SINTOMACATASTROFEM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "SintomaCatastrofeM");

            migrationBuilder.RenameColumn(
                name: "NOMECATASTROFEM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "NomeCatastrofeM");

            migrationBuilder.RenameColumn(
                name: "ATIVO",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "IDCATASTROFEM",
                table: "TGS_CATASTROFE_MAPEADA",
                newName: "IdCatastrofeM");

            migrationBuilder.RenameColumn(
                name: "IDCATASTROFEM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "IdCatastrofeM");

            migrationBuilder.RenameColumn(
                name: "ATIVO",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "IDCARTILHAM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "IdCartilhaM");

            migrationBuilder.RenameColumn(
                name: "NOMECARTILHAM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "DESCRICAOCARTILHA",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "Descricao");

            migrationBuilder.RenameIndex(
                name: "IX_TGS_CARTILHA_MAPEADA_IDCATASTROFEM",
                table: "TGS_CARTILHA_MAPEADA",
                newName: "IX_TGS_CARTILHA_MAPEADA_IdCatastrofeM");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "TGS_CATASTROFE_MAPEADA",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "TGS_CARTILHA_MAPEADA",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AddForeignKey(
                name: "FK_TGS_CARTILHA_MAPEADA_TGS_CATASTROFE_MAPEADA_IdCatastrofeM",
                table: "TGS_CARTILHA_MAPEADA",
                column: "IdCatastrofeM",
                principalTable: "TGS_CATASTROFE_MAPEADA",
                principalColumn: "IdCatastrofeM",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
