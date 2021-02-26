using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRemember.Migrations
{
    public partial class AddingPetOwnerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Pet",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_UserId",
                table: "Pet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_User_UserId",
                table: "Pet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_UserId",
                table: "Pet");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pet",
                newName: "OwnerId");
        }
    }
}
