using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IconRecruitmentTest.Data.Migrations
{
    public partial class NewPropertiesShippingDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ShippingData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ShippingData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "companyType",
                table: "ShippingData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ShippingData");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ShippingData");

            migrationBuilder.DropColumn(
                name: "companyType",
                table: "ShippingData");
        }
    }
}
