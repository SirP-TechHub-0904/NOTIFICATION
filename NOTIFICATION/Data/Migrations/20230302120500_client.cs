using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTIFICATION.Data.Migrations
{
    public partial class client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_AspNetUsers_ProfileId",
                table: "Information");

            migrationBuilder.DropIndex(
                name: "IX_Information_ProfileId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Information",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClientId1",
                table: "Information",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Information_ClientId1",
                table: "Information",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Clients_ClientId1",
                table: "Information",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Clients_ClientId1",
                table: "Information");

            migrationBuilder.DropIndex(
                name: "IX_Information_ClientId1",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Information");

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "Information",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Information_ProfileId",
                table: "Information",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_AspNetUsers_ProfileId",
                table: "Information",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
