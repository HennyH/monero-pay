using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "walletrpcdaemons",
                columns: table => new
                {
                    walletname = table.Column<string>(type: "TEXT", nullable: false),
                    hostname = table.Column<string>(type: "TEXT", nullable: false),
                    port = table.Column<int>(type: "INTEGER", nullable: false),
                    spwaneddate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_walletrpcdaemons", x => x.walletname);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "walletrpcdaemons");
        }
    }
}
