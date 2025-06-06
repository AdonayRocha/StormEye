using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StormEye.Infrastructure.Migrations
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
                    IDCATASTROFEM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMECATASTROFEM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TIPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GRAVIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ATIVO = table.Column<int>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGS_CATASTROFE_MAPEADA", x => x.IDCATASTROFEM);
                });

            migrationBuilder.CreateTable(
                name: "TGS_CARTILHA_MAPEADA",
                columns: table => new
                {
                    IDCARTILHAM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IDCATASTROFEM = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOMECARTILHAM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRICAOCARTILHA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CATEGORIACARTILHA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ATIVO = table.Column<int>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGS_CARTILHA_MAPEADA", x => x.IDCARTILHAM);
                    table.ForeignKey(
                        name: "FK_TGS_CARTILHA_MAPEADA_TGS_CATASTROFE_MAPEADA_IDCATASTROFEM",
                        column: x => x.IDCATASTROFEM,
                        principalTable: "TGS_CATASTROFE_MAPEADA",
                        principalColumn: "IDCATASTROFEM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TGS_CARTILHA_MAPEADA_IDCATASTROFEM",
                table: "TGS_CARTILHA_MAPEADA",
                column: "IDCATASTROFEM");
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
