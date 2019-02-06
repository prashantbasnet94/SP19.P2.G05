using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SP19.P2.Web.Migrations
{
    public partial class addmigratonInitialCreat : Migration
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
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableType = table.Column<string>(maxLength: 5, nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
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
                    MenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
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
                    MailingAddressAddressId = table.Column<int>(nullable: true),
                    TableBillId = table.Column<int>(nullable: true)
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
                    RoleId = table.Column<int>(nullable: true)
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
                name: "TableBills",
                columns: table => new
                {
                    TableBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false),
                    TableFoodItemId = table.Column<int>(nullable: true),
                    TableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBills", x => x.TableBillId);
                    table.ForeignKey(
                        name: "FK_TableBills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TableBills_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableFoodItems",
                columns: table => new
                {
                    TableFoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId = table.Column<int>(nullable: true),
                    AmountOrdered = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    TableBillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFoodItems", x => x.TableFoodItemId);
                    table.ForeignKey(
                        name: "FK_TableFoodItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TableFoodItems_TableBills_TableBillId",
                        column: x => x.TableBillId,
                        principalTable: "TableBills",
                        principalColumn: "TableBillId",
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
                name: "IX_Customers_TableBillId",
                table: "Customers",
                column: "TableBillId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ReceiptId",
                table: "LineItems",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

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
                name: "IX_TableBills_CustomerId",
                table: "TableBills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TableBills_TableFoodItemId",
                table: "TableBills",
                column: "TableFoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TableBills_TableId",
                table: "TableBills",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableFoodItems_MenuItemId",
                table: "TableFoodItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TableFoodItems_TableBillId",
                table: "TableFoodItems",
                column: "TableBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PaymentOptions_PaymentOptionId",
                table: "Customers",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "PaymentOptionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_RelatedUserUserId",
                table: "Customers",
                column: "RelatedUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_TableBills_TableBillId",
                table: "Customers",
                column: "TableBillId",
                principalTable: "TableBills",
                principalColumn: "TableBillId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptions_Receipts_ReceiptId",
                table: "PaymentOptions",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "ReceiptId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TableBills_TableFoodItems_TableFoodItemId",
                table: "TableBills",
                column: "TableFoodItemId",
                principalTable: "TableFoodItems",
                principalColumn: "TableFoodItemId",
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
                name: "FK_Customers_Address_MailingAddressAddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptions_Address_BillingAddressAddressId",
                table: "PaymentOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PaymentOptions_PaymentOptionId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_PaymentOptions_PaymentOptionId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_RelatedUserUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_ServerUserId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_TableBills_TableBillId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_TableFoodItems_TableBills_TableBillId",
                table: "TableFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Receipts_ReceiptId",
                table: "LineItems");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TableBills");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TableFoodItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
