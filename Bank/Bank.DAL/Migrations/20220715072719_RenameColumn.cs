using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.DAL.Migrations
{
    public partial class RenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Client_ClientEntityId",
                table: "CreditCard");

            migrationBuilder.RenameColumn(
                name: "ClientEntityId",
                table: "CreditCard",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCard_ClientEntityId",
                table: "CreditCard",
                newName: "IX_CreditCard_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_Client_ClientId",
                table: "CreditCard",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Client_ClientId",
                table: "CreditCard");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "CreditCard",
                newName: "ClientEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCard_ClientId",
                table: "CreditCard",
                newName: "IX_CreditCard_ClientEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_Client_ClientEntityId",
                table: "CreditCard",
                column: "ClientEntityId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
