using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationConfiguration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    ConfigurationDefinitionID = table.Column<int>(type: "int", nullable: false),
                    ConfigurationValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConfiguration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationDefinition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConfigurationDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateUserID = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationDefinition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SSIS_Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationFilter = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ConfiguredValue = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PackagePath = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ConfiguredValueType = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSIS_Config", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationConfiguration");

            migrationBuilder.DropTable(
                name: "ConfigurationDefinition");

            migrationBuilder.DropTable(
                name: "SSIS_Config");
        }
    }
}
