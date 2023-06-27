using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homies.Data.Migrations
{
    public partial class AddCustomTablesAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the type of the event")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                },
                comment: "Type of the event");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the event"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Description of the event"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of the creation of the event"),
                    HasStart = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of the start of the event"),
                    HasEnd = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of the end of the event"),
                    OrganiserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Organiser's id"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "Type's id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_OrganiserId",
                        column: x => x.OrganiserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Events in the neighborhood");

            migrationBuilder.CreateTable(
                name: "EventsParticipants",
                columns: table => new
                {
                    HelperId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Participant's id"),
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Event's id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsParticipants", x => new { x.EventId, x.HelperId });
                    table.ForeignKey(
                        name: "FK_EventsParticipants_AspNetUsers_HelperId",
                        column: x => x.HelperId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventsParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Participant of an event");

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Animals" },
                    { 2, "Fun" },
                    { 3, "Discussion" },
                    { 4, "Work" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganiserId",
                table: "Events",
                column: "OrganiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeId",
                table: "Events",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsParticipants_HelperId",
                table: "EventsParticipants",
                column: "HelperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsParticipants");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
