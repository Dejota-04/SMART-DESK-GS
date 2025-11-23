using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprint1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DISPOSITIVO",
                columns: table => new
                {
                    UUID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISPOSITIVO", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SENHA_HASH = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ALTURA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PESO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    SEXO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MODELO_TRABALHO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ROLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DISPOSITIVO_ID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_DISPOSITIVO_DISPOSITIVO_ID",
                        column: x => x.DISPOSITIVO_ID,
                        principalTable: "DISPOSITIVO",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUPORTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITULO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA_RECLAMACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA_RESOLUCAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ADMIN_ID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPORTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SUPORTE_USUARIO_ADMIN_ID",
                        column: x => x.ADMIN_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPORTE_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SUPORTE_ADMIN_ID",
                table: "SUPORTE",
                column: "ADMIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPORTE_USUARIO_ID",
                table: "SUPORTE",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_DISPOSITIVO_ID",
                table: "USUARIO",
                column: "DISPOSITIVO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUPORTE");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "DISPOSITIVO");
        }
    }
}
