using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BangTestDemo2.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabsetDatabase",
                columns: table => new
                {
                    CabsetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabsetName = table.Column<string>(nullable: true),
                    CabCount = table.Column<int>(nullable: false),
                    CabConfigLocation = table.Column<string>(nullable: true),
                    CabTypes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabsetDatabase", x => x.CabsetId);
                });

            migrationBuilder.CreateTable(
                name: "PackageDatabase",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(nullable: true),
                    PackageType = table.Column<string>(nullable: true),
                    PackageLocation = table.Column<string>(nullable: true),
                    PackageHash = table.Column<string>(nullable: true),
                    IsReleased = table.Column<bool>(nullable: false),
                    PackageFileCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDatabase", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "ResultsDatabase",
                columns: table => new
                {
                    ResultKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunId = table.Column<int>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    PackageName = table.Column<string>(nullable: true),
                    CabsetId = table.Column<int>(nullable: false),
                    CabId = table.Column<int>(nullable: false),
                    FailureString = table.Column<string>(nullable: true),
                    HasSymbolIssue = table.Column<bool>(nullable: false),
                    TotalElapsedMs = table.Column<int>(nullable: false),
                    TotalCpuMs = table.Column<int>(nullable: false),
                    XmlPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsDatabase", x => x.ResultKey);
                });

            migrationBuilder.CreateTable(
                name: "RunDatabase",
                columns: table => new
                {
                    RunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasePackageId = table.Column<int>(nullable: false),
                    BasePackageName = table.Column<string>(nullable: true),
                    ComparisonPackageId = table.Column<int>(nullable: false),
                    ComparisonPackageName = table.Column<string>(nullable: true),
                    CabsetId = table.Column<int>(nullable: false),
                    TotalCabCount = table.Column<int>(nullable: false),
                    CabsCompleted = table.Column<int>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    RunSubmissionTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunDatabase", x => x.RunId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabsetDatabase");

            migrationBuilder.DropTable(
                name: "PackageDatabase");

            migrationBuilder.DropTable(
                name: "ResultsDatabase");

            migrationBuilder.DropTable(
                name: "RunDatabase");
        }
    }
}
