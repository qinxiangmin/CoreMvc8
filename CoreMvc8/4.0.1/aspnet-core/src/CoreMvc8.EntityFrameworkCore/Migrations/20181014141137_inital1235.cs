using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMvc8.Migrations
{
    public partial class inital1235 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AbpUsers_UserId1",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_UserId1",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Book");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Book",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId",
                table: "Book",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AbpUsers_UserId",
                table: "Book",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AbpUsers_UserId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_UserId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Book",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId1",
                table: "Book",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AbpUsers_UserId1",
                table: "Book",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
