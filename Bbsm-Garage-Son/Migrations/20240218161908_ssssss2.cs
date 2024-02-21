using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bbsm_Garage_Son.Migrations
{
    /// <inheritdoc />
    public partial class ssssss2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StokEntity_UserEntityId",
                table: "StokEntity");

            migrationBuilder.CreateIndex(
                name: "IX_StokEntity_UserEntityId",
                table: "StokEntity",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StokEntity_UserEntityId",
                table: "StokEntity");

            migrationBuilder.CreateIndex(
                name: "IX_StokEntity_UserEntityId",
                table: "StokEntity",
                column: "UserEntityId",
                unique: true);
        }
    }
}
