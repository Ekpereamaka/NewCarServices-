using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Hire_Services__CHS_.Migrations
{
    public partial class paymentRetouch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_UsreId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_UsreId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UsreId",
                table: "Payment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserId",
                table: "Payment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_UserId",
                table: "Payment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_UserId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_UserId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsreId",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UsreId",
                table: "Payment",
                column: "UsreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_UsreId",
                table: "Payment",
                column: "UsreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
