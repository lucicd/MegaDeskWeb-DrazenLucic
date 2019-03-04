using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb_DrazenLucic.Migrations
{
    public partial class ParametersComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Parameter",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Parameter");
        }
    }
}
