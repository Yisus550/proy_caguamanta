using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puesto",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Materiales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPuesto",
                table: "Empleados",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "puestoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdEmpleado",
                table: "Ventas",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_IdCategoria",
                table: "Materiales",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_puestoId",
                table: "Empleados",
                column: "puestoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_IdProducto",
                table: "DetalleVentas",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_IdVenta",
                table: "DetalleVentas",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_IdCompra",
                table: "DetalleCompras",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_IdProducto",
                table: "DetalleCompras",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdEmpleado",
                table: "Compras",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdProveedor",
                table: "Compras",
                column: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Empleados_IdEmpleado",
                table: "Compras",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Proveedores_IdProveedor",
                table: "Compras",
                column: "IdProveedor",
                principalTable: "Proveedores",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompras_Compras_IdCompra",
                table: "DetalleCompras",
                column: "IdCompra",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompras_Materiales_IdProducto",
                table: "DetalleCompras",
                column: "IdProducto",
                principalTable: "Materiales",
                principalColumn: "IdMaterial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Productos_IdProducto",
                table: "DetalleVentas",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Ventas_IdVenta",
                table: "DetalleVentas",
                column: "IdVenta",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puestos_puestoId",
                table: "Empleados",
                column: "puestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiales_Categorias_IdCategoria",
                table: "Materiales",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_IdCategoria",
                table: "Productos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_IdCliente",
                table: "Ventas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Empleados_IdEmpleado",
                table: "Ventas",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Empleados_IdEmpleado",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Proveedores_IdProveedor",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompras_Compras_IdCompra",
                table: "DetalleCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompras_Materiales_IdProducto",
                table: "DetalleCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Productos_IdProducto",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Ventas_IdVenta",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puestos_puestoId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_Categorias_IdCategoria",
                table: "Materiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_IdCategoria",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_IdCliente",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Empleados_IdEmpleado",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdEmpleado",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Materiales_IdCategoria",
                table: "Materiales");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_puestoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVentas_IdProducto",
                table: "DetalleVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVentas_IdVenta",
                table: "DetalleVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompras_IdCompra",
                table: "DetalleCompras");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompras_IdProducto",
                table: "DetalleCompras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdEmpleado",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdProveedor",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "IdPuesto",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "puestoId",
                table: "Empleados");

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
