using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace META_TodoList.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_submit",
                table: "UserSignUp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_submit",
                table: "UserSignUp",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
