using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTIFICATION.Data.Migrations
{
    public partial class jdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    AccountHosted = table.Column<string>(nullable: true),
                    DateHosted = table.Column<string>(nullable: true),
                    DateExpiring = table.Column<string>(nullable: true),
                    DateRenewed = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DLastUpdateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProfileId = table.Column<string>(nullable: true),
                    Interval = table.Column<int>(nullable: false),
                    AccontStatus = table.Column<int>(nullable: false),
                    AccontType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Information_AspNetUsers_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RenewHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateExpired = table.Column<string>(nullable: true),
                    DateRenewed = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    InformationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RenewHistory_Information_InformationId",
                        column: x => x.InformationId,
                        principalTable: "Information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Information_ProfileId",
                table: "Information",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RenewHistory_InformationId",
                table: "RenewHistory",
                column: "InformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RenewHistory");

            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");
        }
    }
}
