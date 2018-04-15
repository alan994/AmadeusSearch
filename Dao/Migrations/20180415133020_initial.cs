using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dao.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DepartureAirportIata = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    DestinationAirportIata = table.Column<string>(nullable: true),
                    NumberOfInterchanges = table.Column<int>(nullable: false),
                    NumberOfPassengers = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Searches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false),
                    DestinationAirportIata = table.Column<string>(nullable: true),
                    NumberOfPassengers = table.Column<int>(nullable: false),
                    OriginAirportIata = table.Column<string>(nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Searches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    InboundFlightId = table.Column<int>(nullable: false),
                    OutboundFlightId = table.Column<int>(nullable: false),
                    PricePerPerson = table.Column<decimal>(nullable: false),
                    SearchId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Flights_InboundFlightId",
                        column: x => x.InboundFlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Options_Flights_OutboundFlightId",
                        column: x => x.OutboundFlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Options_Searches_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_InboundFlightId",
                table: "Options",
                column: "InboundFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_OutboundFlightId",
                table: "Options",
                column: "OutboundFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_SearchId",
                table: "Options",
                column: "SearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Searches");
        }
    }
}
