using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persitance.Migrations
{
    public partial class mg_dec4_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "efcore");

            migrationBuilder.CreateTable(
                name: "Facilities",
                schema: "efcore",
                columns: table => new
                {
                    FacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MemberCost = table.Column<int>(nullable: false),
                    GustCost = table.Column<int>(nullable: false),
                    Initialoutlay = table.Column<int>(nullable: false),
                    MonthlyMaintenance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "efcore",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    RecommendedBy = table.Column<int>(nullable: false),
                    Joindate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Members_RecommendedBy",
                        column: x => x.RecommendedBy,
                        principalSchema: "efcore",
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                schema: "efcore",
                columns: table => new
                {
                    FacId = table.Column<int>(nullable: false),
                    MemId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Slots = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => new { x.FacId, x.MemId });
                    table.ForeignKey(
                        name: "FK_Bookings_Facilities_FacId",
                        column: x => x.FacId,
                        principalSchema: "efcore",
                        principalTable: "Facilities",
                        principalColumn: "FacId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Members_MemId",
                        column: x => x.MemId,
                        principalSchema: "efcore",
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MemId",
                schema: "efcore",
                table: "Bookings",
                column: "MemId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_RecommendedBy",
                schema: "efcore",
                table: "Members",
                column: "RecommendedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings",
                schema: "efcore");

            migrationBuilder.DropTable(
                name: "Facilities",
                schema: "efcore");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "efcore");
        }
    }
}
