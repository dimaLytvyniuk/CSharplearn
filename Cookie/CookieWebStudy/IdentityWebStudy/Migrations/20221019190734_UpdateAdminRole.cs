using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWebStudy.Migrations
{
    public partial class UpdateAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0e70593-b77a-4add-9a67-e2d9901086ec"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f9bf662f-ed65-4593-9c7d-be1504d8a2f5"), "6464af13-bed5-492e-b61e-0f8e7759f033", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f9bf662f-ed65-4593-9c7d-be1504d8a2f5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a0e70593-b77a-4add-9a67-e2d9901086ec"), "9726a638-803c-4bae-9952-14954faf30bd", "Admin", null });
        }
    }
}
