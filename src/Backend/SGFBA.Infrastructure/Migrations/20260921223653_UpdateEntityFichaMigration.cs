using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGFBA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityFichaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "IdOrientador",
            //    table: "fichas",
            //    newName: "IdUsuario");

            //migrationBuilder.CreateIndex(
            //    name: "IX_fichas_IdEstudante",
            //    table: "fichas",
            //    column: "IdEstudante");

            //migrationBuilder.CreateIndex(
            //    name: "IX_estudantes_UserId",
            //    table: "estudantes",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_acoes_IdFicha",
            //    table: "acoes",
            //    column: "IdFicha");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_acoes_fichas_IdFicha",
            //    table: "acoes",
            //    column: "IdFicha",
            //    principalTable: "fichas",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_estudantes_usuarios_UserId",
            //    table: "estudantes",
            //    column: "UserId",
            //    principalTable: "usuarios",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_fichas_estudantes_IdEstudante",
            //    table: "fichas",
            //    column: "IdEstudante",
            //    principalTable: "estudantes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_fichas_usuarios_IdUsuario",
            //    table: "fichas",
            //    column: "IdUsuario",
            //    principalTable: "usuarios",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_acoes_fichas_IdFicha",
                table: "acoes");

            migrationBuilder.DropForeignKey(
                name: "FK_estudantes_usuarios_UserId",
                table: "estudantes");

            migrationBuilder.DropForeignKey(
                name: "FK_fichas_estudantes_IdEstudante",
                table: "fichas");

            migrationBuilder.DropForeignKey(
                name: "FK_fichas_usuarios_IdUsuario",
                table: "fichas");

            migrationBuilder.DropIndex(
                name: "IX_fichas_IdEstudante",
                table: "fichas");

            migrationBuilder.DropIndex(
                name: "IX_estudantes_UserId",
                table: "estudantes");

            migrationBuilder.DropIndex(
                name: "IX_acoes_IdFicha",
                table: "acoes");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "fichas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_fichas_IdUsuario",
                table: "fichas",
                newName: "IX_fichas_UsuarioId");

            migrationBuilder.AddColumn<long>(
                name: "EstudanteId",
                table: "fichas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "IdOrientador",
                table: "fichas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "estudantes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FichaId",
                table: "acoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_fichas_EstudanteId",
                table: "fichas",
                column: "EstudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_estudantes_UsuarioId",
                table: "estudantes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_acoes_FichaId",
                table: "acoes",
                column: "FichaId");

            migrationBuilder.AddForeignKey(
                name: "FK_acoes_fichas_FichaId",
                table: "acoes",
                column: "FichaId",
                principalTable: "fichas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_estudantes_usuarios_UsuarioId",
                table: "estudantes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fichas_estudantes_EstudanteId",
                table: "fichas",
                column: "EstudanteId",
                principalTable: "estudantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fichas_usuarios_UsuarioId",
                table: "fichas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
