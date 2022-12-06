using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Hire_Services__CHS_.Migrations
{
    public partial class referenceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "Payment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "Payment");
        }
    }
}
