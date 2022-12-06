using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Hire_Services__CHS_.Migrations
{
    public partial class carservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GuarantorsAddress",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GuarantorsName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GuarantorsNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CateCarHireServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CateCarHireServices_CustomerId",
                table: "CateCarHireServices",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CateCarHireServices_Customers_CustomerId",
                table: "CateCarHireServices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CateCarHireServices_Customers_CustomerId",
                table: "CateCarHireServices");

            migrationBuilder.DropIndex(
                name: "IX_CateCarHireServices_CustomerId",
                table: "CateCarHireServices");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CateCarHireServices");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorsAddress",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorsName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorsNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
