using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDDD.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class AccesoriesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Version",
                table: "Vehicle",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Version",
                table: "Vehicle",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true,
                oldDefaultValue: 0L);
        }
    }
}
