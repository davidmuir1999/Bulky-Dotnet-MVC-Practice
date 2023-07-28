using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWebMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTableDb : Migration
    {
        /// <inheritdoc />
        //if everything is successful the table defines as 'UP' will be made
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    //ID column 
                });
        }

        /// <inheritdoc />
        //but if something does not go right, the down will be used which will drop the table 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
