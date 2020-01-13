using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySomeTask.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    Country = table.Column<string>(maxLength: 200, nullable: false),
                    Province = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryName = table.Column<string>(maxLength: 200, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: false),
                    ProvinceName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

          var dataSql = @"insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000001','code1', 'Coutry1','Province11');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000002','code1', 'Coutry1','Province12');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000003','code1', 'Coutry1','Province13');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000004','code2', 'Coutry2','Province21');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000005','code2', 'Coutry2','Province22');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000006','code2', 'Coutry2','Province23');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000007','code3', 'Coutry3','Province31');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000008','code3', 'Coutry3','Province32');
          insert into Locations(Id, CountryCode, CountryName, ProvinceName) values('00000000-0000-0000-0000-000000000009','code3', 'Coutry3','Province33');";
          migrationBuilder.Sql(dataSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Locations");
        }

         
    }
}
