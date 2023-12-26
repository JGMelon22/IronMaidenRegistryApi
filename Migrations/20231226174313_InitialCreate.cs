using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronMaidenRegistry.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrumentName = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DurationInMinutes = table.Column<byte>(type: "TINYINT", nullable: false),
                    AverageScore = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    InstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersSongs",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersSongs", x => new { x.MemberId, x.SongId });
                    table.ForeignKey(
                        name: "FK_MembersSongs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Id_Instrument",
                table: "Instruments",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IDX_Id_Member",
                table: "Members",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_InstrumentId",
                table: "Members",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IDX_MemberId_MembersSongs",
                table: "MembersSongs",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IDX_SongId_MembersSongs",
                table: "MembersSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IDX_Id_Song",
                table: "Songs",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembersSongs");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Instruments");
        }
    }
}
