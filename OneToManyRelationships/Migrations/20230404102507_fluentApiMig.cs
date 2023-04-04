using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyRelationships.Migrations
{
    /// <inheritdoc />
    public partial class fluentApiMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Schwarz",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Schwarz",
                table: "Employees",
                newName: "DxId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Schwarz",
                table: "Employees",
                newName: "IX_Employees_DxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DxId",
                table: "Employees",
                column: "DxId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DxId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DxId",
                table: "Employees",
                newName: "Schwarz");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DxId",
                table: "Employees",
                newName: "IX_Employees_Schwarz");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Schwarz",
                table: "Employees",
                column: "Schwarz",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
