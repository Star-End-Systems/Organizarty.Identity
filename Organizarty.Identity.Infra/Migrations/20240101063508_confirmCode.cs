using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizarty.Identity.Infra.Migrations
{
    /// <inheritdoc />
    public partial class confirmCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumerEmailConfirmations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    ValidTill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerEmailConfirmations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerEmailConfirmations");
        }
    }
}
