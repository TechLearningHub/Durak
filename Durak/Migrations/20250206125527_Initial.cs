using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Durak.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Suit = table.Column<int>(type: "integer", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Winner = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CardId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NickName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    CardIds = table.Column<List<long>>(type: "jsonb", nullable: false),
                    DeskId = table.Column<long>(type: "bigint", nullable: false),
                    DeskEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hands_Desks_DeskEntityId",
                        column: x => x.DeskEntityId,
                        principalTable: "Desks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hands_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hands_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoveHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovedCardIds = table.Column<List<long>>(type: "jsonb", nullable: false),
                    MoveId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ActionType = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    IsBeaten = table.Column<bool>(type: "boolean", nullable: false),
                    IsTaken = table.Column<bool>(type: "boolean", nullable: false),
                    BeatenCardIds = table.Column<List<long>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoveHistories_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hands_DeskEntityId",
                table: "Hands",
                column: "DeskEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_DeskId",
                table: "Hands",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_PlayerId",
                table: "Hands",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MoveHistories_PlayerId",
                table: "MoveHistories",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Hands");

            migrationBuilder.DropTable(
                name: "MoveHistories");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
