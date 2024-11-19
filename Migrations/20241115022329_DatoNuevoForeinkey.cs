using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class DatoNuevoForeinkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "Puesto",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Ventas",
                newName: "EmpleadoId");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Ventas",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "IdVenta",
                table: "DetalleVentas",
                newName: "VentaId");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "DetalleVentas",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "DetalleCompras",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "IdCompra",
                table: "DetalleCompras",
                newName: "CompraId");

            migrationBuilder.RenameColumn(
                name: "IdProveedor",
                table: "Compras",
                newName: "ProveedorId");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Compras",
                newName: "EmpleadoId");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Materiales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Materiales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuestoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "PuestoId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Ventas",
                newName: "IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Ventas",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "DetalleVentas",
                newName: "IdVenta");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "DetalleVentas",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "DetalleCompras",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "CompraId",
                table: "DetalleCompras",
                newName: "IdCompra");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "Compras",
                newName: "IdProveedor");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Compras",
                newName: "IdEmpleado");

            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Materiales",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Puesto",
                table: "Empleados",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
