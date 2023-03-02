using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTIFICATION.Data.Migrations
{
    public partial class clienth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostAcccountId",
                table: "Information",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HostAcccountId1",
                table: "Information",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HostAcccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostAcccounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Information_HostAcccountId1",
                table: "Information",
                column: "HostAcccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_HostAcccounts_HostAcccountId1",
                table: "Information",
                column: "HostAcccountId1",
                principalTable: "HostAcccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_HostAcccounts_HostAcccountId1",
                table: "Information");

            migrationBuilder.DropTable(
                name: "HostAcccounts");

            migrationBuilder.DropIndex(
                name: "IX_Information_HostAcccountId1",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "HostAcccountId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "HostAcccountId1",
                table: "Information");
        }
    }
}
