using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    FkIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_employee_rol_FkIdRol",
                        column: x => x.FkIdRol,
                        principalTable: "rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "IdRol", "Name" },
                values: new object[,]
                {
                    { 1, "Seller" },
                    { 2, "Cashier" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_FkIdRol",
                table: "employee",
                column: "FkIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "rol");
        }
    }
}
