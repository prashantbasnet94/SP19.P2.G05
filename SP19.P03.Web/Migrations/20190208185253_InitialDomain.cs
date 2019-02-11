using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SP19.P03.Web.Migrations
{
    public partial class InitialDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfSeats = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 1024, nullable: true),
                    Phone = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(38,16)", nullable: false),
                    PictureUrl = table.Column<string>(maxLength: 1024, nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableBill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    EndDateUtc = table.Column<DateTimeOffset>(nullable: true),
                    TableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableBill_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MailingAddress_Line1 = table.Column<string>(maxLength: 64, nullable: true),
                    MailingAddress_Line2 = table.Column<string>(maxLength: 64, nullable: true),
                    MailingAddress_City = table.Column<string>(maxLength: 64, nullable: true),
                    MailingAddress_State = table.Column<string>(maxLength: 2, nullable: true),
                    MailingAddress_ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    TableBillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_TableBill_TableBillId",
                        column: x => x.TableBillId,
                        principalTable: "TableBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableFoodItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId = table.Column<int>(nullable: false),
                    QuantityOrdered = table.Column<long>(nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(38,16)", nullable: true),
                    TableBillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFoodItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableFoodItem_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableFoodItem_TableBill_TableBillId",
                        column: x => x.TableBillId,
                        principalTable: "TableBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(maxLength: 16, nullable: true),
                    TokenizedCardReference = table.Column<string>(maxLength: 32, nullable: true),
                    BillingAddress_Line1 = table.Column<string>(maxLength: 64, nullable: true),
                    BillingAddress_Line2 = table.Column<string>(maxLength: 64, nullable: true),
                    BillingAddress_City = table.Column<string>(maxLength: 64, nullable: true),
                    BillingAddress_State = table.Column<string>(maxLength: 2, nullable: true),
                    BillingAddress_ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentOption_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOption_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentOptionId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(38,16)", nullable: false),
                    DateOfPaymentUtc = table.Column<DateTimeOffset>(nullable: false),
                    ReferenceNumber = table.Column<string>(maxLength: 16, nullable: true),
                    AuthNumber = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_PaymentOption_PaymentOptionId",
                        column: x => x.PaymentOptionId,
                        principalTable: "PaymentOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 128, nullable: true),
                    ReceiptId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" },
                    { 3, "Manager" },
                    { 4, "Server" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TableBillId",
                table: "Customer",
                column: "TableBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ReceiptId",
                table: "LineItem",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuId",
                table: "MenuItem",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOption_CustomerId",
                table: "PaymentOption",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOption_UserId",
                table: "PaymentOption",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PaymentOptionId",
                table: "Receipt",
                column: "PaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TableBill_TableId",
                table: "TableBill",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableFoodItem_MenuItemId",
                table: "TableFoodItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TableFoodItem_TableBillId",
                table: "TableFoodItem",
                column: "TableBillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "TableFoodItem");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "PaymentOption");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TableBill");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Table");
        }
    }
}
