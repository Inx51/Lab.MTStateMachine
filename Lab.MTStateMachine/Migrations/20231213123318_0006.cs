using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab.MTStateMachine.Migrations
{
    /// <inheritdoc />
    public partial class _0006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaladeEventStatus",
                table: "MakeSaladState",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaladeEventStatus",
                table: "MakeSaladState");
        }
    }
}
