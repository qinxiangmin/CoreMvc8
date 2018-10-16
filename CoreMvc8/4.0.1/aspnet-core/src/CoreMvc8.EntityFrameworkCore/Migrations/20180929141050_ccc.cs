using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMvc8.Migrations
{
    public partial class ccc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_AbpUsers_UserId1",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_UserId1",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Movie");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Movie_UserId",
                table: "Movie",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_AbpUsers_UserId",
                table: "Movie",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_AbpUsers_UserId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_UserId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_UserId1",
                table: "Movie",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_AbpUsers_UserId1",
                table: "Movie",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
