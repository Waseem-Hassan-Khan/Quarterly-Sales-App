using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quarterly_Sales_App.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManagerName",
                value: "Tim Cook");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "ManagerName" },
                values: new object[] { "Tim", "Cook", "" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "ManagerName" },
                values: new object[] { "Jhon", "Rock", "Tim Cook" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManagerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "ManagerId" },
                values: new object[] { "Grace", "Hopper", 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "ManagerId" },
                values: new object[] { "Grace", "Hopper", 2 });
        }
    }
}
