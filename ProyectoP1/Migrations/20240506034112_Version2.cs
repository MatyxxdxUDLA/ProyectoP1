using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class Version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Vehiculo_carroId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_carroId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "carroId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Registro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registro_VehiculoId",
                table: "Registro",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Vehiculo_VehiculoId",
                table: "Registro",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Vehiculo_VehiculoId",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Registro_VehiculoId",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Registro");

            migrationBuilder.AddColumn<int>(
                name: "carroId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_carroId",
                table: "Usuario",
                column: "carroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Vehiculo_carroId",
                table: "Usuario",
                column: "carroId",
                principalTable: "Vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
