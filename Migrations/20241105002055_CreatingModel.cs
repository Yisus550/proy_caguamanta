using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class CreatingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puestos_puestoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_puestoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "puestoId",
                table: "Empleados");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdPuesto",
                table: "Empleados",
                column: "IdPuesto");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puestos_IdPuesto",
                table: "Empleados",
                column: "IdPuesto",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puestos_IdPuesto",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_IdPuesto",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "puestoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_puestoId",
                table: "Empleados",
                column: "puestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puestos_puestoId",
                table: "Empleados",
                column: "puestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
