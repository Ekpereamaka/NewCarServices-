using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Hire_Services__CHS_.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CateCarHireServices_Customers_CustomerId",
                table: "CateCarHireServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_State_StateId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_StateId",
                table: "Customer",
                newName: "IX_Customer_StateId");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Payment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Payment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Payment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsreId",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CarId",
                table: "Payment",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UsreId",
                table: "Payment",
                column: "UsreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CateCarHireServices_Customer_CustomerId",
                table: "CateCarHireServices",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_State_StateId",
                table: "Customer",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Cars_CarId",
                table: "Payment",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customer_CustomerId",
                table: "Payment",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_UsreId",
                table: "Payment",
                column: "UsreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CateCarHireServices_Customer_CustomerId",
                table: "CateCarHireServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_State_StateId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Cars_CarId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customer_CustomerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_UsreId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CarId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_UsreId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UsreId",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_StateId",
                table: "Customers",
                newName: "IX_Customers_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CateCarHireServices_Customers_CustomerId",
                table: "CateCarHireServices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_State_StateId",
                table: "Customers",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
