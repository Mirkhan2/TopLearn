using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DataLayeer.Migrations
{
    public partial class ChangeAnswerIsTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrue",
                table: "Answers");
        }
    }
}
