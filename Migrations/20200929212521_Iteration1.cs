using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BangTestDemo2.Migrations
{
    public partial class Iteration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunSubmissionTime",
                table: "RunDatabase");

            migrationBuilder.AddColumn<string>(
                name: "CabsetName",
                table: "RunDatabase",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionTime",
                table: "RunDatabase",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredTime",
                table: "ResultsDatabase",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PackageDatabase",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RunCount",
                table: "PackageDatabase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CabsetDatabase",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CabsetName",
                table: "RunDatabase");

            migrationBuilder.DropColumn(
                name: "SubmissionTime",
                table: "RunDatabase");

            migrationBuilder.DropColumn(
                name: "RegisteredTime",
                table: "ResultsDatabase");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PackageDatabase");

            migrationBuilder.DropColumn(
                name: "RunCount",
                table: "PackageDatabase");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CabsetDatabase");

            migrationBuilder.AddColumn<DateTime>(
                name: "RunSubmissionTime",
                table: "RunDatabase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
