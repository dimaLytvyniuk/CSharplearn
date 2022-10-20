using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWebStudy.Migrations
{
    public partial class AddRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a0e70593-b77a-4add-9a67-e2d9901086ec"), "9726a638-803c-4bae-9952-14954faf30bd", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0e70593-b77a-4add-9a67-e2d9901086ec"));
        }
    }
}
