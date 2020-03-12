using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactMgrApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Orginazation = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friend" },
                    { 3, "Work" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "CategoryID", "DateAdded", "Email", "FirstName", "LastName", "Orginazation", "Phone" },
                values: new object[] { 1, 1, new DateTime(2020, 2, 12, 19, 16, 6, 420, DateTimeKind.Local).AddTicks(5640), "marryellen@yahoo.com", "Marry Ellen", "Walton", null, "555-123-1234" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "CategoryID", "DateAdded", "Email", "FirstName", "LastName", "Orginazation", "Phone" },
                values: new object[] { 2, 2, new DateTime(2020, 2, 12, 19, 16, 6, 425, DateTimeKind.Local).AddTicks(5650), "delores@yahoo.com", "Delores", "Del Rio", null, "555-987-6543" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "CategoryID", "DateAdded", "Email", "FirstName", "LastName", "Orginazation", "Phone" },
                values: new object[] { 3, 3, new DateTime(2020, 2, 12, 19, 16, 6, 425, DateTimeKind.Local).AddTicks(5690), "efren@yahoo.com", "Efren", "Herrera", null, "555-111-1111" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryID",
                table: "Contacts",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
