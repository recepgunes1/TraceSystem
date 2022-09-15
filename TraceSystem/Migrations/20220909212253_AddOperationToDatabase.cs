using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraceSystem.Migrations
{
    public partial class AddOperationToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerContact = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceAppearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceFault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceAccessory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIMEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DevicePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryStatus = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
