using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
    /// <inheritdoc />
    public partial class cambio_id_cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Clientes",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "IdCliente");
        }
    }
}
