using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SP19.P2.Web.Migrations
{
    public partial class valuesInserting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(maxLength: 128, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<string>(maxLength: 30, nullable: true),
                    Zip = table.Column<int>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 26, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "TableFoodItems",
                columns: table => new
                {
                    TableFoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId = table.Column<int>(nullable: false),
                    AmountOrdered = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFoodItems", x => x.TableFoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableType = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuJoinMenuItems",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    MenutItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuJoinMenuItems", x => new { x.MenuId, x.MenutItemId });
                    table.ForeignKey(
                        name: "FK_MenuJoinMenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuJoinMenuItems_MenuItems_MenutItemId",
                        column: x => x.MenutItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableBills",
                columns: table => new
                {
                    TableBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customer = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false),
                    TableFoodItemId = table.Column<int>(nullable: false),
                    TableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBills", x => x.TableBillId);
                    table.ForeignKey(
                        name: "FK_TableBills_TableFoodItems_TableFoodItemId",
                        column: x => x.TableFoodItemId,
                        principalTable: "TableFoodItems",
                        principalColumn: "TableFoodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableBills_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelatedUserUserId = table.Column<int>(nullable: true),
                    PaymentOptionId = table.Column<int>(nullable: true),
                    MailingAddressAddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Address_MailingAddressAddressId",
                        column: x => x.MailingAddressAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_RelatedUserUserId",
                        column: x => x.RelatedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                columns: table => new
                {
                    PaymentOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(maxLength: 64, nullable: true),
                    TokenizedCardReference = table.Column<string>(maxLength: 128, nullable: true),
                    BillingAddressAddressId = table.Column<int>(nullable: true),
                    ReceiptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.PaymentOptionId);
                    table.ForeignKey(
                        name: "FK_PaymentOptions_Address_BillingAddressAddressId",
                        column: x => x.BillingAddressAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentOptionId = table.Column<int>(nullable: true),
                    LineItemId = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: false),
                    DateOfPayment = table.Column<DateTimeOffset>(nullable: false),
                    PaymentReferenceNumber = table.Column<int>(nullable: false),
                    PaymentAuthenticationNumber = table.Column<int>(nullable: false),
                    TableId = table.Column<int>(nullable: true),
                    ServerUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_Receipts_PaymentOptions_PaymentOptionId",
                        column: x => x.PaymentOptionId,
                        principalTable: "PaymentOptions",
                        principalColumn: "PaymentOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipts_Users_ServerUserId",
                        column: x => x.ServerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipts_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    LineItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    PerItemCost = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ReceiptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.LineItemId);
                    table.ForeignKey(
                        name: "FK_LineItems_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Picture", "Price" },
                values: new object[,]
                {
                    { 10, "awesome", "sandwiches", "www.sandwiches.com", 20 },
                    { 11, "awesome", "Nuggets", "www.Nuggets.com", 40 },
                    { 12, "awesome", "taco", "www.taco.com", 20 },
                    { 13, "awesome", "buritos", "www.buritos.com", 20 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Name" },
                values: new object[,]
                {
                    { 1, "Lunch Menu" },
                    { 2, "Entre Menu" },
                    { 3, "Desert Menu" }
                });

            migrationBuilder.InsertData(
                table: "TableFoodItems",
                columns: new[] { "TableFoodItemId", "AmountOrdered", "Discount", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 100, 10, 10 },
                    { 2, 110, 20, 11 },
                    { 3, 119, 0, 12 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "NumberOfSeats", "TableType" },
                values: new object[,]
                {
                    { 1, 10, "Round Type" },
                    { 2, 20, "Bar Height Table" },
                    { 3, 20, "Family Dining Table" },
                    { 4, 5, "Outdoor Table" }
                });

            migrationBuilder.InsertData(
                table: "MenuJoinMenuItems",
                columns: new[] { "MenuId", "MenutItemId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 }
                });

            migrationBuilder.InsertData(
                table: "TableBills",
                columns: new[] { "TableBillId", "Customer", "EndTime", "StartTime", "TableFoodItemId", "TableId" },
                values: new object[,]
                {
                    { 50, 1000, new DateTimeOffset(new DateTime(2019, 2, 6, 18, 50, 4, 762, DateTimeKind.Unspecified).AddTicks(6381), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 6, 18, 50, 4, 760, DateTimeKind.Unspecified).AddTicks(9810), new TimeSpan(0, -6, 0, 0, 0)), 1, 1 },
                    { 51, 1001, new DateTimeOffset(new DateTime(2019, 2, 6, 18, 50, 4, 762, DateTimeKind.Unspecified).AddTicks(8001), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 6, 18, 50, 4, 762, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, -6, 0, 0, 0)), 2, 2 },
                    { 52, 1002, new DateTimeOffset(new DateTime(2019, 2, 6, 18, 50, 4, 762, DateTimeKind.Unspecified).AddTicks(8020), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 6, 18, 50, 4, 762, DateTimeKind.Unspecified).AddTicks(8016), new TimeSpan(0, -6, 0, 0, 0)), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MailingAddressAddressId",
                table: "Customers",
                column: "MailingAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentOptionId",
                table: "Customers",
                column: "PaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RelatedUserUserId",
                table: "Customers",
                column: "RelatedUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ReceiptId",
                table: "LineItems",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuJoinMenuItems_MenutItemId",
                table: "MenuJoinMenuItems",
                column: "MenutItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_BillingAddressAddressId",
                table: "PaymentOptions",
                column: "BillingAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_ReceiptId",
                table: "PaymentOptions",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_LineItemId",
                table: "Receipts",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_PaymentOptionId",
                table: "Receipts",
                column: "PaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ServerUserId",
                table: "Receipts",
                column: "ServerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_TableId",
                table: "Receipts",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TableBills_TableFoodItemId",
                table: "TableBills",
                column: "TableFoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TableBills_TableId",
                table: "TableBills",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PaymentOptions_PaymentOptionId",
                table: "Customers",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "PaymentOptionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptions_Receipts_ReceiptId",
                table: "PaymentOptions",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "ReceiptId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_LineItems_LineItemId",
                table: "Receipts",
                column: "LineItemId",
                principalTable: "LineItems",
                principalColumn: "LineItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptions_Address_BillingAddressAddressId",
                table: "PaymentOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_PaymentOptions_PaymentOptionId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_ServerUserId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Receipts_ReceiptId",
                table: "LineItems");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MenuJoinMenuItems");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TableBills");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "TableFoodItems");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
