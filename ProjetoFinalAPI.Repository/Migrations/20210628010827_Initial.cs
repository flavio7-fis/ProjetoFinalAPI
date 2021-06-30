using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinalAPI.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROFISSIONAL",
                columns: table => new
                {
                    IDPROFISSIONAL = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 150, nullable: false),
                    CPF = table.Column<string>(maxLength: 15, nullable: false),
                    TELEFONE = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONAL", x => x.IDPROFISSIONAL);
                });

            migrationBuilder.CreateTable(
                name: "SERVICO",
                columns: table => new
                {
                    IDSERVICO = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 150, nullable: false),
                    VALOR = table.Column<double>(maxLength: 150, nullable: false),
                    IDPROFISSIONAL = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICO", x => x.IDSERVICO);
                    table.ForeignKey(
                        name: "FK_SERVICO_PROFISSIONAL_IDPROFISSIONAL",
                        column: x => x.IDPROFISSIONAL,
                        principalTable: "PROFISSIONAL",
                        principalColumn: "IDPROFISSIONAL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_CPF",
                table: "PROFISSIONAL",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SERVICO_IDPROFISSIONAL",
                table: "SERVICO",
                column: "IDPROFISSIONAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SERVICO");

            migrationBuilder.DropTable(
                name: "PROFISSIONAL");
        }
    }
}
