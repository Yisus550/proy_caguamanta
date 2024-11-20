using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class FinRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpleadoId",
                table: "Ventas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_CategoriaId",
                table: "Materiales",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_ProductoId",
                table: "DetalleVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_VentaId",
                table: "DetalleVentas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CompraId",
                table: "DetalleCompras",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_MaterialId",
                table: "DetalleCompras",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_EmpleadoId",
                table: "Compras",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Empleados_EmpleadoId",
                table: "Compras",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Proveedores_ProveedorId",
                table: "Compras",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompras_Compras_CompraId",
                table: "DetalleCompras",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompras_Materiales_MaterialId",
                table: "DetalleCompras",
                column: "MaterialId",
                principalTable: "Materiales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Productos_ProductoId",
                table: "DetalleVentas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Ventas_VentaId",
                table: "DetalleVentas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiales_Categorias_CategoriaId",
                table: "Materiales",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Empleados_EmpleadoId",
                table: "Ventas",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Empleados_EmpleadoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Proveedores_ProveedorId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompras_Compras_CompraId",
                table: "DetalleCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompras_Materiales_MaterialId",
                table: "DetalleCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Productos_ProductoId",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Ventas_VentaId",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_Categorias_CategoriaId",
                table: "Materiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Empleados_EmpleadoId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_EmpleadoId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Materiales_CategoriaId",
                table: "Materiales");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVentas_ProductoId",
                table: "DetalleVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVentas_VentaId",
                table: "DetalleVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompras_CompraId",
                table: "DetalleCompras");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompras_MaterialId",
                table: "DetalleCompras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_EmpleadoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras");
        }
    }
}
