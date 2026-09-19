using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SGFBA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Matricula = table.Column<string>(type: "longtext", nullable: false),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Senha = table.Column<string>(type: "longtext", nullable: false),
                    Role = table.Column<string>(type: "longtext", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserIdentifier = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estudantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Turma = table.Column<int>(type: "int", nullable: false),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "longtext", nullable: false),
                    TelefoneResponsavel = table.Column<string>(type: "longtext", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StudentIdentifier = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estudantes_usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fichas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataAbertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motivo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "longtext", nullable: true),
                    FichaIdentifier = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdOrientador = table.Column<long>(type: "bigint", nullable: false),
                    IdEstudante = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fichas_estudantes_IdEstudante",
                        column: x => x.IdEstudante,
                        principalTable: "estudantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_fichas_usuarios_IdOrientador",
                        column: x => x.IdOrientador,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacao = table.Column<string>(type: "longtext", nullable: true),
                    AcaoIdentifier = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdFicha = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_acoes_fichas_IdFicha",
                        column: x => x.IdFicha,
                        principalTable: "fichas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_acoes_IdFicha",
                table: "acoes",
                column: "IdFicha");

            migrationBuilder.CreateIndex(
                name: "IX_estudantes_UserId",
                table: "estudantes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_fichas_IdEstudante",
                table: "fichas",
                column: "IdEstudante");

            migrationBuilder.CreateIndex(
                name: "IX_fichas_IdOrientador",
                table: "fichas",
                column: "IdOrientador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acoes");

            migrationBuilder.DropTable(
                name: "fichas");

            migrationBuilder.DropTable(
                name: "estudantes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
