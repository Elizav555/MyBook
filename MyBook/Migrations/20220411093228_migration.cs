using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBook.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscr_type");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "subscription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_subscription_TypeId",
                table: "subscription",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_subscription_types_TypeId",
                table: "subscription",
                column: "TypeId",
                principalTable: "types",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscription_types_TypeId",
                table: "subscription");

            migrationBuilder.DropIndex(
                name: "IX_subscription_TypeId",
                table: "subscription");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "subscription");

            migrationBuilder.CreateTable(
                name: "subscr_type",
                columns: table => new
                {
                    subscr_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscr_type", x => x.subscr_type_id);
                    table.ForeignKey(
                        name: "FK_subscr_type_subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscription",
                        principalColumn: "subscr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subscr_type_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "types",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscr_type_SubscriptionId",
                table: "subscr_type",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_subscr_type_TypeId",
                table: "subscr_type",
                column: "TypeId");
        }
    }
}
