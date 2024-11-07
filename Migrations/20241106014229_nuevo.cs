using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class nuevo : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Materiales",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Materiales");

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
