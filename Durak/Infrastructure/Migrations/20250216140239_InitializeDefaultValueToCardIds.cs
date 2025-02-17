using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Durak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDefaultValueToCardIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<HashSet<long>>(
                name: "CardIds",
                table: "Hands",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "[]",
                oldClrType: typeof(HashSet<long>),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<HashSet<long>>(
                name: "CardIds",
                table: "Hands",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(HashSet<long>),
                oldType: "jsonb",
                oldDefaultValueSql: "[]");
        }
    }
}
