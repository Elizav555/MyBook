using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBook.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_book_desc_DescriptionId",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_rating_book_FK_rating_book_bookId",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_subscription_user_subscr_FK_subscr_user_subscr_user_subscr_~",
                table: "subscription");

            migrationBuilder.DropIndex(
                name: "IX_subscription_FK_subscr_user_subscr_user_subscr_id",
                table: "subscription");

            migrationBuilder.DropColumn(
                name: "FK_subscr_user_subscr_user_subscr_id",
                table: "subscription");

            migrationBuilder.RenameColumn(
                name: "FK_rating_book_bookId",
                table: "rating",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_rating_FK_rating_book_bookId",
                table: "rating",
                newName: "IX_rating_BookId");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "book",
                newName: "BookDescId");

            migrationBuilder.RenameIndex(
                name: "IX_book_DescriptionId",
                table: "book",
                newName: "IX_book_BookDescId");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "user_subscr",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "book_desc",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_subscr_SubscriptionId",
                table: "user_subscr",
                column: "SubscriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_book_book_desc_BookDescId",
                table: "book",
                column: "BookDescId",
                principalTable: "book_desc",
                principalColumn: "book_desc_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_book_BookId",
                table: "rating",
                column: "BookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_subscr_subscription_SubscriptionId",
                table: "user_subscr",
                column: "SubscriptionId",
                principalTable: "subscription",
                principalColumn: "subscr_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_book_desc_BookDescId",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_rating_book_BookId",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_user_subscr_subscription_SubscriptionId",
                table: "user_subscr");

            migrationBuilder.DropIndex(
                name: "IX_user_subscr_SubscriptionId",
                table: "user_subscr");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "user_subscr");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "book_desc");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "rating",
                newName: "FK_rating_book_bookId");

            migrationBuilder.RenameIndex(
                name: "IX_rating_BookId",
                table: "rating",
                newName: "IX_rating_FK_rating_book_bookId");

            migrationBuilder.RenameColumn(
                name: "BookDescId",
                table: "book",
                newName: "DescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_book_BookDescId",
                table: "book",
                newName: "IX_book_DescriptionId");

            migrationBuilder.AddColumn<int>(
                name: "FK_subscr_user_subscr_user_subscr_id",
                table: "subscription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_subscription_FK_subscr_user_subscr_user_subscr_id",
                table: "subscription",
                column: "FK_subscr_user_subscr_user_subscr_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_book_book_desc_DescriptionId",
                table: "book",
                column: "DescriptionId",
                principalTable: "book_desc",
                principalColumn: "book_desc_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_book_FK_rating_book_bookId",
                table: "rating",
                column: "FK_rating_book_bookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subscription_user_subscr_FK_subscr_user_subscr_user_subscr_~",
                table: "subscription",
                column: "FK_subscr_user_subscr_user_subscr_id",
                principalTable: "user_subscr",
                principalColumn: "user_subscr_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
