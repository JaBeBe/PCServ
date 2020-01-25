using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCServ.Migrations
{
    public partial class NewInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServReqs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StuffId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServReqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServReqs_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServReqs_Product_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserClientId = table.Column<int>(nullable: true),
                    UserTechnicianId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserClientId",
                        column: x => x.UserClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserTechnicianId",
                        column: x => x.UserTechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatusChange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(nullable: true),
                    UserTechnicianId = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatusChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketStatusChange_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketStatusChange_Users_UserTechnicianId",
                        column: x => x.UserTechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServReqs_ClientId",
                table: "ServReqs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServReqs_StuffId",
                table: "ServReqs",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserClientId",
                table: "Tickets",
                column: "UserClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserTechnicianId",
                table: "Tickets",
                column: "UserTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusChange_TicketId",
                table: "TicketStatusChange",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusChange_UserTechnicianId",
                table: "TicketStatusChange",
                column: "UserTechnicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServReqs");

            migrationBuilder.DropTable(
                name: "TicketStatusChange");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
