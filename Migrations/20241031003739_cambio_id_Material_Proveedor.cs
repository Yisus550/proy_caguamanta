using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class cambio_id_Material_Proveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProveedor",
                table: "Proveedores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdMaterial",
                table: "Materiales",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Proveedores",
                newName: "IdProveedor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Materiales",
                newName: "IdMaterial");
        }
    }
}
