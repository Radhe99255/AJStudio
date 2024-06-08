using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AJStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactUS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUsTable",
                columns: table => new
                {
                    Customer_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Selected_Plane = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggested = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsTable", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaneVarietyTable",
                columns: table => new
                {
                    PlaneVariety_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneVariety = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneVarietyTable", x => x.PlaneVariety_Id);
                });

            migrationBuilder.CreateTable(
                name: "SuggestedTable",
                columns: table => new
                {
                    Suggested_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suggested = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestedTable", x => x.Suggested_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUsTable");

            migrationBuilder.DropTable(
                name: "PlaneVarietyTable");

            migrationBuilder.DropTable(
                name: "SuggestedTable");
        }
    }
}
