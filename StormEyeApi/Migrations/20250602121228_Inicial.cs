using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StormEyeApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TGS_CATASTROFE_MAPEADA",
                columns: table => new
                {
                    IdCatastrofeM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCatastrofeM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SintomaCatastrofeM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AtivoM = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGS_CATASTROFE_MAPEADA", x => x.IdCatastrofeM);
                });

            migrationBuilder.CreateTable(
                name: "TGS_CARTILHA_MAPEADA",
                columns: table => new
                {
                    IdCartilhaM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IdCatastrofeM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGS_CARTILHA_MAPEADA", x => x.IdCartilhaM);
                    table.ForeignKey(
                        name: "FK_TGS_CARTILHA_MAPEADA_TGS_CATASTROFE_MAPEADA_IdCatastrofeM",
                        column: x => x.IdCatastrofeM,
                        principalTable: "TGS_CATASTROFE_MAPEADA",
                        principalColumn: "IdCatastrofeM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TGS_CARTILHA_MAPEADA_IdCatastrofeM",
                table: "TGS_CARTILHA_MAPEADA",
                column: "IdCatastrofeM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TGS_CARTILHA_MAPEADA");

            migrationBuilder.DropTable(
                name: "TGS_CATASTROFE_MAPEADA");
        }
    }
}
