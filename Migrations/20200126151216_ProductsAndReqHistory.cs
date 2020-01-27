using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCServ.Migrations
{
    public partial class ProductsAndReqHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReqHistory",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestId = table.Column<int>(nullable: true),
                    ServiceManId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CtreateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReqHistory_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReqHistory_ServReqs_RequestId",
                        column: x => x.RequestId,
                        principalTable: "ServReqs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReqHistory_Users_ServiceManId",
                        column: x => x.ServiceManId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReqHistory_ClientId",
                table: "ReqHistory",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReqHistory_RequestId",
                table: "ReqHistory",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ReqHistory_ServiceManId",
                table: "ReqHistory",
                column: "ServiceManId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReqHistory");
        }
    }
}
