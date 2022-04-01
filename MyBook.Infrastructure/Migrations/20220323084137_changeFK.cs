using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBook.Migrations
{
    public partial class changeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_user_FK_user_identity_user_userId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FK_user_identity_user_userId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FK_user_identity_user_userId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FK_user_identity_user_userId",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_FK_user_identity_user_userId",
                table: "user",
                column: "FK_user_identity_user_userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_AspNetUsers_FK_user_identity_user_userId",
                table: "user",
                column: "FK_user_identity_user_userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_AspNetUsers_FK_user_identity_user_userId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_FK_user_identity_user_userId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "FK_user_identity_user_userId",
                table: "user");

            migrationBuilder.AddColumn<int>(
                name: "FK_user_identity_user_userId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FK_user_identity_user_userId",
                table: "AspNetUsers",
                column: "FK_user_identity_user_userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_user_FK_user_identity_user_userId",
                table: "AspNetUsers",
                column: "FK_user_identity_user_userId",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
