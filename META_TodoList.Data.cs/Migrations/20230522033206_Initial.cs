using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace META_TodoList.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfig",
                columns: table => new
                {
                    key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfig", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "UserSignUp",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    _email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _repass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _submit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSignUp", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTitle",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    _title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _checkedtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTitle", x => x._id);
                    table.ForeignKey(
                        name: "FK_ToDoTitle_UserSignUp_User_Id",
                        column: x => x.User_Id,
                        principalTable: "UserSignUp",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTitle_User_Id",
                table: "ToDoTitle",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfig");

            migrationBuilder.DropTable(
                name: "ToDoTitle");

            migrationBuilder.DropTable(
                name: "UserSignUp");
        }
    }
}
