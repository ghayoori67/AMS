using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Migrations
{
    /// <inheritdoc />
    public partial class add_UserPayment_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "PaymentPlans",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "UserPaymentId",
                table: "PaymentPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GatewayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSucceed = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_UserPaymentId",
                table: "PaymentPlans",
                column: "UserPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPlans_UserPayments_UserPaymentId",
                table: "PaymentPlans",
                column: "UserPaymentId",
                principalTable: "UserPayments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPlans_UserPayments_UserPaymentId",
                table: "PaymentPlans");

            migrationBuilder.DropTable(
                name: "UserPayments");

            migrationBuilder.DropIndex(
                name: "IX_PaymentPlans_UserPaymentId",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "UserPaymentId",
                table: "PaymentPlans");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PaymentPlans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
