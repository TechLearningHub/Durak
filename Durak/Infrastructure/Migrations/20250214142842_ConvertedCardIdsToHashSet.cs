using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Durak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConvertedCardIdsToHashSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "MoveHistories",
                type: "integer USING \"MoveId\"::integer",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MoveId",
                table: "MoveHistories",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 10);
        }
    }
}
