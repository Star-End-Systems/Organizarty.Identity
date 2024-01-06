using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizarty.Identity.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateThirdParty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThirdParties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    AuthorizationStatus = table.Column<int>(type: "integer", nullable: false),
                    ContactEmail = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: true),
                    ContactPhone = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: true),
                    PhoneConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdParties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThirdParties_CNPJ",
                table: "ThirdParties",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThirdParties_Email",
                table: "ThirdParties",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThirdParties");
        }
    }
}
