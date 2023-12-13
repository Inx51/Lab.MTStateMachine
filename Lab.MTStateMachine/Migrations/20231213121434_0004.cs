using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab.MTStateMachine.Migrations
{
    /// <inheritdoc />
    public partial class _0004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VegId",
                table: "MakeSaladState",
                newName: "TomatoId");

            migrationBuilder.AddColumn<string>(
                name: "CucumberId",
                table: "MakeSaladState",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CucumberId",
                table: "MakeSaladState");

            migrationBuilder.RenameColumn(
                name: "TomatoId",
                table: "MakeSaladState",
                newName: "VegId");
        }
    }
}
