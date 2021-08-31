using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Gdpr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GdprRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GdprRecordYear = table.Column<int>(type: "int", nullable: false),
                    GdprCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GdprLaw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GdprNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessGdprRequirement = table.Column<bool>(type: "bit", nullable: false),
                    ProcessSortOrder = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GdprRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GdprRecords_AppUsers_LastEditorId",
                        column: x => x.LastEditorId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GdprRecords_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GdprRecords_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GdprRecords_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GdprRecords_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GdprRecords_LastEditorId",
                table: "GdprRecords",
                column: "LastEditorId");

            migrationBuilder.CreateIndex(
                name: "IX_GdprRecords_PartnerId",
                table: "GdprRecords",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GdprRecords_ProcessId",
                table: "GdprRecords",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_GdprRecords_ServiceId",
                table: "GdprRecords",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_GdprRecords_VendorId",
                table: "GdprRecords",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GdprRecords");
        }
    }
}
