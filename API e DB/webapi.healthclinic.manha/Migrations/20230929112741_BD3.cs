using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class BD3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "VARCHAR(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "VARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(60)");
        }
    }
}
