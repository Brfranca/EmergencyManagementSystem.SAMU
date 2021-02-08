using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.SAMU.DAL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telephone",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                schema: "dbo",
                table: "Patients",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "dbo",
                table: "Addresses",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
