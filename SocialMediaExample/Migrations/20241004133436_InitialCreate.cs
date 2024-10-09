using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaExample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
                //name: "Login",
                //columns: table => new
                //{
                    //IdLogin = table.Column<int>(type: "int", nullable: false)
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    //User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    //UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    //Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    //Role = table.Column<bool>(type: "bit", nullable: false)
                //},
                //constraints: table =>
                //{
                    //table.PrimaryKey("PK_Login", x => x.IdLogin);
                //});

            //migrationBuilder.CreateTable(
                //name: "User",
                //columns: table => new
                //{
                    //IdUser = table.Column<int>(type: "int", nullable: false)
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    //Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    //Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    //IsActive = table.Column<bool>(type: "bit", nullable: false)
                //},
                //constraints: table =>
                //{
                    //table.PrimaryKey("PK_User", x => x.IdUser);
                //});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
