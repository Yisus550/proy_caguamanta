using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proy_caguamanta.Migrations
{
	/// <inheritdoc />
	public partial class cambio_DateOnly_DateTime_Venta : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "FechaVenta",
				table: "Ventas",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateOnly),
				oldType: "date");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateOnly>(
				name: "FechaVenta",
				table: "Ventas",
				type: "date",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "datetime2");
		}
	}
}
